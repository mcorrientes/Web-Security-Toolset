using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    public delegate void HTMLDocumentEventHandler(object sender, HTMLDocumentEventArgs e);
    public class HTMLDocumentEventArgs : EventArgs
    {
        private IHTMLEventObj m_pEvtObj = null;
        private bool m_AllowDefault = true;
        public HTMLDocumentEventArgs(IHTMLEventObj pEvtObj)
        {
            m_pEvtObj = pEvtObj;
            m_AllowDefault = true;
        }
        public IHTMLEventObj EventObj
        {
            get { return m_pEvtObj; }
        }
        public bool AllowDefault
        {
            get { return m_AllowDefault; }
            set { m_AllowDefault = value; }
        }
    }
    public class HTMLDocumentEvents : HTMLDocumentEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_dwCookie = 0; //Connection cookie
        public HTMLDocumentEvents()
        {
        }

        //if(e.IsTopLevel)
        //IHTMLDocument2 doc2 = (IHTMLDocument2)WebBrowser2.Document;
        //ConnectToHtmlDocumentEvents(doc2);
        public bool ConnectToHtmlDocumentEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref Iid_Clsids.DIID_HTMLDocumentEvents2, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlElementEvents()
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

        #region HTMLDocumentEvents2 Members

        public event HTMLDocumentEventHandler doconhelp = null;
        bool HTMLDocumentEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            if (doconhelp != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconhelp(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconclick = null;
        bool HTMLDocumentEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            if (doconclick != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconclick(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler docondblclick = null;
        bool HTMLDocumentEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            if (docondblclick != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                docondblclick(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconkeypress = null;
        bool HTMLDocumentEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            if (doconkeypress != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconkeypress(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconkeydown = null;
        void HTMLDocumentEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            if (doconkeydown != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconkeydown(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconkeyup = null;
        void HTMLDocumentEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            if (doconkeyup != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconkeyup(this, arg);
            }
        }


        public event HTMLDocumentEventHandler doconmouseout = null;
        void HTMLDocumentEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            if (doconmouseout != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconmouseout(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconmouseover = null;
        void HTMLDocumentEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            if (doconmouseover != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconmouseover(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconmousemove = null;
        void HTMLDocumentEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            if (doconmousemove != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconmousemove(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconmousedown = null;
        void HTMLDocumentEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            if (doconmousedown != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconmousedown(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconmouseup = null;
        void HTMLDocumentEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            if (doconmouseup != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconmouseup(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconreadystatechange = null;
        void HTMLDocumentEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            if (doconreadystatechange != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconreadystatechange(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconbeforeupdate = null;
        bool HTMLDocumentEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            if (doconbeforeupdate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconbeforeupdate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconafterupdate = null;
        void HTMLDocumentEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            if (doconafterupdate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconafterupdate(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconrowexit = null;
        bool HTMLDocumentEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            if (doconrowexit != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconrowexit(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconrowenter = null;
        void HTMLDocumentEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            if (doconrowenter != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconrowenter(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconselectstart = null;
        bool HTMLDocumentEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            if (doconselectstart != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconselectstart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler docondragstart = null;
        bool HTMLDocumentEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            if (docondragstart != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                docondragstart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconerrorupdate = null;
        bool HTMLDocumentEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            if (doconerrorupdate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconerrorupdate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconcontextmenu = null;
        bool HTMLDocumentEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            if (doconcontextmenu != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconcontextmenu(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconstop = null;
        bool HTMLDocumentEvents2.onstop(IHTMLEventObj pEvtObj)
        {
            if (doconstop != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconstop(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconrowsdelete = null;
        void HTMLDocumentEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            if (doconrowsdelete != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconrowsdelete(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconrowsinserted = null;
        void HTMLDocumentEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            if (doconrowsinserted != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconrowsinserted(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconcellchange = null;
        void HTMLDocumentEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            if (doconcellchange != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconcellchange(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconpropertychange = null;
        void HTMLDocumentEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            if (doconpropertychange != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconpropertychange(this, arg);
            }
        }

        public event HTMLDocumentEventHandler docondatasetchanged = null;
        void HTMLDocumentEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            if (docondatasetchanged != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                docondatasetchanged(this, arg);
            }
        }

        public event HTMLDocumentEventHandler docondataavialable = null;
        void HTMLDocumentEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            if (docondataavialable != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                docondataavialable(this, arg);
            }
        }

        public event HTMLDocumentEventHandler docondatasetcomplete = null;
        void HTMLDocumentEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            if (docondatasetcomplete != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                docondatasetcomplete(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconbeforeeditfocus = null;
        void HTMLDocumentEvents2.onbeforeeditfocus(IHTMLEventObj pEvtObj)
        {
            if (doconbeforeeditfocus != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconbeforeeditfocus(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconselectionchange = null;
        void HTMLDocumentEvents2.onselectionchange(IHTMLEventObj pEvtObj)
        {
            if (doconselectionchange != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconselectionchange(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconcontrolselect = null;
        bool HTMLDocumentEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            if (doconcontrolselect != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconcontrolselect(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconmousewheel = null;
        bool HTMLDocumentEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            if (doconmousewheel != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconmousewheel(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconfocusin = null;
        void HTMLDocumentEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            if (doconfocusin != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconfocusin(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconfocusout = null;
        void HTMLDocumentEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            if (doconfocusout != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconfocusout(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconactivate = null;
        void HTMLDocumentEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            if (doconactivate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconactivate(this, arg);
            }
        }

        public event HTMLDocumentEventHandler docondeactivate = null;
        void HTMLDocumentEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            if (docondeactivate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                docondeactivate(this, arg);
            }
        }

        public event HTMLDocumentEventHandler doconbeforeactivate = null;
        bool HTMLDocumentEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            if (doconbeforeactivate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconbeforeactivate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLDocumentEventHandler doconbeforedeactivate = null;
        bool HTMLDocumentEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            if (doconbeforedeactivate != null)
            {
                HTMLDocumentEventArgs arg = new HTMLDocumentEventArgs(pEvtObj);
                doconbeforedeactivate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        #endregion
    }
}
