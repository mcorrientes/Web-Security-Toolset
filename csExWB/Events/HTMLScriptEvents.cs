using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    public delegate void HTMLScriptEventHandler(object sender, HTMLScriptEventArgs e);
    public class HTMLScriptEventArgs : EventArgs
    {
        private IHTMLEventObj m_pEvtObj = null;
        private bool m_AllowDefault = true;
        public HTMLScriptEventArgs(IHTMLEventObj pEvtObj)
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

    public class HTMLScriptEvents : HTMLScriptEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_dwCookie = 0; //Connection cookie

        public HTMLScriptEvents()
        {
        }

        public bool ConnectToHtmlScriptEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref Iid_Clsids.DIID_HTMLScriptEvents2, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlScriptEvents()
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

        #region HTMLScriptEvents2 Members

        public event HTMLScriptEventHandler scriptonhelp = null;
        bool HTMLScriptEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            if (scriptonhelp != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonhelp(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }

        public event HTMLScriptEventHandler scriptonclick = null;
        bool HTMLScriptEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            if (scriptonclick != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonclick(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }

        public event HTMLScriptEventHandler scriptondblclick = null;
        bool HTMLScriptEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            if (scriptondblclick != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondblclick(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }

        public event HTMLScriptEventHandler scriptonkeypress = null;
        bool HTMLScriptEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            if (scriptonkeypress != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonkeypress(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }

        public event HTMLScriptEventHandler scriptonkeydown = null;
        void HTMLScriptEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            if (scriptonkeydown != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonkeydown(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonkeyup = null;
        void HTMLScriptEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            if (scriptonkeyup != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonkeyup(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmouseout = null;
        void HTMLScriptEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            if (scriptonmouseout != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmouseout(this, arg);
            }
        }

        public event HTMLScriptEventHandler scriptonmouseover = null;
        void HTMLScriptEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            if (scriptonmouseover != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmouseover(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmousemove = null;
        void HTMLScriptEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            if (scriptonmousemove != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmousemove(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmousedown = null;
        void HTMLScriptEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            if (scriptonmousedown != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmousedown(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmouseup = null;
        void HTMLScriptEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            if (scriptonmouseup != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmouseup(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonselectstart = null;
        bool HTMLScriptEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            if (scriptonselectstart != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonselectstart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonfilterchange = null;
        void HTMLScriptEvents2.onfilterchange(IHTMLEventObj pEvtObj)
        {
            if (scriptonfilterchange != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonfilterchange(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondragstart = null;
        bool HTMLScriptEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            if (scriptondragstart != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondragstart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonbeforeupdate = null;
        bool HTMLScriptEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            if (scriptonbeforeupdate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonbeforeupdate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonafterupdate = null;
        void HTMLScriptEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            if (scriptonafterupdate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonafterupdate(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonerrorupdate = null;
        bool HTMLScriptEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            if (scriptonerrorupdate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonerrorupdate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonrowexit = null;
        bool HTMLScriptEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            if (scriptonrowexit != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonrowexit(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonrowenter = null;
        void HTMLScriptEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            if (scriptonrowenter != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonrowenter(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondatasetchanged = null;
        void HTMLScriptEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            if (scriptondatasetchanged != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondatasetchanged(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondataavailable = null;
        void HTMLScriptEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            if (scriptondataavailable != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondataavailable(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondatasetcomplete = null;
        void HTMLScriptEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            if (scriptondatasetcomplete != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondatasetcomplete(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonlosecapture = null;
        void HTMLScriptEvents2.onlosecapture(IHTMLEventObj pEvtObj)
        {
            if (scriptonlosecapture != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonlosecapture(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonpropertychange = null;
        void HTMLScriptEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            if (scriptonpropertychange != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonpropertychange(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonscroll = null;
        void HTMLScriptEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            if (scriptonscroll != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonscroll(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonfocus = null;
        void HTMLScriptEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            if (scriptonfocus != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonfocus(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonblur = null;
        void HTMLScriptEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            if (scriptonblur != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonblur(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonresize = null;
        void HTMLScriptEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            if (scriptonresize != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonresize(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondrag = null;
        bool HTMLScriptEvents2.ondrag(IHTMLEventObj pEvtObj)
        {
            if (scriptondrag != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondrag(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptondragend = null;
        void HTMLScriptEvents2.ondragend(IHTMLEventObj pEvtObj)
        {
            if (scriptondragend != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondragend(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondragenter = null;
        bool HTMLScriptEvents2.ondragenter(IHTMLEventObj pEvtObj)
        {
            if (scriptondragenter != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondragenter(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptondragover = null;
        bool HTMLScriptEvents2.ondragover(IHTMLEventObj pEvtObj)
        {
            if (scriptondragover != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondragover(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptondragleave = null;
        void HTMLScriptEvents2.ondragleave(IHTMLEventObj pEvtObj)
        {
            if (scriptondragleave != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondragleave(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondrop = null;
        bool HTMLScriptEvents2.ondrop(IHTMLEventObj pEvtObj)
        {
            if (scriptondrop != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondrop(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonbeforecut = null;
        bool HTMLScriptEvents2.onbeforecut(IHTMLEventObj pEvtObj)
        {
            if (scriptonbeforecut != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonbeforecut(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptoncut = null;
        bool HTMLScriptEvents2.oncut(IHTMLEventObj pEvtObj)
        {
            if (scriptoncut != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptoncut(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonbeforecopy = null;
        bool HTMLScriptEvents2.onbeforecopy(IHTMLEventObj pEvtObj)
        {
            if (scriptonbeforecopy != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonbeforecopy(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptoncopy = null;
        bool HTMLScriptEvents2.oncopy(IHTMLEventObj pEvtObj)
        {
            if (scriptoncopy != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptoncopy(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonbeforepaste = null;
        bool HTMLScriptEvents2.onbeforepaste(IHTMLEventObj pEvtObj)
        {
            if (scriptonbeforepaste != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonbeforepaste(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonpaste = null;
        bool HTMLScriptEvents2.onpaste(IHTMLEventObj pEvtObj)
        {
            if (scriptonpaste != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonpaste(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptoncontextmenu = null;
        bool HTMLScriptEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            if (scriptoncontextmenu != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptoncontextmenu(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonrowsdelete = null;
        void HTMLScriptEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            if (scriptonrowsdelete != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonrowsdelete(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonrowsinserted = null;
        void HTMLScriptEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            if (scriptonrowsinserted != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonrowsinserted(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptoncellchange = null;
        void HTMLScriptEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            if (scriptoncellchange != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptoncellchange(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonreadystatechange = null;
        void HTMLScriptEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            if (scriptonreadystatechange != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonreadystatechange(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonlayoutcomplete = null;
        void HTMLScriptEvents2.onlayoutcomplete(IHTMLEventObj pEvtObj)
        {
            if (scriptonlayoutcomplete != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonlayoutcomplete(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonpage = null;
        void HTMLScriptEvents2.onpage(IHTMLEventObj pEvtObj)
        {
            if (scriptonpage != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonpage(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmouseenter = null;
        void HTMLScriptEvents2.onmouseenter(IHTMLEventObj pEvtObj)
        {
            if (scriptonmouseenter != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmouseenter(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmouseleave = null;
        void HTMLScriptEvents2.onmouseleave(IHTMLEventObj pEvtObj)
        {
            if (scriptonmouseleave != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmouseleave(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonactivate = null;
        void HTMLScriptEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            if (scriptonactivate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonactivate(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptondeactivate = null;
        void HTMLScriptEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            if (scriptondeactivate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptondeactivate(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonbeforedeactivate = null;
        bool HTMLScriptEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            if (scriptonbeforedeactivate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonbeforedeactivate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonbeforeactivate = null;
        bool HTMLScriptEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            if (scriptonbeforeactivate != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonbeforeactivate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonfocusin = null;
        void HTMLScriptEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            if (scriptonfocusin != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonfocusin(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonfocusout = null;
        void HTMLScriptEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            if (scriptonfocusout != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonfocusout(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmove = null;
        void HTMLScriptEvents2.onmove(IHTMLEventObj pEvtObj)
        {
            if (scriptonmove != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmove(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptoncontrolselect = null;
        bool HTMLScriptEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            if (scriptoncontrolselect != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptoncontrolselect(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonmovestart = null;
        bool HTMLScriptEvents2.onmovestart(IHTMLEventObj pEvtObj)
        {
            if (scriptonmovestart != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmovestart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonmoveend = null;
        void HTMLScriptEvents2.onmoveend(IHTMLEventObj pEvtObj)
        {
            if (scriptonmoveend != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmoveend(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonresizestart = null;
        bool HTMLScriptEvents2.onresizestart(IHTMLEventObj pEvtObj)
        {
            if (scriptonresizestart != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonresizestart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonresizeend = null;
        void HTMLScriptEvents2.onresizeend(IHTMLEventObj pEvtObj)
        {
            if (scriptonresizeend != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonresizeend(this, arg);
            }
        }
        public event HTMLScriptEventHandler scriptonmousewheel = null;
        bool HTMLScriptEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            if (scriptonmousewheel != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonmousewheel(this, arg);
                return arg.AllowDefault;
            }
            else
                return true;
        }
        public event HTMLScriptEventHandler scriptonerror = null;
        void HTMLScriptEvents2.onerror(IHTMLEventObj pEvtObj)
        {
            if (scriptonerror != null)
            {
                HTMLScriptEventArgs arg = new HTMLScriptEventArgs(pEvtObj);
                scriptonerror(this, arg);
            }
        }

        #endregion
    }
}
