//
// This class is based on Bill Long's HtmlEventHandler class
// contributed - Feb 2008
// william.long@ripnet.com
//

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    /*
     * Generic html event handler
     * Sample:
        void cEXWB1_DocumentComplete(object sender, csExWB.DocumentCompleteEventArgs e)
        {
            if (e.istoplevel)
            {
                IHTMLDocument2 pdoc = this.cEXWB1.WebbrowserObject.Document as IHTMLDocument2;
                IHTMLWindow2 win2 = pdoc.parentWindow as IHTMLWindow2;
                //This action replaces the onload handler
                win2.onload = new csExWB.GenericElementEventHandler(DocOnloadhandler, null, win2.onload, "onload");
            }
        }

        private void DocOnloadhandler(object sender, EventArgs e)
        {
            csExWB.GenericElementEventHandler handler = sender as csExWB.GenericElementEventHandler;
            MessageBox.Show("DocOnloadhandler => " + handler.EventType);
            //Invoke old handler if desired
            handler.InvokeOldHandler();
        }
    */

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class GenericElementEventHandler
    {
        private object m_elem; //Any HTML element
        private EventHandler m_handler; //Who to notify
        private string m_eventtype; //Event string representation onload,...
        private object m_oldhandler; //The original event handler replaced by this class instance

        public GenericElementEventHandler(EventHandler _eventhandler, object _elem, object _oldhandler, string _eventtype)
        {
            this.m_handler = _eventhandler;
            this.m_elem = _elem;
            this.m_eventtype = _eventtype;
            this.m_oldhandler = _oldhandler;
        }

        // New --- Custom
        ~GenericElementEventHandler()
        {
            m_handler = null;
            m_elem = null;
            m_eventtype = null;
            m_oldhandler = null;
        }

        /// <summary>
        /// The method that gets called when an event occurs.
        /// The key thing to note here is the "[DispId(0)]" attribute.
        /// Setting this attribute on a method makes it the default.
        /// </summary>
        [DispId(0)]
        public void HtmlElementEvent()
        {
            m_handler(this, EventArgs.Empty);
        }

        public void InvokeOldHandler()
        {
            if (m_oldhandler != null && m_oldhandler != System.DBNull.Value)
            {
                // Get a reference to the IDisplatch type
                Type lIDispatch = Type.GetTypeFromCLSID(new System.Guid("{00020400-0000-0000-C000-000000000046}"));
                // Invoke the default method "[DispID=0]"
                try
                {
                    lIDispatch.InvokeMember("[DispID=0]", System.Reflection.BindingFlags.InvokeMethod, null, m_oldhandler, null);
                }
                catch (System.MissingMemberException)
                {
                    throw;
                    //System.Diagnostics.Debug.Print("InvokeOldHandler=>" + e.ToString());
                }
            }
        }

        public object HTMLElement
        {
            get { return this.m_elem; }
            set { this.m_elem = value; }
        }

        public string EventType
        {
            get { return this.m_eventtype; }
        }
    }

}
