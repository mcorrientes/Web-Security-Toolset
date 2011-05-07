using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    public delegate void HTMLElementEventHandler(object sender, HTMLElementEventArgs e);
    public class HTMLElementEventArgs : EventArgs
    {
        private IHTMLEventObj m_pEvtObj = null;
        private bool m_AllowDefault = true;
        public HTMLElementEventArgs(IHTMLEventObj pEvtObj)
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
    public class HTMLElementEvents : HTMLElementEvents2
    {
        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_dwCookie = 0; //Connection cookie
        public HTMLElementEvents()
        {
        }

        //IHTMLDocument3 doc3 = (IHTMLDocument3)WebBrowser2.Document;
        //ConnectToHtmlElementEvents(doc3.documentElement);
        public bool ConnectToHtmlElementEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref Iid_Clsids.DIID_HTMLElementEvents2, out m_WBConnectionPoint);
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

        #region HTMLElementEvents2 Members

        public event HTMLElementEventHandler elemonhelp = null;
        bool HTMLElementEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            if (elemonhelp != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonhelp(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonclick = null;
        bool HTMLElementEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            if (elemonclick != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonclick(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemondblclick = null;
        bool HTMLElementEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            if (elemondblclick != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondblclick(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonkeypress = null;
        bool HTMLElementEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            if (elemonkeypress != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonkeypress(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonkeydown = null;
        void HTMLElementEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            if (elemonkeydown != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonkeydown(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonkeyup = null;
        void HTMLElementEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            if (elemonkeyup != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonkeyup(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmouseout = null;
        void HTMLElementEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            if (elemonmouseout != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmouseout(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmouseover = null;
        void HTMLElementEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            if (elemonmouseover != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmouseover(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmousemove = null;
        void HTMLElementEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            if (elemonmousemove != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmousemove(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmousedown = null;
        void HTMLElementEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            if (elemonmousedown != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmousedown(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmouseup = null;
        void HTMLElementEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            if (elemonmouseup != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmouseup(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonselectstart = null;
        bool HTMLElementEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            if (elemonselectstart != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonselectstart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonfilterchange = null;
        void HTMLElementEvents2.onfilterchange(IHTMLEventObj pEvtObj)
        {
            if (elemonfilterchange != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonfilterchange(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondragstart = null;
        bool HTMLElementEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            if (elemondragstart != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondragstart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonbeforeupdate = null;
        bool HTMLElementEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            if (elemonbeforeupdate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonbeforeupdate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonafterupdate = null;
        void HTMLElementEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            if (elemonafterupdate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonafterupdate(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonerrorupdate = null;
        bool HTMLElementEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            if (elemonerrorupdate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonerrorupdate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonrowexit = null;
        bool HTMLElementEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            if (elemonrowexit != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonrowexit(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonrowenter = null;
        void HTMLElementEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            if (elemonrowenter != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonrowenter(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondatasetchanged = null;
        void HTMLElementEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            if (elemondatasetchanged != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondatasetchanged(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondataavialable = null;
        void HTMLElementEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            if (elemondataavialable != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondataavialable(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondatasetcomplete = null;
        void HTMLElementEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            if (elemondatasetcomplete != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondatasetcomplete(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonlosecapture = null;
        void HTMLElementEvents2.onlosecapture(IHTMLEventObj pEvtObj)
        {
            if (elemonlosecapture != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonlosecapture(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonpropertychange = null;
        void HTMLElementEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            if (elemonpropertychange != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonpropertychange(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonscroll = null;
        void HTMLElementEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            if (elemonscroll != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonscroll(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonfocus = null;
        void HTMLElementEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            if (elemonfocus != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonfocus(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonblur = null;
        void HTMLElementEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            if (elemonblur != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonblur(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonresize = null;
        void HTMLElementEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            if (elemonresize != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonresize(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondrag = null;
        bool HTMLElementEvents2.ondrag(IHTMLEventObj pEvtObj)
        {
            if (elemondrag != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondrag(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemondragend = null;
        void HTMLElementEvents2.ondragend(IHTMLEventObj pEvtObj)
        {
            if (elemondragend != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondragend(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondragenter = null;
        bool HTMLElementEvents2.ondragenter(IHTMLEventObj pEvtObj)
        {
            if (elemondragenter != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondragenter(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemondragover = null;
        bool HTMLElementEvents2.ondragover(IHTMLEventObj pEvtObj)
        {
            if (elemondragover != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondragover(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemondragleave = null;
        void HTMLElementEvents2.ondragleave(IHTMLEventObj pEvtObj)
        {
            if (elemondragleave != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondragleave(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondrop = null;
        bool HTMLElementEvents2.ondrop(IHTMLEventObj pEvtObj)
        {
            if (elemondrop != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondrop(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonbeforecut = null;
        bool HTMLElementEvents2.onbeforecut(IHTMLEventObj pEvtObj)
        {
            if (elemonbeforecut != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonbeforecut(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemoncut = null;
        bool HTMLElementEvents2.oncut(IHTMLEventObj pEvtObj)
        {
            if (elemoncut != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemoncut(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonbeforecopy = null;
        bool HTMLElementEvents2.onbeforecopy(IHTMLEventObj pEvtObj)
        {
            if (elemonbeforecopy != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonbeforecopy(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemoncopy = null;
        bool HTMLElementEvents2.oncopy(IHTMLEventObj pEvtObj)
        {
            if (elemoncopy != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemoncopy(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonbeforepaste = null;
        bool HTMLElementEvents2.onbeforepaste(IHTMLEventObj pEvtObj)
        {
            if (elemonbeforepaste != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonbeforepaste(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonpaste = null;
        bool HTMLElementEvents2.onpaste(IHTMLEventObj pEvtObj)
        {
            if (elemonpaste != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonpaste(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemoncontextmenu = null;
        bool HTMLElementEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            if (elemoncontextmenu != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemoncontextmenu(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonrowsdelete = null;
        void HTMLElementEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            if (elemonrowsdelete != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonrowsdelete(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonrowsinserted = null;
        void HTMLElementEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            if (elemonrowsinserted != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonrowsinserted(this, arg);
            }
        }

        public event HTMLElementEventHandler elemoncellchange = null;
        void HTMLElementEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            if (elemoncellchange != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemoncellchange(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonreadystatechange = null;
        void HTMLElementEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            if (elemonreadystatechange != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonreadystatechange(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonlayoutcomplete = null;
        void HTMLElementEvents2.onlayoutcomplete(IHTMLEventObj pEvtObj)
        {
            if (elemonlayoutcomplete != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonlayoutcomplete(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonpage = null;
        void HTMLElementEvents2.onpage(IHTMLEventObj pEvtObj)
        {
            if (elemonpage != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonpage(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmouseenter = null;
        void HTMLElementEvents2.onmouseenter(IHTMLEventObj pEvtObj)
        {
            if (elemonmouseenter != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmouseenter(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmouseleave = null;
        void HTMLElementEvents2.onmouseleave(IHTMLEventObj pEvtObj)
        {
            if (elemonmouseleave != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmouseleave(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonactivate = null;
        void HTMLElementEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            if (elemonactivate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonactivate(this, arg);
            }
        }

        public event HTMLElementEventHandler elemondeactivate = null;
        void HTMLElementEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            if (elemondeactivate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemondeactivate(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonbeforedeactivate = null;
        bool HTMLElementEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            if (elemonbeforedeactivate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonbeforedeactivate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonbeforeactivate = null;
        bool HTMLElementEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            if (elemonbeforeactivate != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonbeforeactivate(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonfocusin = null;
        void HTMLElementEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            if (elemonfocusin != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonfocusin(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonfocusout = null;
        void HTMLElementEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            if (elemonfocusout != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonfocusout(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmove = null;
        void HTMLElementEvents2.onmove(IHTMLEventObj pEvtObj)
        {
            if (elemonmove != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmove(this, arg);
            }
        }

        public event HTMLElementEventHandler elemoncontrolselect = null;
        bool HTMLElementEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            if (elemoncontrolselect != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemoncontrolselect(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonmovestart = null;
        bool HTMLElementEvents2.onmovestart(IHTMLEventObj pEvtObj)
        {
            if (elemonmovestart != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmovestart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonmoveend = null;
        void HTMLElementEvents2.onmoveend(IHTMLEventObj pEvtObj)
        {
            if (elemonmoveend != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmoveend(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonresizestart = null;
        bool HTMLElementEvents2.onresizestart(IHTMLEventObj pEvtObj)
        {
            if (elemonresizestart != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonresizestart(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLElementEventHandler elemonresizeend = null;
        void HTMLElementEvents2.onresizeend(IHTMLEventObj pEvtObj)
        {
            if (elemonresizeend != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonresizeend(this, arg);
            }
        }

        public event HTMLElementEventHandler elemonmousewheel = null;
        bool HTMLElementEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            if (elemonmousewheel != null)
            {
                HTMLElementEventArgs arg = new HTMLElementEventArgs(pEvtObj);
                elemonmousewheel(this, arg);
                return arg.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        #endregion
    }
}
