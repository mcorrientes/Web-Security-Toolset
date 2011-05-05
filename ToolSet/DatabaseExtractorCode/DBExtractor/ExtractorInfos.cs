using System;
using System.Collections.Generic;
using System.Text;

namespace Sql_Database_Extraction
{
    public class ExtractorInfos
    {
        public bool ParameterInjectable;
        public List<string> Requests;
        public List<DatabaseInfo> DatabaseInfos;
        public List<string> Databases;
        public List<string> Tables;
        public bool CurrentTestFinished;
        public string CurrentQueryOutput;
        public List<string> Status;
        public List<string> QueryOutput;
        public string Version;
        public string CurrentDatabaseName;
        public string User;
        public bool CurrentTestComplete;
        public string DatabaseType;


        public ExtractorInfos()
        {
            ParameterInjectable = false;
            Requests = new List<string>();
            DatabaseInfos = new List<DatabaseInfo>();
            Databases = new List<string>();
            Tables = new List<string>();
            CurrentTestFinished = false;
            CurrentQueryOutput = string.Empty;
            Status = new List<string>();
            QueryOutput = new List<string>();
            Version = string.Empty;
            CurrentDatabaseName = string.Empty;
            User = string.Empty;
            CurrentTestComplete = false;
            DatabaseType = string.Empty;
        }
    }
}
