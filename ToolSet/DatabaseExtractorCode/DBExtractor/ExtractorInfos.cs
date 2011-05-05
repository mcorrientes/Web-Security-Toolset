using System.Collections.Generic;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public class ExtractorInfos
   {
      public bool ParameterInjectable { get; set; }
      public List<string> Requests { get; set; }
      public List<DatabaseInfo> DatabaseInfos { get; set; }
      public List<string> Databases { get; set; }
      public List<string> Tables { get; set; }
      public bool CurrentTestFinished { get; set; }
      public string CurrentQueryOutput { get; set; }
      public List<string> Status { get; set; }
      public List<string> QueryOutput { get; set; }
      public string Version { get; set; }
      public string CurrentDatabaseName { get; set; }
      public string User { get; set; }
      public bool CurrentTestComplete { get; set; }
      public string DatabaseType { get; set; }

      public ExtractorInfos()
      {
         ParameterInjectable = false;
         Requests = new List<string>();
         DatabaseInfos = new List<DatabaseInfo>();
         Databases = new List<string>();
         Tables = new List<string>();
         CurrentTestFinished = false;
         CurrentQueryOutput = string.Empty;
         Status = new List<string>();
         QueryOutput = new List<string>();
         Version = string.Empty;
         CurrentDatabaseName = string.Empty;
         User = string.Empty;
         CurrentTestComplete = false;
         DatabaseType = string.Empty;
      }
   }
}
