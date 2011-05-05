using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ToolSet.CustomRequestCode.Components
{
   internal class CreateWebrequest
   {
      public CookieCollection CustomCookieCollection;
      public string Password = string.Empty;
      public HttpWebResponse Response;
      public string Username = string.Empty;
      public NetworkCredential netCredentials;

      public CreateWebrequest()
      {
         CustomCookieCollection = new CookieCollection();
         Response = null;
         netCredentials = new NetworkCredential();
      }

      public string StringGetWebPage(string URL, string POST, List<string> headers, bool mediatype)
      {
         if (URL == string.Empty)
         {
            Console.WriteLine("URL ist leer");
         }

         string HTML = string.Empty;
         try
         {
            // Create a request for the URL.         
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Timeout = 3000;

            request.Credentials = netCredentials;
            foreach (string header in headers)
            {
               try
               {
                  request.Headers.Add(header);
               }
               catch (Exception)
               {
                  Console.WriteLine(header);
               }
            }
            if (mediatype)
            {
               request.MediaType = "HTTP/1.0";
            }
            else
            {
               request.MediaType = "HTTP/1.1";
            }

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

            var response = (HttpWebResponse)request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
               using (var reader = new StreamReader(dataStream))
               {
                  HTML = reader.ReadToEnd();
               }
            }

            response.Close();
            Response = response;
         }
         catch (Exception ex)
         {
            Console.WriteLine("Fehler bei StringGetWebPage:" + ex);
            if (ex.GetType() == typeof(WebException))
            {
               var WebExc = (WebException)ex;
               if (WebExc.Response != null)
               {
                  Response = (HttpWebResponse)WebExc.Response;
                  using (Stream dataStream = Response.GetResponseStream())
                  {
                     using (var reader = new StreamReader(dataStream))
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