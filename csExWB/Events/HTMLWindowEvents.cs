using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    public delegate void HTMLWindowEventHandler(object sender, HTMLWindowEventArgs e);
    public class HTMLWindowEventArgs : EventArgs
    {
        private IHTMLEventObj m_pEvtObj = null;
        public HTMLWindowEventArgs(IHTMLEventObj pEvtObj)
        {
            this.m_pEvtObj = pEvtObj;
        }
        public IHTMLEventObj EventObj
        {
            get { return m_pEvtObj; }
        }
    }

    public class HTMLWindowEvents : HTMLWindowEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_dwCookie = 0; //Connection cookie

        public HTMLWindowEvents()
        {
        }

        //IHTMLDocument2 doc2 = (IHTMLDocument2)WebBrowser2.Document;
        //IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
        //ConnectToHtmlEvents(win2)
        public bool ConnectToHtmlWindowEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref Iid_Clsids.DIID_HTMLWindowEvents2, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlWindowEvents()
        {
            m_IsCOnnected = false;
            bool bRet = false;
            //Do we have a connection point
            if (m_WBConnectionPoint != null)
            {
                if (m_dwCookie > 0)
                {
                    m_WBConnectionPoint.Unadvise(m_dwCookie);
                    m_dwCookie = 0;
                    bRet = true;
                }
                Marshal.ReleaseComObject(m_WBConnectionPoint);
            }
            return bRet;
        }


        #region HTMLWindowEvents2 Members

        public event HTMLWindowEventHandler winonLoad = null;
        void HTMLWindowEvents2.onload(IHTMLEventObj pEvtObj)
        {
            if (winonLoad != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonLoad(this, arg);
            }
        }
        public event HTMLWindowEventHandler winunload = null;
        void HTMLWindowEvents2.onunload(IHTMLEventObj pEvtObj)
        {
            if (winunload != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winunload(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonhelp = null;
        void HTMLWindowEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            if (winonhelp != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonhelp(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonfocus = null;
        void HTMLWindowEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            if (winonfocus != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonfocus(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonblur = null;
        void HTMLWindowEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            if (winonblur != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonblur(this, arg);
            }
        }

        void HTMLWindowEvents2.onerror(string description, string url, long line)
        {
            //
        }
        public event HTMLWindowEventHandler winonresize = null;
        void HTMLWindowEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            if (winonresize != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonresize(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonscroll = null;
        void HTMLWindowEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            if (winonscroll != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonscroll(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonbeforeunload = null;
        void HTMLWindowEvents2.onbeforeunload(IHTMLEventObj pEvtObj)
        {
            if (winonbeforeunload != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonbeforeunload(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonbeforeprint = null;
        void HTMLWindowEvents2.onbeforeprint(IHTMLEventObj pEvtObj)
        {
            if (winonbeforeprint != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonbeforeprint(this, arg);
            }
        }
        public event HTMLWindowEventHandler winonafterprint = null;
        void HTMLWindowEvents2.onafterprint(IHTMLEventObj pEvtObj)
        {
            if (winonafterprint != null)
            {
                HTMLWindowEventArgs arg = new HTMLWindowEventArgs(pEvtObj);
                winonafterprint(this, arg);
            }
        }

        #endregion
    }
}
