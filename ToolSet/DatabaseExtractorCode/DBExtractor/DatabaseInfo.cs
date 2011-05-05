using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    public class DatabaseInfo
    {
        public string DatabaseName;
        public List<Table> Tables;

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
