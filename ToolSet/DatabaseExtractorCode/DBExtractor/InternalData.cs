using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    public enum eDataBase
    {
        MSSQL,
        MySQL,
        unknown
    }
    public class InternalData
    {
        public bool Prepared;
        public bool ParameterInjectable;
        public string InjectableCondition;
        public string InjectableBegin;
        public string InjectableEnd;
        public eDataBase DataBaseType;
        public bool UseConditions;

        public InternalData()
        {
            Prepared = false;
            ParameterInjectable = false;
            InjectableCondition = string.Empty;
            InjectableBegin = string.Empty;
            InjectableEnd = string.Empty;
            DataBaseType = eDataBase.unknown;
            UseConditions = true;
        }
    }
}
