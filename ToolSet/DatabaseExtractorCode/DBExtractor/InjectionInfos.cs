using System.Net;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public enum ModifyType
   {
      GET,
      POST
   }

   public class InjectionInfos
   {
      public CookieCollection CustomCookieCollection;
      public string DefaultValue;
      public string Fail;
      public string InjectableParameter;
      public ModifyType ModifyType;
      public string POST;
      public string Success;
      public string URL;

      public InjectionInfos()
      {
         Success = string.Empty;
         Fail = string.Empty;
         InjectableParameter = string.Empty;
         POST = string.Empty;
         URL = string.Empty;
         ModifyType = ModifyType.GET;
         DefaultValue = string.Empty;
         CustomCookieCollection = new CookieCollection();
      }
   }
}