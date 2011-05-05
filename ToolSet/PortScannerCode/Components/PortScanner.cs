using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace PortScanner
{
    public enum eProtocol
    {
        tcp,
        udp
    }

    public class FinishedService
    {
        private bool succeeded;
        public bool Succeeded
        {
            get { return succeeded; }
            set { succeeded = value; }
        }

        private Service testedService;
        public Service TestedService
        {
            get { return testedService; }
            set { testedService = value; }
        }
      
        public FinishedService()
        {
            succeeded = false;
            testedService = new Service();
        }
    }

    public class Service
    {
        public string ServiceName;
        public string IP;
        public int Port;
        public eProtocol Protocol;

        public Service()
        {
            ServiceName = string.Empty;
            IP = string.Empty;
            Port = -1;
            Protocol = eProtocol.tcp;
        }
    }
    class PortScanner
    {
        private Queue<Service> Work;
        private object Lock;
        private bool UserStopped;
        private int ActiveThreads;

        private int waitfornextthread;
        public int Waitfornextthread
        {
            get { return waitfornextthread; }
            set { waitfornextthread = value; }
        }

        private int requestTimeout;
        public int RequestTimeout
        {
            get { return requestTimeout; }
            set { requestTimeout = value; }
        }


        private List<FinishedService> finishedServices;
        public List<FinishedService> FinishedServices
        {
            get { lock (Lock) { return finishedServices; } }
        }

        private bool scanningActive;
        public bool ScanningActive
        {
            get { return scanningActive; }
        }

        public PortScanner()
        {
            Work = new Queue<Service>();
            Lock = new object();
            UserStopped = false;
            ActiveThreads = 0;
            requestTimeout = 2000;
            waitfornextthread = 0;
            finishedServices = new List<FinishedService>();
            scanningActive = false;
        }

        public void StartScan(List<Service> ServicesToScan)
        {
            if (scanningActive)
                return;

            UserStopped = false;
            scanningActive = true;
            Work.Clear();
            finishedServices.Clear();
            AddWork(ServicesToScan);
            StartThreads(30);
        }

        public void Stop()
        {
            UserStopped = true;
        }

        public int ScansLeft()
        {
            lock (Lock)
            {
                return Work.Count;
            }
        }

        private void AddWork(List<Service> ServicesToScan)
        {
            for (int i = 0; i < ServicesToScan.Count; i++)
                Work.Enqueue(ServicesToScan[i]);
        }

        private void StartThreads(int Count)
        {
            for (int i = 0; i < Count && i < Work.Count; i++)
            {
                Thread thread = new Thread(new ThreadStart(ThreadFunction));
                Thread.Sleep(waitfornextthread);
                thread.Start();
            }
        }

        private void ThreadFunction()
        {
            ActiveThreads++;
            while (!UserStopped)
            {
                Service service = GetWork();
                if (service == null)
                    break;

                FinishedService FS = new FinishedService();
                FS.TestedService = service;
                FS.Succeeded = Connect(service.IP, service.Port, service.Protocol);
                AddFinishedService(FS);
            }

            ActiveThreads--;
            while (ActiveThreads > 0)
                Thread.Sleep(1000);
            scanningActive = false;
        }

        private void AddFinishedService(FinishedService FS)
        {
            lock (Lock)
            {
                finishedServices.Add(FS);
            }
        }

        private Service GetWork()
        {
            lock (Lock)
            {
                if (Work.Count > 0)
                    return Work.Dequeue();
            }
            return null;
        }

        private bool Connect(string IP, int Port, eProtocol Protocol)
        {
            try
            {
                IPEndPoint IPep = new IPEndPoint(IPAddress.Parse(IP), Port);

                Socket socket = null;
                if (Protocol == eProtocol.tcp)
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                else
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
                socket.ReceiveTimeout = requestTimeout;
                socket.Connect(IPep);
                socket.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
