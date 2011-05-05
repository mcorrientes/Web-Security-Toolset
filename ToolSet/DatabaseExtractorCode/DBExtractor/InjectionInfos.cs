using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Sql_Database_Extraction
{
    public enum eModifyType
    {
        GET,
        POST
    }
    public class InjectionInfos
    {
        public string InjectableParameter;
        public string POST;
        public string URL;
        public eModifyType ModifyType;
        public string DefaultValue;
        public string Success;
        public string Fail;
        public CookieCollection CustomCookieCollection;

        public InjectionInfos()
        {
            Success = string.Empty;
            Fail = string.Empty;
            InjectableParameter = string.Empty;
            POST = string.Empty;
            URL = string.Empty;
            ModifyType = eModifyType.GET;
            DefaultValue = string.Empty;
            CustomCookieCollection = new CookieCollection();
        }
    }
}
