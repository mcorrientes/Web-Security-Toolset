using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace ToolSet.DatabaseExtractorCode.DBExtractor
{
   public delegate void EventFinishedDelegate(Request request);

   internal class RequestManager
   {
      private readonly ManualResetEvent _newRequestEvent;
      private readonly Queue<Request> _queueList;
      private readonly List<Thread> _threads;
      private readonly object _lockObject;
      private bool _managerActive;
      private int _currentRequestNr;
      private int _lastreturnedReqNr;

      public CookieCollection CustomCookieCollection { get; set; }
      public ManualResetEvent ManagerStopped { get; set; }

      public RequestManager()
      {
         _queueList = new Queue<Request>();
         _lockObject = new object();
         _threads = new List<Thread>();
         _newRequestEvent = new ManualResetEvent(false);
         _currentRequestNr = 0;
         _lastreturnedReqNr = -1;
         _managerActive = false;

         ManagerStopped = new ManualResetEvent(false);
         CustomCookieCollection = new CookieCollection();
      }

      public event EventFinishedDelegate RequestFinished;

      public int Count()
      {
         lock (_lockObject)
         {
            return _queueList.Count;
         }
      }

      public void StartThreads(int count)
      {
         _managerActive = true;
         ManagerStopped.Reset();
         _threads.Clear();

         if (count <= 0 || count > 8)
            return;
         for (int i = 0; i < count; i++)
         {
            var thr = new Thread(ThreadFunc);
            thr.Start();
            _threads.Add(thr);
         }
      }

      public void Stop()
      {
         _managerActive = false;
         ManagerStopped.Set();
         _currentRequestNr = 0;
         _lastreturnedReqNr = -1;
      }

      public void AddRequest(Request req)
      {
         lock (_lockObject)
         {
            req.NaturalRequestNr = _currentRequestNr;
            _currentRequestNr++;

            _queueList.Enqueue(req);
            _newRequestEvent.Set();
         }
      }

      public Request GetRequest()
      {
         lock (_lockObject)
         {
            if (_queueList.Count > 0)
               return _queueList.Dequeue();

            return null;
         }
      }

      private void ThreadFunc()
      {
         var wh = new WaitHandle[] { _newRequestEvent, ManagerStopped };

         while (_managerActive)
         {
            if (WaitHandle.WaitAny(wh) == 0)
            {
               Request req = GetRequest();
               if (req != null)
               {
                  var cwr = new CreateWebrequest
                               {
                                  CustomCookieCollection = CustomCookieCollection
                               };

                  req.HTML = cwr.StringGetWebPage(req.URL, req.POST);
                  OnRequestFinish(req);
               }
            }
         }
      }

      private void OnRequestFinish(Request req)
      {
         if (RequestFinished != null)
         {
            while (_lastreturnedReqNr + 1 != req.NaturalRequestNr && _managerActive)
               Thread.Sleep(100);

            lock (_lockObject)
            {
               if (_managerActive)
                  RequestFinished(req);

               _lastreturnedReqNr++;
            }
         }
      }
   }

   public class Request
   {
      public DataBaseType DataBaseType;
      public string Function;
      public string HTML;
      public string POST;
      public string URL;
      public int NaturalRequestNr;

      public Request()
      {
         NaturalRequestNr = 0;
         URL = string.Empty;
         POST = string.Empty;
         HTML = string.Empty;
         DataBaseType = DataBaseType.Unknown;
         Function = string.Empty;
      }
   }
}