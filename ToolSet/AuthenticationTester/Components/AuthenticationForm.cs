using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.AuthenticationTester
{
    public class AuthenticationForm
    {
        public enum Methods
        {
            GET,
            POST
        }
        public Methods Method;
        public string Action;
        public List<InputField> InputFields;

        public AuthenticationForm()
        {
            Method = Methods.POST;
            InputFields = new List<InputField>();
            Action = string.Empty;
        }
    }
}
