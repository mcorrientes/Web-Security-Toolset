using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    public class InjectPatterns
    {
        private List<string> conditions;
        public List<string> Conditions
        {
            get { return conditions; }
        }

        private List<string> begin;
        public List<string> Begin
        {
            get { return begin; }
        }

        private List<string> end;
        public List<string> End
        {
            get { return end; }
        }

        public InjectPatterns()
        {
            conditions = new List<string>() { "and ", "or " };
            begin = new List<string>() { "' ", "\" ", " " };
            end = new List<string>() { "", "--", "/*", "#", ";", "%00" };
        }
    }
}
