using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

//This file is obsolete as of version 2.x
//These classes have been replaced with HTMLxxxxEvents classes
//which are C# compliant in regard to activation and event handling

namespace csExWB
{
    /// <summary>
    /// HTMLEventHandler delegate
    /// </summary>
    /// <param name="sender">Instance of cHTMLWindowEvents or cHTMLDocumentEvents class</param>
    /// <param name="e">HTMLEventArgs</param>
    public delegate void HTMLEventHandler(object sender, HTMLEventArgs e);

    /// <summary>
    /// html document and window event argument class
    /// </summary>
    public class HTMLEventArgs : System.ComponentModel.CancelEventArgs
    {
        public HTMLEventDispIds m_EventDispId = 0;
        public HTMLEventType m_EventType = HTMLEventType.HTMLEventNone;
        public IHTMLEventObj m_pEvtObj = null;

        public HTMLEventArgs() { }
        public HTMLEventArgs(IHTMLEventObj pEvtObj)
        {
            this.Cancel = false;
            m_pEvtObj = pEvtObj;
        }

        public void ResetParameters(HTMLEventType EventType, HTMLEventDispIds DispID, IHTMLEventObj pEvtObj)
        {
            this.Cancel = false;
            this.m_EventDispId = DispID;
            m_pEvtObj = pEvtObj;
            m_EventType = EventType;
        }

        public IHTMLEventObj EventObj
        {
            get { return m_pEvtObj; }
        }
    }

    /// <summary>
    /// To handle Window events
    /// </summary>
    public class cHTMLWindowEvents : HTMLWindowEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private IHTMLEventCallBack m_EventCallBack = null; //Who to send relay events to
        public Guid m_guid = Guid.Empty;
        private int m_dwCookie = 0; //Connection cookie
        public int[] m_dispIds = null; //List of events to handle

        ~cHTMLWindowEvents()
        {
            m_EventCallBack = null;
            m_dispIds = null;
        }

        public void InitHTMLEvents(IHTMLEventCallBack EventCallBack, int[] EventsDispIds, Guid guid)
        {
            m_EventCallBack = EventCallBack;
            m_dispIds = EventsDispIds;
            m_guid = guid;
        }

        //elem = IHTMLWindow2
        public bool ConnectToHtmlEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref m_guid, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlEvents()
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

        private void Invoke_Handler(int id, IHTMLEventObj pEvt)
        {
            foreach (int i in m_dispIds)
            {
                if (i == id)
                {
                    if (m_EventCallBack != null)
                        m_EventCallBack.HandleHTMLEvent(HTMLEventType.HTMLWindowEvent, (HTMLEventDispIds)i, pEvt);
                    return;
                }
            }
        }

