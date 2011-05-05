using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.Threading; 

namespace usertools.WebServerFinder
{
    public enum HttpProtocol
    {
        HTTP,
        HTTPs
    }
    public class Target
    {
        public string Address;
        public int Port;
        public HttpProtocol Protocol;
        public Target()
        {
            Address = string.Empty;
            Port = -1;
            Protocol = HttpProtocol.HTTP;
        }
    }

    public class TargetResult
    {
        public string Url;
        public string Html;
        public NameValueCollection ResponseHeaders;
        public HttpProtocol Protocol;
        public string Banner;
        public string WebServer;
        public bool Success;
        public string Hostname;
        public string Response;
        public HttpStatusCode StatusCode;

        public TargetResult()
        {
            Url = string.Empty;
            Html = string.Empty;
            ResponseHeaders = new NameValueCollection();
            Protocol = HttpProtocol.HTTP;
            Banner = string.Empty;
            WebServer = string.Empty;
            Success = false;
            Hostname = string.Empty;
            StatusCode = HttpStatusCode.Accepted;
        }
    }

    class WebServerFinder
    {
        private Queue<Target> Work;

        private bool userStopped;
        public bool UserStopped
        {
            get { return userStopped; }
        }

        private bool finished;
        public bool Finished
        {
            get { return finished; }
        }

        private List<TargetResult> results;
        public List<TargetResult> Results
        {
            get { return results; }
        }

        public WebServerFinder()
        {
            Work = new Queue<Target>();
            userStopped = false;
            finished = true;
            results = new List<TargetResult>();
        }

        public void Start(Object targets)
        {
            Start((List<Target>)targets);
        }

        public void Start(List<Target> targetList)
        {
            finished = false;
            Work.Clear();
            for (int i = 0; i < targetList.Count; i++)
                Work.Enqueue(targetList[i]);
            userStopped = false;
            results = new List<TargetResult>();

            StartThreads(6);
        }

        private void StartThreads(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Thread thread = new Thread(new ThreadStart(StartSearch));
                thread.Start();
            }
        }

        public void Stop()
        {
            userStopped = true;
        }

        private Target GetTarget()
        {
            lock (Work)
            {
                if (Work.Count > 0)
                    return Work.Dequeue();

                return null;
            }
        }

        private void StartSearch()
        {
            while (true)
            {
                Target target = GetTarget();
                if (target != null && !userStopped)
                    results.Add(Connect(target.Protocol, target.Address, target.Port));
                else
                    break;
            }
            finished = true;
        }

        public int TargetsLeft()
        {
            lock (Work)
            {
                return Work.Count;
            }
        }

        private TargetResult Connect(HttpProtocol Protocol, string IPAddress, int Port)
        {
            TargetResult Result = new TargetResult();
            string Address = string.Empty;
            if (Protocol == HttpProtocol.HTTP)
                Address = "http://" + IPAddress + ":" + Port.ToString();
            else if (Protocol == HttpProtocol.HTTPs)
                Address = "https://" + IPAddress + ":" + Port.ToString();


            CreateWebrequest webRequest = new CreateWebrequest();
            Result.Html = webRequest.StringGetWebPage(Address, string.Empty);
            Result.Url = Address;
            Result.Protocol = Protocol;

            if (webRequest.Response != null)
            {
                Result.ResponseHeaders = webRequest.Response.Headers;
                Result.Banner = webRequest.Response.Server;
                Result.WebServer = GetWebServer(webRequest.Response.Server);
                IPHostEntry Hostname = Dns.GetHostEntry(IPAddress);
                Result.Hostname = Hostname.HostName;
                Result.Success = true;
                Result.StatusCode = webRequest.Response.StatusCode;
            }
            else
            {
                Result.Success = false;
            }

            return Result;
        }


        private string GetWebServer(string Banner)
        {
            try
            {
                FingerPrinter fingerprint = new FingerPrinter();
                fingerprint.ReadText();
                return fingerprint.GetWebServer(Banner);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Fehler bei GeWebserverbanner" + Ex);
                return "unknown Web Server";
            }
        }
    }
}
