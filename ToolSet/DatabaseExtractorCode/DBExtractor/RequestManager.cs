using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.Net;

namespace Sql_Database_Extraction
{
    public delegate void EventFinishedDelegate(Request request);
    class RequestManager
    {
        private Queue<Request> QueueList;
        private object lockObject;
        private List<Thread> Threads;
        private ManualResetEvent NewRequestEvent;
        public event EventFinishedDelegate RequestFinished;
        public ManualResetEvent ManagerStopped;
        private int currentRequestNr;
        private int lastreturnedReqNr;
        private bool ManagerActive;
        public CookieCollection CustomCookieCollection;

        public RequestManager()
        {
            QueueList = new Queue<Request>();
            lockObject = new object();
            Threads = new List<Thread>();
            NewRequestEvent = new ManualResetEvent(false);
            ManagerStopped = new ManualResetEvent(false);
            currentRequestNr = 0;
            lastreturnedReqNr = -1;
            ManagerActive = false;
            CustomCookieCollection = new CookieCollection();
        }

        public int Count()
        {
            lock (lockObject)
            {
                return QueueList.Count;
            }
        }

        public void StartThreads(int Count)
        {
            ManagerActive = true;
            ManagerStopped.Reset();
            Threads.Clear();

            if (Count <= 0 || Count > 8)
                return;
            for (int i = 0; i < Count; i++)
            {
                Thread thr = new Thread(new ThreadStart(ThreadFunc));
                thr.Start();
                Threads.Add(thr);
            }
        }

        public void Stop()
        {
            ManagerActive = false;
            ManagerStopped.Set();
            currentRequestNr = 0;
            lastreturnedReqNr = -1;
        }

        public void AddRequest(Request req)
        {
            lock (lockObject)
            {
                req.naturalRequestNr = currentRequestNr;
                currentRequestNr++;

                QueueList.Enqueue(req);
                NewRequestEvent.Set();
            }
        }

        public Request GetRequest()
        {
            lock (lockObject)
            {
                if (QueueList.Count > 0)
                    return QueueList.Dequeue();

                return null;
            }
        }

        private void ThreadFunc()
        {
            WaitHandle[] WH = new WaitHandle[] { NewRequestEvent, ManagerStopped };

            while (ManagerActive)
            {
                if (WaitHandle.WaitAny(WH) == 0)
                {
                    Request Req = GetRequest();
                    if (Req != null)
                    {
                        CreateWebrequest CWR = new CreateWebrequest();
                        CWR.CustomCookieCollection = CustomCookieCollection;
                        Req.HTML = CWR.StringGetWebPage(Req.URL, Req.POST);
                        OnRequestFinish(Req);
                    }
                }
            }
        }

        private void OnRequestFinish(Request req)
        {
            if (RequestFinished != null)
            {
                while (lastreturnedReqNr + 1 != req.naturalRequestNr && ManagerActive)
                    Thread.Sleep(100);

                lock (lockObject)
                {
                    if (ManagerActive)
                        RequestFinished(req);

                    lastreturnedReqNr++;
                }
            }
        }
    }

    public class Request
    {
        public int naturalRequestNr;
        public string URL;
        public string POST;
        public string HTML;
        public eDataBase DataBaseType;
        public string Function;

        public Request()
        {
            naturalRequestNr = 0;
            URL = string.Empty;
            POST = string.Empty;
            HTML = string.Empty;
            DataBaseType = eDataBase.unknown;
            Function = string.Empty;
        }
    }
}
