// Proxy.cs -- Implements a multi-threaded Web proxy server
//
//             Compile this program with the following command line:
//                 C:>csc Proxy.cs
using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;

using System.Text;
using System.IO;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
namespace ScanServerManager.Components
{
    class clsProxyConnection
    {
        private ProxyOutput Output;
        private Socket m_sockClient; //, m_sockServer;
        private Byte[] readBuf = new Byte[1024];
        private Byte[] buffer = null;
        private Encoding ASCII = Encoding.ASCII;

        public clsProxyConnection(Socket sockClient, ProxyOutput ProxyOutput)
        {
            m_sockClient = sockClient;
            Output = ProxyOutput;
        }

        public void Run()
        {
            string strFromClient = string.Empty;
            try
            {
                // Read the incoming text on the socket/
                int bytes = ReadMessage(m_sockClient, readBuf, ref strFromClient);
                // If it's empty, it's an error, so just return.
                if (bytes == 0)
                    return;
                // Extract the URL as the string betweeen the spaces.
                int index1 = strFromClient.IndexOf(' ');
                int index2 = strFromClient.IndexOf(' ', index1 + 1);
                string strClientConnection =
                      strFromClient.Substring(index1 + 1, index2 - index1);

                if ((index1 < 0) || (index2 < 0))
                {
                    throw (new IOException());
                }

                string CleanedStrFromClient = strFromClient;
                if (strFromClient.IndexOf("\0\0") != -1)
                    CleanedStrFromClient = strFromClient.Remove(strFromClient.IndexOf("\0\0"));

                string url = string.Empty;

                string connecturl = string.Empty;
                string httpversion = string.Empty;
                bool sendconnectback = false;

                System.Text.RegularExpressions.Regex Reg = new System.Text.RegularExpressions.Regex("(?:GET|POST)+ (.*) ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Match match = Reg.Match(CleanedStrFromClient);

                if (match.Success)
                    url = match.Groups[1].Value;
                else
                {
                    Reg = new System.Text.RegularExpressions.Regex("(?:CONNECT)+ (.*):(\\d+) (HTTP/1\\..)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    match = Reg.Match(CleanedStrFromClient);
                    if (match.Success)
                    {
                        sendconnectback = true;
                        connecturl = match.Groups[1].Value + ":" + match.Groups[2].Value + " " + match.Groups[3].Value;
                        httpversion = match.Groups[3].Value;

                        if (match.Groups[2].Value == "443")
                            url = "https://" + match.Groups[1].Value;
                        else
                            url = "http://" + match.Groups[1].Value + ":" + match.Groups[2].Value;
                    }
                }

                // Create a WebRequest object.
                HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(url);
                req.AllowAutoRedirect = false;
                StringReader SR = new StringReader(CleanedStrFromClient);
                string Header;
                bool Postdata = false;
                string Post = string.Empty;
                for (int line = 0; (Header = SR.ReadLine()) != null; line++)
                {
                    // SKIP URL
                    if (Header.ToLower().StartsWith("get") || Header.ToLower().StartsWith("post"))
                        continue;

                    if (Header == "" && Post.Length == 0)
                    {
                        Postdata = true;
                        continue;
                    }

                    if (Postdata)
                    {
                        Post = Header;
                        continue;
                    }


                    string[] HeaderSplitted = Header.Split(new char[] { ':' }, 2);
                    if (HeaderSplitted != null)
                    {
                        if (HeaderSplitted[0].ToLower() == "accept")
                            req.Accept = HeaderSplitted[1].TrimStart(' ');
                        else if (HeaderSplitted[0].ToLower().StartsWith("connect "))
                        {
                            //if (HeaderSplitted[1].ToLower().Contains("http/1.0"))
                            //    req.ProtocolVersion = HttpVersion.Version10;
                            //req.Headers.Set("CONNECT", connecturl);
                        }
                        else if (HeaderSplitted[0].ToLower() == "proxy-connection")
                        {
                            if (HeaderSplitted[1].TrimStart(' ').ToLower() == "keep-alive")
                                req.KeepAlive = true;
                        }
                        else if (HeaderSplitted[0].ToLower() == "content-length")
                            req.ContentLength = Convert.ToInt32(HeaderSplitted[1].TrimStart(' '));
                        else if (HeaderSplitted[0].ToLower() == "referer")
                            req.Referer = HeaderSplitted[1].TrimStart(' ');
                        else if (HeaderSplitted[0].ToLower() == "user-agent")
                            req.UserAgent = HeaderSplitted[1].TrimStart(' ');
                        //else if (HeaderSplitted[0].ToLower() == "accept-encoding")
                        //    req.Headers.Set("Accept-Encoding", HeaderSplitted[1].TrimStart(' '));
                        else if (HeaderSplitted[0].ToLower() == "content-type")
                            req.ContentType = HeaderSplitted[1].TrimStart(' ');
                        else if (HeaderSplitted[0].ToLower() == "cookie")
                        {
                            req.Headers.Set("Cookie", HeaderSplitted[1].TrimStart(' '));
                            //CookieCollection CC = new CookieCollection();
                            // Cookie Ck  =new Cookie();
                            // Ck.
                            // req.CookieContainer.Add( = HeaderSplitted[1].TrimStart(' ');
                        }
                    }
                }

                if (Post.Length > 0)
                {
                    req.Method = "POST";
                    byte[] postbytes = Encoding.GetEncoding(0x4e4).GetBytes(Post);
                    //loHttp.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = postbytes.Length;
                    Stream dataStream = req.GetRequestStream();
                    dataStream.Write(postbytes, 0, postbytes.Length);
                    dataStream.Close();
                }


                // Get the response from the Web site.
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    int BytesRead = 0;
                    Byte[] Buffer = new Byte[32];
                    int BytesSent = 0;

                    if (sendconnectback)
                    {
                        SendMessage(m_sockClient, httpversion + " 200 Connection established\n\n");
                        SendMessage(m_sockClient, "Proxy-Agent: Proxy/1.1\r\n\r\n");
                    }
                    SendMessage(m_sockClient, "HTTP/1.1" + " " +
                             Convert.ToString((int)response.StatusCode) + " " + response.StatusDescription + "\r\n");
                    for (int i = 0; i < response.Headers.Count; i++)
                    {
                            SendMessage(m_sockClient, response.Headers.GetKey(i) + ": " + response.Headers[i] + "\r\n");
                    }
                    SendMessage(m_sockClient, "\r\n");

                    StringBuilder strResponse = new StringBuilder("");
                    using (Stream ResponseStream = response.GetResponseStream())
                    {

                        //using (StreamReader reader = new StreamReader(ResponseStream))
                        //{
                        //    strResponse.Append(reader.ReadToEnd());
                        //    //m_sockClient.Send(Buffer, BytesRead, 0);
                        //}
                        // Read the response into a buffer.
                        BytesRead = ResponseStream.Read(Buffer, 0, 32);
                        while (BytesRead != 0)
                        {
                            // Pass the response back to the client
                            strResponse.Append(Encoding.ASCII.GetString(Buffer,
                                                0, BytesRead));
                            m_sockClient.Send(Buffer, BytesRead, 0);
                            BytesSent += BytesRead;
                            // Read the next part of the response
                            BytesRead = ResponseStream.Read(Buffer, 0, 32);
                        }
                        //byte[] sendBytes = Encoding.ASCII.GetBytes(strResponse.ToString());
                        //m_sockClient.Send(sendBytes, sendBytes.Length, 0);
                    }
                    
                    Output.InsertRequest(url, strResponse.ToString(), Post, req.Headers, response.Headers);
                }
            }
            catch (FileNotFoundException e)
            {
                SendErrorPage(404, "File Not Found", e.Message);
            }
            catch (IOException e)
            {
                SendErrorPage(503, "Service not available", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                if (e.GetType() == typeof(WebException))
                {
                    WebException webException = (WebException)e;
                    if (webException.Response != null)
                    {
                        HttpWebResponse Response = (HttpWebResponse)webException.Response;
                        SendErrorPage((int)Response.StatusCode, Response.StatusCode.ToString(), e.Message);
                    }
                }
            }
            finally
            {
                // Disconnect and close the socket.
                if (m_sockClient != null)
                {
                    if (m_sockClient.Connected)
                    {
                        m_sockClient.Close();
                    }
                }
            }
            // Returning from this method will terminate the thread.
        }
        // Write an error response to the client.
        void SendErrorPage(int status, string strReason, string strText)
        {
            SendMessage(m_sockClient, "HTTP/1.0" + " " +
                         status + " " + strReason + "\r\n");
            SendMessage(m_sockClient, "Content-Type: text/plain" + "\r\n");
            SendMessage(m_sockClient, "Proxy-Connection: close" + "\r\n");
            SendMessage(m_sockClient, "\r\n");
            SendMessage(m_sockClient, status + " " + strReason);
            SendMessage(m_sockClient, strText);
        }

        // Send a string to a socket.
        void SendMessage(Socket sock, string strMessage)
        {
            buffer = new Byte[strMessage.Length + 1];
            int len = ASCII.GetBytes(strMessage.ToCharArray(), 0, strMessage.Length, buffer, 0);
            try
            {
                sock.Send(buffer, len, 0);
            }
            catch (Exception)
            {
            }
        }

        // Read a string from a socket.
        int ReadMessage(Socket sock, byte[] buf, ref string strMessage)
        {
            int iBytes = sock.Receive(buf, 1024, 0);
            strMessage = Encoding.ASCII.GetString(buf);
            return (iBytes);
        }
    }
}

