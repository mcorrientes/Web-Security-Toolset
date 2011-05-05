using System;
using System.Collections.Generic;
using System.Text;

namespace ToolSet.InjectionBrowsercode.Components
{
    public class AttackedUrl
    {
        private string originalURL;
        public string OriginalURL
        {
            get { return originalURL; }
            set { originalURL = value; }
        }

        private string modifiedURL;
        public string ModifiedURL
        {
            get { return modifiedURL; }
            set { modifiedURL = value; }
        }

        private string originalPOST;
        public string OriginalPOST
        {
            get { return originalPOST; }
            set { originalPOST = value; }
        }

        private string modifiedPOST;
        public string ModifiedPOST
        {
            get { return modifiedPOST; }
            set { modifiedPOST = value; }
        }

        private string html;
        public string HTML
        {
            get { return html; }
            set { html = value; }
        }

        public AttackedUrl()
        {
            originalURL = string.Empty;
            modifiedURL = string.Empty;
            originalPOST = string.Empty;
            modifiedPOST = string.Empty;
            html = string.Empty;
        }
    }
}
