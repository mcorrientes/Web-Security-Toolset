using System;
using System.IO;
using System.Net;
using System.Text;

namespace ToolSet.DatabaseExtractorCode
{
   internal class CreateWebrequest
   {
      public CookieCollection CustomCookieCollection;

      public CreateWebrequest()
      {
         CustomCookieCollection = new CookieCollection();
      }

      public string StringGetWebPage(string url, string post)
      {
         if (url == string.Empty)
         {
            Console.WriteLine("URL is empty.");
         }

         string html = string.Empty;
         try
         {
            // Create a request for the URL.         
            var request = (HttpWebRequest) WebRequest.Create(url);

            if (CustomCookieCollection.Count > 0)
            {
               string domain = string.Empty;
               if (url.ToLower().StartsWith("http://"))
                  domain = url.Remove(0, 7);
               else if (url.ToLower().StartsWith("https://"))
                  domain = url.Remove(0, 8);

               int lastDomainSlash = domain.IndexOf('/');
               if (lastDomainSlash > 0)
                  domain = domain.Remove(lastDomainSlash);


               request.CookieContainer = new CookieContainer(CustomCookieCollection.Count);
               foreach (Cookie cookie in CustomCookieCollection)
               {
                  cookie.Domain = domain;
                  request.CookieContainer.Add(cookie);
               }
            }

            if (post != string.Empty)
            {
               request.Method = "POST";
               byte[] byteArray = Encoding.UTF8.GetBytes(post);
               request.ContentType = "application/x-www-form-urlencoded";
               request.ContentLength = byteArray.Length;
               using (Stream dataStream = request.GetRequestStream())
               {
                  dataStream.Write(byteArray, 0, byteArray.Length);
               }
               Console.WriteLine(post);
            }

            var response = (HttpWebResponse) request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
               if (dataStream != null)
                  using (var reader = new StreamReader(dataStream))
                  {
                     html = reader.ReadToEnd();
                  }
            }

            response.Close();
         }
         catch (Exception ex)
         {
            Console.WriteLine("An Error occoured in Method StringGetWebPage():" + ex);
         }
         return html;
      }
   }
}