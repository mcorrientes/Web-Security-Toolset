using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;

namespace usertools.AuthenticationTester
{
    class AuthenticationTester
    {
        public enum AuthenticationMethods
        {
            BasicAuth,
            HTMLForm
        }

        private string url;
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        private List<string> usernames;
        public List<string> Usernames
        {
            get { return usernames; }
            set { usernames = value; }
        }

        private List<string> passwords;
        public List<string> Passwords
        {
            get { return passwords; }
            set { passwords = value; }
        }

        private Filter successFilter;
        public Filter SuccessFilter
        {
            get { return successFilter; }
            set { successFilter = value; }
        }

        private AuthenticationMethods authentication;
        public AuthenticationMethods Authentication
        {
            get { return authentication; }
            set { authentication = value; }
        }

        private AuthenticationForm authForm;
        public AuthenticationForm AuthForm
        {
            get { return authForm; }
            set { authForm = value; }
        }

        private List<ValidCombination> validCombinations;
        public List<ValidCombination> ValidCombinations
        {
            get { return validCombinations; }
            set { validCombinations = value; }
        }

        private bool finished;
        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }

        private bool userStopped;
        public bool UserStopped
        {
            get { return userStopped; }
        }

        private Queue<CreateWebrequest> Work;

        public AuthenticationTester()
        {
            url = string.Empty;
            usernames = new List<string>();
            passwords = new List<string>();
            successFilter = new Filter();
            authentication = AuthenticationMethods.BasicAuth;
            authForm = new AuthenticationForm();
            validCombinations = new List<ValidCombination>();
            finished = false;
            userStopped = false;
            Work = new Queue<CreateWebrequest>();
        }

        public void Start()
        {
            if (successFilter.Text.Length == 0)
                return;
            if (usernames.Count == 0 || passwords.Count == 0)
                return;
            if (authentication == AuthenticationMethods.HTMLForm)
                if (authForm.InputFields.Count == 0)
                    return;
            if (url == string.Empty)
                return;

            PrepareWork();
            StartThreads(4);
        }

        public void Stop()
        {
            userStopped = true;
        }

        private void StartThreads(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Thread thread = new Thread(new ThreadStart(ThreadFunction));
                thread.Start();
            }
        }

        private void ThreadFunction()
        {
            while (true)
            {
                CreateWebrequest webRequest = GetWebRequest();
                if (webRequest != null && !userStopped)
                {
                    ValidateRequest(webRequest);
                }
                else
                {
                    Thread.Sleep(2500);
                    finished = true;
                    break;
                }
            }
        }

        public int RequestsLeft()
        {
            lock (Work)
            {
                return Work.Count;
            }
        }

        private void ValidateRequest(CreateWebrequest webRequest)
        {
            bool succeeded = false;
            try
            {
                string HTML = webRequest.StringGetWebPage();
                if (successFilter.Condition == Filter.Conditions.HTMLContains)
                    succeeded = HTML.Contains(successFilter.Text);
                else if (successFilter.Condition == Filter.Conditions.HTMLContainsNot)
                    succeeded = !HTML.Contains(successFilter.Text);
                else if (successFilter.Condition == Filter.Conditions.RegularExpression)
                {
                    Regex regex = new Regex(successFilter.Text);
                    Match match = regex.Match(HTML);
                    succeeded = match.Success;
                }

                if (webRequest.Response != null)
                {
                    if (successFilter.Condition == Filter.Conditions.StatusCodeIs)
                        succeeded = ((int)webRequest.Response.StatusCode == Convert.ToInt32(successFilter.Text));
                    else if (successFilter.Condition == Filter.Conditions.StatusCodeIsNot)
                        succeeded = ((int)webRequest.Response.StatusCode != Convert.ToInt32(successFilter.Text));
                }
            }
            catch (Exception)
            {
            }

            if (succeeded)
            {
                ValidCombination validCombination = new ValidCombination();
                validCombination.Username = webRequest.BasicUser;
                validCombination.Password = webRequest.BasicPass;
                validCombinations.Add(validCombination);
            }

        }

        private CreateWebrequest GetWebRequest()
        {
            lock (Work)
            {
                if (Work.Count > 0)
                    return Work.Dequeue();

                return null;
            }
        }

        private void PrepareWork()
        {
            foreach (string Username in usernames)
            {
                foreach (string Password in passwords)
                {
                    CreateWebrequest webRequest = new CreateWebrequest();
                    webRequest.BasicUser = Username;
                    webRequest.BasicPass = Password;
                    if (Authentication == AuthenticationMethods.BasicAuth)
                    {
                        webRequest.URL = url;
                        webRequest.UseBasicAuthentication = true;
                    }
                    else
                    {
                        webRequest.URL = authForm.Action;
                        if (authForm.Method == AuthenticationForm.Methods.GET)
                            webRequest.URL = BuildGET(authForm.Action, authForm.InputFields, Username, Password);
                        else
                            webRequest.POST = BuildPOST(authForm.InputFields, Username, Password);
                    }
                    Work.Enqueue(webRequest);
                }
            }
        }

        private string BuildGET(string URL, List<InputField> InputFields, string Username, string Password)
        {
            string Query = "";
            if (URL.Contains("?"))
                Query = "&";
            else
                Query = "?";

            for (int i = 0; i < InputFields.Count; i++)
            {
                string Value = InputFields[i].Value;
                if (InputFields[i].InputType == InputField.InputTypes.Password)
                    Value = Password;
                else if (InputFields[i].InputType == InputField.InputTypes.Username)
                    Value = Username;

                if (i == 0)
                    Query += InputFields[i].Name + "=" + HttpUtility.UrlEncode(Value);
                else
                    Query += "&" + InputFields[i].Name + "=" + HttpUtility.UrlEncode(Value);
            }
            return Query;
        }

        private string BuildPOST(List<InputField> InputFields, string Username, string Password)
        {
            string Query = "";
            for (int i = 0; i < InputFields.Count; i++)
            {
                string Value = InputFields[i].Value;
                if (InputFields[i].InputType == InputField.InputTypes.Password)
                    Value = Password;
                else if (InputFields[i].InputType == InputField.InputTypes.Username)
                    Value = Username;

                if (i == 0)
                    Query += InputFields[i].Name + "=" + HttpUtility.UrlEncode(Value);
                else
                    Query += "&" + InputFields[i].Name + "=" + HttpUtility.UrlEncode(Value);
            }
            return Query;
        }

    }
}
