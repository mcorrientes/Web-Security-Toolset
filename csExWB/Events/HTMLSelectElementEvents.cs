using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{

    public delegate void HTMLSelectElementEventHandler(object sender, HTMLSelectElementEventArgs e);
    public class HTMLSelectElementEventArgs : EventArgs
    {
        private IHTMLEventObj m_pEvtObj = null;
        private bool m_AllowDefault = true;
        public HTMLSelectElementEventArgs(IHTMLEventObj pEvtObj)
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

    public class HTMLSelectElementEvents : HTMLSelectElementEvents2
    {
        public HTMLSelectElementEvents()
        {
        }

        public bool m_IsCOnnected = false;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_dwCookie = 0; //Connection cookie

        //selectelem (IHTMLSelectElement)
        //ConnectToHtmlSelectElementEvents(selectelem);
        public bool ConnectToHtmlSelectElementEvents(object elem)
        {
            if (elem == null)
                return m_IsCOnnected;

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = elem as IConnectionPointContainer;
            //Find connection point
            if (cpCont != null)
            {
                cpCont.FindConnectionPoint(ref Iid_Clsids.DIID_HTMLSelectElementEvents2, out m_WBConnectionPoint);
                //Advice
                if (m_WBConnectionPoint != null)
                {
                    m_WBConnectionPoint.Advise(this, out m_dwCookie);
                    m_IsCOnnected = true;
                }
            }
            return m_IsCOnnected;
        }

        public bool DisconnectHtmlSelectElementEvents()
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


        #region HTMLSelectElementEvents2 Members

        public event HTMLSelectElementEventHandler selectonhelp = null;
        bool HTMLSelectElementEvents2.onhelp(IHTMLEventObj pEvtObj)
        {
            if (selectonhelp != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonhelp(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }

        public event HTMLSelectElementEventHandler selectonclick = null;
        bool HTMLSelectElementEvents2.onclick(IHTMLEventObj pEvtObj)
        {
            if (selectonclick != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonclick(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }
        public event HTMLSelectElementEventHandler selectondblclick = null;
        bool HTMLSelectElementEvents2.ondblclick(IHTMLEventObj pEvtObj)
        {
            if (selectondblclick != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondblclick(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }
        public event HTMLSelectElementEventHandler selectonkeypress = null;
        bool HTMLSelectElementEvents2.onkeypress(IHTMLEventObj pEvtObj)
        {
            if (selectonkeypress != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonkeypress(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }
        public event HTMLSelectElementEventHandler selectonkeydown = null;
        void HTMLSelectElementEvents2.onkeydown(IHTMLEventObj pEvtObj)
        {
            if (selectonkeydown != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonkeydown(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonkeyup = null;
        void HTMLSelectElementEvents2.onkeyup(IHTMLEventObj pEvtObj)
        {
            if (selectonkeyup != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonkeyup(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmouseout = null;
        void HTMLSelectElementEvents2.onmouseout(IHTMLEventObj pEvtObj)
        {
            if (selectonmouseout != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmouseout(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmouseover = null;
        void HTMLSelectElementEvents2.onmouseover(IHTMLEventObj pEvtObj)
        {
            if (selectonmouseover != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmouseover(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmousemove = null;
        void HTMLSelectElementEvents2.onmousemove(IHTMLEventObj pEvtObj)
        {
            if (selectonmousemove != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmousemove(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmousedown = null;
        void HTMLSelectElementEvents2.onmousedown(IHTMLEventObj pEvtObj)
        {
            if (selectonmousedown != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmousedown(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmouseup = null;
        void HTMLSelectElementEvents2.onmouseup(IHTMLEventObj pEvtObj)
        {
            if (selectonmouseup != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmouseup(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonselectstart = null;
        bool HTMLSelectElementEvents2.onselectstart(IHTMLEventObj pEvtObj)
        {
            if (selectonselectstart != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonselectstart(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }
        public event HTMLSelectElementEventHandler selectonfilterchange = null;
        void HTMLSelectElementEvents2.onfilterchange(IHTMLEventObj pEvtObj)
        {
            if (selectonfilterchange != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonfilterchange(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondragstart = null;
        bool HTMLSelectElementEvents2.ondragstart(IHTMLEventObj pEvtObj)
        {
            if (selectondragstart != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondragstart(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }
        public event HTMLSelectElementEventHandler selectonbeforeupdate = null;
        bool HTMLSelectElementEvents2.onbeforeupdate(IHTMLEventObj pEvtObj)
        {
            if (selectonbeforeupdate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonbeforeupdate(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default
        }
        public event HTMLSelectElementEventHandler selectonafterupdate = null;
        void HTMLSelectElementEvents2.onafterupdate(IHTMLEventObj pEvtObj)
        {
            if (selectonafterupdate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonafterupdate(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonerrorupdate = null;
        bool HTMLSelectElementEvents2.onerrorupdate(IHTMLEventObj pEvtObj)
        {
            if (selectonerrorupdate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonerrorupdate(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonrowexit = null;
        bool HTMLSelectElementEvents2.onrowexit(IHTMLEventObj pEvtObj)
        {
            if (selectonrowexit != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonrowexit(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default   
        }
        public event HTMLSelectElementEventHandler selectonrowenter = null;
        void HTMLSelectElementEvents2.onrowenter(IHTMLEventObj pEvtObj)
        {
            if (selectonrowenter != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonrowenter(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondatasetchanged = null;
        void HTMLSelectElementEvents2.ondatasetchanged(IHTMLEventObj pEvtObj)
        {
            if (selectondatasetchanged != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondatasetchanged(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondataavailable = null;
        void HTMLSelectElementEvents2.ondataavailable(IHTMLEventObj pEvtObj)
        {
            if (selectondataavailable != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondataavailable(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondatasetcomplete = null;
        void HTMLSelectElementEvents2.ondatasetcomplete(IHTMLEventObj pEvtObj)
        {
            if (selectondatasetcomplete != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondatasetcomplete(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonlosecapture = null;
        void HTMLSelectElementEvents2.onlosecapture(IHTMLEventObj pEvtObj)
        {
            if (selectonlosecapture != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonlosecapture(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonpropertychange = null;
        void HTMLSelectElementEvents2.onpropertychange(IHTMLEventObj pEvtObj)
        {
            if (selectonpropertychange != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonpropertychange(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonscroll = null;
        void HTMLSelectElementEvents2.onscroll(IHTMLEventObj pEvtObj)
        {
            if (selectonscroll != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonscroll(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonfocus = null;
        void HTMLSelectElementEvents2.onfocus(IHTMLEventObj pEvtObj)
        {
            if (selectonfocus != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonfocus(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonblur = null;
        void HTMLSelectElementEvents2.onblur(IHTMLEventObj pEvtObj)
        {
            if (selectonblur != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonblur(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonresize = null;
        void HTMLSelectElementEvents2.onresize(IHTMLEventObj pEvtObj)
        {
            if (selectonresize != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonresize(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondrag = null;
        bool HTMLSelectElementEvents2.ondrag(IHTMLEventObj pEvtObj)
        {
            if (selectondrag != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondrag(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectondragend = null;
        void HTMLSelectElementEvents2.ondragend(IHTMLEventObj pEvtObj)
        {
            if (selectondragend != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondragend(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondragenter = null;
        bool HTMLSelectElementEvents2.ondragenter(IHTMLEventObj pEvtObj)
        {
            if (selectondragenter != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondragenter(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectondragover = null;
        bool HTMLSelectElementEvents2.ondragover(IHTMLEventObj pEvtObj)
        {
            if (selectondragover != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondragover(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectondragleave = null;
        void HTMLSelectElementEvents2.ondragleave(IHTMLEventObj pEvtObj)
        {
            if (selectondragleave != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondragleave(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondrop = null;
        bool HTMLSelectElementEvents2.ondrop(IHTMLEventObj pEvtObj)
        {
            if (selectondrop != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondrop(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonbeforecut = null;
        bool HTMLSelectElementEvents2.onbeforecut(IHTMLEventObj pEvtObj)
        {
            if (selectonbeforecut != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonbeforecut(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectoncut = null;
        bool HTMLSelectElementEvents2.oncut(IHTMLEventObj pEvtObj)
        {
            if (selectoncut != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectoncut(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonbeforecopy = null;
        bool HTMLSelectElementEvents2.onbeforecopy(IHTMLEventObj pEvtObj)
        {
            if (selectonbeforecopy != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonbeforecopy(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectoncopy = null;
        bool HTMLSelectElementEvents2.oncopy(IHTMLEventObj pEvtObj)
        {
            if (selectoncopy != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectoncopy(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonbeforepaste = null;
        bool HTMLSelectElementEvents2.onbeforepaste(IHTMLEventObj pEvtObj)
        {
            if (selectonbeforepaste != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonbeforepaste(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonpaste = null;
        bool HTMLSelectElementEvents2.onpaste(IHTMLEventObj pEvtObj)
        {
            if (selectonpaste != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonpaste(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectoncontextmenu = null;
        bool HTMLSelectElementEvents2.oncontextmenu(IHTMLEventObj pEvtObj)
        {
            if (selectoncontextmenu != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectoncontextmenu(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonrowsdelete = null;
        void HTMLSelectElementEvents2.onrowsdelete(IHTMLEventObj pEvtObj)
        {
            if (selectonrowsdelete != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonrowsdelete(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonrowsinserted = null;
        void HTMLSelectElementEvents2.onrowsinserted(IHTMLEventObj pEvtObj)
        {
            if (selectonrowsinserted != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonrowsinserted(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectoncellchange = null;
        void HTMLSelectElementEvents2.oncellchange(IHTMLEventObj pEvtObj)
        {
            if (selectoncellchange != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectoncellchange(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonreadystatechange = null;
        void HTMLSelectElementEvents2.onreadystatechange(IHTMLEventObj pEvtObj)
        {
            if (selectonreadystatechange != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonreadystatechange(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonlayoutcomplete = null;
        void HTMLSelectElementEvents2.onlayoutcomplete(IHTMLEventObj pEvtObj)
        {
            if (selectonlayoutcomplete != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonlayoutcomplete(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonpage = null;
        void HTMLSelectElementEvents2.onpage(IHTMLEventObj pEvtObj)
        {
            if (selectonpage != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonpage(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmouseenter = null;
        void HTMLSelectElementEvents2.onmouseenter(IHTMLEventObj pEvtObj)
        {
            if (selectonmouseenter != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmouseenter(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmouseleave = null;
        void HTMLSelectElementEvents2.onmouseleave(IHTMLEventObj pEvtObj)
        {
            if (selectonmouseleave != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmouseleave(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonactivate = null;
        void HTMLSelectElementEvents2.onactivate(IHTMLEventObj pEvtObj)
        {
            if (selectonactivate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonactivate(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectondeactivate = null;
        void HTMLSelectElementEvents2.ondeactivate(IHTMLEventObj pEvtObj)
        {
            if (selectondeactivate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectondeactivate(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonbeforedeactivate = null;
        bool HTMLSelectElementEvents2.onbeforedeactivate(IHTMLEventObj pEvtObj)
        {
            if (selectonbeforedeactivate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonbeforedeactivate(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonbeforeactivate = null;
        bool HTMLSelectElementEvents2.onbeforeactivate(IHTMLEventObj pEvtObj)
        {
            if (selectonbeforeactivate != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonbeforeactivate(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonfocusin = null;
        void HTMLSelectElementEvents2.onfocusin(IHTMLEventObj pEvtObj)
        {
            if (selectonfocusin != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonfocusin(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonfocusout = null;
        void HTMLSelectElementEvents2.onfocusout(IHTMLEventObj pEvtObj)
        {
            if (selectonfocusout != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonfocusout(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmove = null;
        void HTMLSelectElementEvents2.onmove(IHTMLEventObj pEvtObj)
        {
            if (selectonmove != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmove(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectoncontrolselect = null;
        bool HTMLSelectElementEvents2.oncontrolselect(IHTMLEventObj pEvtObj)
        {
            if (selectoncontrolselect != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectoncontrolselect(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonmovestart = null;
        bool HTMLSelectElementEvents2.onmovestart(IHTMLEventObj pEvtObj)
        {
            if (selectonmovestart != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmovestart(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonmoveend = null;
        void HTMLSelectElementEvents2.onmoveend(IHTMLEventObj pEvtObj)
        {
            if (selectonmoveend != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmoveend(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonresizestart = null;
        bool HTMLSelectElementEvents2.onresizestart(IHTMLEventObj pEvtObj)
        {
            if (selectonresizestart != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonresizestart(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonresizeend = null;
        void HTMLSelectElementEvents2.onresizeend(IHTMLEventObj pEvtObj)
        {
            if (selectonresizeend != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonresizeend(this, args);
            }
        }
        public event HTMLSelectElementEventHandler selectonmousewheel = null;
        bool HTMLSelectElementEvents2.onmousewheel(IHTMLEventObj pEvtObj)
        {
            if (selectonmousewheel != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonmousewheel(this, args);
                return args.AllowDefault;
            }
            else
                return true; //Allow, default        
        }
        public event HTMLSelectElementEventHandler selectonchange = null;
        void HTMLSelectElementEvents2.onchange(IHTMLEventObj pEvtObj)
        {
            if (selectonchange != null)
            {
                HTMLSelectElementEventArgs args = new HTMLSelectElementEventArgs(pEvtObj);
                selectonchange(this, args);
            }
        }

        #endregion
    }
}
