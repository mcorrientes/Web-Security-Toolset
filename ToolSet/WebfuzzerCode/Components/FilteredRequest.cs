using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.WebFuzzer
{
    class FilteredRequest
    {
        public string URL;
        public string RequestHeaders;
        public string ResponseHeaders;
        public string HTML;

        public FilteredRequest()
        {
            URL = string.Empty;
            RequestHeaders = string.Empty;
            ResponseHeaders = string.Empty;
            HTML = string.Empty;
        }
    }
}
