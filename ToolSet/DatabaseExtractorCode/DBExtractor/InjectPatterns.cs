using System.Collections.Generic;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public class InjectPatterns
   {
      public List<string> Conditions { get; private set; }

      public List<string> Begin { get; private set; }

      public List<string> End { get; private set; }

      public InjectPatterns()
      {
         Conditions = new List<string> { "and ", "or " };
         Begin = new List<string> { "' ", "\" ", " " };
         End = new List<string> { "", "--", "/*", "#", ";", "%00" };
      }
   }
}
