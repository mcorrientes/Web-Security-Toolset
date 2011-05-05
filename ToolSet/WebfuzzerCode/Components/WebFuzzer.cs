using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace usertools.WebFuzzer
{
    class WebFuzzer
    {
        private int requestsMade = 0;
        public int RequestsMade
        {
            get { return requestsMade; }
            set { requestsMade = value; }
        }

        private int requestAnzahl = 0;
        public int RequestAnzahl
        {
            get { return requestAnzahl; }
            set { requestsMade = value; }
        }
        private string url;
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
        private string post;
        public string POST
        {
            get { return post; }
            set { post = value; }
        }

        private List<IGenerator> generators;
        public List<IGenerator> Generators
        {
            get { return generators; }
            set { generators = value; }
        }

        private List<FuzzerFilter> fuzzerFilters;
        public List<FuzzerFilter> FuzzerFilters
        {
            get { return fuzzerFilters; }
            set { fuzzerFilters = value; }
        }

        private CookieCollection customCookieCollection;
        public CookieCollection CustomCookieCollection
        {
            get { return customCookieCollection; }
            set { customCookieCollection = value; }
        }

        private bool useMatchFile;
        public bool UseMatchFile
        {
            get { return useMatchFile; }
            set { useMatchFile = value; }
        }

        private string regularMatch;
        public string RegularMatch
        {
            get { return regularMatch; }
            set { regularMatch = value; }
        }

        private string matchFile;
        public string MatchFile
        {
            get { return matchFile; }
            set { matchFile = value; }
        }

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

        private List<FilteredRequest> filteredRequests;
        public List<FilteredRequest> FilteredRequests
        {
            get { return filteredRequests; }
        }

        private Queue<CreateWebrequest> Work;

        public WebFuzzer()
        {
            // Properties
            url = string.Empty;
            post = string.Empty;
            generators = new List<IGenerator>();
            fuzzerFilters = new List<FuzzerFilter>();
            customCookieCollection = new CookieCollection();
            useMatchFile = false;
            regularMatch = string.Empty;
            matchFile = string.Empty;
            userStopped = false;
            finished = false;
            filteredRequests = new List<FilteredRequest>();

            // Internal Objects
            Work = new Queue<CreateWebrequest>();
        }

        private void Reset()
        {
            userStopped = false;
            finished = false;
            Work.Clear();
            filteredRequests = new List<FilteredRequest>();
        }

        public void Start()
        {
            if (URL == string.Empty)
                return;
            if (generators.Count == 0)
                return;
            if (useMatchFile)
                if (regularMatch == string.Empty || matchFile == string.Empty)
                    return;

            Reset();
            StartThreads(4);
        }

        public void Stop()
        {
            userStopped = true;
        }

        private void StartThreads(int Count)
        {
            PrepareQueue();
            for (int i = 0; i < Count; i++)
            {
                Thread thread = new Thread(new ThreadStart(StartFuzzing));
                thread.Start();
            }
        }

        private void PrepareQueue()
        {
            RequestGenerator RG = new RequestGenerator(Generators);
            List<string> RequestListGET = RG.GenerateRequestList(URL);
            List<string> RequestListPOST = RG.GenerateRequestList(URL);

            if (RequestListGET.Count > 0)
                requestAnzahl = RequestListGET.Count;
            else
                requestAnzahl = RequestListPOST.Count;

            foreach (string _URL in RequestListGET)
            {
                if (post.Length == 0)
                {
                    CreateWebrequest webRequest = new CreateWebrequest();
                    webRequest.URL = _URL;
                    Work.Enqueue(webRequest);
                }
                else
                {
                    foreach (string _POST in RequestListPOST)
                    {
                        CreateWebrequest webRequest = new CreateWebrequest();
                        webRequest.URL = _URL;
                        webRequest.POST = _POST;
                        Work.Enqueue(webRequest);
                    }
                }
            }
        }

        private CreateWebrequest GetWork()
        {
            lock (Work)
            {
                if (Work.Count > 0)
                {
                    requestsMade++;
                    return Work.Dequeue();
                }

                return null;
            }
        }

        private void StartFuzzing()
        {
            while (true)
            {
                CreateWebrequest webRequest = GetWork();
                if (webRequest == null || userStopped)
                {
                    Thread.Sleep(4000);
                    finished = true;
                    break;
                }
                else
                    Process(webRequest);
            }
            //string HTML = SendWebRequest(RequestList[i], string.Empty);
            //if (Filtered(HTML))
            //{
            //    if (useMatchFile)
            //    {
            //        string Match = GetMatch(HTML);
            //        WriteMatch(Match);
            //    }
            //}
        }

        private string SendWebRequest(string URL, string POST)
        {
            CreateWebrequest request = new CreateWebrequest();
            request.CustomCookieCollection = CustomCookieCollection;
            string HTML = request.StringGetWebPage(URL, POST);

            return HTML;
        }

        private void Process(CreateWebrequest webRequest)
        {
            string HTML = webRequest.StringGetWebPage();

            if (webRequest.Response != null)
            {
                string ResponseHeaders = "";
                for (int iKey = 0; iKey < webRequest.Response.Headers.Keys.Count; iKey++)
                {
                    string Values = "";
                    string[] ValuesSplitted = webRequest.Response.Headers.GetValues(iKey);
                    for (int iValue = 0; iValue < ValuesSplitted.Length; iValue++)
                        Values += ValuesSplitted[iValue] + " ";

                    ResponseHeaders += webRequest.Response.Headers.Keys[iKey] + ": " + Values + "\r\n";
                }

                string RequestHeaders = "";
                if (webRequest.Request != null)
                {
                    for (int iKey = 0; iKey < webRequest.Request.Headers.Keys.Count; iKey++)
                    {
                        string Values = "";
                        string[] ValuesSplitted = webRequest.Request.Headers.GetValues(iKey);
                        for (int iValue = 0; iValue < ValuesSplitted.Length; iValue++)
                            Values += ValuesSplitted[iValue] + " ";

                        RequestHeaders += webRequest.Request.Headers.Keys[iKey] + ": " + Values + "\r\n";
                    }
                }

                bool RequestSuccess = true;
                for (int i = 0; i < fuzzerFilters.Count; i++)
                {
                    bool Filtered = true;
                    FuzzerFilter Filter = fuzzerFilters[i];
                    if (Filter.ConditionType == FuzzerFilter.ConditionTypes.ResponseHeaders)
                    {
                        if (!RegexMatch(ResponseHeaders, Filter.ConditionValue))
                            Filtered = false;
                    }
                    if (Filter.ConditionType == FuzzerFilter.ConditionTypes.ResponseHTML)
                    {
                        if (!RegexMatch(HTML, Filter.ConditionValue))
                            Filtered = false;
                    }
                    if (Filter.ConditionType == FuzzerFilter.ConditionTypes.ResponseStatusCode)
                    {
                        if (!RegexMatch(Convert.ToInt32(webRequest.Response.StatusCode).ToString(), Filter.ConditionValue))
                            Filtered = false;
                    }

                    if (Filtered && Filter.FilterType == FuzzerFilter.FilterTypes.Exclude)
                        RequestSuccess = false;
                }

                if (RequestSuccess)
                {
                    FilteredRequest filteredRequest = new FilteredRequest();
                    filteredRequest.HTML = HTML;
                    filteredRequest.URL = webRequest.URL;
                    filteredRequest.RequestHeaders = RequestHeaders;
                    filteredRequest.ResponseHeaders = ResponseHeaders;
                    filteredRequests.Add(filteredRequest);
                }
            }
        }

        private bool RegexMatch(string Text, string Search)
        {
            bool Matched = false;
            try
            {
                Regex Reg = new Regex(Search);
                Match M = Reg.Match(Text);
                if (M.Success)
                    Matched = true;
            }
            catch (Exception)
            {
            }
            return Matched;
        }

        #region Matches

        private string GetMatch(string HTML)
        {
            string MatchString = string.Empty;
            try
            {
                Regex Reg = new Regex(regularMatch);
                Match M = Reg.Match(HTML);
                if (M.Success)
                    if (M.Groups.Count > 1)
                        MatchString = M.Groups[1].Value;
            }
            catch (Exception)
            {
            }
            return MatchString;
        }

        private void WriteMatch(string Match)
        {
            try
            {
                if (File.Exists(matchFile))
                    File.AppendAllText(matchFile, Match + "\r\n");
                else
                {
                    StreamWriter SW = File.CreateText(matchFile);
                    SW.WriteLine(Match);
                    SW.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
