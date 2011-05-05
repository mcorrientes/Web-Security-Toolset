using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Sql_Database_Extraction
{
    class CreateWebrequest
    {
        public CookieCollection CustomCookieCollection;

        public CreateWebrequest()
        {
            CustomCookieCollection = new CookieCollection();
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
                    Console.WriteLine(POST);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler bei StringGetWebPage:" + ex);
            }
            return HTML;
        }
    }
}