        #region HTMLWindowEvents2 Members
        void HTMLWindowEvents2.onload(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONLOAD, pEvtObj);
        }
        void HTMLWindowEvents2.onunload(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONUNLOAD, pEvtObj);
        }
        void HTMLWindowEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONHELP, pEvtObj);
        }
        void HTMLWindowEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONFOCUS, pEvtObj);
        }
        void HTMLWindowEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBLUR, pEvtObj);
        }
        void HTMLWindowEvents2.onerror(string description, string url, long line)
        {
            //
        }
        void HTMLWindowEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONRESIZE, pEvtObj);
        }
        void HTMLWindowEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONSCROLL, pEvtObj);
        }
        void HTMLWindowEvents2.onbeforeunload(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBEFOREUNLOAD, pEvtObj);
        }
        void HTMLWindowEvents2.onbeforeprint(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBEFOREPRINT, pEvtObj);
        }
        void HTMLWindowEvents2.onafterprint(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONAFTERPRINT, pEvtObj);
        }

        #endregion
    }

    /// <summary>
    /// To handle Document events
    /// </summary>
    public class cHTMLDocumentEvents : HTMLDocumentEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private IHTMLEventCallBack m_EventCallBack = null;
        public Guid m_guid = Guid.Empty;
        private int m_dwCookie = 0;
        public int[] m_dispIds = null;

        ~cHTMLDocumentEvents()
        {
            m_EventCallBack = null;
            m_dispIds = null;
        }

        public void InitHTMLEvents(IHTMLEventCallBack EventCallBack, int[] EventsDispIds, Guid guid)
        {
            m_EventCallBack = EventCallBack;
            m_dispIds = EventsDispIds;
            m_guid = guid;
        }

        //elem = IHTMLElement
        public bool ConnectToHtmlEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;
            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref m_guid, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlEvents()
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

        private bool Invoke_Handler(int id, IHTMLEventObj pEvt)
        {
            foreach (int i in m_dispIds)
            {
                if (i == id)
                {
                    if (m_EventCallBack != null)
                        return m_EventCallBack.HandleHTMLEvent(HTMLEventType.HTMLDocumentEvent, (HTMLEventDispIds)i, pEvt);
                }
            }
            return true; //Allow, default
        }

        #region HTMLDocumentEvents2 Members

        //[DispId(0)]
        //private void DefaultMethod()
        //{
        //    //get the window.event, reason is within the eventobject.type "click, dbclick"
        //}

        bool HTMLDocumentEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONHELP, pEvtObj); //true;
        }

        bool HTMLDocumentEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCLICK, pEvtObj);
        }

        bool HTMLDocumentEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDBLCLICK, pEvtObj);
        }

        void HTMLDocumentEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYDOWN, pEvtObj);
        }

        void HTMLDocumentEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYUP, pEvtObj);
        }

        bool HTMLDocumentEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYPRESS , pEvtObj);
        }

        void HTMLDocumentEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEDOWN , pEvtObj);
        }

        void HTMLDocumentEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEMOVE , pEvtObj);
        }

        void HTMLDocumentEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEUP , pEvtObj);
        }

        void HTMLDocumentEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOUT, pEvtObj);
        }

        void HTMLDocumentEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOVER, pEvtObj);
        }

        void HTMLDocumentEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONREADYSTATECHANGE , pEvtObj);
        }

        bool HTMLDocumentEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREUPDATE , pEvtObj);
        }

        void HTMLDocumentEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONAFTERUPDATE, pEvtObj);
        }

        bool HTMLDocumentEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWEXIT , pEvtObj);
        }

        void HTMLDocumentEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWENTER, pEvtObj);
        }

        bool HTMLDocumentEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDRAGSTART, pEvtObj);
        }

        bool HTMLDocumentEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSELECTSTART, pEvtObj);
        }

        bool HTMLDocumentEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONERRORUPDATE , pEvtObj);
        }

        bool HTMLDocumentEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCONTEXTMENU, pEvtObj);
        }

        bool HTMLDocumentEvents2.onstop(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSTOP , pEvtObj);
        }

        void HTMLDocumentEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWSDELETE, pEvtObj);
        }

        void HTMLDocumentEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWSINSERTED, pEvtObj);
        }

        void HTMLDocumentEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCELLCHANGE, pEvtObj);
        }

        void HTMLDocumentEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONPROPERTYCHANGE, pEvtObj);
        }

        void HTMLDocumentEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCHANGED, pEvtObj);
        }

        void HTMLDocumentEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATAAVAILABLE, pEvtObj);
        }

        void HTMLDocumentEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCOMPLETE , pEvtObj);
        }

        void HTMLDocumentEvents2.onbeforeeditfocus(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREEDITFOCUS, pEvtObj);
        }

        void HTMLDocumentEvents2.onselectionchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSELECTIONCHANGE , pEvtObj);
        }

        bool HTMLDocumentEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCONTROLSELECT , pEvtObj);
        }

        bool HTMLDocumentEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEWHEEL , pEvtObj);
        }

        void HTMLDocumentEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSIN , pEvtObj);
        }

        void HTMLDocumentEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSOUT , pEvtObj);
        }

        void HTMLDocumentEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONACTIVATE, pEvtObj);
        }

        void HTMLDocumentEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDEACTIVATE, pEvtObj);
        }

        bool HTMLDocumentEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREACTIVATE, pEvtObj);
        }

        bool HTMLDocumentEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREDEACTIVATE, pEvtObj);
        }

        #endregion
    }

    /// <summary>
    /// To handle any HTMLElement event
    /// </summary>
    public class cHTMLElementEvents : HTMLElementEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private IHTMLEventCallBack m_EventCallBack = null;
        public Guid m_guid = Guid.Empty;
        private int m_dwCookie = 0;
        public int[] m_dispIds = null;

        ~cHTMLElementEvents()
        {
            m_EventCallBack = null;
            m_dispIds = null;
        }

        public void InitHTMLEvents(IHTMLEventCallBack EventCallBack, int[] EventsDispIds, Guid guid)
        {
            m_EventCallBack = EventCallBack;
            m_dispIds = EventsDispIds;
            m_guid = guid;
        }

        //elem = IHTMLElement
        public bool ConnectToHtmlEvents(object elem)
        {
            if (elem == null)
                throw new ApplicationException("ConnectToHtmlEvents, elem can not be null!");
            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref m_guid, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlEvents()
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

        private bool Invoke_Handler(int id, IHTMLEventObj pEvt)
        {
            foreach (int i in m_dispIds)
            {
                if (i == id)
                {
                    if (m_EventCallBack != null)
                        return m_EventCallBack.HandleHTMLEvent(HTMLEventType.HTMLElementEvent , (HTMLEventDispIds)i, pEvt);
                }
            }
            return true; //Allow, default
        }

        #region HTMLElementEvents2 Members

        bool HTMLElementEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONHELP, pEvtObj);
        }

        bool HTMLElementEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCLICK , pEvtObj);
        }

        bool HTMLElementEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK, pEvtObj);
        }

        bool HTMLElementEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS, pEvtObj);
        }

        void HTMLElementEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN, pEvtObj);
        }

        void HTMLElementEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYUP, pEvtObj);
        }

        void HTMLElementEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT , pEvtObj);
        }

        void HTMLElementEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER, pEvtObj);
        }

        void HTMLElementEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE, pEvtObj);
        }

        void HTMLElementEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN, pEvtObj);
        }

        void HTMLElementEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP, pEvtObj);
        }

        bool HTMLElementEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART, pEvtObj);
        }

        void HTMLElementEvents2.onfilterchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE, pEvtObj);
        }

        bool HTMLElementEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART, pEvtObj);
        }

        bool HTMLElementEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE, pEvtObj);
        }

        void HTMLElementEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE, pEvtObj);
        }

        bool HTMLElementEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE, pEvtObj);
        }

        bool HTMLElementEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWEXIT, pEvtObj);
        }

        void HTMLElementEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWENTER, pEvtObj);
        }

        void HTMLElementEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED, pEvtObj);
        }

        void HTMLElementEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE, pEvtObj);
        }

        void HTMLElementEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE, pEvtObj);
        }

        void HTMLElementEvents2.onlosecapture(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE, pEvtObj);
        }

        void HTMLElementEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE, pEvtObj);
        }

        void HTMLElementEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSCROLL, pEvtObj);
        }

        void HTMLElementEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUS, pEvtObj);
        }

        void HTMLElementEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBLUR, pEvtObj);
        }

        void HTMLElementEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZE, pEvtObj);
        }

        bool HTMLElementEvents2.ondrag(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAG, pEvtObj);
        }

        void HTMLElementEvents2.ondragend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGEND, pEvtObj);
        }

        bool HTMLElementEvents2.ondragenter(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER, pEvtObj);
        }

        bool HTMLElementEvents2.ondragover(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER, pEvtObj);
        }

        void HTMLElementEvents2.ondragleave(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE, pEvtObj);
        }

        bool HTMLElementEvents2.ondrop(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDROP, pEvtObj);
        }

        bool HTMLElementEvents2.onbeforecut(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT, pEvtObj);
        }

        bool HTMLElementEvents2.oncut(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCUT, pEvtObj);
        }

        bool HTMLElementEvents2.onbeforecopy(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY, pEvtObj);
        }

        bool HTMLElementEvents2.oncopy(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCOPY, pEvtObj);
        }

        bool HTMLElementEvents2.onbeforepaste(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE, pEvtObj);
        }

        bool HTMLElementEvents2.onpaste(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPASTE, pEvtObj);
        }

        bool HTMLElementEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU, pEvtObj);
        }

        void HTMLElementEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE, pEvtObj);
        }

        void HTMLElementEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED, pEvtObj);
        }

        void HTMLElementEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE, pEvtObj);
        }

        void HTMLElementEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE, pEvtObj);
        }

        void HTMLElementEvents2.onlayoutcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE, pEvtObj);
        }

        void HTMLElementEvents2.onpage(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPAGE, pEvtObj);
        }

        void HTMLElementEvents2.onmouseenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER, pEvtObj);
        }

        void HTMLElementEvents2.onmouseleave(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE, pEvtObj);
        }

        void HTMLElementEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONACTIVATE, pEvtObj);
        }

        void HTMLElementEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE, pEvtObj);
        }

        bool HTMLElementEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE, pEvtObj);
        }

        bool HTMLElementEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE, pEvtObj);
        }

        void HTMLElementEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN, pEvtObj);
        }

        void HTMLElementEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT, pEvtObj);
        }

        void HTMLElementEvents2.onmove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVE , pEvtObj);
        }

        bool HTMLElementEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT, pEvtObj);
        }

        bool HTMLElementEvents2.onmovestart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVESTART, pEvtObj);
        }

        void HTMLElementEvents2.onmoveend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVEEND, pEvtObj);
        }

        bool HTMLElementEvents2.onresizestart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART, pEvtObj);
        }

        void HTMLElementEvents2.onresizeend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND, pEvtObj);
        }

        bool HTMLElementEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL, pEvtObj);
        }

        #endregion
    }

    /// <summary>
    /// To handle HTMLSelect element events
    /// Use ID_ONCHANGE
    /// Choose a different option in a select object using mouse or keyboard navigation. 
    /// Alter text in the text area and then navigate out of the object. 
    /// </summary>
    public class cHTMLSelectElementEvents : HTMLSelectElementEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private IHTMLEventCallBack m_EventCallBack = null;
        public Guid m_guid = Guid.Empty;
        private int m_dwCookie = 0;
        public int[] m_dispIds = null;

        ~cHTMLSelectElementEvents()
        {
            m_EventCallBack = null;
            m_dispIds = null;
        }

        public void InitHTMLEvents(IHTMLEventCallBack EventCallBack, int[] EventsDispIds, Guid guid)
        {
            m_EventCallBack = EventCallBack;
            m_dispIds = EventsDispIds;
            m_guid = guid;
        }

        //elem = IHTMLElement
        public bool ConnectToHtmlEvents(object elem)
        {
            if (elem == null)
                throw new ApplicationException("ConnectToHtmlEvents, elem can not be null!");
            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref m_guid, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlEvents()
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

        private bool Invoke_Handler(int id, IHTMLEventObj pEvt)
        {
            foreach (int i in m_dispIds)
            {
                if (i == id)
                {
                    if (m_EventCallBack != null)
                        return m_EventCallBack.HandleHTMLEvent(HTMLEventType.HTMLElementEvent, (HTMLEventDispIds)i, pEvt);
                }
            }
            return true; //Allow, default
        }

        #region HTMLSelectElementEvents2 Members

        bool HTMLSelectElementEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONHELP, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCLICK, pEvtObj);
        }

        bool HTMLSelectElementEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS, pEvtObj);
        }

        void HTMLSelectElementEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN, pEvtObj);
        }

        void HTMLSelectElementEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYUP, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART, pEvtObj);
        }

        void HTMLSelectElementEvents2.onfilterchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART , pEvtObj);
        }

        bool HTMLSelectElementEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE , pEvtObj);
        }

        void HTMLSelectElementEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE , pEvtObj);
        }

        bool HTMLSelectElementEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWEXIT , pEvtObj);
        }

        void HTMLSelectElementEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWENTER, pEvtObj);
        }

        void HTMLSelectElementEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED , pEvtObj);
        }

        void HTMLSelectElementEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE, pEvtObj);
        }

        void HTMLSelectElementEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onlosecapture(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSCROLL, pEvtObj);
        }

        void HTMLSelectElementEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUS, pEvtObj);
        }

        void HTMLSelectElementEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBLUR, pEvtObj);
        }

        void HTMLSelectElementEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.ondrag(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAG, pEvtObj);
        }

        void HTMLSelectElementEvents2.ondragend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGEND, pEvtObj);
        }

        bool HTMLSelectElementEvents2.ondragenter(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER, pEvtObj);
        }

        bool HTMLSelectElementEvents2.ondragover(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER, pEvtObj);
        }

        void HTMLSelectElementEvents2.ondragleave(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.ondrop(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDROP, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onbeforecut(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT, pEvtObj);
        }

        bool HTMLSelectElementEvents2.oncut(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCUT, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onbeforecopy(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY, pEvtObj);
        }

        bool HTMLSelectElementEvents2.oncopy(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCOPY, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onbeforepaste(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onpaste(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPASTE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU, pEvtObj);
        }

        void HTMLSelectElementEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED, pEvtObj);
        }

        void HTMLSelectElementEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onlayoutcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onpage(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPAGE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmouseenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmouseleave(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONACTIVATE, pEvtObj);
        }

        void HTMLSelectElementEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE, pEvtObj);
        }

        void HTMLSelectElementEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN, pEvtObj);
        }

        void HTMLSelectElementEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVE, pEvtObj);
        }

        bool HTMLSelectElementEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onmovestart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVESTART, pEvtObj);
        }

        void HTMLSelectElementEvents2.onmoveend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVEEND, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onresizestart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART, pEvtObj);
        }

        void HTMLSelectElementEvents2.onresizeend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND, pEvtObj);
        }

        bool HTMLSelectElementEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL, pEvtObj);
        }

        void HTMLSelectElementEvents2.onchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLSELECTELEMENTEVENTS2_ONCHANGE, pEvtObj);
        }

        #endregion
    }

    /// <summary>
    /// To handle script element events
    /// </summary>
    public class cHTMLScriptEvents2 : HTMLScriptEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private IHTMLEventCallBack m_EventCallBack = null;
        public Guid m_guid = Guid.Empty;
        private int m_dwCookie = 0;
        public int[] m_dispIds = null;

        ~cHTMLScriptEvents2()
        {
            m_EventCallBack = null;
            m_dispIds = null;
        }

        public void InitHTMLEvents(IHTMLEventCallBack EventCallBack, int[] EventsDispIds, Guid guid)
        {
            m_EventCallBack = EventCallBack;
            m_dispIds = EventsDispIds;
            m_guid = guid;
        }

        //elem = IHTMLElement
        public bool ConnectToHtmlEvents(object elem)
        {
            if (elem == null)
                throw new ApplicationException("ConnectToHtmlEvents, elem can not be null!");
            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref m_guid, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlEvents()
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

        private bool Invoke_Handler(int id, IHTMLEventObj pEvt)
        {
            foreach (int i in m_dispIds)
            {
                if (i == id)
                {
                    if (m_EventCallBack != null)
                        return m_EventCallBack.HandleHTMLEvent(HTMLEventType.HTMLElementEvent, (HTMLEventDispIds)i, pEvt);
                }
            }
            return true; //Allow, default
        }

        #region HTMLScriptEvents2 Members

        bool HTMLScriptEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONHELP, pEvtObj);
        }

        bool HTMLScriptEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCLICK, pEvtObj);
        }

        bool HTMLScriptEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK, pEvtObj);
        }

        bool HTMLScriptEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS, pEvtObj);
        }

        void HTMLScriptEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN, pEvtObj);
        }

        void HTMLScriptEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYUP, pEvtObj);
        }

        void HTMLScriptEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT, pEvtObj);
        }

        void HTMLScriptEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER, pEvtObj);
        }

        void HTMLScriptEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE, pEvtObj);
        }

        void HTMLScriptEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN, pEvtObj);
        }

        void HTMLScriptEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP, pEvtObj);
        }

        bool HTMLScriptEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART, pEvtObj);
        }

        void HTMLScriptEvents2.onfilterchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE, pEvtObj);
        }

        bool HTMLScriptEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART, pEvtObj);
        }

        bool HTMLScriptEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE, pEvtObj);
        }

        void HTMLScriptEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE, pEvtObj);
        }

        bool HTMLScriptEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE, pEvtObj);
        }

        bool HTMLScriptEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWEXIT, pEvtObj);
        }

        void HTMLScriptEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWENTER, pEvtObj);
        }

        void HTMLScriptEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED, pEvtObj);
        }

        void HTMLScriptEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE, pEvtObj);
        }

        void HTMLScriptEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE, pEvtObj);
        }

        void HTMLScriptEvents2.onlosecapture(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE, pEvtObj);
        }

        void HTMLScriptEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE, pEvtObj);
        }

        void HTMLScriptEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSCROLL, pEvtObj);
        }

        void HTMLScriptEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUS, pEvtObj);
        }

        void HTMLScriptEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBLUR, pEvtObj);
        }

        void HTMLScriptEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZE, pEvtObj);
        }

        bool HTMLScriptEvents2.ondrag(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAG, pEvtObj);
        }

        void HTMLScriptEvents2.ondragend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGEND, pEvtObj);
        }

        bool HTMLScriptEvents2.ondragenter(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER, pEvtObj);
        }

        bool HTMLScriptEvents2.ondragover(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER, pEvtObj);
        }

        void HTMLScriptEvents2.ondragleave(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE, pEvtObj);
        }

        bool HTMLScriptEvents2.ondrop(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDROP, pEvtObj);
        }

        bool HTMLScriptEvents2.onbeforecut(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT, pEvtObj);
        }

        bool HTMLScriptEvents2.oncut(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCUT, pEvtObj);
        }

        bool HTMLScriptEvents2.onbeforecopy(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY, pEvtObj);
        }

        bool HTMLScriptEvents2.oncopy(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCOPY, pEvtObj);
        }

        bool HTMLScriptEvents2.onbeforepaste(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE, pEvtObj);
        }

        bool HTMLScriptEvents2.onpaste(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPASTE, pEvtObj);
        }

        bool HTMLScriptEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU, pEvtObj);
        }

        void HTMLScriptEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE, pEvtObj);
        }

        void HTMLScriptEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED, pEvtObj);
        }

        void HTMLScriptEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE, pEvtObj);
        }

        void HTMLScriptEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE, pEvtObj);
        }

        void HTMLScriptEvents2.onlayoutcomplete(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE, pEvtObj);
        }

        void HTMLScriptEvents2.onpage(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPAGE, pEvtObj);
        }

        void HTMLScriptEvents2.onmouseenter(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER, pEvtObj);
        }

        void HTMLScriptEvents2.onmouseleave(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE, pEvtObj);
        }

        void HTMLScriptEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONACTIVATE, pEvtObj);
        }

        void HTMLScriptEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE, pEvtObj);
        }

        bool HTMLScriptEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE, pEvtObj);
        }

        bool HTMLScriptEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE, pEvtObj);
        }

        void HTMLScriptEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN, pEvtObj);
        }

        void HTMLScriptEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT, pEvtObj);
        }

        void HTMLScriptEvents2.onmove(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVE, pEvtObj);
        }

        bool HTMLScriptEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT, pEvtObj);
        }

        bool HTMLScriptEvents2.onmovestart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVESTART, pEvtObj);
        }

        void HTMLScriptEvents2.onmoveend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVEEND, pEvtObj);
        }

        bool HTMLScriptEvents2.onresizestart(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART, pEvtObj);
        }

        void HTMLScriptEvents2.onresizeend(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND, pEvtObj);
        }

        bool HTMLScriptEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            return Invoke_Handler(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL, pEvtObj);
        }

        void HTMLScriptEvents2.onerror(IHTMLEventObj pEvtObj)
        {
            Invoke_Handler(HTMLDispIDs.DISPID_HTMLSCRIPTEVENTS2_ONERROR, pEvtObj);
        }

        #endregion
    }

}

