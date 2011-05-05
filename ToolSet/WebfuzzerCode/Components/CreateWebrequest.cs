using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace usertools.WebFuzzer
{
    class CreateWebrequest
    {
        public CookieCollection CustomCookieCollection;
        public HttpWebResponse Response;
        public HttpWebRequest Request;
        public string URL;
        public string POST;
        public bool UseBasicAuthentication;
        public string BasicUser;
        public string BasicPass;

        public CreateWebrequest()
        {
            CustomCookieCollection = new CookieCollection();
            Response = null;
            URL = string.Empty;
            POST = string.Empty;
            UseBasicAuthentication = false;
            BasicUser = string.Empty;
            BasicPass = string.Empty;
        }

        public string StringGetWebPage()
        {
            return StringGetWebPage(URL, POST);
        }

        public string StringGetWebPage(string URL, string POST)
        {
            if (URL == string.Empty)
            {
                Console.WriteLine("URL ist leer");
            }

            string HTML = string.Empty;
            try
            {
                // Create a request for the URL.         
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 4000;
                if (UseBasicAuthentication)
                    request.Credentials = new NetworkCredential(BasicUser, BasicPass);


                if (CustomCookieCollection.Count > 0)
                {
                    string Domain = string.Empty;
                    if (URL.ToLower().StartsWith("http://"))
                        Domain = URL.Remove(0, 7);
                    else if (URL.ToLower().StartsWith("https://"))
                        Domain = URL.Remove(0, 8);

                    int lastDomainSlash = Domain.IndexOf('/');
                    if (lastDomainSlash > 0)
                        Domain = Domain.Remove(lastDomainSlash);


                    request.CookieContainer = new CookieContainer(CustomCookieCollection.Count);
                    foreach (Cookie cookie in CustomCookieCollection)
                    {
                        cookie.Domain = Domain;
                        request.CookieContainer.Add(cookie);
                    }
                }

                if (POST != string.Empty)
                {
                    request.Method = "POST";
                    byte[] byteArray = Encoding.UTF8.GetBytes(POST);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        HTML = reader.ReadToEnd();
                    }
                }
                response.Close();

                for (int i = 0; i < response.Headers.Keys.Count; i++)
                {
                    if (response.Headers.Keys[i].ToLower() == "location")
                    {
                        string[] Location = response.Headers.GetValues(i);
                        if (Location.Length > 0 && Location[0] != string.Empty)
                            URL = Location[0];
                    }
                    else if (response.Headers.Keys[i].ToLower() == "set-cookie")
                    {
                        string[] Cookies = response.Headers.GetValues(i);
                        foreach (string hCookie in Cookies)
                        {
                            if (hCookie == string.Empty)
                                continue;

                            string strippedCookie = hCookie;
                            if (hCookie.IndexOf(';') != -1)
                                strippedCookie = hCookie.Remove(hCookie.IndexOf(';'));

                            string[] CookieSplitted = strippedCookie.Split('=');
                            if (CookieSplitted.Length != 2)
                                continue;

                            string Domain = string.Empty;
                            if (URL.ToLower().StartsWith("http://"))
                                Domain = URL.Remove(0, 7);
                            else if (URL.ToLower().StartsWith("https://"))
                                Domain = URL.Remove(0, 8);

                            int lastDomainSlash = Domain.IndexOf('/');
                            if (lastDomainSlash > 0)
                                Domain = Domain.Remove(lastDomainSlash);

                            Cookie cookie = new Cookie();
                            cookie.Domain = Domain;
                            cookie.Name = CookieSplitted[0];
                            cookie.Value = CookieSplitted[1];
                            CustomCookieCollection.Add(cookie);
                        }
                    }
                }

                Request = request;
                Response = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler bei StringGetWebPage:" + ex);
                if (ex.GetType() == typeof(System.Net.WebException))
                {
                    WebException WebExc = (WebException)ex;
                    if (WebExc.Response != null)
                    {
                        Response = (HttpWebResponse)WebExc.Response;
                        using (Stream dataStream = Response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(dataStream))
                            {
                                HTML = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }


            return HTML;
        }
    }
}
