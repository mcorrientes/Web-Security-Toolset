using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ToolSet.Global
{
   public static class Settings
   {
      public static bool UseProxy { get; set; }
      public static WebProxy Proxy { get; set; }
   }
}
