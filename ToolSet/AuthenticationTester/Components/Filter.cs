using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.AuthenticationTester
{
    public class Filter
    {
        public enum Conditions
        {
            StatusCodeIs,
            StatusCodeIsNot,
            HTMLContains,
            HTMLContainsNot,
            RegularExpression
        }

        public Conditions Condition;
        public string Text;

        public Filter()
        {
            Condition = Conditions.StatusCodeIs;
            Text = string.Empty;
        }
    }
}
