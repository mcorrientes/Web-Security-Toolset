using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace ScanServerManager.Components
{
    public class ProxyRequest
    {
        public DateTime RequestTime;
        public string URL;
        public string POST;
        public string Data;
        public string RequestHeaders;
        public string ResponseHeaders;

        public ProxyRequest()
        {
            RequestTime = DateTime.MinValue;
            URL = string.Empty;
            POST = string.Empty;
            Data = string.Empty;
            RequestHeaders = string.Empty;
            ResponseHeaders = string.Empty;
        }
    }
    public class ProxyOutput
    {
        public List<ProxyRequest> Requests;

        public ProxyOutput()
        {
            Requests = new List<ProxyRequest>();
        }

        public void InsertRequest(string SendedData, string ReceivedData)
        {
            if (SendedData.Length == 0 || ReceivedData.Length == 0)
                return;
            if (!SendedData.ToLower().Contains("get") && !SendedData.ToLower().Contains("post") && !SendedData.ToLower().Contains("put"))
                return;

            string SendData = SendedData.Replace("\0", "");
            string RecData = ReceivedData.Replace("\0", "");
            //if(SendData == null

            ProxyRequest proxyRequest = new ProxyRequest();

            int GetIndex = SendedData.IndexOf("GET ");
            string URL = SendData.Substring(GetIndex + 4);
            URL = URL.Substring(0, URL.IndexOf(' '));

            proxyRequest.URL = URL;
            proxyRequest.POST = "";
            int DataIndex = RecData.IndexOf("\r\n\r\n");
            if (DataIndex != -1)
            {
                if (DataIndex + 4 < RecData.Length)
                    proxyRequest.Data = RecData.Substring(DataIndex + 4);
                if (DataIndex < RecData.Length)
                    proxyRequest.ResponseHeaders = RecData.Substring(0, DataIndex);
            }
            proxyRequest.RequestHeaders = SendData;
            proxyRequest.RequestTime = DateTime.Now;
            Requests.Add(proxyRequest);
        }

        public void InsertRequest(string URL, string Data, string POST, WebHeaderCollection RequestHeaders, WebHeaderCollection ResponseHeaders)
        {
            ProxyRequest proxyRequest = new ProxyRequest();
            proxyRequest.URL = URL;
            proxyRequest.POST = POST;
            proxyRequest.Data = Data;
            //proxyRequest.RequestHeaders = RequestHeaders;
            //proxyRequest.ResponseHeaders = ResponseHeaders;
            proxyRequest.RequestTime = DateTime.Now;
            Requests.Add(proxyRequest);
        }
    }

    class ProxyManager
    {
        private Org.Mentalis.Proxy.Http.HttpListener Listener;

        private bool userStopped;
        public bool UserStopped
        {
            get { return userStopped; }
            set { userStopped = value; }
        }

        public bool ProxyActive
        {
            get
            {
                if (Listener == null)
                    return false;
                else if (Listener.IsDisposed)
                    return false;
                else
                    return Listener.Listening;
            }
        }

        private ProxyOutput output;
        public ProxyOutput Output
        {
            get { return output; }
        }

        public ProxyManager()
        {
            output = new ProxyOutput();

            //ServicePointManager.Expect100Continue = false;
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(securityCallBack);
        }

        //private bool securityCallBack(Object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolerrors)
        //{
        //    return true;
        //}

        //void OpenNewSocket(object State)
        //{
        //    try
        //    {
        //        Socket socket = sockServer.EndAcceptSocket((IAsyncResult)State);
        //        clsProxyConnection proxy = new clsProxyConnection(socket, output);
        //        Thread thread = new Thread(new ThreadStart(proxy.Run));
        //        thread.Start();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    AcceptNewSocket = true;
        //}

        public void StartProxy(int Port)
        {
            Listener = new Org.Mentalis.Proxy.Http.HttpListener(Port);
            Listener.OnDataReceived += new Org.Mentalis.Proxy.DataRecDelegate(Listener_OnDataReceived);
            Listener.Start();

            //sockServer = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
            //Thread thread = new Thread(new ThreadStart(StartListening));
            //thread.Start();
        }

        void Listener_OnDataReceived(string SendData, string RecData)
        {
            output.InsertRequest(SendData, RecData);
        }

        public void Stop()
        {
            if (Listener != null)
                Listener.Dispose();
        }

        //private void StartListening()
        //{
        //    proxyActive = false;
        //    userStopped = false;

        //    try
        //    {
        //        proxyActive = true;
        //        // Create a listener for the proxy port
        //        sockServer.Start();
        //        while (!userStopped)
        //        {
        //            if (AcceptNewSocket)
        //            {
        //                AcceptNewSocket = false;
        //                System.AsyncCallback AcBegin = new System.AsyncCallback(OpenNewSocket);
        //                sockServer.BeginAcceptSocket(AcBegin, null);
        //            }
        //            Thread.Sleep(50);
        //        }
        //        sockServer.Stop();
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    proxyActive = false;
        //}
    }
}
