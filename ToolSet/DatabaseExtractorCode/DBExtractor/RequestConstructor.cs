using System;
using System.Text;
using System.Web;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   internal class RequestConstructor
   {
      private readonly InjectionInfos _injectInfos;

      public bool EncodeWhiteSpace { get; set; }

      public bool EncodeCharacters { get; set; }

      private string _modifiedURL;
      private string _modifiedPOST;

      public string GetURL()
      {
         return _modifiedURL;
      }

      public string GetPOST()
      {
         return _modifiedPOST;
      }

      public RequestConstructor(InjectionInfos injectInfos)
      {
         _injectInfos = injectInfos;
         _modifiedURL = string.Empty;
         _modifiedPOST = string.Empty;
         EncodeCharacters = false;
         EncodeWhiteSpace = false;
      }

      public void InsertQuery(string query)
      {
         _modifiedURL = string.Empty;
         _modifiedPOST = string.Empty;
         ChangeRequest(query);
      }

      private void ChangeRequest(string origQuery)
      {
         string query;
         _modifiedURL = _injectInfos.URL;
         _modifiedPOST = _injectInfos.POST;

         if (!EncodeCharacters)
         {
            query = HttpUtility.UrlEncode(origQuery);
            if (!EncodeWhiteSpace)
               query = HttpUtility.UrlEncode(origQuery).Replace("+", "%20");
         }
         else
            query = StringToHex(origQuery);

         if (_injectInfos.ModifyType == ModifyType.GET)
            _modifiedURL = _injectInfos.URL.Replace("{Inject}", query);
         else
            _modifiedPOST = _injectInfos.POST.Replace("{Inject}", query);
      }

      /// <summary>
      /// Wandelt den übergebenen String in die Hexadezimaldarstellung
      /// </summary>
      /// <param name="hexstring">der umzuwandelnde String</param>
      /// <returns>Hexadezimaldarstellung</returns>
      private static string StringToHex(string hexstring)
      {
         var sb = new StringBuilder();
         for (int i = 0; i < hexstring.Length; i++)
            sb.Append("%" + Convert.ToInt32(hexstring[i]).ToString("x"));
         return sb.ToString();
      }


   }
}
