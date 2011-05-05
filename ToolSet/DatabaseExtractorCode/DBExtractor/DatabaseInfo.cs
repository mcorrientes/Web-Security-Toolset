using System.Collections.Generic;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public class DatabaseInfo
   {
      public string DatabaseName { get; set; }
      public List<Table> Tables { get; set; }

      public DatabaseInfo()
      {
         DatabaseName = string.Empty;
         Tables = new List<Table>();
      }
   }

   public class Table
   {
      public string TableName;
      public List<Field> Fields;

      public Table()
      {
         TableName = string.Empty;
         Fields = new List<Field>();
      }
   }

   public class Field
   {
      public string FeldName;
      public string FeldTyp;
      public List<string> FeldWert;

      public Field()
      {
         FeldName = string.Empty;
         FeldTyp = string.Empty;
         FeldWert = new List<string>();
      }
   }
}
