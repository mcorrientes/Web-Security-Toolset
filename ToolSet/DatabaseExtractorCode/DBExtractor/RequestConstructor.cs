using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Sql_Database_Extraction
{
    class RequestConstructor
    {
        private InjectionInfos injectInfos;

        private bool encodeWhiteSpace;
        public bool EncodeWhiteSpace
        {
            get { return encodeWhiteSpace; }
            set { encodeWhiteSpace = value; }
        }

        private bool encodeCharacters;
        public bool EncodeCharacters
        {
            get { return encodeCharacters; }
            set { encodeCharacters = value; }
        }

        private string ModifiedURL;
        private string ModifiedPOST;

        public RequestConstructor(InjectionInfos InjectInfos)
        {
            injectInfos = InjectInfos;
            ModifiedURL = string.Empty;
            ModifiedPOST = string.Empty;
            encodeCharacters = false;
            encodeWhiteSpace = false;
        }

        public void InsertQuery(string Query)
        {
                ModifiedURL = string.Empty;
                ModifiedPOST = string.Empty;
                ChangeRequest(Query);
        }

        private void ChangeRequest(string OrigQuery)
        {
            string query = string.Empty;
            ModifiedURL = injectInfos.URL;
            ModifiedPOST = injectInfos.POST;


            if (!encodeCharacters)
            {
                query = HttpUtility.UrlEncode(OrigQuery);
                if (!encodeWhiteSpace)
                    query = HttpUtility.UrlEncode(OrigQuery).Replace("+", "%20");
            }
            else
                query = StringToHex(OrigQuery);

            if (injectInfos.ModifyType == eModifyType.GET)
                ModifiedURL = injectInfos.URL.Replace("{Inject}", query);
            else
                ModifiedPOST = injectInfos.POST.Replace("{Inject}", query);
        }

        /// <summary>
        /// Wandelt den übergebenen String in die Hexadezimaldarstellung
        /// </summary>
        /// <param name="Hexstring">der umzuwandelnde String</param>
        /// <returns>Hexadezimaldarstellung</returns>
        private string StringToHex(string Hexstring)
        {
            string ausgabe = string.Empty;
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < Hexstring.Length; i++)
                SB.Append("%" + Convert.ToInt32(Hexstring[i]).ToString("x"));
            return SB.ToString();
        }

        public string GetURL()
        {
            return ModifiedURL;
        }

        public string GetPOST()
        {
            return ModifiedPOST;
        }
    }
}
