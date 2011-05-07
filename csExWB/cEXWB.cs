//************************************************************************************
// csEXWB control - The most complete C# Webbrowser control.
//
// Auther: MH
// Email: mehr13@hotmail.com
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so.
//
// Although reasonable care has been taken to ensure the correctness of this
// implementation, this code should never be used in
// any application without proper verification and testing.
//************************************************************************************


using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using IfacesEnumsStructsClasses;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.Reflection;

namespace csExWB
{
    public class cEXWB :
        Control,
        IOleClientSite,
        IOleInPlaceSite,
        IDocHostShowUI,
        IDocHostUIHandler,
        DWebBrowserEvents2,
        IfacesEnumsStructsClasses.IDropTarget,
        IfacesEnumsStructsClasses.IServiceProvider,
        IHttpSecurity,
        IWindowForBindingUI,
        INewWindowManager, //WinXP sp2 and up - Can be used to stop HTML dialogs (including help) + popups
        IAuthenticate,
        IOleCommandTarget,
        IInternetSecurityManager,
        //IHTMLEventCallBack, //Removed, please read the ChangeLog.txt for details
        IProtectFocus, //IE7 + Vista
        IHTMLOMWindowServices, //WinXP sp2 and up
        IHTMLEditHost, //Please refer to IHTMLEditHost.cs for description
        IManagedProtocolSink,
        ICustomProtocolSink,
        IHTMLChangeSink
    {

        #region Events and EventArgs Memebrs


        public event csExWB.DocumentCompleteEventHandler DocumentComplete = null;
        public event csExWB.BeforeNavigate2EventHandler BeforeNavigate2 = null;
        public event csExWB.ClientToHostWindowEventHandler ClientToHostWindow = null;
        public event csExWB.CommandStateChangeEventHandler CommandStateChange = null;
        public event csExWB.DownloadBeginEventHandler DownloadBegin = null;
        public event csExWB.DownloadCompleteEventHandler DownloadComplete = null;
        public event csExWB.FileDownloadEventHandler FileDownload = null;
        public event csExWB.NavigateComplete2EventHandler NavigateComplete2 = null;
        public event csExWB.NavigateErrorEventHandler NavigateError = null;
        public event csExWB.NewWindow2EventHandler NewWindow2 = null;
        public event csExWB.NewWindow3EventHandler NewWindow3 = null;
        public event csExWB.PrintTemplateInstantiationEventHandler PrintTemplateInstantiation = null;
        public event csExWB.PrintTemplateTeardownEventHandler PrintTemplateTeardown = null;
        public event csExWB.PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange = null;
        public event csExWB.ProgressChangeEventHandler ProgressChange = null;
        public event csExWB.PropertyChangeEventHandler PropertyChange = null;
        public event csExWB.SetSecureLockIconEventHandler SetSecureLockIcon = null;
        public event csExWB.StatusTextChangeEventHandler StatusTextChange = null;
        public event csExWB.TitleChangeEventHandler TitleChange = null;
        public event csExWB.WindowClosingEventHandler WindowClosing = null;
        public event csExWB.WindowSetHeightEventHandler WindowSetHeight = null;
        public event csExWB.WindowSetLeftEventHandler WindowSetLeft = null;
        public event csExWB.WindowSetResizableEventHandler WindowSetResizable = null;
        public event csExWB.WindowSetTopEventHandler WindowSetTop = null;
        public event csExWB.WindowSetWidthEventHandler WindowSetWidth = null;
        public event csExWB.WBDragEnterEventHandler WBDragEnter = null;
        public event csExWB.WBDragLeaveEventHandler WBDragLeave = null;
        public event csExWB.WBDragOverEventHandler WBDragOver = null;
        public event csExWB.WBDropEventHandler WBDragDrop = null;
        public event csExWB.WBKeyDownEventHandler WBKeyDown = null;
        public event csExWB.WBKeyUpEventHandler WBKeyUp = null;
        public event csExWB.ContextMenuEventHandler WBContextMenu = null;
        public event csExWB.GetOptionKeyPathEventHandler WBGetOptionKeyPath = null;
        public event csExWB.DocHostShowUIShowMessageEventHandler WBDocHostShowUIShowMessage = null;
        public event csExWB.DocumentCompleteExEventHandler DocumentCompleteEX = null;
        public event csExWB.AuthenticateEventHandler WBAuthenticate = null;
        public event csExWB.SecurityProblemEventHandler WBSecurityProblem = null;
        public event csExWB.EvaluateNewWindowEventHandler WBEvaluteNewWindow = null;
        public event csExWB.ScriptErrorEventHandler ScriptError = null;
        public event csExWB.UpdatePageStatusEventHandler UpdatePageStatus = null;
        public event csExWB.RefreshBeginEventHandler RefreshBegin = null;
        public event csExWB.RefreshEndEventHandler RefreshEnd = null;
        public event csExWB.ProcessUrlActionEventHandler ProcessUrlAction = null;
        public event csExWB.AllowFocusChangeEventHandler AllowFocusChange = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_moveTo = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_moveBy = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_resizeTo = null;
        public event csExWB.HTMLOMWindowServicesEventHandler HTMLOMWindowServices_resizeBy = null;
        public event csExWB.HTMLMouseEventHandler WBLButtonDown = null;
        public event csExWB.HTMLMouseEventHandler WBLButtonUp = null;
        public event csExWB.HTMLMouseEventHandler WBMouseMove = null;
        public event AuthenticationEventHandler AuthenticationEvent = null;

        private TitleChangeEventArgs TitleChangeEvent = new TitleChangeEventArgs();
        private DocumentCompleteEventArgs DocumentCompleteEvent = new DocumentCompleteEventArgs();
        private DocumentCompleteExEventArgs DocumentCompleteExEvent = new DocumentCompleteExEventArgs();
        private StatusTextChangeEventArgs StatusTextChangeEvent = new StatusTextChangeEventArgs();
        private ProgressChangeEventArgs ProgressChangeEvent = new ProgressChangeEventArgs();
        private CommandStateChangeEventArgs CommandStateChangeEvent = new CommandStateChangeEventArgs();
        private PropertyChangeEventArgs PropertyChangeEvent = new PropertyChangeEventArgs();
        private BeforeNavigate2EventArgs BeforeNavigate2Event = new BeforeNavigate2EventArgs();
        private NavigateComplete2EventArgs NavigateComplete2Event = new NavigateComplete2EventArgs();
        private NewWindow2EventArgs NewWindow2Event = new NewWindow2EventArgs();
        private NewWindow3EventArgs NewWindow3Event = new NewWindow3EventArgs();
        private WindowSetResizableEventArgs WindowSetResizableEvent = new WindowSetResizableEventArgs();
        private WindowSetLeftEventArgs WindowSetLeftEvent = new WindowSetLeftEventArgs();
        private WindowSetTopEventArgs WindowSetTopEvent = new WindowSetTopEventArgs();
        private WindowSetWidthEventArgs WindowSetWidthEvent = new WindowSetWidthEventArgs();
        private WindowSetHeightEventArgs WindowSetHeightEvent = new WindowSetHeightEventArgs();
        private WindowClosingEventArgs WindowClosingEvent = new WindowClosingEventArgs();
        private ClientToHostWindowEventArgs ClientToHostWindowEvent = new ClientToHostWindowEventArgs();
        private SetSecureLockIconEventArgs SetSecureLockIconEvent = new SetSecureLockIconEventArgs();
        private FileDownloadEventArgs FileDownloadEvent = new FileDownloadEventArgs();
        private NavigateErrorEventArgs NavigateErrorEvent = new NavigateErrorEventArgs();
        private PrintTemplateInstantiationEventArgs PrintTemplateInstantiationEvent = new PrintTemplateInstantiationEventArgs();
        private PrintTemplateTeardownEventArgs PrintTemplateTeardownEvent = new PrintTemplateTeardownEventArgs();
        private PrivacyImpactedStateChangeEventArgs PrivacyImpactedStateChangeEvent = new PrivacyImpactedStateChangeEventArgs();
        private UpdatePageStatusEventArgs UpdatePageStatusEvent = new UpdatePageStatusEventArgs();

        private DocHostShowUIShowMessageEventArgs DocHostShowUIShowMessageEvent = new DocHostShowUIShowMessageEventArgs();
        private ContextMenuEventArgs ContextMenuEvent = new ContextMenuEventArgs();
        private GetOptionKeyPathEventArgs GetOptionKeyPathEvent = new GetOptionKeyPathEventArgs();
        private WBKeyDownEventArgs WBKeyDownEvent = new WBKeyDownEventArgs();
        private WBKeyUpEventArgs WBKeyUpEvent = new WBKeyUpEventArgs();
        private EvaluateNewWindowEventArgs EvaluateNewWindowEvent = new EvaluateNewWindowEventArgs();
        private SecurityProblemEventArgs SecurityProblemEvent = new SecurityProblemEventArgs();
        private WBDragEnterEventArgs WBDragEnterEvent = new WBDragEnterEventArgs();
        private WBDragOverEventArgs WBDragOverEvent = new WBDragOverEventArgs();
        private WBDropEventArgs WBDropEvent = new WBDropEventArgs();
        private ScriptErrorEventArgs ScriptErrorEvent = new ScriptErrorEventArgs();
        private ProcessUrlActionEventArgs ProcessUrlActionEvent = new ProcessUrlActionEventArgs();
        private AllowFocusChangeEventArgs AllowFocusChangeEvent = new AllowFocusChangeEventArgs();
        private HTMLOMWindowServicesEventArgs HTMLOMWindowServicesEvent = new HTMLOMWindowServicesEventArgs();

        #endregion //Events and EventArgs Memebrs

        #region Local members

        //Required by designer
        private System.ComponentModel.IContainer components = null;

        //Use the internal dragdrop in combination with WBDrag/Drop events
        private bool m_bUseInternalDragDrop = true;
        //Fires DocumentCompleteEx, with an additional parameter "docsource"
        //containning the source of the incoming document before any scripts
        //are executed.
        private bool m_bSendSourceOnDocumentCompleteWBEx = false;
        //this.Control->ShellEmbedding->ShellDocObj->IEServer
        private IntPtr m_hWBServerHandle = (IntPtr)0;
        private IntPtr m_hWBShellDocObjHandle = (IntPtr)0;
        private IntPtr m_hWBShellEmbeddingHandle = (IntPtr)0;
        //Startup URL + LocationUrl
        private const string m_AboutBlank = "about:blank";
        private string m_sUrl = "about:blank";
        private bool m_bCanGoBack = false;
        private bool m_bCanGoForward = false;
        private TextSizeWB m_enumTextSize = TextSizeWB.Medium; //default
        //Default, selecttext+no3dborder+flatscrollbars+themes(xp look)
        private DOCHOSTUIFLAG m_DocHostUiFlags = DOCHOSTUIFLAG.NO3DBORDER |
            DOCHOSTUIFLAG.FLAT_SCROLLBAR | DOCHOSTUIFLAG.THEME;
        private DOCHOSTUIDBLCLK m_DocHostUiDbClkFlag = DOCHOSTUIDBLCLK.DEFAULT;
        //DLCTL_DLIMAGES
        private DOCDOWNLOADCTLFLAG m_DLCtlFlags = DOCDOWNLOADCTLFLAG.DLIMAGES |
            DOCDOWNLOADCTLFLAG.BGSOUNDS | DOCDOWNLOADCTLFLAG.VIDEOS;

        //Used in find
        private IHTMLTxtRange m_txtrange = null;
        private string m_sLastSearch = string.Empty;
        //Pointer to our browser interface
        private IWebBrowser2 m_WBWebBrowser2 = null;
        //IntPtr.Zero
        private IntPtr m_NullPointer = IntPtr.Zero;
        private tagMSG m_NullMsg = new tagMSG();
        private object m_NullObject = null;
        //ConnectionPoint Cookie
        private int m_dwCookie = 0;
        //Keep track of our location + size
        private tagRECT m_WBRect = new tagRECT(0, 0, 0, 0);
        //WB IUnknown and other ifaces
        private object m_WBUnknown = null;
        private IOleObject m_WBOleObject = null;
        private IOleInPlaceObject m_WBOleInPlaceObject = null;
        private IOleCommandTarget m_WBOleCommandTarget = null;
        ///Taken from article:
        ///Invoke Hidden Commands in Your Web Browser
        ///http://www.codeguru.com/cpp/i-n/ieprogram/openfaq/article.php/c8163/
        ///As I stated above, the IDocHostUIHandler::ShowContextMenu demo of
        ///"WebBrowser Customization" in the MSDN shows a way to manually build
        ///IE's context menu from correlative resource file "SHDOCLC.DLL".
        ///So, open the file "SHDOCLC.DLL" by using some resource explorer software
        ///such as "eXeScope", we can find all the Command IDs (also menu item IDs)
        ///used by the WebBrowser Control under menu resources, and all of them are
        ///the same in IE 4.x/5.x/6.x according to my tesing.

        //command send to IE server hwnd
        private const int ID_IE_CONTEXTMENU_ADDFAV = 2261;
        //comands send to shelldocobject hwnd
        private const int ID_IE_FIND = 67;
        private const int ID_IE_PAGESETUP = 259;
        private const int ID_IE_PRINT = 260;
        private const int ID_IE_PRINTPREVIEW = 277;
        private const int ID_IE_FILE_NEWMAIL = 279;
        private const int ID_IE_FILE_SENDPAGE = 282;
        private const int ID_IE_FILE_SENDLINK = 283;
        private const int ID_IE_FILE_SENDDESKTOPSHORTCUT = 284;
        private const int ID_IE_FILE_IMPORTEXPORT = 374;
        private const int ID_IE_FILE_ADDTRUST = 376;
        private const int ID_IE_FILE_ADDLOCAL = 377;
        private const int ID_IE_FILE_NEWCALL = 395; //Internet call
        //To catch Refresh event!
        // counter to monitor number of requests to BeforeNavigate2 vs number of requests to DownloadBegin.
        private int m_nPageCounter = 0;
        // counter to monitor number of DownloadBegin and DownloadEnd calls.
        private int m_nObjCounter = 0;
        // variable to tell us whether a refresh request has started.	
        private bool m_bIsRefresh = false;
        //browser thumb image cache
        private Image m_WBThumbImg = null;

        private int m_SecureLockIcon = (int)SecureLockIconConstants.secureLockIconUnsecure;
        private object m_WinExternal = null;

        //allow or disallow HTML dialogs launched using showModelessDialog() + showModalDialog() methods!
        //Using CBT window hook
        private WindowsHookUtil.HookInfo m_CBT = new WindowsHookUtil.HookInfo(ComUtilitiesLib.WINDOWSHOOK_TYPES.WHT_CBT);
        //private WindowsHookUtil.HookInfo m_CBT = new WindowsHookUtil.HookInfo(CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT);
        private const string m_HTMLDlgClassName = "Internet Explorer_TridentDlgFrame";
        private IntPtr m_HookHandled = IntPtr.Zero;
        private string m_strTemp = string.Empty;
        private int m_NCode = 0;

        //To subclass Internet Explorer_Server handle in order to catch back and forward buttons
        private IEServerWindow m_ieServerWindow = null;
        private bool m_DocDone = false;

        #endregion //Local members

        #region Properties list

        [Category("ExWB"), Description("Indicates if the top level document has fully loaded. Note that this does not include any dynamic content such as javascripts that may run after main document loads.")]
        public bool MainDocumentFullyLoaded
        {
            get { return m_DocDone; }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public int WBDOCDOWNLOADCTLFLAG
        {
            get { return (int)m_DLCtlFlags; }
            set
            {
                m_DLCtlFlags = (DOCDOWNLOADCTLFLAG)value;
                if ((m_WBUnknown != null) && (m_WBWebBrowser2 != null))
                {
                    //Signal change of DL property
                    //so MSHTML call our Invoke method through Dispatch
                    //Otherwise refreshing the page will have no effect
                    //MSHTML does not know of new flags set by us
                    //QI for IOleControl
                    IOleControl pOC = m_WBUnknown as IOleControl;
                    if (pOC != null)
                        pOC.OnAmbientPropertyChange(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL);
                }
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadImages
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.DLIMAGES) != 0); }
            set { SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.DLIMAGES, value); }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadSounds
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.BGSOUNDS) != 0); }
            set { SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.BGSOUNDS, value); }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadVideo
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.VIDEOS) != 0); }
            set { SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.VIDEOS, value); }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadActiveX
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS, true);
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadJava
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_JAVA) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_JAVA, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_JAVA, true);
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadFrames
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD, true);
            }
        }

        [Category("DOCDOWNLOADCTLFLAG")]
        public bool DownloadScripts
        {
            get { return ((m_DLCtlFlags & DOCDOWNLOADCTLFLAG.NO_SCRIPTS) == 0); }
            set
            {
                if (value)
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_SCRIPTS, false);
                else
                    SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG.NO_SCRIPTS, true);
            }
        }

        [Category("DOCHOSTUIFLAG")]
        public int WBDOCHOSTUIFLAG
        {
            get { return (int)m_DocHostUiFlags; }
            set { m_DocHostUiFlags = (DOCHOSTUIFLAG)value; }
        }

        [Category("DOCHOSTUIFLAG")]
        public bool Border3DEnabled
        {
            get { return ((m_DocHostUiFlags & DOCHOSTUIFLAG.NO3DBORDER) == 0); }
            set
            {
                if (value)
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.NO3DBORDER, false);
                else
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.NO3DBORDER, true);
            }
        }

        [Category("DOCHOSTUIFLAG")]
        public bool ScrollBarsEnabled
        {
            get { return ((m_DocHostUiFlags & DOCHOSTUIFLAG.SCROLL_NO) == 0); }
            set
            {
                if (value)
                {
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.SCROLL_NO, false);
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.FLAT_SCROLLBAR, value);
                }
                else
                {
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.FLAT_SCROLLBAR, false);
                    SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG.SCROLL_NO, true);
                }
            }
        }

        [Category("DOCHOSTUIDBLCLK")]
        public DOCHOSTUIDBLCLK WBDOCHOSTUIDBLCLK
        {
            get { return m_DocHostUiDbClkFlag; }
            set { m_DocHostUiDbClkFlag = value; }
        }

        [Category("ExWB")]
        public SecureLockIconConstants SecureLockIcon
        {
            get
            {
                return (SecureLockIconConstants)m_SecureLockIcon;
            }
        }

        [Category("ExWB")]
        public TextSizeWB TextSize
        {
            get
            {
                if (m_WBOleCommandTarget != null)
                {
                    object retVal = new object(); //VT_NULL
                    IntPtr pRet = m_NullPointer;
                    int iZoom = (int)5;
                    try
                    {
                        pRet = Marshal.AllocCoTaskMem((int)1024);
                        Marshal.GetNativeVariantForObject(retVal, pRet);

                        //NULL to specify the standard group
                        int hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                            (uint)OLECMDID.OLECMDID_ZOOM,
                            (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                            m_NullPointer, pRet);

                        retVal = Marshal.GetObjectForNativeVariant(pRet);
                        Marshal.FreeCoTaskMem(pRet);
                        pRet = m_NullPointer;
                        if (Type.GetTypeCode(retVal.GetType()) == TypeCode.Int32)
                            iZoom = int.Parse(retVal.ToString());
                        //else
                        //    Debug.Write("Incorrect TypeCode!", "Get_TextSizeWB");
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        if (pRet != m_NullPointer)
                            Marshal.FreeCoTaskMem(pRet);
                    }
                    if ((iZoom > -1) && (iZoom < 5))
                        m_enumTextSize = (TextSizeWB)iZoom;
                }
                return m_enumTextSize;
            }

            set
            {
                if (m_WBOleCommandTarget != null)
                {
                    if (((int)value > (int)-1) && ((int)value < (int)5))
                    {
                        IntPtr pRet = m_NullPointer;
                        try
                        {
                            pRet = Marshal.AllocCoTaskMem((int)1024);
                            Marshal.GetNativeVariantForObject((int)value, pRet);

                            int hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                                (uint)OLECMDID.OLECMDID_ZOOM,
                                (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                                pRet, m_NullPointer);
                            Marshal.FreeCoTaskMem(pRet);
                            pRet = m_NullPointer;
                            if (hr == Hresults.S_OK)
                                m_enumTextSize = (TextSizeWB)value;
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            if (pRet != m_NullPointer)
                                Marshal.FreeCoTaskMem(pRet);
                        }
                    }
                }
            }
        }

        [Category("ExWB")]
        public bool CanGoBack
        {
            get { return m_bCanGoBack; }
        }

        [Category("ExWB")]
        public bool CanGoForward
        {
            get { return m_bCanGoForward; }
        }

        [Category("ExWB")]
        public IWebBrowser2 WebbrowserObject
        {
            get { return m_WBWebBrowser2; }
        }

        [Category("ExWB"), Description("true, fires DocumentCompleteEX instead of DocumentComplete passing source of the pDisp Document.")]
        public bool SendSourceOnDocumentCompleteWBEx
        {
            get { return m_bSendSourceOnDocumentCompleteWBEx; }
            set { m_bSendSourceOnDocumentCompleteWBEx = value; }
        }

        [Category("ExWB"), Description("Internet Explorer_Server HWND")]
        public IntPtr IEServerHwnd
        {
            get { return WBIEServerHandle(); }
        }

        [Category("ExWB"), Description("ShellEmbedding HWND")]
        public IntPtr ShellEmbedingHwnd
        {
            get { return WBShellEmbedingHandle(); }
        }

        [Category("ExWB"), Description("ShellDocObject HWND")]
        public IntPtr ShellDocObjectHwnd
        {
            get { return WBShellDocObjHandle(); }
        }

        [Category("ExWB"),
        Description("Allows default drag drop operations. Default false. To use internal drag drop, set RegisterForInternalDragDrop to true. Setting this property to true will deactivate internal drag drop.")]
        public bool RegisterAsDropTarget
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.RegisterAsDropTarget;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.RegisterAsDropTarget = value;
                if (value)
                    this.RegisterForInternalDragDrop = false;
            }
        }

        [Category("ExWB"),
        Description("Uses internal drag drop events to notify the client. Default true.")]
        public bool RegisterForInternalDragDrop
        {
            get
            {
                return m_bUseInternalDragDrop;
            }
            set
            {
                m_bUseInternalDragDrop = value;
                //Make sure we set RegisterAsDropTarget to false
                if ((m_bUseInternalDragDrop) && (m_WBWebBrowser2 != null))
                    this.RegisterAsDropTarget = false;
            }
        }

        [Category("ExWB")]
        public bool RegisterAsBrowser
        {
            //MessageBox(IntPtr.Zero, "", "", 0);
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.RegisterAsBrowser;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.RegisterAsBrowser = value;
            }
        }

        [Category("ExWB")]
        public bool Silent
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.Silent;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.Silent = value;
            }
        }

        [Category("ExWB")]
        public string LocationName
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.LocationName;
                else
                    return string.Empty;
            }
        }

        [Category("ExWB"), Description("Set or get current LocationURL. Works in design mode as well.")]
        public string LocationUrl
        {
            get
            {
                if ((!DesignMode) && (m_WBWebBrowser2 != null))
                    m_sUrl = m_WBWebBrowser2.LocationURL;

                if (m_sUrl.Length == 0)
                    m_sUrl = m_AboutBlank;
                return m_sUrl;
            }
            set
            {
                m_sUrl = value;
                if ((m_WBWebBrowser2 != null) && (m_sUrl.Length > 0))
                {
                    if ((m_sUrl == m_AboutBlank) && (!this.DesignMode))
                        return;
                    this.Navigate(m_sUrl);
                }
            }
        }

        [Category("ExWB")]
        public bool Busy
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.Busy;
                else
                    return false;
            }
        }

        [Category("ExWB")]
        public bool OffLine
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.Offline;
                else
                    return false;
            }
            set
            {
                if (m_WBWebBrowser2 != null)
                    m_WBWebBrowser2.Offline = value;
            }
        }

        [Category("ExWB")]
        public tagREADYSTATE ReadyState
        {
            get
            {
                if (m_WBWebBrowser2 != null)
                    return m_WBWebBrowser2.ReadyState;
                else
                    return tagREADYSTATE.READYSTATE_UNINITIALIZED;
            }
        }

        [Category("ExWB")]
        public Image ThumbImage
        {
            get
            {
                if (m_WBThumbImg != null)
                    return m_WBThumbImg;
                else
                    return new Bitmap(16, 16);
            }
        }

        [Category("ExWB"), Description("Offers same functionality as ObjectForScripting of C# webbrowser wrapper control.")]
        public object ObjectForScripting
        {
            get
            {
                return m_WinExternal;
            }
            set
            {
                m_WinExternal = value;
            }
        }

        [Category("ExWB"), Description("Sets or retrieves the title of the document")]
        public string DocumentTitle
        {
            get { return this.GetTitle(true); }
            set
            {
                if ((this.m_WBWebBrowser2 != null) &&
                    (m_WBWebBrowser2.Document != null))
                {
                    IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                    if (doc2 != null)
                        doc2.title = value;
                }
            }
        }

        [Category("ExWB"), Description("Sets or retrives the HTML source of the document")]
        public string DocumentSource
        {
            get { return this.GetSource(true); }
            set { this.LoadHtmlIntoBrowser(value); }
        }

        #endregion

        #region Overriden members

        public cEXWB()
        {
            //Force creation of control
            this.CreateControl();
        }

        internal bool m_InternalHasFocus = false;
        protected override void OnGotFocus(EventArgs e)
        {
            if (!m_InternalHasFocus)
                base.OnGotFocus(e);
            if ((!this.DesignMode) && (!m_InternalHasFocus))
            {
                m_InternalHasFocus = true;
                SetFocus();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if ((disposing) && (!this.DesignMode))
            {
                if (m_HookHandled != IntPtr.Zero)
                    Marshal.FreeHGlobal(m_HookHandled);
                if (m_WBThumbImg != null)
                    m_WBThumbImg.Dispose();
                InternalFreeWB();
                if ((components != null))
                    components.Dispose();

                // New Stuff
                m_WBWebBrowser2 = null;
                m_WBUnknown = null;
                m_WBOleObject = null;
                m_WBOleInPlaceObject = null;
                m_WBOleCommandTarget = null;

                RemoveDocumentChangeNotification();
                RemoveIUtilManEvents();
                RemCOMLibrary();

                // ParentWindow.onload should be nulled
                // the frames also
                //(IHTMLWindow2)doc2.parentWindow

                DocumentComplete = null;
                BeforeNavigate2 = null;
                ClientToHostWindow = null;
                CommandStateChange = null;
                DownloadBegin = null;
                DownloadComplete = null;
                FileDownload = null;
                NavigateComplete2 = null;
                NavigateError = null;
                NewWindow2 = null;
                NewWindow3 = null;
                PrintTemplateInstantiation = null;
                PrintTemplateTeardown = null;
                PrivacyImpactedStateChange = null;
                ProgressChange = null;
                PropertyChange = null;
                SetSecureLockIcon = null;
                StatusTextChange = null;
                TitleChange = null;
                WindowClosing = null;
                WindowSetHeight = null;
                WindowSetLeft = null;
                WindowSetResizable = null;
                WindowSetTop = null;
                WindowSetWidth = null;
                WBDragEnter = null;
                WBDragLeave = null;
                WBDragOver = null;
                WBDragDrop = null;
                WBKeyDown = null;
                WBKeyUp = null;
                WBContextMenu = null;
                WBGetOptionKeyPath = null;
                WBDocHostShowUIShowMessage = null;
                DocumentCompleteEX = null;
                WBAuthenticate = null;
                WBSecurityProblem = null;
                WBEvaluteNewWindow = null;
                ScriptError = null;
                UpdatePageStatus = null;
                RefreshBegin = null;
                RefreshEnd = null;
                ProcessUrlAction = null;
                AllowFocusChange = null;
                HTMLOMWindowServices_moveTo = null;
                HTMLOMWindowServices_moveBy = null;
                HTMLOMWindowServices_resizeTo = null;
                HTMLOMWindowServices_resizeBy = null;
                WBLButtonDown = null;
                WBLButtonUp = null;
                WBMouseMove = null;
                AuthenticationEvent = null;
            }
            base.Dispose(disposing);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.SetLocation();
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            bool handled = false;
            if ((msg.Msg >= WindowsMessages.WM_KEYFIRST) &&
                (msg.Msg <= WindowsMessages.WM_KEYLAST_NT501))
            {
                //// If it's a key down, first see if the key combo is a command key
                //if (msg.Msg == WindowsMessages.WM_KEYDOWN)
                //{
                //    handled = ProcessCmdKey(ref msg, (Keys)(int)msg.WParam | ModifierKeys);
                //}

                //if (!handled)
                //{
                //int keyCode = (int)msg.WParam;
                //// Don't let Trident eat Ctrl-PgUp/PgDn
                //if (((keyCode != (int)Keys.PageUp) && 
                //    (keyCode != (int)Keys.PageDown)) || 
                //    ((ModifierKeys & Keys.Control) == 0))
                //{
                tagMSG cm = new tagMSG();

                cm.hwnd = msg.HWnd;
                cm.message = msg.Msg;
                cm.wParam = msg.WParam;
                cm.lParam = msg.LParam;

                IOleInPlaceActiveObject accele = m_WBUnknown as IOleInPlaceActiveObject;
                if ((accele != null) &&
                    (accele.TranslateAccelerator(ref cm) == Hresults.S_OK))
                    handled = true;
                //}
                //else
                //{
                //    // WndProc for Ctrl-PgUp/PgDn is never called so call it directly here
                //    WndProc(ref msg);
                //    handled = true;
                //}
                //}
            }
            if (!handled)
            {
                handled = base.PreProcessMessage(ref msg);
            }
            return handled;
        }

        //private int m_wparam = 0;
        //private KBDLLHOOKSTRUCT m_KBLL = new KBDLLHOOKSTRUCT();
        //How to handle LLKeyboardHook
        /*
            if (m.Msg == m_KEYBOARD_LL.UniqueMsgID)
            {
                //To stop, set to handled
                //m.Result = m_HookHandled;
                m_wparam = (int)m.WParam;

                //Get the structure
                m_KBLL.Reset();
                Marshal.PtrToStructure(m.LParam, m_KBLL);

                //bCtlPressed = (Control.ModifierKeys & Keys.Control) != 0);
                if (m_wparam == WindowsMessages.WM_KEYDOWN)
                    AppendText("KEYBOARD_LL_KEYDOWN=" + m_KBLL.vkCode.ToString() + "\r\n");
                else if (m_wparam == WindowsMessages.WM_KEYUP)
                    AppendText("KEYBOARD_LL_KEYUP=" + m_KBLL.vkCode.ToString() + "\r\n");
                else if (m_wparam == WindowsMessages.WM_SYSKEYDOWN)
                    AppendText("KEYBOARD_LL_SYSKEYDOWN=" + m_KBLL.vkCode.ToString() + "\r\n");
                else if (m_wparam == WindowsMessages.WM_SYSKEYUP)
                    AppendText("KEYBOARD_LL_SYSKEYUP=" + m_KBLL.vkCode.ToString() + "\r\n");
            }
        */

        //private WindowsHookUtil.CBT_CREATEWND m_CBT_CREATEWND = new CBT_CREATEWND();
        //private WindowsHookUtil.CREATESTRUCT m_CREATESTRUCT = new CREATESTRUCT();
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == m_CBT.UniqueMsgID)
            {
                m_csexwbCOMLib.HookProcNCode(ComUtilitiesLib.WINDOWSHOOK_TYPES.WHT_CBT, ref m_NCode);
                //m_csexwbCOMLib.HookProcNCode(CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT, ref m_NCode);
                if (m_NCode == WindowsHookUtil.HCBT_CREATEWND)
                {
                    //m.WParam contains handle to the new window

                    //One method of getting new window information
                    //Marshal.PtrToStructure(m.LParam, m_CBT_CREATEWND);
                    //Marshal.PtrToStructure(m_CBT_CREATEWND.lpcs, m_CREATESTRUCT);
                    //if (m_CREATESTRUCT.lpszClass != IntPtr.Zero)
                    //{
                    m_strTemp = WinApis.GetWindowClass(m.WParam); //Marshal.PtrToStringAnsi(m_CREATESTRUCT.lpszClass);
                    if (!string.IsNullOrEmpty(m_strTemp))
                    {
                        if (m_strTemp.Equals(m_HTMLDlgClassName, StringComparison.CurrentCultureIgnoreCase))
                            m.Result = m_HookHandled; //dismiss it
                        if (m_strTemp.Equals("#32770"))
                            m.Result = m_HookHandled;
                    }
                    //}
                }
            }
            else
                base.WndProc(ref m);
        }

        //public override string ToString()
        //{
        //    //return base.ToString();
        //}

        //protected override void OnVisibleChanged(EventArgs e)
        //{
        //    base.OnVisibleChanged(e);
        //    if(m_WBOleObject == null)
        //        return;
        //    if(this.Visible)
        //        m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_SHOW, ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);
        //    else
        //        m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_HIDE, ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);
        //}

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.IsHandleCreated)
            {
                if (!this.DesignMode)
                {
                    //CBT hook return value to stop an HTMLDialog
                    m_HookHandled = Marshal.AllocHGlobal(Marshal.SizeOf((Int32)1) + 1);
                    Marshal.WriteInt32(m_HookHandled, 1);
                    InitCOMLibrary();
                }
                InternalCreateWB();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            if ((m_WBWebBrowser2 != null) && (!this.DesignMode))
                m_WBWebBrowser2.Refresh();
        }

        #endregion

        #region Private Method Members

        //Called from resize event to adjust the size of browser
        private void SetLocation()
        {
            if (m_WBOleInPlaceObject == null)
                return;
            bool brect = WinApis.GetClientRect(this.Handle, out m_WBRect);
            //Setup H+W
            m_WBRect.Right = m_WBRect.Right - m_WBRect.Left; //W
            m_WBRect.Bottom = m_WBRect.Bottom - m_WBRect.Top; //H
            m_WBRect.Left = 0;
            m_WBRect.Top = 0;

            m_WBOleInPlaceObject.SetObjectRects(ref m_WBRect, ref m_WBRect);
        }

        //Returns corresponding string for an HRESULT
        private string HresultAsString(int iHRESULT)
        {
            string sRet = "S_OK";
            if (iHRESULT == Hresults.S_OK)
            {
                return sRet;
            }
            else if (iHRESULT == Hresults.S_FALSE)
            {
                sRet = "S_FALSE";
            }
            else if (iHRESULT == Hresults.E_INVALIDARG)
            {
                sRet = "E_INVALIDARG";
            }
            else if (iHRESULT == Hresults.E_NOTIMPL)
            {
                sRet = "E_NOTIMPL";
            }
            else if (iHRESULT == Hresults.E_ABORT)
            {
                sRet = "E_ABORT";
            }
            else if (iHRESULT == Hresults.E_ACCESSDENIED)
            {
                sRet = "E_ACCESSDENIED";
            }
            else if (iHRESULT == Hresults.E_FAIL)
            {
                sRet = "E_FAIL";
            }
            else if (iHRESULT == Hresults.E_FLAGS)
            {
                sRet = "E_FLAGS";
            }
            else if (iHRESULT == Hresults.E_HANDLE)
            {
                sRet = "E_HANDLE";
            }
            else if (iHRESULT == Hresults.E_NOINTERFACE)
            {
                sRet = "E_NOINTERFACE";
            }
            else if (iHRESULT == Hresults.E_OUTOFMEMORY)
            {
                sRet = "E_OUTOFMEMORY";
            }
            else if (iHRESULT == Hresults.E_PENDING)
            {
                sRet = "E_PENDING";
            }
            else if (iHRESULT == Hresults.E_POINTER)
            {
                sRet = "E_POINTER";
            }
            else if (iHRESULT == Hresults.E_UNEXPECTED)
            {
                sRet = "E_UNEXPECTED";
            }
            else if (iHRESULT == Hresults.DV_E_LINDEX)
            {
                sRet = "DV_E_LINDEX";
            }
            else if (iHRESULT == Hresults.OLEOBJ_S_CANNOT_DOVERB_NOW)
            {
                sRet = "OLEOBJ_S_CANNOT_DOVERB_NOW";
            }
            else if (iHRESULT == Hresults.OLEOBJ_S_INVALIDHWND)
            {
                sRet = "OLEOBJ_S_INVALIDHWND";
            }
            else if (iHRESULT == Hresults.OLEOBJ_S_INVALIDVERB)
            {
                sRet = "OLEOBJ_S_INVALIDVERB";
            }
            else if (iHRESULT == Hresults.OLEOBJ_E_NOVERBS)
            {
                sRet = "OLEOBJ_E_NOVERBS";
            }
            else if (iHRESULT == Hresults.OLE_E_NOT_INPLACEACTIVE)
            {
                sRet = "OLE_E_NOT_INPLACEACTIVE";
            }
            else if (iHRESULT == Hresults.OLE_E_CANT_BINDTOSOURCE)
            {
                sRet = "OLE_E_CANT_BINDTOSOURCE";
            }
            else if (iHRESULT == Hresults.OLE_E_CLASSDIFF)
            {
                sRet = "OLE_E_CLASSDIFF";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_UNKNOWNGROUP)
            {
                sRet = "OLECMDERR_E_UNKNOWNGROUP";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_NOTSUPPORTED)
            {
                sRet = "OLECMDERR_E_NOTSUPPORTED";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_DISABLED)
            {
                sRet = "OLECMDERR_E_DISABLED";
            }
            else if (iHRESULT == Hresults.OLECMDERR_E_CANCELED)
            {
                sRet = "OLECMDERR_E_CANCELED";
            }
            else
            {
                sRet = "UNKNOWN-VALUE: " + iHRESULT.ToString();
            }
            return sRet;
        }

        //To retreive ShellEmbeding + ShellDocObj + IEServer HWNDs
        private IntPtr WBShellEmbedingHandle()
        {
            if (m_WBUnknown == null)
                return m_NullPointer;

            if ((!m_hWBShellEmbeddingHandle.Equals(m_NullPointer)) &&
                (WinApis.IsWindow(m_hWBShellEmbeddingHandle)))
                return m_hWBShellEmbeddingHandle;

            m_hWBShellEmbeddingHandle = m_NullPointer;

            IOleWindow pWin = m_WBUnknown as IOleWindow;
            if (pWin != null)
                pWin.GetWindow(ref m_hWBShellEmbeddingHandle);

            return m_hWBShellEmbeddingHandle;
        }
        private IntPtr WBShellDocObjHandle()
        {
            if ((!m_hWBShellDocObjHandle.Equals(m_NullPointer)) &&
                (WinApis.IsWindow(m_hWBShellDocObjHandle)))
                return m_hWBShellDocObjHandle;
            m_hWBShellDocObjHandle = m_NullPointer;
            if (!WBShellEmbedingHandle().Equals(m_NullPointer))
            {
                m_hWBShellDocObjHandle = WinApis.GetWindow(m_hWBShellEmbeddingHandle, (uint)GetWindow_Cmd.GW_CHILD);
            }
            return m_hWBShellDocObjHandle;
        }
        private IntPtr WBIEServerHandle()
        {
            if ((!m_hWBServerHandle.Equals(m_NullPointer)) &&
                (WinApis.IsWindow(m_hWBServerHandle)))
            {
                if (!m_AppStarted)
                    StartApp();
                return m_hWBServerHandle;
            }
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                m_hWBServerHandle = WinApis.GetWindow(m_hWBShellDocObjHandle, (uint)GetWindow_Cmd.GW_CHILD);
            }
            if ((!m_hWBServerHandle.Equals(m_NullPointer)) && (!m_AppStarted))
                StartApp();
            return m_hWBServerHandle;
        }

        //Registers clipboard formats that we can handle
        //Registered Dragdrop formats
        //private short m_CFHTML = 0;
        //private short m_CFRTF = 0;
        //private short m_CFURL = 0;
        //private short m_CFNETRESOURCE = 0;
        //private short m_CFUNTRUSTEDDRAGDROP = 0;
        //private short m_CFFILEGROUPDESCRIPTOR = 0;
        //private short m_CFFILECONTENTS = 0;
        //private void RegisterClipboardFormatsForDragDrop()
        //{
        //    m_CFHTML = (short)WinApis.RegisterClipboardFormat("HTML Format");
        //    m_CFRTF = (short)WinApis.RegisterClipboardFormat("Rich Text Format");
        //    m_CFFILEGROUPDESCRIPTOR = (short)WinApis.RegisterClipboardFormat("FileGroupDescriptor");
        //    m_CFFILECONTENTS = (short)WinApis.RegisterClipboardFormat("FileContents");
        //    m_CFUNTRUSTEDDRAGDROP = (short)WinApis.RegisterClipboardFormat("UntrustedDragDrop");
        //    m_CFURL = (short)WinApis.RegisterClipboardFormat("UniformResourceLocator");
        //    m_CFNETRESOURCE = (short)WinApis.RegisterClipboardFormat("Net Resource");
        //}

        private void InternalFreeWB()
        {
            if ((!DesignMode) && (m_WBUnknown != null))
            {
                //Get connectionpointcontainer
                IConnectionPointContainer cpCont = m_WBUnknown as IConnectionPointContainer;

                //Find connection point
                if (cpCont != null)
                {
                    Guid guid = typeof(DWebBrowserEvents2).GUID;
                    IConnectionPoint m_WBConnectionPoint = null;
                    cpCont.FindConnectionPoint(ref guid, out m_WBConnectionPoint);
                    //UnAdvice
                    if ((m_WBConnectionPoint != null) && (m_dwCookie > 0))
                        m_WBConnectionPoint.Unadvise(m_dwCookie);
                }

                //UI and Inplace deactivate
                if (m_WBOleInPlaceObject != null)
                {
                    m_WBOleInPlaceObject.UIDeactivate();
                    m_WBOleInPlaceObject.InPlaceDeactivate();
                }

                //Disconnect from ole
                if (m_WBOleObject != null)
                {
                    m_WBOleObject.Close((uint)OLEDOVERB.OLECLOSE_NOSAVE);
                    m_WBOleObject.SetClientSite(null);
                }
            }
            if (m_TravelLogStg != null)
            {
                Marshal.ReleaseComObject(m_TravelLogStg);
                m_TravelLogStg = null;
            }
            if (m_txtrange != null)
            {
                Marshal.ReleaseComObject(m_txtrange);
                m_txtrange = null;
            }
            if (m_WBOleCommandTarget != null)
            {
                Marshal.ReleaseComObject(m_WBOleCommandTarget);
                m_WBOleCommandTarget = null;
            }
            if (m_WBWebBrowser2 != null)
            {
                Marshal.ReleaseComObject(m_WBWebBrowser2);
                m_WBWebBrowser2 = null;
            }
            if (m_WBOleInPlaceObject != null)
            {
                Marshal.ReleaseComObject(m_WBOleInPlaceObject);
                m_WBOleCommandTarget = null;
            }
            if (m_WBOleObject != null)
            {
                Marshal.ReleaseComObject(m_WBOleObject);
                m_WBOleObject = null;
            }
            if (m_WBUnknown != null)
            {
                Marshal.ReleaseComObject(m_WBUnknown);
                m_WBUnknown = null;
            }

            //if (m_WantHtmlDocumentEvents)
            //{
            //    m_TopLevelHtmlDocumentevents.DisconnectHtmlEvents();
            //    DisconnectHtmlDocumentEvents();
            //}
            //if (m_WantHtmlWindowEvents)
            //{
            //    m_TopLevelHtmlWindowEvents.DisconnectHtmlEvents();
            //    DisconnectHtmlWindowEvnets();
            //}
        }

        /// <summary>
        /// Create Webbrowser control and set up it's events
        /// called from OnHandleCreated
        /// Webbrowser control hosting requires an HWND
        /// </summary>
        /// <returns></returns>
        private void InternalCreateWB()
        {
            //Create a new WB, throws exception if fails
            Type webbrowsertype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_WebBrowser, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            m_WBUnknown = System.Activator.CreateInstance(webbrowsertype);

            //Get the IOleObject
            m_WBOleObject = (IOleObject)m_WBUnknown;
            //Set client site
            int iret = m_WBOleObject.SetClientSite(this);

            //Set hostnames
            iret = m_WBOleObject.SetHostNames("csEXWB", string.Empty);

            //Get client rect
            bool brect = WinApis.GetClientRect(this.Handle, out m_WBRect);
            //if ((m_WBRect.Right == 0) || (m_WBRect.Bottom == 0))
            //{
            //    m_WBRect.Right = 250;
            //    m_WBRect.Bottom = 250;
            //    m_WBRect.Left = 0;
            //    m_WBRect.Top = 0;
            //}
            //else
            //{
            //Setup H+W
            m_WBRect.Right = m_WBRect.Right - m_WBRect.Left; //W
            m_WBRect.Bottom = m_WBRect.Bottom - m_WBRect.Top; //H
            m_WBRect.Left = 0;
            m_WBRect.Top = 0;
            //}

            //Get the IOleInPlaceObject
            m_WBOleInPlaceObject = (IOleInPlaceObject)m_WBUnknown;
            tagRECT trect = new tagRECT();
            WinApis.CopyRect(ref trect, ref m_WBRect);
            //Set WB rects
            iret = m_WBOleInPlaceObject.SetObjectRects(ref m_WBRect, ref trect);

            //INPLACEACTIVATE the WB
            iret = m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_INPLACEACTIVATE, ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);

            //Get the IWebBrowser2
            m_WBWebBrowser2 = (IWebBrowser2)m_WBUnknown;

            //By default, we handle dragdrops
            m_WBWebBrowser2.RegisterAsDropTarget = false;
            if (!DesignMode)
            {
                //Get connectionpointcontainer
                IConnectionPointContainer cpCont = (IConnectionPointContainer)m_WBUnknown;
                //Find connection point
                Guid guid = typeof(DWebBrowserEvents2).GUID;
                IConnectionPoint m_WBConnectionPoint = null;
                cpCont.FindConnectionPoint(ref guid, out m_WBConnectionPoint);
                //Advice
                m_WBConnectionPoint.Advise(this, out m_dwCookie);

                //Get the IOleComandTarget
                m_WBOleCommandTarget = (IOleCommandTarget)m_WBUnknown;

                //Register clipborad format for internal drag drop
                //RegisterClipboardFormatsForDragDrop();
            }

            //if(!string.IsNullOrEmpty(m_sUrl))
            //    this.Navigate(m_sUrl);
            //else
            //    this.Navigate(m_AboutBlank);

            //Get the shell embedding, ...
            WBIEServerHandle();
        }

        //Wrappers for Webbrowser.ExecWB and IOleCommand.Exec methods
        private void ExecWB(OLECMDID command)
        {

            if (m_WBWebBrowser2 != null)
            {
                m_WBWebBrowser2.ExecWB(command,
                    OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    ref m_NullObject, ref m_NullObject);
            }
        }
        private int WBOleCommandExec(OLECMDID command)
        {
            //Execute the command using default group NULL
            int hr = Hresults.S_FALSE; //1
            if (m_WBOleCommandTarget != null)
            {
                //should return S_OK 0
                hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)command, (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    m_NullPointer, m_NullPointer);

            }
            return hr;
        }
        private int WBOleCommandExec(OLECMDID command, OLECMDEXECOPT cmdopt)
        {
            //Execute the command using default group NULL
            int hr = Hresults.S_FALSE;
            if (m_WBOleCommandTarget != null)
            {
                hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)command, (uint)cmdopt,
                    m_NullPointer, m_NullPointer);
            }
            return hr;
        }

        //Utility, used in Findxxx methods
        //MakeRGB(Color.FromName(Color));
        private int MakeRGB(Color cColor)
        {
            try
            {
                //Taken from RGB macro in wingdi.h
                return (int)((cColor.R | (((short)cColor.G) << 8)) | (((int)cColor.B) << 16));

            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void SynchDOCDOWNLOADCTLFLAG(DOCDOWNLOADCTLFLAG flag, bool add)
        {
            if (add)
            {
                if ((m_DLCtlFlags & flag) == 0)
                    m_DLCtlFlags |= flag;
            }
            else
            {
                if ((m_DLCtlFlags & flag) != 0)
                    m_DLCtlFlags -= flag;
            }

            if ((m_WBUnknown != null) && (m_WBWebBrowser2 != null))
            {
                try
                {
                    //Signal change of DL property
                    //so MSHTML call our Invoke method through Dispatch
                    //Otherwise refreshing the page will have no effect
                    //MSHTML does not know of new flags set by us
                    //QI for IOleControl
                    IOleControl pOC = (IOleControl)m_WBUnknown;
                    pOC.OnAmbientPropertyChange(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL);
                }
                finally
                {
                }
            }
        }

        private void SynchDOCHOSTUIFLAG(DOCHOSTUIFLAG flag, bool add)
        {
            if (add)
            {
                if ((m_DocHostUiFlags & flag) == 0)
                    m_DocHostUiFlags |= flag;
            }
            else
            {
                if ((m_DocHostUiFlags & flag) != 0)
                    m_DocHostUiFlags -= flag;
            }
        }

        /// <summary>
        /// Creates and initializes events for ComUtilitiesLib.UtilManClass instance
        /// Responsible for Asynchronous pluggable protocols and webbrowser file download replacement
        /// </summary>
        private void InitCOMLibrary()
        {
            m_csexwbCOMLib = new ComUtilitiesLib.UtilManClass();

            m_csexwbCOMLib.FileDownloadEx += new ComUtilitiesLib._IUtilManEvents_FileDownloadExEventHandler(dl_FileDownloadEx);
            m_csexwbCOMLib.OnFileDLEndDownload += new ComUtilitiesLib._IUtilManEvents_OnFileDLEndDownloadEventHandler(dl_OnFileDLEndDownload);
            m_csexwbCOMLib.OnFileDLDownloadError += new ComUtilitiesLib._IUtilManEvents_OnFileDLDownloadErrorEventHandler(dl_OnFileDLDownloadError);
            m_csexwbCOMLib.OnFileDLAuthenticate += new ComUtilitiesLib._IUtilManEvents_OnFileDLAuthenticateEventHandler(m_DownloadManager_OnFileDLAuthenticate);
            m_csexwbCOMLib.OnFileDLProgress += new ComUtilitiesLib._IUtilManEvents_OnFileDLProgressEventHandler(m_DownloadManager_OnFileDLProgress);
            m_csexwbCOMLib.OnFileDLFileFullyWritten += new ComUtilitiesLib._IUtilManEvents_OnFileDLFileFullyWrittenEventHandler(m_csexwbCOMLib_OnFileDLFileFullyWritten);
            //m_DownloadManager.OnFileDLBeginningTransaction += new ComUtilitiesLib._IUtilManEvents_OnFileDLBeginningTransactionEventHandler(m_DownloadManager_OnFileDLBeginningTransaction);
            //m_DownloadManager.OnFileDLResponse += new ComUtilitiesLib._IUtilManEvents_OnFileDLResponseEventHandler(m_DownloadManager_OnFileDLResponse);

            m_csexwbCOMLib.OnStartManagedAPP += new ComUtilitiesLib._IUtilManEvents_OnStartManagedAPPEventHandler(m_csexwbCOMLib_OnStartManagedAPP);
            m_csexwbCOMLib.OnStartCustManagedApp += new ComUtilitiesLib._IUtilManEvents_OnStartCustManagedAppEventHandler(m_csexwbCOMLib_OnStartCustManagedApp);
            m_csexwbCOMLib.ManagedAppBeginningTransaction += new ComUtilitiesLib._IUtilManEvents_ManagedAppBeginningTransactionEventHandler(m_csexwbCOMLib_ManagedAppBeginningTransaction);
            m_csexwbCOMLib.ManagedAppOnResponse += new ComUtilitiesLib._IUtilManEvents_ManagedAppOnResponseEventHandler(m_csexwbCOMLib_ManagedAppOnResponse);
            m_csexwbCOMLib.ManagedAppDataFullyAvailable += new ComUtilitiesLib._IUtilManEvents_ManagedAppDataFullyAvailableEventHandler(m_csexwbCOMLib_ManagedAppDataFullyAvailable);
            m_csexwbCOMLib.ManagedAppDataFullyRead += new ComUtilitiesLib._IUtilManEvents_ManagedAppDataFullyReadEventHandler(m_csexwbCOMLib_ManagedAppDataFullyRead);
            m_csexwbCOMLib.ManagedAppOperationFailed += new ComUtilitiesLib._IUtilManEvents_ManagedAppOperationFailedEventHandler(m_csexwbCOMLib_ManagedAppOperationFailed);
            //It is on by default
            //if (!m_csexwbCOMLib.HTTPprotocolManaged)
            //{
            //    m_csexwbCOMLib.HTTPprotocolManaged = true;
            //}
            //if (!m_csexwbCOMLib.HTTPSprotocolManaged)
            //{
            //    m_csexwbCOMLib.HTTPSprotocolManaged = true;
            //}
        }
        private void RemCOMLibrary()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((System.Windows.Forms.MethodInvoker)delegate { RemCOMLibrary(); }, new object[] { });
                return;
            }

            if (m_csexwbCOMLib != null)
            {
                //Marshal.FinalReleaseComObject(m_csexwbCOMLib);
                m_csexwbCOMLib = null;
            }
        }

        private void RemoveIUtilManEvents()
        {
            if (m_csexwbCOMLib != null)
            {
                m_csexwbCOMLib.FileDownloadEx -= new ComUtilitiesLib._IUtilManEvents_FileDownloadExEventHandler(dl_FileDownloadEx);
                m_csexwbCOMLib.OnFileDLEndDownload -= new ComUtilitiesLib._IUtilManEvents_OnFileDLEndDownloadEventHandler(dl_OnFileDLEndDownload);
                m_csexwbCOMLib.OnFileDLDownloadError -= new ComUtilitiesLib._IUtilManEvents_OnFileDLDownloadErrorEventHandler(dl_OnFileDLDownloadError);
                m_csexwbCOMLib.OnFileDLAuthenticate -= new ComUtilitiesLib._IUtilManEvents_OnFileDLAuthenticateEventHandler(m_DownloadManager_OnFileDLAuthenticate);
                m_csexwbCOMLib.OnFileDLProgress -= new ComUtilitiesLib._IUtilManEvents_OnFileDLProgressEventHandler(m_DownloadManager_OnFileDLProgress);
                m_csexwbCOMLib.OnFileDLFileFullyWritten -= new ComUtilitiesLib._IUtilManEvents_OnFileDLFileFullyWrittenEventHandler(m_csexwbCOMLib_OnFileDLFileFullyWritten);

                m_csexwbCOMLib.OnStartManagedAPP -= new ComUtilitiesLib._IUtilManEvents_OnStartManagedAPPEventHandler(m_csexwbCOMLib_OnStartManagedAPP);
                m_csexwbCOMLib.OnStartCustManagedApp -= new ComUtilitiesLib._IUtilManEvents_OnStartCustManagedAppEventHandler(m_csexwbCOMLib_OnStartCustManagedApp);
                m_csexwbCOMLib.ManagedAppBeginningTransaction -= new ComUtilitiesLib._IUtilManEvents_ManagedAppBeginningTransactionEventHandler(m_csexwbCOMLib_ManagedAppBeginningTransaction);
                m_csexwbCOMLib.ManagedAppOnResponse -= new ComUtilitiesLib._IUtilManEvents_ManagedAppOnResponseEventHandler(m_csexwbCOMLib_ManagedAppOnResponse);
                m_csexwbCOMLib.ManagedAppDataFullyAvailable -= new ComUtilitiesLib._IUtilManEvents_ManagedAppDataFullyAvailableEventHandler(m_csexwbCOMLib_ManagedAppDataFullyAvailable);
                m_csexwbCOMLib.ManagedAppDataFullyRead -= new ComUtilitiesLib._IUtilManEvents_ManagedAppDataFullyReadEventHandler(m_csexwbCOMLib_ManagedAppDataFullyRead);
                m_csexwbCOMLib.ManagedAppOperationFailed -= new ComUtilitiesLib._IUtilManEvents_ManagedAppOperationFailedEventHandler(m_csexwbCOMLib_ManagedAppOperationFailed);
            }
        }

        private bool m_AppStarted = false;
        /// <summary>
        /// Called from WBIEServerHandle method
        /// </summary>
        private void StartApp()
        {
            m_AppStarted = true;
            m_csexwbCOMLib.HWNDInternetExplorerServer = m_hWBServerHandle.ToInt32();
        }

        private void AddThisIEServerHwndToComLib()
        {
            if (m_csexwbCOMLib.HWNDInternetExplorerServer == 0)
            {
                m_csexwbCOMLib.HWNDInternetExplorerServer = WBIEServerHandle().ToInt32();
            }
        }

        public event csExWB.TopLevelOnloadEventHandler WBTopLevelOnLoad = null;
        public event csExWB.TopLevelOnUnloadEventHandler WBTopLevelOnUnload = null;
        public event csExWB.SecondaryOnloadEventHandler WBSecondaryOnLoad = null;
        public event csExWB.SecondaryOnUnloadEventHandler WBSecondaryOnUnload = null;

        private void TopLevelOnLoadEvent(object sender, EventArgs e)
        {
            GenericElementEventHandler handler = sender as GenericElementEventHandler;
            if (WBTopLevelOnLoad != null)
            {
                System.ComponentModel.CancelEventArgs args = new CancelEventArgs(false);
                try
                {
                    WBTopLevelOnLoad(this, args);
                }
                catch (Exception)
                {
                }
                if (args.Cancel)
                    return;
            }
            handler.InvokeOldHandler();
        }
        private void TopLevelOnUnloadEvent(object sender, EventArgs e)
        {
            GenericElementEventHandler handler = sender as GenericElementEventHandler;
            if (WBTopLevelOnUnload != null)
            {
                System.ComponentModel.CancelEventArgs args = new CancelEventArgs(false);
                try
                {
                    WBTopLevelOnUnload(this, args);
                }
                catch (Exception)
                {
                }
                if (args.Cancel)
                    return;
            }
            handler.InvokeOldHandler();
        }
        private void SecondaryOnLoadEvent(object sender, EventArgs e)
        {
            GenericElementEventHandler handler = sender as GenericElementEventHandler;
            if (WBSecondaryOnLoad != null)
            {
                SecondaryOnloadEventArgs args =
                    new SecondaryOnloadEventArgs(handler.HTMLElement as IWebBrowser2);
                try
                {
                    WBSecondaryOnLoad(this, args);
                }
                catch (Exception)
                {
                }
                if (args.Cancel)
                    return;
            }
            handler.InvokeOldHandler();
        }
        private void SecondaryOnUnloadEvent(object sender, EventArgs e)
        {
            GenericElementEventHandler handler = sender as GenericElementEventHandler;
            if (WBSecondaryOnUnload != null)
            {
                SecondaryOnloadEventArgs args =
                    new SecondaryOnloadEventArgs(handler.HTMLElement as IWebBrowser2);
                try
                {
                    WBSecondaryOnUnload(this, args);
                }
                catch (Exception)
                {
                }
                if (args.Cancel)
                    return;
            }
            handler.InvokeOldHandler();
            //Clear interfaces
            if (handler.HTMLElement != null)
                handler.HTMLElement = null; //Release IWebbrowser instance
        }

        #endregion

        #region Public Method Members

        /// <summary>
        /// We don't have access to IDispatch::Invoke
        /// Fired when IOleControl::OnAmbientPropertyChange is called
        /// from WBDOCDOWNLOADCTLFLAG property in response to DLCtl flag changing
        /// </summary>
        /// <returns></returns>
        [DispId(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL)]
        public int Idispatch_AmbiantDlControl_Invoke_Handler()
        {
            return (int)m_DLCtlFlags;
        }

        //http://msdn2.microsoft.com/en-us/library/2x07fbw8.aspx
        //Using IWebBrowser2 interface
        public void Navigate(string URL)
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.Navigate(URL, ref m_NullObject, ref m_NullObject, ref m_NullObject, ref m_NullObject);
        }

        /// <summary> 
        /// Navigates to a given url using a combination of BrowserNavConsts 
        /// </summary> 
        /// <param name="URL"></param> 
        /// <param name="BrowserNavConstants_Flags">A combination of the values defined by the BrowserNavConstants enumeration</param> 
        /// <example>cEXWB1.Navigate("http://www.google.com", (int) (BrowserNavConstants.navNoHistory | BrowserNavConstants.navNoReadFromCache | BrowserNavConstants.navNoWriteToCache));</example> 
        public void Navigate(string URL, int BrowserNavConstants_Flags)
        {
            if (m_WBWebBrowser2 != null)
            {
                object outobj = BrowserNavConstants_Flags;
                object outtarget = null;
                m_WBWebBrowser2.Navigate(URL, ref outobj, ref outtarget, ref m_NullObject, ref m_NullObject);
            }
        }
        public void Navigate(string URL, BrowserNavConstants Flags)
        {
            if (m_WBWebBrowser2 != null)
            {
                //At runtime, outobj data type is determined and passed as
                //variant of that type. Used for simple data types
                object outobj = (int)Flags;
                object outtarget = null;
                if (Flags == BrowserNavConstants.navOpenInNewWindow)
                    outtarget = "_BLANK";
                m_WBWebBrowser2.Navigate(URL, ref outobj, ref outtarget, ref m_NullObject, ref m_NullObject);
            }
        }
        public void Navigate(string URL, BrowserNavConstants Flags, string TargetFrameName, string PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vFlags = (int)Flags;
                object vTargetFrameName = TargetFrameName;
                object vPostData = ASCIIEncoding.ASCII.GetBytes(PostData);
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref vFlags, ref vTargetFrameName, ref vPostData, ref vHeaders);
            }
        }
        public void Navigate(string URL, BrowserNavConstants Flags, string PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vFlags = (int)Flags;
                object vPostData = ASCIIEncoding.ASCII.GetBytes(PostData);
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref vFlags, ref m_NullObject, ref vPostData, ref vHeaders);
            }
        }
        //PostData: Flav=red&taste=good
        public void Navigate(string URL, string PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vPostData = ASCIIEncoding.ASCII.GetBytes(PostData);
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref m_NullObject, ref m_NullObject, ref vPostData, ref vHeaders);
            }
        }
        public void Navigate(string URL, byte[] PostData)
        {
            if (m_WBWebBrowser2 != null)
            {
                object vPostData = PostData;
                object vHeaders = "Content-Type: application/x-www-form-urlencoded\r\n";
                m_WBWebBrowser2.Navigate(URL, ref m_NullObject, ref m_NullObject, ref vPostData, ref vHeaders);
            }
        }
        public void Navigate2(string URL)
        {
            if (m_WBWebBrowser2 != null)
            {
                object outobj = URL;
                m_WBWebBrowser2.Navigate2(ref outobj, ref m_NullObject, ref m_NullObject, ref m_NullObject, ref m_NullObject);
            }
        }
        public void NavToBlank()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.Navigate(m_AboutBlank, ref m_NullObject, ref m_NullObject, ref m_NullObject, ref m_NullObject);

        }

        public void Stop()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.Stop();
        }
        public bool GoBack()
        {
            if ((m_WBWebBrowser2 != null) && (m_bCanGoBack))
            {
                m_WBWebBrowser2.GoBack();
                return true;
            }
            return false;
        }
        public bool GoForward()
        {
            if ((m_WBWebBrowser2 != null) && (m_bCanGoForward))
            {
                m_WBWebBrowser2.GoForward();
                return true;
            }
            return false;
        }
        public void GoHome()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.GoHome();
        }
        public void GoSearch()
        {
            if (m_WBWebBrowser2 != null)
                m_WBWebBrowser2.GoSearch();
        }
        public void Refresh2(RefreshConstants Level)
        {
            if (m_WBWebBrowser2 != null)
            {
                object outobj = (Int32)Level;
                m_WBWebBrowser2.Refresh2(ref outobj);
            }
        }

        //Using IOleCommandTarget interface
        public bool SelectAll()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_SELECTALL) == Hresults.S_OK) ? true : false;
        }
        public bool Clear()
        {
            if (m_WBWebBrowser2 == null)
                return false;
            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return false;
            if (doc2.body == null)
                return false;
            doc2.body.innerHTML = "";
            return true;
        }
        public bool ClearSelection()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_CLEARSELECTION) == Hresults.S_OK) ? true : false;
        }
        public bool Copy()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_COPY) == Hresults.S_OK) ? true : false;
        }
        public bool Paste()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PASTE) == Hresults.S_OK) ? true : false;
        }
        public bool Cut()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_CUT) == Hresults.S_OK) ? true : false;
        }
        public bool Undo()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_UNDO) == Hresults.S_OK) ? true : false;
        }
        public bool Redo()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_REDO) == Hresults.S_OK) ? true : false;
        }
        public bool Delete()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_DELETE) == Hresults.S_OK) ? true : false;
        }
        public bool PasteSpecial()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PASTESPECIAL) == Hresults.S_OK) ? true : false;
        }
        public bool Spell()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_SPELL) == Hresults.S_OK) ? true : false;
        }
        public bool NewWindow()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_NEW) == Hresults.S_OK) ? true : false;
        }
        public bool Print()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINT) == Hresults.S_OK) ? true : false;
        }
        public bool Print2()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINT2) == Hresults.S_OK) ? true : false;
        }
        public bool Properties()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PROPERTIES) == Hresults.S_OK) ? true : false;
        }
        public bool PrintPreview()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINTPREVIEW) == Hresults.S_OK) ? true : false;
        }
        public bool PrintPreview2()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PRINTPREVIEW2) == Hresults.S_OK) ? true : false;
        }
        public bool PageSetup()
        {
            return (this.WBOleCommandExec(OLECMDID.OLECMDID_PAGESETUP) == Hresults.S_OK) ? true : false;
        }
        /// <summary>
        /// Displays the Save page dialog.
        /// </summary>
        public void SaveAs()
        {
            ////displays the old style saveas
            ////returns notsupported if user clicks cancel
            ////m_iTmpRet = this.WBOleCommandExec(OLECMDID.OLECMDID_SAVEAS);

            //if (m_iTmpRet != Hresults.S_OK)
            this.ExecWB(OLECMDID.OLECMDID_SAVEAS); //displays modern style
        }

        //using CGI_IWebBrowser group
        private int ShowMiscCommands(WB_MiscCommandTarget command)
        {
            int hr = Hresults.S_FALSE;
            uint uicommand = (uint)command;
            if (m_WBOleCommandTarget != null)
            {
                IntPtr pPt = m_NullPointer;
                try
                {
                    byte[] guidbytes = Iid_Clsids.CLSID_CGI_IWebBrowser.ToByteArray();
                    pPt = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                    Marshal.Copy(guidbytes, 0, pPt, guidbytes.Length);

                    hr = m_WBOleCommandTarget.Exec(pPt,
                        uicommand,
                        (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                        m_NullPointer, m_NullPointer);

                    Marshal.FreeCoTaskMem(pPt);
                    pPt = m_NullPointer;
                    //if (hr != Hresults.S_OK)
                    //    MessageBox(m_NullPointer, HresultAsString(hr),"ShowFindWB",0);
                }
                finally
                {
                    if (pPt != m_NullPointer)
                        Marshal.FreeCoTaskMem(pPt);
                }
            }
            return hr;
        }
        public bool Find()
        {
            return (this.ShowMiscCommands(WB_MiscCommandTarget.Find) == Hresults.S_OK) ? true : false;
        }
        public bool IEOptions()
        {
            return (this.ShowMiscCommands(WB_MiscCommandTarget.Options) == Hresults.S_OK) ? true : false;
        }
        public bool ViewSource()
        {
            return (this.ShowMiscCommands(WB_MiscCommandTarget.ViewSource) == Hresults.S_OK) ? true : false;
        }

        //Using IShellUIHelper
        //If not working use API:
        //DoOrganizeFavDlg
        //AddUrlToFavorites
        private int ShellUIHelperMiscCommands(string scommand)
        {

            #region C++ version
            //    HRESULT hr;
            //    IShellUIHelper* pShellUI = NULL;
            //    hr = CoCreateInstance(CLSID_ShellUIHelper, NULL, CLSCTX_INPROC_SERVER, IID_IShellUIHelper, (void **)&pShellUI);
            //    if(FAILED(hr) || !pShellUI) return Hresults.S_FALSE;
            //
            //LanguageDialog
            //    Opens the Language Preference dialog box.
            //OrganizeFavorites
            //    Opens the Organize Favorites dialog box.
            //PrivacySettings
            //    Microsoft® Internet Explorer 6 and later. Opens the Privacy Preferences dialog box.
            //ProgramAccessAndDefaults
            //    Microsoft Windows® XP Service Pack 1 (SP1) and later. Opens the Set Program Access and Defaults dialog box.
            //
            //    pShellUI->ShowBrowserUI(CComBSTR(L"OrganizeFavorites"), NULL, NULL);
            //    pShellUI->Release(); 
            #endregion

            int hr = Hresults.S_FALSE;
            //Create a new ShellUiHelper
            Type shelluitype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_ShellUIHelper, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            IShellUIHelper uihelper = System.Activator.CreateInstance(shelluitype) as IShellUIHelper;
            if (uihelper == null)
                return hr;
            uihelper.ShowBrowserUI(scommand, ref m_NullObject);
            return hr;
        }
        public void OrganizeFavorites()
        {
            ShellUIHelperMiscCommands("OrganizeFavorites");
        }
        public void PrivacySettings()
        {
            ShellUIHelperMiscCommands("PrivacySettings");
        }
        public void LanguageDialog()
        {
            ShellUIHelperMiscCommands("LanguageDialog");
        }
        public void ProgramAccessAndDefaults()
        {
            ShellUIHelperMiscCommands("ProgramAccessAndDefaults");
        }

        //Using IE Server hwnd and shelldocobject hwnd directly
        //Do not work in Vista IE7, COMMANDID values have changed
        public void AddToFavorites()
        {
            if (!WBIEServerHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBServerHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_CONTEXTMENU_ADDFAV, m_NullPointer);
            }
        }
        /// <summary>
        /// Alternative to Print method
        /// </summary>
        public void PrintDocument()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_PRINT, m_NullPointer);
            }
        }
        /// <summary>
        /// Alternative to PrintPreview method
        /// </summary>
        public void PrintPreviewDoc()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_PRINTPREVIEW, m_NullPointer);
            }
        }
        public void ImportExport()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_FILE_IMPORTEXPORT, m_NullPointer);
            }
        }
        public void SendLinkByEmail()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_FILE_SENDLINK, m_NullPointer);
            }
        }
        public void SendPageByEmail()
        {
            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_FILE_SENDPAGE, m_NullPointer);
            }
        }
        public void SendShortcutToDesktop()
        {

            if (!WBShellDocObjHandle().Equals(m_NullPointer))
            {
                HandleRef hhwnd = new HandleRef(this, m_hWBShellDocObjHandle);
                WinApis.SendMessage(hhwnd, (uint)WindowsMessages.WM_COMMAND,
                    (IntPtr)ID_IE_FILE_SENDDESKTOPSHORTCUT, m_NullPointer);
            }
        }

        //Using IWebbrowser2
        //Loads a URL into browser using IPersistMoniker interface
        public bool LoadUrlIntoBrowser(String url)
        {
            bool ret = false;
            if ((m_WBWebBrowser2 == null) || (url.Length == 0))
                return ret;

            IPersistMoniker persistMoniker = m_WBWebBrowser2.Document as IPersistMoniker;
            if (persistMoniker == null)
                return ret;
            IMoniker moniker = null;
            IBindCtx bindContext = null;
            WinApis.CreateBindCtx((uint)0, out bindContext);
            if (bindContext == null)
                return ret;
            //need our own implementation of moniker
            //moniker.BindToStorage(bindContext, null,ref IID_IStream,out new object(stream));            
            WinApis.CreateURLMoniker(null, url, out moniker);
            if (moniker == null)
                return ret;
            persistMoniker.Load(1, moniker, bindContext, 0);
            return true;
        }
        public bool LoadHtmlIntoBrowser(string html, string sBaseUrl)
        {
            bool ret = false;
            if ((m_WBWebBrowser2 == null) || (html.Length == 0))
                return ret;

            //IStream stream = null;
            ////Use Marshal.StringToHGlobalAnsi to get ANSI
            //int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(html), true, out stream);
            //if ((hr != Hresults.S_OK) || (stream == null))
            //return ret;

            IPersistMoniker pPM = m_WBWebBrowser2.Document as IPersistMoniker;

            if (pPM == null)
                return ret;
            IBindCtx bindctx = null;
            WinApis.CreateBindCtx((uint)0, out bindctx);
            if (bindctx == null)
                return ret;
            LoadHTMLMoniker loader = new LoadHTMLMoniker();
            if (string.IsNullOrEmpty(sBaseUrl))
                sBaseUrl = m_WBWebBrowser2.LocationURL;
            loader.InitLoader(html, sBaseUrl);
            pPM.Load(1, loader, bindctx, WinApis.STGM_READ);
            //stream = null;
            return true;
        }
        public bool LoadHtmlIntoBrowser(string html, IWebBrowser2 wb)
        {
            bool ret = false;
            if ((wb == null) || (wb.Document == null) || (html.Length == 0))
                return ret;
            IStream stream = null;

            int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(html), true, out stream);
            if ((hr != Hresults.S_OK) || (stream == null))
                return ret;

            IPersistStreamInit persistentStreamInit = wb.Document as IPersistStreamInit;
            if (persistentStreamInit != null)
            {
                persistentStreamInit.InitNew();
                persistentStreamInit.Load(stream);
                persistentStreamInit = null;
                ret = true;
            }
            stream = null;
            return ret;
        }
        public bool LoadHtmlIntoBrowser(string html)
        {
            bool ret = false;
            if ((m_WBWebBrowser2 == null) ||
                (m_WBWebBrowser2.Document == null) ||
                (html.Length == 0)
               )
                return ret;
            //IntPtr hglobal = IntPtr.Zero;
            try
            {
                //System.IO.MemoryStream streamA = new System.IO.MemoryStream(html.Length);
                //System.IO.StreamWriter writer = new System.IO.StreamWriter(streamA, Encoding.UTF8);
                //writer.Write(html);
                //writer.Flush();
                //streamA.Position = 0L;
                //hglobal = Marshal.AllocHGlobal((int)streamA.Length);
                //if (hglobal == IntPtr.Zero)
                //    return ret;

                //pWebBrowser->get_Document( &pHTMLDocDisp );
                //pHTMLDocDisp->QueryInterface( IID_IPersistStreamInit,  (void**)&pPersistStreamInit );
                IStream stream = null;

                //Use Marshal.StringToHGlobalAnsi to get ANSI
                //or Marshal.StringToHGlobalUni to get UNICODE
                //or Marshal.StringToHGlobalAuto to default to ANSI
                //define UNICODE in build config to get UNICODE HGlobal
                int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(html), true, out stream);
                if ((hr != Hresults.S_OK) || (stream == null))
                    return ret;

                IPersistStreamInit persistentStreamInit = m_WBWebBrowser2.Document as IPersistStreamInit;
                if (persistentStreamInit != null)
                {
                    persistentStreamInit.InitNew();
                    persistentStreamInit.Load(stream);
                    persistentStreamInit = null;
                    ret = true;
                }
                stream = null;
            }
            finally
            {
                //if (hglobal != IntPtr.Zero)
                //    Marshal.FreeHGlobal(hglobal);
            }
            return ret;
        }

        //Using CGID_ShellDocView
        /// <summary>
        /// If available, attempts to display security certifocate for the current site
        /// </summary>
        public void ShowCertificateDialog()
        {
            if (m_WBOleCommandTarget == null)
                return;
            IntPtr pPt = m_NullPointer;
            int hr = Hresults.S_OK;
            try
            {
                byte[] guidbytes = Iid_Clsids.CGID_ShellDocView.ToByteArray();
                pPt = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                Marshal.Copy(guidbytes, 0, pPt, guidbytes.Length);

                hr = m_WBOleCommandTarget.Exec(pPt,
                    WinApis.SHDVID_SSLSTATUS,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    m_NullPointer, m_NullPointer);

                Marshal.FreeCoTaskMem(pPt);
                pPt = m_NullPointer;
            }
            finally
            {
                if (pPt != m_NullPointer)
                    Marshal.FreeCoTaskMem(pPt);
            }
        }

        public bool HasFocus()
        {
            if (m_WBWebBrowser2 != null)
            {
                IHTMLDocument4 doc4 = m_WBWebBrowser2.Document as IHTMLDocument4;
                if (doc4 != null)
                    return doc4.hasFocus();
            }
            return false;
        }
        public void SetFocus()
        {
            if (m_WBWebBrowser2 == null)
                return;

            //if (!WBIEServerHandle().Equals(m_NullPointer))
            //    WinApis.SetFocus(m_hWBServerHandle);

            //UI activate first
            if (m_WBOleObject != null)
            {
                m_WBOleObject.DoVerb((int)OLEDOVERB.OLEIVERB_UIACTIVATE,
                    ref m_NullMsg, this, 0, this.Handle, ref m_WBRect);
            }

            IHTMLDocument4 doc4 = m_WBWebBrowser2.Document as IHTMLDocument4;
            if (doc4 != null)
                doc4.focus();
        }
        private void SetFocusBody()
        {
            if (m_WBWebBrowser2 == null)
                return;

            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return;
            IHTMLElement2 elem2 = doc2.body as IHTMLElement2;
            if (elem2 == null)
                return;
            elem2.focus();
        }

        /// <summary>
        /// Calls click method of active element
        /// </summary>
        public void ClickActiveElement()
        {
            IHTMLElement elem = this.GetActiveElement();
            if (elem != null)
                elem.click();
            //if (m_WBWebBrowser2 == null)
            //    return;
            //IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            //if ((doc2 != null) && (doc2.activeElement != null))
            //{
            //    doc2.activeElement.click();
            //}
        }

        /// <summary>
        /// Searches a given document for a match
        /// Does not continue from where a match was found
        /// Use FindInPage method instead
        /// </summary>
        /// <param name="pDoc2"></param>
        /// <param name="sFind"></param>
        /// <param name="DownWard"></param>
        /// <param name="MatchWholeWord"></param>
        /// <param name="MatchCase"></param>
        /// <returns></returns>
        public bool FindInPageSimple(IHTMLDocument2 pDoc2, string sFind, bool DownWard, bool MatchWholeWord, bool MatchCase)
        {
            bool found = false;
            if (pDoc2 == null)
                return found;

            IHTMLTxtRange range = null;

            int searchdir = (DownWard) ? 1000000 : -1000000;
            int searchcase = 0; //default

            //Set up search case
            if ((MatchWholeWord) && (MatchCase))
                searchcase = 6;
            else if (MatchWholeWord)
                searchcase = 2;
            else if (MatchCase)
                searchcase = 4;

            //IHTMLDocument2 pDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;

            IHTMLElement pElem = pDoc2.body;
            IHTMLBodyElement pBodyelem = pElem as IHTMLBodyElement;
            if (pBodyelem == null)
                return found;

            range = pBodyelem.createTextRange();
            if (range == null)
                return found;

            found = range.findText(sFind, searchdir, searchcase);

            return found;
        }

        //Find + Find and highlight
        public bool FindInPage(string sFind, bool DownWard, bool MatchWholeWord, bool MatchCase, bool ScrollIntoView)
        {
            bool success = false;
            if (m_WBWebBrowser2 == null)
                return success;

            if (sFind.Length == 0)
            {
                m_sLastSearch = "";
                m_txtrange = null;
                return success;
            }
            else
                m_sLastSearch = sFind;

            int searchdir = (DownWard) ? 1000000 : -1000000;
            int searchcase = 0; //default

            //Set up search case
            if ((MatchWholeWord) && (MatchCase))
                searchcase = 6;
            else if (MatchWholeWord)
                searchcase = 2;
            else if (MatchCase)
                searchcase = 4;

            if (m_txtrange != null)
            {
                if (sFind == m_sLastSearch)
                {
                    if (DownWard)
                        m_txtrange.collapse(false);
                    else
                        m_txtrange.collapse(true);
                }
                else
                    m_txtrange = null;
            }

            IHTMLDocument2 pDoc2 = GetActiveDocument();
            if (pDoc2 == null)
                return success;

            IHTMLElement pElem = pDoc2.body;
            IHTMLBodyElement pBodyelem = pElem as IHTMLBodyElement;
            if (pBodyelem == null)
                return success;

            if (m_txtrange == null)
                m_txtrange = pBodyelem.createTextRange();
            if (m_txtrange == null)
                return success;

            success = m_txtrange.findText(sFind, searchdir, searchcase);
            if (success)
            {
                m_txtrange.select();
                if (ScrollIntoView)
                    m_txtrange.scrollIntoView(true);
            }
            return success;
        }
        public int FindAndHightAllInPage(string sFind, bool MatchWholeWord, bool MatchCase, int cbackColor, int cForeColor)
        {
            int iMatches = 0;
            if ((sFind.Length == 0) || (m_WBWebBrowser2 == null))
                return iMatches;

            int searchdir = 0;
            int searchcase = 0; //default
            const string strbg = "BackColor";
            const string strf = "ForeColor";
            const string sword = "Character";
            const string stextedit = "Textedit";

            //Set up search case
            if ((MatchWholeWord) && (MatchCase))
                searchcase = 6;
            else if (MatchWholeWord)
                searchcase = 2;
            else if (MatchCase)
                searchcase = 4;

            IHTMLDocument2 pDoc2 = GetActiveDocument();
            if (pDoc2 == null)
                return iMatches;

            IHTMLElement pElem = pDoc2.body;
            IHTMLBodyElement pBodyelem = pElem as IHTMLBodyElement;
            if (pBodyelem == null)
                return iMatches;

            IHTMLTxtRange pTxtRange = pBodyelem.createTextRange();
            if (pTxtRange == null)
                return iMatches;

            //Can also QI pTxtRange for IOleCommand and use Exec method
            //is recommanded by MSDN.
            while (pTxtRange.findText(sFind, searchdir, searchcase))
            {
                if (cbackColor != 0)
                    pTxtRange.execCommand(strbg, false, cbackColor);
                if (cForeColor != 0)
                    pTxtRange.execCommand(strf, false, cForeColor);
                pTxtRange.moveStart(sword, 1);
                pTxtRange.moveEnd(stextedit, 1);
                iMatches = iMatches + 1;
            }
            return iMatches;
        }
        public int FindAndHightAllInPage(string sFind, bool MatchWholeWord, bool MatchCase, string cbackColor, string cForeColor)
        {
            int b = 0;
            int f = 0;
            //You may be tempted to use Color.Yellow.ToArgb(). But,
            //the value returned includes the A value which
            //causes confusion for MSHTML. i.e. Color.Cyan is interpreted as yellow
            if (cbackColor.Length > 0)
                b = MakeRGB(Color.FromName(cbackColor));
            if (cForeColor.Length > 0)
                f = MakeRGB(Color.FromName(cForeColor));
            return this.FindAndHightAllInPage(sFind, MatchWholeWord, MatchCase, b, f);
        }
        public int FindAndHightAllInPage(string sFind, bool MatchWholeWord, bool MatchCase, Color cbackColor, Color cForeColor)
        {
            int b = 0;
            int f = 0;
            if (cbackColor != Color.Empty)
                b = MakeRGB(cbackColor);
            if (cForeColor != Color.Empty)
                f = MakeRGB(cForeColor);
            return this.FindAndHightAllInPage(sFind, MatchWholeWord, MatchCase, b, f);
        }

        /// <summary>
        /// Attempts to determine if commands such as "Cut", "Copy", "Paste", etc are enabled
        /// </summary>
        /// <param name="sCmdId"></param>
        /// <returns></returns>
        public bool IsCommandEnabled(string sCmdId)
        {
            if (m_WBWebBrowser2 == null)
                return false;
            IHTMLDocument2 doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.queryCommandEnabled(sCmdId);
            return false;
        }
        /// <summary>
        /// Attempts to set the IHTMLDocument2.designMode to given sMode parameter
        /// </summary>
        /// <param name="sMode"></param>
        /// <returns></returns>
        public bool SetDesignMode(string sMode)
        {
            if (m_WBWebBrowser2 == null)
                return false;

            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
            {
                doc2.designMode = sMode;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns the value of IHTMLDocument2.designMode
        /// </summary>
        /// <returns></returns>
        public string GetDesignMode()
        {
            if (m_WBWebBrowser2 == null)
                return string.Empty;
            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.designMode;
            return string.Empty;
        }

        //if(bTopLevel == true) we use the toplevel document (Not frameset)
        //if(bTopLevel == false) we find the activedocument and use it's document
        //Use IsFrameset method in conjunction with these methods
        public string GetTitle(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;
            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.title;
            else
                return string.Empty;
        }
        public string GetTitle(IWebBrowser2 thisBrowser)
        {
            if (thisBrowser == null)
                return string.Empty;
            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.title;
            else
                return string.Empty;
        }
        public string GetText(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
            {
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
                if (doc3 != null)
                    return doc3.documentElement.outerText;
            }
            else
            {
                doc3 = this.GetActiveDocument() as IHTMLDocument3;
                if (doc3 != null)
                    return doc3.documentElement.outerText;
            }
            return string.Empty;
        }
        public string GetText(IWebBrowser2 thisBrowser)
        {
            if (thisBrowser == null)
                return string.Empty;
            IHTMLDocument3 doc3 = thisBrowser.Document as IHTMLDocument3;
            if (doc3 != null)
                return doc3.documentElement.outerText;
            else
                return string.Empty;
        }
        public string GetSource(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;

            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
            //return GetSource(this.m_WBWebBrowser2);
            else
                doc3 = this.GetActiveDocument() as IHTMLDocument3;
            if ((doc3 != null) && (doc3.documentElement != null))
                return doc3.documentElement.outerHTML; //innerHTML;
            return string.Empty;
        }
        public string GetSource(IWebBrowser2 thisBrowser)
        {
            if ((thisBrowser == null) || (thisBrowser.Document == null))
                return string.Empty;

            //Declare vars
            int hr = Hresults.S_OK;
            IStream pStream = null;
            IPersistStreamInit pPersistStreamInit = null;

            // Query for IPersistStreamInit.
            pPersistStreamInit = thisBrowser.Document as IPersistStreamInit;
            if (pPersistStreamInit == null)
                return string.Empty;

            //Create stream, delete on release
            hr = WinApis.CreateStreamOnHGlobal(m_NullPointer, true, out pStream);
            if ((pStream == null) || (hr != Hresults.S_OK))
                return string.Empty;

            //Save
            hr = pPersistStreamInit.Save(pStream, false);
            if (hr != Hresults.S_OK)
                return string.Empty;

            //Now read from stream....

            //First get the size
            long ulSizeRequired = (long)0;
            //LARGE_INTEGER
            long liBeggining = (long)0;
            System.Runtime.InteropServices.ComTypes.STATSTG statstg = new System.Runtime.InteropServices.ComTypes.STATSTG();
            pStream.Seek(liBeggining, (int)tagSTREAM_SEEK.STREAM_SEEK_SET, m_NullPointer);
            pStream.Stat(out statstg, (int)tagSTATFLAG.STATFLAG_NONAME);

            //Size
            ulSizeRequired = statstg.cbSize;
            if (ulSizeRequired == (long)0)
                return string.Empty;

            //Allocate buffer + read
            byte[] pSource = new byte[ulSizeRequired];
            pStream.Read(pSource, (int)ulSizeRequired, m_NullPointer);

            //Added by schlaup to handle UTF8 and UNICODE pages
            //Convert
            //ASCIIEncoding asce = new ASCIIEncoding();
            //return asce.GetString(pSource);
            Encoding enc = null;

            if (pSource.Length > 8)
            {
                // Check byte order mark
                if ((pSource[0] == 0xFF) && (pSource[1] == 0xFE)) // UTF16LE
                    enc = Encoding.Unicode;

                if ((pSource[0] == 0xFE) && (pSource[1] == 0xFF)) // UTF16BE
                    enc = Encoding.BigEndianUnicode;

                if ((pSource[0] == 0xEF) && (pSource[1] == 0xBB) && (pSource[2] == 0xBF)) //UTF8
                    enc = Encoding.UTF8;

                if (enc == null)
                {
                    // Check for alternating zero bytes which might indicate Unicode
                    if ((pSource[1] == 0) && (pSource[3] == 0) && (pSource[5] == 0) && (pSource[7] == 0))
                        enc = Encoding.Unicode;
                }
            }

            if (enc == null)
                enc = Encoding.Default;

            int bomLength = enc.GetPreamble().Length;

            return enc.GetString(pSource, bomLength, pSource.Length - bomLength);
        }
        /// <summary>
        /// Attempts to return a collection of images
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <returns></returns>
        public IHTMLElementCollection GetImages(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument() as IHTMLDocument2;
            if (doc2 == null)
                return null;
            return doc2.images as IHTMLElementCollection;
        }
        /// <summary>
        /// Attempts to return a collection of A elements
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <returns></returns>
        public IHTMLElementCollection GetAnchors(bool bTopLevel)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument() as IHTMLDocument2;
            if (doc2 == null)
                return null;
            return doc2.anchors as IHTMLElementCollection;
        }
        /// <summary>
        /// Attempts to collect and return a collection of
        /// A elements from the document.
        /// Accounts for frames.
        /// </summary>
        /// <returns></returns>
        public List<IHTMLElement> GetAllLinks()
        {
            List<IHTMLElement> links = new List<IHTMLElement>();
            //Check
            if (this.m_WBWebBrowser2 == null)
                return links;
            IHTMLDocument2 pDoc2 = null;
            string href = string.Empty;

            //Frames to recurse
            if (this.IsWBFrameset(this.m_WBWebBrowser2))
            {
                List<IWebBrowser2> frames = this.GetFrames(this.m_WBWebBrowser2);
                if (frames == null)
                    return links;
                //Recurse frames
                foreach (IWebBrowser2 pwb in frames)
                {
                    if (pwb != null)
                    {
                        pDoc2 = pwb.Document as IHTMLDocument2;

                        if (pDoc2 == null)
                            continue;
                        IHTMLElementCollection col = pDoc2.links as IHTMLElementCollection;
                        if (col == null)
                            continue;
                        foreach (IHTMLElement elem in col)
                        {
                            if ((elem != null) &&
                                (!string.IsNullOrEmpty(elem.tagName)) &&
                                (elem.tagName == "A")
                                )
                            {
                                href = elem.getAttribute("href", 0) as string;
                                if (!string.IsNullOrEmpty(href))
                                {
                                    //If interested in only certain types of links
                                    //if (href.EndsWith(".mpeg")
                                    //or if you don't want
                                    //if (!href.EndsWith("#")
                                    //add to collection
                                    links.Add(elem);
                                }
                            }
                        }
                    }
                }
            }
            //No frames
            else
            {
                pDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                if (pDoc2 == null)
                    return links;
                IHTMLElementCollection col = pDoc2.links as IHTMLElementCollection;
                if (col == null)
                    return links;
                foreach (IHTMLElement elem in col)
                {
                    if ((elem != null) &&
                        (!string.IsNullOrEmpty(elem.tagName)) &&
                        (elem.tagName == "A")
                        )
                    {
                        href = elem.getAttribute("href", 0) as string;
                        if (!string.IsNullOrEmpty(href))
                        {
                            //If interested in only certain types of links
                            //if (href.EndsWith(".mpeg")
                            //or if you don't want
                            //if (!href.EndsWith("#")
                            //add to collection
                            links.Add(elem);
                        }
                    }
                }
            }
            return links;
        }
        /// <summary>
        /// Attempts to retreive selected text
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <param name="ReturnAsHTML">Set to true to return the selected text in HTML format</param>
        /// <returns></returns>
        public string GetSelectedText(bool bTopLevel, bool ReturnAsHTML)
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;

            IHTMLDocument2 doc2 = null;
            IHTMLSelectionObject selobj = null;
            IHTMLTxtRange range = null;

            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if ((doc2 == null) || (doc2.selection == null))
                return string.Empty;

            selobj = doc2.selection as IHTMLSelectionObject;
            if (selobj == null)
                return string.Empty;

            if ((selobj.EventType == "none") || (selobj.EventType == "control"))
                return string.Empty;

            range = selobj.createRange() as IHTMLTxtRange;
            if (range == null)
                return string.Empty;

            if (ReturnAsHTML)
                return range.htmlText;
            else
                return range.text;

        }

        //execCommand(true, "insertimage", false, null)
        public bool ExecCommand(bool bTopLevel, string CmdId, bool showUI, object CmdValue)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;

            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.execCommand(CmdId, showUI, CmdValue);
            else
                return false;
        }
        //OleCommandExec(true, MSHTML_COMMAND_IDS.IDM_HTMLEDITMODE, true);
        //OleCommandExec(true, MSHTML_COMMAND_IDS.IDM_COMPOSESETTINGS, "0,0,0,2,0.0.0,255.255.255,Arial");
        public bool OleCommandExec(bool bTopLevel, MSHTML_COMMAND_IDS CmdID, object pvaIn)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;
            IOleCommandTarget m_Doc2OleCommandTraget = null;
            IntPtr m_Guid_MSHTML = m_NullPointer;
            bool bret = false;
            IntPtr pIn = IntPtr.Zero;
            try
            {
                byte[] guidbytes = Iid_Clsids.Guid_MSHTML.ToByteArray();
                m_Guid_MSHTML = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                Marshal.Copy(guidbytes, 0, m_Guid_MSHTML, guidbytes.Length);

                IHTMLDocument2 doc2 = null;
                if (bTopLevel)
                    doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                else
                    doc2 = this.GetActiveDocument();
                if (doc2 == null)
                    return false;
                m_Doc2OleCommandTraget = doc2 as IOleCommandTarget;
                if (m_Doc2OleCommandTraget == null)
                    return false;

                pIn = Marshal.AllocCoTaskMem((int)1024);
                Marshal.GetNativeVariantForObject(pvaIn, pIn);

                bret = (m_Doc2OleCommandTraget.Exec(m_Guid_MSHTML, (uint)CmdID,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    pIn, m_NullPointer) == Hresults.S_OK) ? true : false;

                Marshal.FreeCoTaskMem(m_Guid_MSHTML);
                m_Guid_MSHTML = m_NullPointer;
                Marshal.FreeCoTaskMem(pIn);
                pIn = IntPtr.Zero;
            }
            finally
            {
                if (m_Guid_MSHTML != m_NullPointer)
                    Marshal.FreeCoTaskMem(m_Guid_MSHTML);
                if (pIn != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pIn);
            }
            return bret;
        }
        public bool OleCommandExec(bool bTopLevel, MSHTML_COMMAND_IDS CmdID)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;
            IOleCommandTarget m_Doc2OleCommandTraget = null;
            IntPtr m_Guid_MSHTML = m_NullPointer;
            bool bret = false;
            try
            {
                byte[] guidbytes = Iid_Clsids.Guid_MSHTML.ToByteArray();
                m_Guid_MSHTML = Marshal.AllocCoTaskMem((int)(guidbytes.Length * 2));
                Marshal.Copy(guidbytes, 0, m_Guid_MSHTML, guidbytes.Length);

                IHTMLDocument2 doc2 = null;
                if (bTopLevel)
                    doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
                else
                    doc2 = this.GetActiveDocument();
                if (doc2 == null)
                    return false;
                m_Doc2OleCommandTraget = doc2 as IOleCommandTarget;
                if (m_Doc2OleCommandTraget == null)
                    return false;

                bret = (m_Doc2OleCommandTraget.Exec(m_Guid_MSHTML, (uint)CmdID,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                    m_NullPointer, m_NullPointer) == Hresults.S_OK) ? true : false;

                Marshal.FreeCoTaskMem(m_Guid_MSHTML);
                m_Guid_MSHTML = m_NullPointer;
            }
            finally
            {
                if (m_Guid_MSHTML != m_NullPointer)
                    Marshal.FreeCoTaskMem(m_Guid_MSHTML);
            }
            return bret;
        }
        public object QueryCommandValue(string CmdID)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;

            IHTMLDocument2 doc2 = null;
            doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 != null)
                return doc2.queryCommandValue(CmdID);

            return null;
        }
        public bool QueryCommandState(bool bTopLevel, string CmdId)
        {
            if (this.m_WBWebBrowser2 == null)
                return false;

            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.queryCommandState(CmdId);
            else
                return false;
        }
        /// <summary>
        /// Wrapper for IHTMLDocument3.getElementById method
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <param name="idval"></param>
        /// <returns></returns>
        public IHTMLElement GetElementByID(bool bTopLevel, string idval)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
            else
                doc3 = GetActiveDocument() as IHTMLDocument3;
            if (doc3 != null)
                return doc3.getElementById(idval);
            else
                return null;
        }
        /// <summary>
        /// Wrapper for IHTMLDocument3.getElementsByName method
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <param name="elemname"></param>
        /// <returns></returns>
        public IHTMLElementCollection GetElementsByName(bool bTopLevel, string elemname)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
            else
                doc3 = GetActiveDocument() as IHTMLDocument3;
            if (doc3 != null)
                return doc3.getElementsByName(elemname) as IHTMLElementCollection;
            else
                return null;
        }
        /// <summary>
        /// Wrapper for IHTMLDocument3.getElementsByTagName method
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public IHTMLElementCollection GetElementsByTagName(bool bTopLevel, String tagname)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;
            IHTMLDocument3 doc3 = null;
            if (bTopLevel)
                doc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
            else
                doc3 = GetActiveDocument() as IHTMLDocument3;
            if (doc3 != null)
                return doc3.getElementsByTagName(tagname) as IHTMLElementCollection;
            else
                return null;
        }
        /// <summary>
        /// Wrapper for IHTMLWindow2.execScript method
        /// <code>m_CurWB.execScript(true, "javascript:__doPostBack('NY,412800013,09/15/2007,10010,18,C,165,0','false')", "JavaScript");</code>
        /// </summary>
        /// <param name="bTopLevel"></param>
        /// <param name="ScriptName"></param>
        /// <param name="ScriptLanguage"></param>
        /// <returns></returns>
        public object execScript(bool bTopLevel, string ScriptName, string ScriptLanguage)
        {
            if ((this.m_WBWebBrowser2 == null) || (ScriptName.Length == 0))
                return null;

            IHTMLDocument2 doc2 = null;
            IHTMLWindow2 win2 = null;

            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 == null)
                return null;

            win2 = doc2.parentWindow as IHTMLWindow2;
            if (win2 == null) //change from !=
                return null;

            //MSDN, JScript is MSHTML default
            if (ScriptLanguage.Length == 0)
                ScriptLanguage = "JavaScript";
            return win2.execScript(ScriptName, ScriptLanguage);
        }
        /// <summary>
        /// Invokes a script within the HTML page
        /// </summary>
        /// <param name="ScriptName"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public object InvokeScript(string ScriptName, object[] Data)
        {
            object oRet = null;

            if (m_WBWebBrowser2 == null)
                return oRet;

            IHTMLDocument doc = m_WBWebBrowser2.Document as IHTMLDocument;
            if (doc == null)
                return oRet;
            object oScript = doc.Script;
            if (oScript == null)
                return oRet;
            //Invoke script
            if (Data == null)
                Data = new object[] { };
            //http://msdn2.microsoft.com/en-us/library/system.reflection.bindingflags.aspx
            oRet = oScript.GetType().InvokeMember(ScriptName,
                System.Reflection.BindingFlags.InvokeMethod, null, oScript, Data);
            return oRet;
        }
        public object InvokeScript(IWebBrowser2 wb, string ScriptName, object[] Data)
        {
            object oRet = null;

            if (wb == null)
                return oRet;

            IHTMLDocument doc = wb.Document as IHTMLDocument;
            if (doc == null)
                return oRet;
            object oScript = doc.Script;
            if (oScript == null)
                return oRet;
            //Invoke script
            if (Data == null)
                Data = new object[] { };
            //http://msdn2.microsoft.com/en-us/library/system.reflection.bindingflags.aspx
            oRet = oScript.GetType().InvokeMember(ScriptName,
                System.Reflection.BindingFlags.InvokeMethod, null, oScript, Data);
            return oRet;
        }

        /// <summary>
        /// Determines if the current document is a FRAMESET
        /// </summary>
        /// <returns></returns>
        public bool IsFrameset()
        {
            return IsWBFrameset(this.m_WBWebBrowser2);
        }
        /// <summary>
        /// Returns number of FRAMES in a FRAMESET document
        /// </summary>
        /// <returns></returns>
        public int FramesCount()
        {
            return WBFramesCount(this.m_WBWebBrowser2);
        }
        /// <summary>
        /// Returns a list of IWebBrowser2 instances.
        /// Each IWebBrowser2 instance represents a FRAME
        /// </summary>
        /// <returns></returns>
        public List<IWebBrowser2> GetFrames()
        {
            return GetFrames(this.m_WBWebBrowser2);
        }
        private List<IWebBrowser2> GetFrames(IWebBrowser2 pWB)
        {
            List<IWebBrowser2> wbFrames = new List<IWebBrowser2>();

            IOleContainer oc = pWB.Document as IOleContainer;
            if (oc == null)
                return null;

            //get the OLE enumerator for the embedded objects
            int hr = 0;
            IEnumUnknown eu;

            hr = oc.EnumObjects(tagOLECONTF.OLECONTF_EMBEDDINGS, out eu); //EU ALLOC
            Marshal.ReleaseComObject(oc);                                 //OC FREE
            Marshal.ThrowExceptionForHR(hr);

            object pUnk = null;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;

            //get the first ebmedded object
            hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);         //PUNK ALLOC
            Marshal.ThrowExceptionForHR(hr);
            //while sucessfully get a new embedding, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                //QI pUnk for the IWebBrowser2 interface
                IWebBrowser2 brow = pUnk as IWebBrowser2;
                if (brow != null)
                {
                    if (IsWBFrameset(brow))
                    {
                        List<IWebBrowser2> frames = GetFrames(brow);
                        if ((frames != null) && (frames.Count > 0))
                        {
                            wbFrames.AddRange(frames);
                            frames.Clear();
                        }
                    }
                    else
                    {
                        wbFrames.Add(brow);
                        //Marshal.ReleaseComObject(brow);                         //PUNK FREE
                    }
                } //if(brow != null)

                //get the next ebmedded object
                hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);       //PUNK ALLOC
                Marshal.ThrowExceptionForHR(hr);

            } //for(int i = 0; HRESULTS.S_OK == hr; i++)
            Marshal.ReleaseComObject(eu);                                 //EU FREE

            return wbFrames;
        }
        private bool IsWBFrameset(IWebBrowser2 pWB)
        {
            bool bRet = true;

            IHTMLDocument2 doc2 = pWB.Document as IHTMLDocument2;
            if (doc2 == null)
                return bRet;

            IHTMLElement elem = doc2.body;
            if (elem != null)
            {
                //QI for IHtmlBodyElement
                IntPtr pbody = Marshal.GetIUnknownForObject(elem);
                IntPtr pbodyelem = IntPtr.Zero;
                if (pbody != IntPtr.Zero)
                {
                    int iRet = Marshal.QueryInterface(pbody,
                        ref Iid_Clsids.IID_IHTMLBodyElement, out pbodyelem);
                    Marshal.Release(pbody);
                    if (pbodyelem != IntPtr.Zero)
                    {
                        bRet = false;
                        Marshal.Release(pbodyelem);
                    }
                }
                //IHTMLBodyElement bodyelem = (IHTMLBodyElement)elem;
                //MSDN, If no body present then this is a frameset
                //if (bodyelem != null)
                //    bRet = false;
            }

            return bRet;
        }
        private bool IsWBFrameset(IHTMLDocument2 doc2)
        {
            bool bRet = true;
            if (doc2 == null)
                return bRet;

            IHTMLElement elem = doc2.body;
            if (elem != null)
            {
                //QI for IHtmlBodyElement
                IntPtr pbody = Marshal.GetIUnknownForObject(elem);
                IntPtr pbodyelem = IntPtr.Zero;
                if (pbody != IntPtr.Zero)
                {
                    int iRet = Marshal.QueryInterface(pbody,
                        ref Iid_Clsids.IID_IHTMLBodyElement, out pbodyelem);
                    Marshal.Release(pbody);
                    if (pbodyelem != IntPtr.Zero)
                    {
                        bRet = false;
                        Marshal.Release(pbodyelem);
                    }
                }
            }

            return bRet;
        }
        private int WBFramesCount(IWebBrowser2 pWB)
        {
            int lRet = 0;

            IOleContainer oc = pWB.Document as IOleContainer;
            if (oc == null)
                return lRet;

            //get the OLE enumerator for the embedded objects
            int hr = 0;
            IEnumUnknown eu;

            hr = oc.EnumObjects(tagOLECONTF.OLECONTF_EMBEDDINGS, out eu); //EU ALLOC
            Marshal.ReleaseComObject(oc);                                 //OC FREE
            Marshal.ThrowExceptionForHR(hr);

            object pUnk = null;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;

            //get the first ebmedded object
            hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);         //PUNK ALLOC
            Marshal.ThrowExceptionForHR(hr);
            //while sucessfully get a new embedding, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                //QI pUnk for the IWebBrowser2 interface
                IWebBrowser2 brow = pUnk as IWebBrowser2;
                if (brow != null)
                {
                    if (IsWBFrameset(brow))
                        lRet += WBFramesCount(brow);
                    else
                    {
                        lRet++;
                        Marshal.ReleaseComObject(brow);                         //PUNK FREE
                    }
                } //if(brow != null)

                //get the next ebmedded object
                hr = eu.Next(MAX_FETCH_COUNT, out pUnk, out fetched);       //PUNK ALLOC
                Marshal.ThrowExceptionForHR(hr);

            } //for(int i = 0; HRESULTS.S_OK == hr; i++)
            Marshal.ReleaseComObject(eu);                                 //EU FREE

            return lRet;
        }

        /// <summary>
        /// Attempts to create an internet short cut givena filename and url
        /// </summary>
        /// <param name="LocalFileName"></param>
        /// <param name="URL"></param>
        /// <param name="Description"></param>
        /// <param name="IconFileName"></param>
        /// <param name="IconIndex"></param>
        /// <returns></returns>
        public bool CreateInternetShortCut(string LocalFileName, string URL, string Description, string IconFileName, int IconIndex)
        {
            bool bRet = false;
            Type iURL = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_InternetShortcut);
            //#if UNICODE
            IUniformResourceLocatorW pURL = System.Activator.CreateInstance(iURL) as IUniformResourceLocatorW;
            //#else
            //            IUniformResourceLocatorA pURL = (IUniformResourceLocatorA)System.Activator.CreateInstance(iURL);
            //#endif
            if (pURL == null)
                return bRet;

            IPersistFile pPF = pURL as IPersistFile;
            if (pPF == null)
                return bRet;
            //#if UNICODE
            IShellLinkW pSL = pURL as IShellLinkW;
            //#else
            //            IShellLinkA pSL = (IShellLinkA)pURL;
            //#endif
            if (pSL == null)
                return bRet;

            int hr = pURL.SetURL(URL, (uint)0);
            if (hr != Hresults.S_OK)
                return bRet;

            if (Description.Length > 0)
                pSL.SetDescription(Description);
            if (IconFileName.Length > 0)
                pSL.SetIconLocation(IconFileName, IconIndex);

            //Save
            pPF.Save(LocalFileName, true);

            return bRet;
        }
        /// <summary>
        /// Attempts to retrieve url of a given internet shortcut
        /// </summary>
        /// <param name="InternetShortCutPath"></param>
        /// <returns></returns>
        public string ResolveInternetShortCut(string InternetShortCutPath)
        {
            string URL = string.Empty;
            Type iURL = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_InternetShortcut);
            //#if UNICODE
            IUniformResourceLocatorW pURL = System.Activator.CreateInstance(iURL) as IUniformResourceLocatorW;
            //#else
            //            IUniformResourceLocatorA pURL = (IUniformResourceLocatorA)System.Activator.CreateInstance(iURL);
            //#endif
            if (pURL == null)
                return URL;

            IPersistFile pPF = pURL as IPersistFile;
            if (pPF == null)
                return URL;

            pPF.Load(InternetShortCutPath, (int)WinApis.STGM_READ);

            IntPtr str = IntPtr.Zero;
            int hr = pURL.GetURL(out str);

            if (str == m_NullPointer)
                return URL;

            //IntPtr hIcon, hInst;
            //Icon ico, clone;
            //StringBuilder sb = new StringBuilder(MAX_PATH);
            //int nIconIdx;
            ////#if UNICODE
            //            IShellLinkW pSL = (IShellLinkW)pURL;
            ////#else
            ////            IShellLinkA pSL = (IShellLinkA)pURL;
            ////#endif
            //pSL.GetIconLocation(sb, sb.Capacity, out nIconIdx);
            ////Icon Path: sb.ToString();
            ////Icon index: nIconIdx
            //hInst = Marshal.GetHINSTANCE(this.GetType().Module);
            //hIcon = WinApis.ExtractIcon(hInst, sb.ToString(), nIconIdx);
            //if (hIcon == IntPtr.Zero)
            //    return null;

            //// Return a cloned Icon, because we have to free the original ourselves.
            //ico = Icon.FromHandle(hIcon);
            //clone = (Icon)ico.Clone();
            //ico.Dispose();
            //WinApis.DestroyIcon(hIcon);
            ////clone: Url icon

            //#if UNICODE
            URL = Marshal.PtrToStringUni(str);
            //#else
            //            URL = Marshal.PtrToStringAnsi(str);
            //#endif
            Marshal.FreeCoTaskMem(str);

            return URL;
        }
        /// <summary>
        /// Attempts to clear browsing history
        /// </summary>
        /// <returns></returns>
        public bool ClearHistory()
        {
            int hr = Hresults.S_OK;
            Type urlhistorystg2type = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_CUrlHistory, true);
            IUrlHistoryStg2 urlhistorystg2 = System.Activator.CreateInstance(urlhistorystg2type) as IUrlHistoryStg2;
            if (urlhistorystg2 == null)
                return false;
            hr = urlhistorystg2.ClearHistory();
            return (hr == Hresults.S_OK) ? true : false;
        }

        /// <summary>
        /// Call this only once, as other calls are ignored by library.
        /// Allow or disallow HTML dialogs launched using showModelessDialog() 
        /// and showModalDialog() methods using CBT Window Hook.
        /// </summary>
        /// <param name="bAllow"></param>
        public void SetAllowHTMLDialogs(bool bAllow)
        {
            //Environment.OSVersion.Platform.ToString() Win32NT //XPpro
            //Environment.OSVersion.ServicePack Service Pack 2

            //If using WinXP sp2 and up
            //you can use WBEvaluteNewWindow event
            //check for flags parameter, if equals
            //NWMF_HTMLDIALOG then cancel the popup
            //Else use CBT hook
            if (this.DesignMode)
                return;
            if (bAllow)
            {
                if (m_CBT.IsHooked) //Unhook
                {
                    m_CBT.IsHooked = false;
                    //m_csexwbCOMLib.SetupWindowsHook(
                    //    CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT,
                    //    (int)this.Handle.ToInt32(),
                    //    m_CBT.IsHooked,
                    //    ref m_CBT.UniqueMsgID);
                    m_csexwbCOMLib.SetupWindowsHook(
                        ComUtilitiesLib.WINDOWSHOOK_TYPES.WHT_CBT,
                        (int)this.Handle.ToInt32(),
                        m_CBT.IsHooked,
                        ref m_CBT.UniqueMsgID);
                }
            }
            else
            {
                if (!m_CBT.IsHooked) //Hook
                {
                    m_CBT.IsHooked = true;
                    //m_csexwbCOMLib.SetupWindowsHook(
                    //    CSEXWBDLMANLib.WINDOWSHOOK_TYPES.WHT_CBT,
                    //    (int)this.Handle.ToInt32(),
                    //    m_CBT.IsHooked,
                    //    ref m_CBT.UniqueMsgID);
                    m_csexwbCOMLib.SetupWindowsHook(
                        ComUtilitiesLib.WINDOWSHOOK_TYPES.WHT_CBT,
                        (int)this.Handle.ToInt32(),
                        m_CBT.IsHooked,
                        ref m_CBT.UniqueMsgID);
                }
            }
        }
        public bool GetAllowHTMLDialogs()
        {
            return (m_CBT.IsHooked) ? false : true;
        }

        /// <summary>
        /// Attempts to convert UNICODE chars to their numeric values
        /// to be used with LoadHtmlIntoBrowser methods. sample
        /// "&#1581;&#1602;&#1608;&#1602; &#1575;&#1604;&#1591;&#1576;&#1593;"
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string UnicodeToHTMLEncoding(string html)
        {
            char[] chars = HttpUtility.HtmlEncode(html).ToCharArray();
            StringBuilder result = new StringBuilder(html.Length + (int)(html.Length * 0.1));
            const string appformat = "&#{0};";
            foreach (char c in chars)
            {
                int value = Convert.ToInt32(c);
                if (value > 127)
                    result.AppendFormat(appformat, value);
                else
                    result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// Clears session cookies
        /// </summary>
        /// <returns></returns>
        public bool ClearSessionCookies()
        {
            return WinApis.InternetSetOption(IntPtr.Zero,
                InternetSetOptionFlags.INTERNET_OPTION_END_BROWSER_SESSION,
                IntPtr.Zero, 0);
        }

        /// <summary>
        /// Adds a given url to the Internet explorer trusted zone
        /// </summary>
        /// <param name="url">format: http://msdn.microsoft.com</param>
        /// <returns></returns>
        public int AddUrlToTrustedZone(string url)
        {
            //Create a new InternetSecurityManager
            Type ismtype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_InternetSecurityManager, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            IInternetSecurityManager ismhelper = System.Activator.CreateInstance(ismtype) as IInternetSecurityManager;
            if (ismhelper == null)
                return Hresults.S_FALSE;
            return ismhelper.SetZoneMapping(
                (int)(tagURLZONE.URLZONE_ESC_FLAG | tagURLZONE.URLZONE_TRUSTED),
                url, (int)SZM_FLAGS.SZM_CREATE);
        }

        /// <summary>
        /// Attempts to retreive UserAgent from
        /// IHTMLWindow2.navigator object
        /// </summary>
        /// <returns></returns>
        public string UserAgnet()
        {
            if (this.m_WBWebBrowser2 == null)
                return string.Empty;

            IHTMLDocument2 doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            IHTMLWindow2 win2 = null;
            IOmNavigator navigator = null;

            if (doc2 == null)
                return string.Empty;

            win2 = doc2.parentWindow as IHTMLWindow2;
            if (win2 == null)
                return string.Empty;

            navigator = win2.navigator;
            if (navigator == null)
                return string.Empty;
            //webbrowser.type = HTML Document
            //Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)
            //userAgent = Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727)
            return navigator.userAgent;
        }

        /// <summary>
        /// Attempts to find IE version by searching IOmNavigator.userAgnet
        /// </summary>
        /// <returns>return format X.X (7.0)</returns>
        public string IEVersion()
        {
            string iev = this.UserAgnet();
            if (!string.IsNullOrEmpty(iev))
            {
                int index = iev.IndexOf("MSIE");
                if (index > -1)
                    return iev.Substring(index + 5, 3);
            }
            return iev;
        }

        /// <summary>
        /// Attempts to set the optical zoom value. Example: 
        /// <code>
        /// m_CurWB.SetOpticalZoomValue(300);
        /// </code>
        /// </summary>
        /// <param name="zoomvalue">Must be in the range 10 - 1000 percent</param>
        /// <returns>One of Hresults.S_OK or S_FALSE</returns>
        public int SetOpticalZoomValue(int zoomvalue)
        {
            if ((zoomvalue < 10) || (zoomvalue > 1000) || (m_WBOleCommandTarget == null))
                return Hresults.S_FALSE;
            IntPtr pRet = m_NullPointer;
            int hr = Hresults.S_FALSE;

            try
            {
                pRet = Marshal.AllocCoTaskMem((int)1024);
                Marshal.GetNativeVariantForObject((int)zoomvalue, pRet);

                hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)OLECMDID.OLECMDID_OPTICAL_ZOOM,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    pRet, m_NullPointer);
                Marshal.FreeCoTaskMem(pRet);
                pRet = m_NullPointer;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (pRet != m_NullPointer)
                    Marshal.FreeCoTaskMem(pRet);
            }
            return hr;
        }

        /// <summary>
        /// Attempts to retreive optical zoom range. Example: 
        /// <code>
        /// int[] range = m_CurWB.GetOpticalZoomRange();
        /// AllForms.m_frmLog.AppendToLog(
        /// "Min==>" + range[0].ToString() + 
        /// "\r\nMax==>" + range[1].ToString());
        /// </code>
        /// </summary>
        /// <returns>Return int array index 0 = Min and index 1 = Max</returns>
        public int[] GetOpticalZoomRange()
        {
            object retVal = new object(); //VT_NULL
            IntPtr pRet = m_NullPointer;
            int iZoom = (int)0;
            int[] range = { 0, 0 };

            if (m_WBOleCommandTarget == null)
                return range;

            try
            {
                pRet = Marshal.AllocCoTaskMem((int)1024);
                Marshal.GetNativeVariantForObject(retVal, pRet);

                //NULL to specify the standard group
                int hr = m_WBOleCommandTarget.Exec(m_NullPointer,
                    (uint)OLECMDID.OLECMDID_OPTICAL_GETZOOMRANGE,
                    (uint)OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    m_NullPointer, pRet);

                retVal = Marshal.GetObjectForNativeVariant(pRet);
                Marshal.FreeCoTaskMem(pRet);
                pRet = m_NullPointer;
                if (Type.GetTypeCode(retVal.GetType()) == TypeCode.Int32)
                    iZoom = int.Parse(retVal.ToString());
            }
            catch (Exception)
            {
            }
            finally
            {
                if (pRet != m_NullPointer)
                    Marshal.FreeCoTaskMem(pRet);
            }
            if (iZoom > 0)
            {
                range[0] = WinApis.LoWord(iZoom); //Min
                range[1] = WinApis.HiWord(iZoom); //Max
            }
            return range;
            //            Registry
        }

        //Add IE registry setting and getting
        /// <summary>
        /// Attempts to set Disable Script Debugger registry keyname to yes
        /// to enable our control to receive script errors.
        /// Default value of this key in IE6 is yes and in IE7 is no?
        /// </summary>
        /// <returns>Value of Disable Script Debugger registry key before modification.
        ///  yes or no</returns>
        public string DisableScriptDebugger()
        {
            string regkey = "Software\\Microsoft\\Internet Explorer\\Main";
            string ret = string.Empty;

            RegistryKey reg = Registry.CurrentUser.OpenSubKey(regkey,
                RegistryKeyPermissionCheck.ReadWriteSubTree);
            //Get value before modification
            ret = reg.GetValue("Disable Script Debugger", "nothing").ToString();
            if ((!string.IsNullOrEmpty(ret)) && (ret.Length == 2))
                reg.SetValue("Disable Script Debugger", "yes", RegistryValueKind.String);
            return ret;
        }

        //Frames Proof methods
        /// <summary>
        /// Attempts to return active IWebbrowser2 interface instance
        /// </summary>
        /// <returns></returns>
        public IWebBrowser2 GetActiveWebBrowser2()
        {
            IHTMLDocument2 doc2 = null;
            IHTMLElement elem = null;
            IWebBrowser2 wb = null;
            if (this.m_WBWebBrowser2 == null)
                return null;

            //Get document
            doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null) return m_WBWebBrowser2;

            if (!IsWBFrameset(doc2))
                return m_WBWebBrowser2;

            //Get active element
            elem = doc2.activeElement;

            if (elem == null)
                return m_WBWebBrowser2;

            IntPtr pelem = Marshal.GetIUnknownForObject(elem);
            if (pelem != IntPtr.Zero)
            {
                IntPtr pWB = IntPtr.Zero;
                int iRet = Marshal.QueryInterface(pelem,
                    ref Iid_Clsids.IID_IWebBrowser2, out pWB);
                //GetIUnknownForObject AddRefs so Release                        
                Marshal.Release(pelem);

                while (pWB != IntPtr.Zero)
                {
                    wb = Marshal.GetObjectForIUnknown(pWB) as IWebBrowser2;

                    //QueryInterface AddRefs so Release
                    Marshal.Release(pWB);
                    pWB = IntPtr.Zero;

                    if (wb == null) break;

                    doc2 = wb.Document as IHTMLDocument2;
                    if (doc2 == null) break;

                    elem = doc2.activeElement;
                    if (elem == null) break;

                    pelem = Marshal.GetIUnknownForObject(elem);
                    if (pelem != IntPtr.Zero)
                    {
                        iRet = Marshal.QueryInterface(pelem,
                            ref Iid_Clsids.IID_IWebBrowser2, out pWB);
                        Marshal.Release(pelem);
                    }
                }
            }

            return wb;
        }
        /// <summary>
        /// Attempts to return active IHTMLDocument2 interface instance
        /// </summary>
        /// <returns></returns>
        public IHTMLDocument2 GetActiveDocument()
        {
            IHTMLDocument2 doc2 = null;
            IHTMLElement elem = null;
            IWebBrowser2 wb = null;
            if (this.m_WBWebBrowser2 == null)
                return doc2;

            //Get document
            doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null) return doc2;

            if (!IsWBFrameset(doc2))
                return doc2;

            //Get active element
            elem = doc2.activeElement;

            if (elem == null)
                return doc2;

            IntPtr pelem = Marshal.GetIUnknownForObject(elem);
            if (pelem != IntPtr.Zero)
            {
                IntPtr pWB = IntPtr.Zero;
                int iRet = Marshal.QueryInterface(pelem,
                    ref Iid_Clsids.IID_IWebBrowser2, out pWB);
                //GetIUnknownForObject AddRefs so Release                        
                Marshal.Release(pelem);

                while (pWB != IntPtr.Zero)
                {
                    wb = Marshal.GetObjectForIUnknown(pWB) as IWebBrowser2;

                    //QueryInterface AddRefs so Release
                    Marshal.Release(pWB);
                    pWB = IntPtr.Zero;

                    if (wb == null) break;

                    doc2 = wb.Document as IHTMLDocument2;
                    if (doc2 == null) break;

                    elem = doc2.activeElement;
                    if (elem == null) break;

                    pelem = Marshal.GetIUnknownForObject(elem);
                    if (pelem != IntPtr.Zero)
                        iRet = Marshal.QueryInterface(pelem,
                            ref Iid_Clsids.IID_IWebBrowser2, out pWB);
                    Marshal.Release(pelem);
                }
            }

            //Here is the C# version. Raises exception

            ////QI for IWebbrowser2 iface
            //wb = (IWebBrowser2)elem;
            ////Continue till no more frames to traverse
            //while (wb != null)
            //{
            //    doc2 = (IHTMLDocument2)wb.Document;
            //    elem = doc2.activeElement;
            //    wb = (IWebBrowser2)elem;
            //}

            return doc2;
        }
        /// <summary>
        /// Attempts to return active IHTMLElement interface instance
        /// Accounts for Frames and Iframes
        /// </summary>
        /// <returns></returns>
        public IHTMLElement GetActiveElement()
        {
            IHTMLElement elem = null;
            string tagname = string.Empty;
            IHTMLDocument2 doc2 = GetActiveDocument();
            if (doc2 != null)
                elem = doc2.activeElement;
            if ((elem != null) && (!string.IsNullOrEmpty(elem.tagName)))
                tagname = elem.tagName.ToLower();
            while ((!string.IsNullOrEmpty(elem.tagName)) &&
                ((tagname == "frame") || (tagname == "iframe")))
            {
                //Cast it to IWebBrowser2
                IWebBrowser2 pwb = elem as IWebBrowser2;
                if (pwb != null)
                {
                    //Now get the document
                    //If you attempt to access the document via IHTMLFrameBase2.contentWindow
                    //you will get a "Access Denied" exception
                    IHTMLDocument2 pdoc2 = pwb.Document as IHTMLDocument2;
                    if (pdoc2 != null)
                        elem = pdoc2.activeElement;
                    if ((elem != null) && (!string.IsNullOrEmpty(elem.tagName)))
                        tagname = elem.tagName.ToLower();
                    else
                        tagname = string.Empty;
                }
            }
            return elem;
        }
        /// <summary>
        /// Attempts to return active IHTMLDocument3 interface instance
        /// </summary>
        /// <returns></returns>
        public IHTMLDocument3 GetActiveDocument3()
        {
            IWebBrowser2 wb = this.GetActiveWebBrowser2();
            if (wb != null)
                return wb.Document as IHTMLDocument3;
            else
                return null;
        }
        /// <summary>
        /// Attempts to return active IHTMLDocument4 interface instance
        /// </summary>
        /// <returns></returns>
        public IHTMLDocument4 GetActiveDocument4()
        {
            IWebBrowser2 wb = this.GetActiveWebBrowser2();
            if (wb != null)
                return wb.Document as IHTMLDocument4;
            else
                return null;
        }
        /// <summary>
        /// Attempts to return active IHTMLWindow2 interface instance
        /// </summary>
        /// <returns></returns>
        public IHTMLWindow2 GetActiveWindow2()
        {
            IHTMLDocument2 doc2 = this.GetActiveDocument();
            if (doc2 == null)
                return null;
            return doc2.parentWindow as IHTMLWindow2;
        }
        /// <summary>
        /// Wrapper for IHTMLDocument2.elementFromPoint method
        /// Attempts to retreive an HTML element from given x and y
        /// coordinates relative to the main document or if frameset
        /// relative to the active document
        /// </summary>
        /// <param name="bTopLevel">True, use the toplevel IHTMLDocument2 instance</param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public IHTMLElement ElementFromPoint(bool bTopLevel, int X, int Y)
        {
            if (this.m_WBWebBrowser2 == null)
                return null;

            IHTMLDocument2 doc2 = null;
            if (bTopLevel)
                doc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            else
                doc2 = this.GetActiveDocument();
            if (doc2 != null)
                return doc2.elementFromPoint(X, Y);
            else
                return null;
        }
        /// <summary>
        /// Wrapper for IHTMLDocument2.elementFromPoint method
        /// Attempts to retreive an HTML element from given x and y
        /// coordinates, accounts for FRAMES and IFRAMES
        /// </summary>
        /// <param name="clientx"></param>
        /// <param name="clienty"></param>
        /// <returns></returns>
        public IHTMLElement ElementFromPoint(int clientx, int clienty)
        {
            IHTMLElement elem = null;
            int offsetx = 0;
            int offsety = 0;
            string tagname = string.Empty;

            //Get the main document
            IHTMLDocument2 pdoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;

            if (pdoc2 != null)
                elem = pdoc2.elementFromPoint(clientx, clienty);

            //Get the tagname
            if ((elem != null) && (!string.IsNullOrEmpty(elem.tagName)))
                tagname = elem.tagName.ToLower();

            //Do we have a frame or iframe?
            if ((!string.IsNullOrEmpty(tagname)) &&
                ((tagname == "frame") || (tagname == "iframe"))
                )
            {
                IHTMLElement offsetparent = elem.offsetParent;
                IHTMLElement2 elem2 = null;

                //Account for offsetLeft, offsetTop, scrollLeft, scrollTop

                //First get the main document scrolltop and scrollleft
                IHTMLDocument3 pdoc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
                if (pdoc3 != null)
                {
                    elem2 = pdoc3.documentElement as IHTMLElement2;
                    if (elem2 != null)
                    {
                        offsetx -= elem2.scrollLeft;
                        offsety -= elem2.scrollTop;
                    }
                }

                //This is needed if we have a fame
                elem2 = elem as IHTMLElement2;
                if (elem2 != null)
                {
                    offsetx -= elem2.scrollLeft;
                    offsety -= elem2.scrollTop;
                }
                offsetx += elem.offsetLeft;
                offsety += elem.offsetTop;

                //For frame+iframe
                while (offsetparent != null)
                {
                    offsetx += offsetparent.offsetLeft;
                    offsety += offsetparent.offsetTop;
                    offsetparent = offsetparent.offsetParent;
                }

                //Cast it to IWebBrowser2
                IWebBrowser2 pwb = elem as IWebBrowser2;
                if (pwb != null)
                {
                    //Now get the document
                    //If you attempt to access the document via IHTMLFrameBase2.contentWindow
                    //you will get a "Access Denied" exception
                    pdoc2 = pwb.Document as IHTMLDocument2;

                    IHTMLElement loopelem = null;
                    if (pdoc2 != null)
                    {
                        elem = pdoc2.elementFromPoint(clientx - offsetx, clienty - offsety);
                        loopelem = elem;
                        //There is only one website that I know of that has so many nested frames
                        //MSDN archive website.
                        while ((loopelem != null) &&
                            (loopelem.tagName.ToLower() == "frame" ||
                            loopelem.tagName.ToLower() == "iframe"))
                        {
                            pwb = loopelem as IWebBrowser2;
                            if (pwb == null)
                                break;
                            pdoc2 = pwb.Document as IHTMLDocument2;
                            if (pdoc2 == null)
                                break;

                            if (elem.offsetParent != null)
                            {
                                offsetx += elem.offsetParent.offsetLeft;
                                offsety += elem.offsetParent.offsetTop;
                            }

                            offsetx += elem.offsetLeft;
                            offsety += elem.offsetTop;

                            loopelem = pdoc2.elementFromPoint(clientx - offsetx, clienty - offsety);
                            if (loopelem != null)
                            {
                                elem = loopelem;
                            }
                        }
                    }
                }
            }

            return elem;
        }
        /// <summary>
        /// Attempts to return absolute position of a given html element
        /// </summary>
        /// <param name="elem">Target element</param>
        /// <returns></returns>
        public Point ElementToPoint(IHTMLElement elem)
        {
            Point pt = new Point(0, 0);

            if (elem == null)
                throw new Exception("elem can not be null.");

            pt.X = elem.offsetLeft;
            pt.Y = elem.offsetTop;

            IHTMLElement poffsetparent = elem.offsetParent;
            while (poffsetparent != null)
            {
                pt.X += poffsetparent.offsetLeft;
                pt.Y += poffsetparent.offsetTop;
                poffsetparent = poffsetparent.offsetParent;
            }

            return pt;
        }
        /// <summary>
        /// Attempts to return a List of IHTMLElements with the given Name or Id
        /// If document is frameset then all frames are searched
        /// </summary>
        /// <param name="NameOrId">Name or Id of the element</param>
        /// <returns></returns>
        public List<IHTMLElement> GetElementsByNameOrId(string NameOrId)
        {
            List<IHTMLElement> elemCols = new List<IHTMLElement>();

            if ((this.m_WBWebBrowser2 == null) ||
                string.IsNullOrEmpty(NameOrId))
                return elemCols;

            IHTMLDocument2 doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return elemCols;

            IHTMLElementCollection col = null;
            string elemname = string.Empty;
            if (this.IsWBFrameset(doc2))
            {
                List<IWebBrowser2> frames = this.GetFrames(this.m_WBWebBrowser2);
                if (frames == null)
                    return elemCols;
                IHTMLDocument2 framedoc = null;

                foreach (IWebBrowser2 wb in frames)
                {
                    if (wb == null)
                        continue;
                    framedoc = wb.Document as IHTMLDocument2;
                    if (framedoc == null)
                        continue;
                    col = framedoc.all as IHTMLElementCollection;
                    if (col == null)
                        continue;
                    foreach (IHTMLElement elem in col)
                    {
                        if (elem != null)
                        {
                            elemname = elem.getAttribute("name", 0) as string;
                            if ((elem.id == NameOrId) ||
                                (elemname == NameOrId))
                            {
                                elemCols.Add(elem);
                            }
                        }
                    }
                }
            }
            else
            {
                col = doc2.all as IHTMLElementCollection;
                if (col == null)
                    return elemCols;
                foreach (IHTMLElement elem in col)
                {
                    if (elem != null)
                    {
                        elemname = elem.getAttribute("name", 0) as string;
                        if ((elem.id == NameOrId) ||
                            (elemname == NameOrId))
                        {
                            elemCols.Add(elem);
                        }
                    }
                }
            }

            return elemCols;
        }

        /// <summary>
        /// Attempts to save a given url in a single file (MHT).
        /// Local cached copies of the resource are used, if available.
        /// Need to add reference to "Microsoft CDO for Windows 2000 Library" COM library.
        /// Use the UserName and Password parameters when you are requesting Web pages using HTTP from a server that requires client authentication.
        /// If the Web server supports only the basic authentication mechanism, these credentials must be supplied.
        /// If the Web server supports the NTLM authentication mechanism, by default, the current process security context is used to authenticate; however, you can specify alternate credentials for NTLM authentication with the UserName and Password parameters.
        /// <code>cEXWB1.Navigate("http://www.yahoo.com"); cEXWB1.SavePageAsMHT(cEXWB1.LocationUrl, "C:\\yahoo.mht", "", "");</code>
        /// </summary>
        /// <param name="url">A valid URL. Webbrowser.LocationUrl</param>
        /// <param name="filename">Local file name with mht extension</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        //public void SavePageAsMHT(string url, string filename, string username, string password)
        //{
        //    //Create an instance of MessageClass
        //    CDO.MessageClass msg = new CDO.MessageClass();
        //    if (msg == null)
        //        throw new Exception("Unable to create an instance of CDO.MessageClass.");
        //    //Create the MHTML, Adjust CdoMHTMLFlags for desired results
        //    msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressBGSounds | 
        //        CDO.CdoMHTMLFlags.cdoSuppressObjects, username, password);
        //    //Get the stream
        //    ADODB.Stream pstream  = msg.GetStream() as ADODB.Stream;
        //    //Save the file
        //    if(pstream != null)
        //        pstream.SaveToFile(filename, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
        //}

        #endregion

        #region Interfaces Implementation

        #region IOleClientSite Members

        int IOleClientSite.SaveObject()
        {
            return Hresults.E_NOTIMPL;
            //throw new Exception("The method or operation is not implemented.");
        }

        int IOleClientSite.GetMoniker(uint dwAssign, uint dwWhichMoniker, out IMoniker ppmk)
        {
            ppmk = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.GetContainer(out IOleContainer ppContainer)
        {
            ppContainer = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.ShowObject()
        {
            return Hresults.S_OK;
        }

        int IOleClientSite.OnShowWindow(bool fShow)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.RequestNewObjectLayout()
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region IOleInPlaceSite Members

        int IOleInPlaceSite.GetWindow(ref IntPtr phwnd)
        {
            phwnd = IntPtr.Zero;
            if (this.IsHandleCreated)
            {
                phwnd = this.Handle;
                return Hresults.S_OK;
            }
            else
                return Hresults.E_FAIL;
        }

        int IOleInPlaceSite.ContextSensitiveHelp(bool fEnterMode)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.CanInPlaceActivate()
        {
            return Hresults.S_OK;
        }

        int IOleInPlaceSite.OnInPlaceActivate()
        {
            if (!this.DesignMode)
            {
                Application.DoEvents();
                m_ieServerWindow = new IEServerWindow(this);
            }
            return Hresults.S_OK;
        }

        int IOleInPlaceSite.OnUIActivate()
        {
            if ((!this.DesignMode) &&
                (m_ieServerWindow != null) &&
                (m_ieServerWindow.Handle.Equals(IntPtr.Zero)))
                m_ieServerWindow.SetupSubclassing();
            return Hresults.S_OK;
        }

        int IOleInPlaceSite.GetWindowContext(out IOleInPlaceFrame ppFrame, out IOleInPlaceUIWindow ppDoc, ref tagRECT lprcPosRect, ref tagRECT lprcClipRect, ref tagOIFI lpFrameInfo)
        {
            ppDoc = null;
            ppFrame = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.Scroll(ref tagSIZE scrollExtent)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.OnUIDeactivate(bool fUndoable)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.OnInPlaceDeactivate()
        {
            if ((!this.DesignMode) && (m_ieServerWindow != null))
            {
                m_ieServerWindow.Release();
                m_ieServerWindow = null;
            }
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.DiscardUndoState()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.DeactivateAndUndo()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleInPlaceSite.OnPosRectChange(ref tagRECT lprcPosRect)
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region IDocHostShowUI Members
        //Can not catch VBScript MsgBox and InputBox functions and javascript prompt
        //This does catch alert and confirm (VBScript as well)
        int IDocHostShowUI.ShowMessage(IntPtr hwnd, string lpstrText,
            string lpstrCaption, uint dwType,
            string lpstrHelpFile, uint dwHelpContext, ref int lpResult)
        {
            //Initially
            //lpResult is set 0 //S_OK

            //Host did not display its UI. MSHTML displays its message box.
            int iRet = Hresults.S_FALSE;

            //raise event?
            if (WBDocHostShowUIShowMessage != null)
            {
                //Refer to http://msdn2.microsoft.com/en-us/library/ms645505.aspx
                //for possible values of dwType
                DocHostShowUIShowMessageEvent.SetParameters(hwnd, lpstrText, lpstrCaption, dwType, lpstrHelpFile, dwHelpContext, lpResult);
                WBDocHostShowUIShowMessage(this, DocHostShowUIShowMessageEvent);
                if (DocHostShowUIShowMessageEvent.handled)
                {
                    //Host displayed its user interface (UI). MSHTML does not display its message box.
                    iRet = Hresults.S_OK;
                    lpResult = DocHostShowUIShowMessageEvent.result;
                }
                DocHostShowUIShowMessageEvent.Reset();
            }
            ////uncomment to use
            //else
            //{
            //  lpResult = (int)WinApis.MessageBox(hwnd, lpstrText, lpstrCaption, dwType);
            //  iRet = Hresults.S_OK;
            //}
            return iRet;
        }

        int IDocHostShowUI.ShowHelp(IntPtr hwnd, string pszHelpFile, uint uCommand, uint dwData, tagPOINT ptMouse, object pDispatchObjectHit)
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region IDocHostUIHandler Members

        int IDocHostUIHandler.ShowContextMenu(uint dwID, ref tagPOINT pt, object pcmdtReserved, object pdispReserved)
        {
            // return Hresults.S_OK; //Do not display context menu
            // return Hresults.S_FALSE; //Default IE ctxmnu

            //Raise event
            if (WBContextMenu != null)
            {
                //Screen coordinates
                Point outpt = new Point(pt.X, pt.Y);
                //Client coordinates
                Point clientpt = this.PointToClient(outpt);
                IHTMLElement elem = this.ElementFromPoint(clientpt.X, clientpt.Y);

                ContextMenuEvent.SetParameters((WB_CONTEXTMENU_TYPES)dwID, outpt, clientpt, elem, elem);
                WBContextMenu(this, ContextMenuEvent);
                if (ContextMenuEvent.displaydefault == false) //Handled or don't display
                    return Hresults.S_OK;
                ContextMenuEvent.dispctxmenuobj = null;
                ContextMenuEvent.ctxmenuelem = null;
            }
            return Hresults.S_FALSE;
        }

        int IDocHostUIHandler.GetHostInfo(ref DOCHOSTUIINFO info)
        {
            //Default, selecttext+no3dborder+flatscrollbars+themes(xp look)
            //Size has be set
            info.cbSize = (uint)Marshal.SizeOf(info);
            info.dwDoubleClick = (uint)m_DocHostUiDbClkFlag;
            info.dwFlags = (uint)m_DocHostUiFlags;
            //info.pchHostCss = "BODY {background-color:#ffcccc}";
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.ShowUI(int dwID, IOleInPlaceActiveObject activeObject, IOleCommandTarget commandTarget, IOleInPlaceFrame frame, IOleInPlaceUIWindow doc)
        {
            //activeObject.GetWindow should return Internet Explorer_Server hwnd
            if (activeObject != null)
                activeObject.GetWindow(ref m_hWBServerHandle);
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.HideUI()
        {
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.UpdateUI()
        {
            return Hresults.S_OK;
        }

        int IDocHostUIHandler.EnableModeless(bool fEnable)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.OnDocWindowActivate(bool fActivate)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.OnFrameWindowActivate(bool fActivate)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.ResizeBorder(ref tagRECT rect, IOleInPlaceUIWindow doc, bool fFrameWindow)
        {
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.TranslateAccelerator(ref tagMSG msg, ref Guid group, uint nCmdID)
        {
            //    return Hresults.S_OK; //Cancel
            //    return Hresults.S_FALSE; //IE default action
            Keys nVirtExtKey = Keys.None; // (int)0;
            if ((ModifierKeys & Keys.Control) != 0)
                nVirtExtKey = Keys.ControlKey; //CONTROL 17
            if ((ModifierKeys & Keys.ShiftKey) != 0)
                nVirtExtKey = Keys.ShiftKey; //SHIFT 16
            if ((ModifierKeys & Keys.Menu) != 0)
                nVirtExtKey = Keys.Menu; //ALT 18
            Keys keyCode = (Keys)msg.wParam;

            if ((msg.message == WindowsMessages.WM_KEYDOWN) && (WBKeyDown != null))
            {
                WBKeyDownEvent.SetParameters(keyCode, nVirtExtKey);
                WBKeyDown(this, WBKeyDownEvent);
                if (WBKeyDownEvent.handled)
                    return Hresults.S_OK;
            }
            if ((msg.message == WindowsMessages.WM_KEYUP) && (WBKeyUp != null))
            {
                WBKeyUpEvent.SetParameters(keyCode, nVirtExtKey);
                WBKeyUp(this, WBKeyUpEvent);
                if (WBKeyUpEvent.handled == true)
                    return Hresults.S_OK;
            }
            //IE default action
            return Hresults.S_FALSE;
        }

        int IDocHostUIHandler.GetOptionKeyPath(out string pbstrKey, uint dw)
        {
            //pbstrKey[0] = null;
            pbstrKey = null;
            if (WBGetOptionKeyPath != null)
            {
                GetOptionKeyPathEvent.SetParameters();
                WBGetOptionKeyPath(this, GetOptionKeyPathEvent);
                if (GetOptionKeyPathEvent.handled == true)
                {
                    pbstrKey = GetOptionKeyPathEvent.keypath;
                    GetOptionKeyPathEvent.SetParameters();
                    return Hresults.S_OK;
                }
            }
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.GetDropTarget(IfacesEnumsStructsClasses.IDropTarget pDropTarget, out IfacesEnumsStructsClasses.IDropTarget ppDropTarget)
        {
            int hret = Hresults.E_NOTIMPL;
            ppDropTarget = null;
            if (m_bUseInternalDragDrop)
            {
                ppDropTarget = this as IfacesEnumsStructsClasses.IDropTarget;
                if (ppDropTarget != null)
                    hret = Hresults.S_OK;
            }
            return hret;
        }

        int IDocHostUIHandler.GetExternal(out object ppDispatch)
        {
            //Set to new Object() so as to avoid scripts checking for window.external
            //causing the javascript error "not implemented" being generated
            if (m_WinExternal == null)
                m_WinExternal = new object();
            //if (m_WinExternal != null)
            //{
            ppDispatch = m_WinExternal;
            return Hresults.S_OK;
            //}
            //else
            //{
            //    ppDispatch = null;
            //    return Hresults.E_NOTIMPL;
            //}
        }

        int IDocHostUIHandler.TranslateUrl(uint dwTranslate, string strURLIn, out string pstrURLOut)
        {
            pstrURLOut = null;
            return Hresults.E_NOTIMPL;
        }

        int IDocHostUIHandler.FilterDataObject(System.Runtime.InteropServices.ComTypes.IDataObject pDO, out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet)
        {
            ppDORet = null;
            return Hresults.E_NOTIMPL;
        }

        #endregion

        #region DWebBrowserEvents2 Members

        [System.Runtime.InteropServices.DispId(250)]
        void DWebBrowserEvents2.BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            //For catching Refresh and coordinating events
            m_nPageCounter++;
            bool bTopFrame = m_WBWebBrowser2.Equals(pDisp);

            if (bTopFrame)
                m_DocDone = false;

            ////Want events
            //if( m_WantHTMLEvents )
            //{
            //    //Top level
            //    if (bTopFrame)
            //    {
            //        if (m_WantHtmlDocumentEvents)
            //            m_TopLevelHtmlDocumentevents.DisconnectHtmlEvents();
            //        if (m_WantHtmlWindowEvents)
            //            m_TopLevelHtmlWindowEvents.DisconnectHtmlEvents();
            //    }
            //    else //Secondary pages (frameset)
            //    {
            //        //Want events and we don't bother with navigation within framesets
            //        if ((m_WantHtmlDocumentEvents) && (m_nPageCounter > 1) )
            //            DisconnectHtmlDocumentEvents();

            //        if( (m_WantHtmlWindowEvents) && (m_nPageCounter > 1) )
            //            DisconnectHtmlWindowEvnets();
            //    }
            //}

            if (BeforeNavigate2 != null)
            {
                //Reserved, must be set to null
                Flags = null;
                string surl = string.Empty;
                if (URL != null)
                    surl = URL.ToString();
                BeforeNavigate2Event.SetParameters(pDisp, surl, TargetFrameName, PostData, Headers, bTopFrame);
                BeforeNavigate2(this, BeforeNavigate2Event);
                Cancel = BeforeNavigate2Event.Cancel;
                BeforeNavigate2Event.Reset();
            }
        }

        [DispId(268)]
        void DWebBrowserEvents2.ClientToHostWindow(ref int CX, ref int CY)
        {
            if (ClientToHostWindow != null)
            {
                ClientToHostWindowEvent.SetParameters(CX, CY);
                ClientToHostWindow(this, ClientToHostWindowEvent);
                if (ClientToHostWindowEvent.handled == true)
                {
                    CX = ClientToHostWindowEvent.cx;
                    CY = ClientToHostWindowEvent.cy;
                }
            }
        }

        [DispId(105)]
        void DWebBrowserEvents2.CommandStateChange(int Command, bool Enable)
        {
            if (Command == (int)CommandStateChangeConstants.CSC_NAVIGATEBACK)
                m_bCanGoBack = Enable;
            else if (Command == (int)CommandStateChangeConstants.CSC_NAVIGATEFORWARD)
                m_bCanGoForward = Enable;

            if (CommandStateChange != null)
            {
                CommandStateChangeEvent.SetParameters(Command, Enable);
                CommandStateChange(this, CommandStateChangeEvent);
            }
        }

        [DispId(104)]
        void DWebBrowserEvents2.DocumentComplete(object pDisp, ref object URL)
        {
            m_nPageCounter--;
            //Compare the IUnknowns for equality
            bool bTopFrame = m_WBWebBrowser2.Equals(pDisp);
            if (bTopFrame)
                m_DocDone = true;

            //Hooking to onload and onunload events of the toplevel and
            //any frames present
            if (bTopFrame)
            {
                IHTMLDocument2 doc2 = (IHTMLDocument2)m_WBWebBrowser2.Document;
                IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
                win2.onload = new GenericElementEventHandler(this.TopLevelOnLoadEvent, null, win2.onload, "onload");
                win2.onunload = new GenericElementEventHandler(this.TopLevelOnUnloadEvent, null, win2.onunload, "onunload");
                //To receive notification when a document DOM has changed
                SetupDocumentChangeNotification((IHTMLDocument4)m_WBWebBrowser2.Document);
            }
            else
            {
                IWebBrowser2 wb2 = (IWebBrowser2)pDisp;
                IHTMLDocument2 doc2 = (IHTMLDocument2)wb2.Document;
                IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
                win2.onload = new GenericElementEventHandler(this.SecondaryOnLoadEvent, wb2, win2.onload, "onload");
                win2.onunload = new GenericElementEventHandler(this.SecondaryOnUnloadEvent, wb2, win2.onunload, "onunload");
            }
            string surl = string.Empty;
            if (m_bSendSourceOnDocumentCompleteWBEx) //want source?
            {
                if (DocumentCompleteEX != null)
                {
                    //Declare vars
                    string strSource = "";
                    IWebBrowser2 thisBrowser = null;
                    if (URL != null)
                        surl = URL.ToString();
                    //Reset event object parameters
                    DocumentCompleteExEvent.SetParameters(pDisp, surl, bTopFrame, strSource);

                    //Attempt to get a IWebBrowser2 iface from disp
                    //throws an exception if not an html doc
                    thisBrowser = (IWebBrowser2)pDisp;
                    if (thisBrowser == null)
                        return;

                    strSource = GetSource(thisBrowser);
                    DocumentCompleteExEvent.docsource = strSource;
                    DocumentCompleteEX(this, DocumentCompleteExEvent);
                    DocumentCompleteExEvent.Reset();
                }
            }
            else if (DocumentComplete != null) //Do not want source
            {
                if (URL != null)
                    surl = URL.ToString();
                DocumentCompleteEvent.SetParameters(pDisp, surl, bTopFrame);
                DocumentComplete(this, DocumentCompleteEvent);
                DocumentCompleteEvent.Reset();
            }
            //Go to MSDN library(archive) + stop + refresh
            //without this, refresh end hits somewhere in between documentCompletes
            if ((m_bIsRefresh) && (m_nPageCounter == 0) && (m_nObjCounter == 0))
            {
                m_bIsRefresh = false;
                if (RefreshEnd != null)
                    RefreshEnd(this);
            }
        }

        [DispId(106)]
        void DWebBrowserEvents2.DownloadBegin()
        {
            m_nObjCounter++;
            if (DownloadBegin != null)
                DownloadBegin(this);
            if (m_nPageCounter == 0)
            {
                m_bIsRefresh = true;
                if (RefreshBegin != null)
                    RefreshBegin(this);
            }
        }

        [DispId(259)]
        void DWebBrowserEvents2.DownloadComplete()
        {
            m_nObjCounter--;
            if (DownloadComplete != null)
                DownloadComplete(this);
            if ((m_bIsRefresh) && (m_nPageCounter == 0) && (m_nObjCounter == 0))
            {
                m_bIsRefresh = false;
                if (RefreshEnd != null)
                    RefreshEnd(this);
            }
        }

        [DispId(270)]
        void DWebBrowserEvents2.FileDownload(bool ActiveDocument, ref bool Cancel)
        {
            if ((FileDownload != null) && (m_UseInternalDownloadManager == false))
            {
                FileDownloadEvent.Cancel = false;
                FileDownloadEvent.ActiveDocument = ActiveDocument;
                FileDownload(this, FileDownloadEvent);
                Cancel = FileDownloadEvent.Cancel;
            }
        }

        [DispId(252)]
        void DWebBrowserEvents2.NavigateComplete2(object pDisp, ref object URL)
        {
            if (NavigateComplete2 != null)
            {
                string surl = string.Empty;
                if (URL != null)
                    surl = URL.ToString();
                bool bTopFrame = m_WBWebBrowser2.Equals(pDisp);
                NavigateComplete2Event.SetParameters(pDisp, surl, bTopFrame);
                NavigateComplete2(this, NavigateComplete2Event);
                NavigateComplete2Event.Reset();
            }
        }

        [DispId(271)]
        void DWebBrowserEvents2.NavigateError(object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel)
        {
            if (NavigateError != null)
            {
                string surl = string.Empty;
                if (URL != null)
                    surl = URL.ToString();
                if (Frame != null) //Thank you Arjan
                    NavigateErrorEvent.SetParameters(pDisp, surl, Frame.ToString(), (int)StatusCode);
                else
                    NavigateErrorEvent.SetParameters(pDisp, surl, string.Empty, (int)StatusCode);
                NavigateError(this, NavigateErrorEvent);
                Cancel = NavigateErrorEvent.Cancel;
                NavigateErrorEvent.Reset();
            }
        }

        [DispId(251)]
        void DWebBrowserEvents2.NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            if (NewWindow2 != null)
            {
                NewWindow2Event.SetParameters();
                NewWindow2(this, NewWindow2Event);
                Cancel = NewWindow2Event.Cancel;
                if ((!Cancel) && (NewWindow2Event.browser != null))
                {
                    ppDisp = NewWindow2Event.browser;
                }
                NewWindow2Event.SetParameters();
            }
        }

        [DispId(0x111)]
        void DWebBrowserEvents2.NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {

            if (NewWindow3 != null)
            {
                NewWindow3Event.SetParameters(bstrUrlContext, bstrUrl, (NWMF)dwFlags);
                NewWindow3(this, NewWindow3Event);
                Cancel = NewWindow3Event.Cancel;
                if ((!Cancel) && (NewWindow3Event.browser != null))
                {
                    ppDisp = NewWindow3Event.browser;
                }
                NewWindow3Event.Reset();
            }
        }

        #region Unused Events
        void DWebBrowserEvents2.OnFullScreen(bool FullScreen)
        {
            //
        }

        void DWebBrowserEvents2.OnMenuBar(bool MenuBar)
        {
            //
        }

        void DWebBrowserEvents2.OnQuit()
        {
            //
        }

        void DWebBrowserEvents2.OnStatusBar(bool StatusBar)
        {
            //
        }

        void DWebBrowserEvents2.OnTheaterMode(bool TheaterMode)
        {
            //
        }

        void DWebBrowserEvents2.OnToolBar(bool ToolBar)
        {
            //
        }

        void DWebBrowserEvents2.OnVisible(bool Visible)
        {
            //
        }
        #endregion

        [DispId(227)]
        void DWebBrowserEvents2.UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
        {
            if (UpdatePageStatus != null)
            {
                if (nPage != null)
                    UpdatePageStatusEvent.SetParameters(pDisp, (int)nPage, (bool)fDone);
                else
                    UpdatePageStatusEvent.SetParameters(pDisp, 0, (bool)fDone);
                UpdatePageStatus(this, UpdatePageStatusEvent);
                UpdatePageStatusEvent.Reset();
            }
        }

        [DispId(225)]
        void DWebBrowserEvents2.PrintTemplateInstantiation(object pDisp)
        {
            if (PrintTemplateInstantiation != null)
            {
                PrintTemplateInstantiationEvent.browser = pDisp;
                PrintTemplateInstantiation(this, PrintTemplateInstantiationEvent);
                PrintTemplateInstantiationEvent.browser = null;
            }
        }

        [DispId(226)]
        void DWebBrowserEvents2.PrintTemplateTeardown(object pDisp)
        {
            if (PrintTemplateTeardown != null)
            {
                PrintTemplateTeardownEvent.browser = pDisp;
                PrintTemplateTeardown(this, PrintTemplateTeardownEvent);
                PrintTemplateTeardownEvent.browser = null;
            }
        }

        [DispId(272)]
        void DWebBrowserEvents2.PrivacyImpactedStateChange(bool bImpacted)
        {
            if (PrivacyImpactedStateChange != null)
            {
                PrivacyImpactedStateChangeEvent.impacted = bImpacted;
                PrivacyImpactedStateChange(this, PrivacyImpactedStateChangeEvent);
            }
        }

        [DispId(108)]
        void DWebBrowserEvents2.ProgressChange(int Progress, int ProgressMax)
        {
            if (ProgressChange != null)
            {
                ProgressChangeEvent.SetParameters(Progress, ProgressMax);
                ProgressChange(this, ProgressChangeEvent);
            }
        }

        [DispId(112)]
        void DWebBrowserEvents2.PropertyChange(string szProperty)
        {
            if (PropertyChange != null)
            {
                PropertyChangeEvent.szproperty = szProperty;
                PropertyChange(this, PropertyChangeEvent);
                PropertyChangeEvent.szproperty = string.Empty;
            }
        }

        [DispId(269)]
        void DWebBrowserEvents2.SetSecureLockIcon(int SecureLockIcon)
        {
            m_SecureLockIcon = SecureLockIcon;
            if (SetSecureLockIcon != null)
            {
                SetSecureLockIconEvent.SetParameters(SecureLockIcon);
                SetSecureLockIcon(this, SetSecureLockIconEvent);
            }
        }

        [DispId(102)]
        void DWebBrowserEvents2.StatusTextChange(string Text)
        {
            if (StatusTextChange != null)
            {
                StatusTextChangeEvent.text = Text;
                StatusTextChange(this, StatusTextChangeEvent);
                StatusTextChangeEvent.text = string.Empty;
            }
        }

        [DispId(113)]
        void DWebBrowserEvents2.TitleChange(string Text)
        {
            if (TitleChange != null)
            {
                TitleChangeEvent.title = Text;
                TitleChange(this, TitleChangeEvent);
                TitleChangeEvent.title = "";
            }
        }

        //DWebBrowserEvents2.WindowClosing is never called?
        //So here is the workaround
        [DispId(263)]
        public void DISPATCH_WindowClosing(bool IsChildWindow, ref bool Cancel)
        {
            if (WindowClosing != null)
            {
                WindowClosingEvent.SetParameters(IsChildWindow);
                WindowClosing(this, WindowClosingEvent);
                Cancel = WindowClosingEvent.Cancel;
            }
        }

        [DispId(263)]
        void DWebBrowserEvents2.WindowClosing(bool IsChildWindow, ref bool Cancel)
        {
        }

        [DispId(267)]
        void DWebBrowserEvents2.WindowSetHeight(int Height)
        {
            if (WindowSetHeight != null)
            {
                WindowSetHeightEvent.height = Height;
                WindowSetHeight(this, WindowSetHeightEvent);
            }
        }

        [DispId(264)]
        void DWebBrowserEvents2.WindowSetLeft(int Left)
        {
            if (WindowSetLeft != null)
            {
                WindowSetLeftEvent.left = Left;
                WindowSetLeft(this, WindowSetLeftEvent);
            }
        }

        [DispId(262)]
        void DWebBrowserEvents2.WindowSetResizable(bool Resizable)
        {
            if (WindowSetResizable != null)
            {
                WindowSetResizableEvent.resizable = Resizable;
                WindowSetResizable(this, WindowSetResizableEvent);
            }
        }

        [DispId(265)]
        void DWebBrowserEvents2.WindowSetTop(int Top)
        {
            if (WindowSetTop != null)
            {
                WindowSetTopEvent.top = Top;
                WindowSetTop(this, WindowSetTopEvent);
            }
        }

        [DispId(266)]
        void DWebBrowserEvents2.WindowSetWidth(int Width)
        {
            if (WindowSetWidth != null)
            {
                WindowSetWidthEvent.width = Width;
                WindowSetWidth(this, WindowSetWidthEvent);
            }
        }

        #endregion

        #region IDropTarget Members

        int IfacesEnumsStructsClasses.IDropTarget.DragEnter(System.Runtime.InteropServices.ComTypes.IDataObject pDataObj, uint grfKeyState, tagPOINT pt, ref uint pdwEffect)
        {
            if (WBDragEnter != null)
            {
                DataObject obja = null;
                if (pDataObj != null)
                    obja = new DataObject(pDataObj);
                Point ppt = new Point(pt.X, pt.Y);
                WBDragEnterEvent.SetParameters(obja, grfKeyState, ppt, pdwEffect);
                WBDragEnter(this, WBDragEnterEvent);
                if (WBDragEnterEvent.handled == true)
                    pdwEffect = (uint)WBDragEnterEvent.dropeffect;
            }
            return Hresults.S_OK;
        }
        int IfacesEnumsStructsClasses.IDropTarget.DragOver(uint grfKeyState, tagPOINT pt, ref uint pdwEffect)
        {
            if (WBDragOver != null)
            {
                Point ppt = new Point(pt.X, pt.Y);
                WBDragOverEvent.SetParameters(grfKeyState, ppt, pdwEffect);
                WBDragOver(this, WBDragOverEvent);
                if (WBDragOverEvent.handled == true)
                    pdwEffect = (uint)WBDragOverEvent.dropeffect;
            }
            return Hresults.S_OK;
        }
        int IfacesEnumsStructsClasses.IDropTarget.DragLeave()
        {
            if (WBDragLeave != null)
                WBDragLeave(this);
            return Hresults.S_OK;
        }
        int IfacesEnumsStructsClasses.IDropTarget.Drop(System.Runtime.InteropServices.ComTypes.IDataObject pDataObj, uint grfKeyState, tagPOINT pt, ref uint pdwEffect)
        {
            if (pDataObj == null)
                return Hresults.S_OK;
            if (WBDragDrop != null)
            {
                DataObject obja = new DataObject(pDataObj);
                Point ppt = new Point(pt.X, pt.Y);
                WBDropEvent.SetParameters(grfKeyState, ppt, obja, pdwEffect);
                WBDragDrop(this, WBDropEvent);
                if (WBDropEvent.handled == true)
                    pdwEffect = (uint)WBDropEvent.dropeffect;
            }
            return Hresults.S_OK;
        }

        #endregion

        #region IOleCommandTarget Members

        int IOleCommandTarget.QueryStatus(IntPtr pguidCmdGroup, uint cCmds, ref tagOLECMD prgCmds, IntPtr pCmdText)
        {
            //int hr = Hresults.S_OK;
            //if (m_WBOleCommandTarget != null)
            //{
            //    try
            //    {
            //        hr = m_WBOleCommandTarget.QueryStatus(pguidCmdGroup,
            //            cCmds, ref prgCmds, ref pCmdText);
            //    }
            //    finally
            //    {
            //    }
            //}
            //else
            //    hr = OLECMDERR_E_NOTSUPPORTED;
            return Hresults.OLECMDERR_E_NOTSUPPORTED;
        }

        public event StopEventHandler WBStop = null;
        //pguidCmdGroup must be declared as IntPtr not a GUID, as pguidCmdGroup may be null, hence generating execption
        int IOleCommandTarget.Exec(IntPtr pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            int hr = Hresults.S_OK;

            //Catch stop
            if ((nCmdID == (int)OLECMDID.OLECMDID_STOP) && (WBStop != null))
            {
                WBStop(this);
            }

            if ((pguidCmdGroup != m_NullPointer) &&
                (Type.GetTypeCode(pguidCmdGroup.GetType()) != TypeCode.Empty))
            {
                try
                {
                    ////Allocate mem for a GUID
                    //byte[] bguid = Guid.Empty.ToByteArray();
                    ////Copy incoming into byte array
                    //Marshal.Copy(pguidCmdGroup, bguid, 0, bguid.Length);
                    ////back to GUID
                    //Guid guid = new Guid(bguid);

                    Guid guid = (Guid)Marshal.PtrToStructure(pguidCmdGroup, typeof(Guid));
                    //if( (this.m_DocDone) && (guid == Iid_Clsids.CGID_Explorer) && (nCmdID == 67) )
                    //{
                    //    //for 67 script exec, 69 timer/something is going
                    //    //66 open
                    //    //CGID_Explorer = 000214d0-0000-0000-c000-000000000046
                    //    //for 11 guid = 000214d4-0000-0000-c000-000000000046 , undocumented???
                    //    Debug.Print("IOleCommandTarget.Exec=> " + this.m_WBWebBrowser2.LocationURL);
                    //}

                    //Only group we are interested
                    //F38BC242-B950-11D1-8918-00C04FC2C836
                    if (guid == Iid_Clsids.CLSID_CGID_DocHostCommandHandler)
                    {
                        //http://support.microsoft.com/kb/261003
                        if (nCmdID == (int)OLECMDID.OLECMDID_SHOWSCRIPTERROR)
                        {
                            //false -> stop running scripts
                            if ((pvaIn != IntPtr.Zero) && (ScriptError != null))
                            {
                                //default: continueScripts = true
                                ScriptErrorEvent.SetParameters();
                                try
                                {
                                    IHTMLDocument2 doc2 = (IHTMLDocument2)Marshal.GetObjectForNativeVariant(pvaIn);
                                    IHTMLWindow2 win2 = (IHTMLWindow2)doc2.parentWindow;
                                    IHTMLEventObj2 eveobj = (IHTMLEventObj2)win2.eventobj;

                                    if (eveobj != null)
                                    {
                                        ScriptErrorEvent.lineNumber = (int)eveobj.getAttribute("errorLine", 0);
                                        ScriptErrorEvent.characterNumber = (int)eveobj.getAttribute("errorCharacter", 0);
                                        ScriptErrorEvent.errorCode = (int)eveobj.getAttribute("errorCode", 0);
                                        ScriptErrorEvent.errorMessage = eveobj.getAttribute("errorMessage", 0) as string;
                                        ScriptErrorEvent.url = eveobj.getAttribute("errorUrl", 0) as string;
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                ScriptError(this, ScriptErrorEvent);
                                if (pvaOut != IntPtr.Zero)
                                    Marshal.GetNativeVariantForObject(ScriptErrorEvent.continueScripts, pvaOut);
                                ScriptErrorEvent.SetParameters();
                            }
                            else
                            {
                                //Default Continue running scripts
                                if (pvaOut != IntPtr.Zero) //VARIANT (VT_NULL) - object (null)
                                    Marshal.GetNativeVariantForObject(true, pvaOut);
                            }
                        }
                        else
                            hr = Hresults.OLECMDERR_E_NOTSUPPORTED;
                    }
                    else
                        hr = Hresults.OLECMDERR_E_UNKNOWNGROUP;
                }
                catch (Exception)
                {
                    hr = Hresults.OLECMDERR_E_UNKNOWNGROUP;
                }
            }
            else
                hr = Hresults.OLECMDERR_E_UNKNOWNGROUP;
            return hr;
        }

        #endregion

        #region IServiceProvider Members

        int IfacesEnumsStructsClasses.IServiceProvider.QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
        {
            int hr = Hresults.E_NOINTERFACE;
            ppvObject = m_NullPointer;

            if ((guidService == Iid_Clsids.SID_SDownloadManager) &&
                (riid == Iid_Clsids.IID_IDownloadManager) &&
                (m_UseInternalDownloadManager))
            {
                AddThisIEServerHwndToComLib();
                //QI for IDownloadManager interface from our COM object
                ppvObject = Marshal.GetComInterfaceForObject(m_csexwbCOMLib, typeof(IDownloadManager));
                hr = Hresults.S_OK;
            }
            else if (riid == Iid_Clsids.IID_IHttpSecurity)
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IHttpSecurity));
                hr = Hresults.S_OK;

                //Ulternative
                //try
                //{
                //    m_pUnk = IntPtr.Zero;
                //    m_pTargetIface = IntPtr.Zero;
                //    m_pUnk = Marshal.GetIUnknownForObject(this);
                //    Marshal.QueryInterface(m_pUnk, ref IID_IHttpSecurity, out m_pTargetIface);
                //    Marshal.Release(m_pUnk);
                //    ppvObject = m_pTargetIface;
                //    hr = Hresults.S_OK;
                //}
                //catch (Exception)
                //{
                //}
            }
            else if (riid == Iid_Clsids.IID_INewWindowManager) //xpsp2
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(INewWindowManager));
                hr = Hresults.S_OK;
            }
            else if (riid == Iid_Clsids.IID_IWindowForBindingUI)
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IWindowForBindingUI));
                hr = Hresults.S_OK;
            }
            else if (guidService == Iid_Clsids.IID_IInternetSecurityManager)
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IInternetSecurityManager));
                hr = Hresults.S_OK;
            }
            else if ((guidService == Iid_Clsids.IID_IAuthenticate)
               && (riid == Iid_Clsids.IID_IAuthenticate))
            {
                try
                {
                    if (AuthenticationEvent != null)
                        AuthenticationEvent(this);
                }
                catch (Exception)
                {
                }
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IAuthenticate));
                hr = Hresults.S_OK;
            }
            else if (riid == Iid_Clsids.IID_IProtectFocus) //IE7 + Vista
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IProtectFocus));
                hr = Hresults.S_OK;
            }
            else if ((riid == Iid_Clsids.IID_IHTMLOMWindowServices) &&
                (guidService == Iid_Clsids.IID_IHTMLOMWindowServices))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IHTMLOMWindowServices));
                hr = Hresults.S_OK;
            }
            else if ((riid == Iid_Clsids.IID_IHTMLEditHost) &&
                (guidService == Iid_Clsids.SID_SHTMLEditHost))
            {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IHTMLEditHost));
                hr = Hresults.S_OK;
            }
            //else if ((riid == Iid_Clsids.IID_IUnknown) &&
            //    (guidService == Iid_Clsids.IID_ITargetFrame2))
            //{
            //    ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ITargetFrame2));
            //    hr = Hresults.S_OK;
            //}

            return hr;
        }

        #endregion

        #region IHttpSecurity Members

        int IHttpSecurity.GetWindow(ref Guid rguidReason, ref IntPtr phwnd)
        {
            phwnd = m_NullPointer;
            int hr = Hresults.S_FALSE;
            if ((rguidReason == Iid_Clsids.IID_IHttpSecurity) || (rguidReason == Iid_Clsids.IID_IAuthenticate))
            {
                if (!WBIEServerHandle().Equals(m_NullPointer))
                {
                    phwnd = m_hWBServerHandle;
                    hr = Hresults.S_OK;
                }
            }
            return hr;
        }
        int IHttpSecurity.OnSecurityProblem(uint dwProblem)
        {
            /*
            IHttpSecurity, Some possible problems:
                ERROR_INTERNET_SEC_CERT_DATE_INVALID
                ERROR_INTERNET_SEC_CERT_CN_INVALID
                ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR
                ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR
                ERROR_HTTP_REDIRECT_NEEDS_CONFIRMATION
                ERROR_INTERNET_INVALID_CA
                ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED

		    Returning S_FALSE implies that you have asked the user
		    if it is ok to proceed despite a security problem and they have agreed
		    return RPC_E_RETRY;
		    Retries using Registry options and most likely fails again
            */

            //dwProblem one of WinInetErrors enum (need more additions)
            int iRet = Hresults.S_FALSE;
            int hr = iRet;
            if (WBSecurityProblem != null)
            {
                SecurityProblemEvent.SetParameters((int)dwProblem);
                WBSecurityProblem(this, SecurityProblemEvent);
                if (SecurityProblemEvent.handled == true)
                {
                    iRet = SecurityProblemEvent.retvalue;
                    //if ((iRet == Hresults.RPC_E_RETRY) || (iRet == Hresults.S_FALSE) || (iRet == Hresults.E_ABORT))
                    hr = iRet;
                }
            }
            //Possible return values;
            //RPC_E_RETRY (cautious) The calling application should continue or retry the download. 
            //S_FALSE The calling application should open a dialog box to warn the user. 
            //E_ABORT The calling application should abort the download.
            //S_OK Undocumented - used with ERROR_INTERNET_INVALID_CA to bypass security dialog
            return hr;
        }

        #endregion

        #region IWindowForBindingUI Members

        int IWindowForBindingUI.GetWindow(ref Guid rguidReason, ref IntPtr phwnd)
        {
            phwnd = m_NullPointer;
            int hr = Hresults.S_FALSE;

            if ((rguidReason == Iid_Clsids.IID_IHttpSecurity) || (rguidReason == Iid_Clsids.IID_IAuthenticate))
            {
                if (!WBIEServerHandle().Equals(m_NullPointer))
                {
                    phwnd = m_hWBServerHandle;
                    hr = Hresults.S_OK;
                }
            }
            return hr;
        }

        #endregion

        #region INewWindowManager Members

        int INewWindowManager.EvaluateNewWindow(string pszUrl, string pszName,
            string pszUrlContext, string pszFeatures, bool fReplace, uint dwFlags, uint dwUserActionTime)
        {
            int hr = Hresults.E_FAIL; //To perform default IE action - Calls NewWindow3 else NewWindow2 else shows popup
            if (WBEvaluteNewWindow != null)
            {
                EvaluateNewWindowEvent.SetParameters(pszUrl, pszName, pszUrlContext, pszFeatures, fReplace, (int)dwFlags, (int)dwUserActionTime);
                WBEvaluteNewWindow(this, EvaluateNewWindowEvent);
                if (EvaluateNewWindowEvent.Cancel == true)
                    hr = Hresults.S_FALSE; //Block
                //hr = Hresults.S_OK; //Allow all
                EvaluateNewWindowEvent.Reset();
            }
            return hr;
        }

        #endregion

        #region IAuthenticate Members

        //To pass a doamin as in a NTLM authentication scheme, use this format: Username = Domain\username
        int IAuthenticate.Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername, ref IntPtr pszPassword)
        {
            int hr = Hresults.E_ACCESSDENIED; //to abort, to proceed Hresults.S_OK
            int iRet = hr; //Assume failure
            phwnd = this.Handle;
            pszUsername = IntPtr.Zero;
            pszPassword = IntPtr.Zero;
            if (WBAuthenticate != null)
            {
                AuthenticateEventArgs auth = new AuthenticateEventArgs();
                WBAuthenticate(this, auth);
                if (auth.handled == true)
                {
                    //Marshal.StringToCoTaskMemAuto
                    pszUsername = Marshal.StringToCoTaskMemUni(auth.username);
                    pszPassword = Marshal.StringToCoTaskMemUni(auth.password);
                    iRet = auth.retvalue; //Should be 0
                }
                //accepted return values
                if ((iRet == Hresults.S_OK) || (iRet == Hresults.E_INVALIDARG) || (iRet == Hresults.E_ACCESSDENIED))
                    hr = iRet;
            }
            return hr;
        }

        #endregion

        #region IInternetSecurityManager Members

        int IInternetSecurityManager.SetSecuritySite(IntPtr pSite)
        {
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.GetSecuritySite(out IntPtr pSite)
        {
            pSite = IntPtr.Zero;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.MapUrlToZone(string pwszUrl, out uint pdwZone, uint dwFlags)
        {
            // All URLs are on the local machine - most trusted and return S_OK;
            //pdwZone = (uint)tagURLZONE.URLZONE_LOCAL_MACHINE;
            //pdwZone =  (uint)tagURLZONE.URLZONE_INTRANET;
            //pdwZone =  (uint)tagURLZONE.URLZONE_TRUSTED; //....
            //return Hresults.S_OK;
            pdwZone = 0;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        //private const string m_strSecurity = "None:localhost+My Computer";
        int IInternetSecurityManager.GetSecurityId(string pwszUrl, IntPtr pbSecurityId, ref uint pcbSecurityId, ref uint dwReserved)
        {
            //pbSecurityId = Marshal.StringToCoTaskMemUni(m_strSecurity);
            //pcbSecurityId = (uint)m_strSecurity.Length;
            //return Hresults.S_OK;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        /*
        MSDN:
        The current list of URLACTION that will not be passed to the custom security manager
        in most circumstances by Internet Explorer 5 are:
            URLACTION_SHELL_FILE_DOWNLOAD 
            URLACTION_COOKIES 
            URLACTION_JAVA_PERMISSIONS 
            URLACTION_SCRIPT_PASTE 
        There is no workaround for this problem. The behavior for the URLACTION can only be
        changed for all browser clients on the system by altering the security zone settings
        from Internet Options.
        */
        int IInternetSecurityManager.ProcessUrlAction(string pwszUrl, uint dwAction, IntPtr pPolicy, uint cbPolicy, IntPtr pContext, uint cbContext, uint dwFlags, uint dwReserved)
        {
            if (ProcessUrlAction == null)
                return (int)WinInetErrors.INET_E_DEFAULT_ACTION;

            try
            {
                URLACTION action = (URLACTION)dwAction;
                ProcessUrlActionFlags flags = (ProcessUrlActionFlags)dwFlags;
                bool hasUrlPolicy = (cbPolicy >= unchecked((uint)Marshal.SizeOf(typeof(int))));
                URLPOLICY urlPolicy = (hasUrlPolicy) ? urlPolicy = (URLPOLICY)Marshal.ReadInt32(pPolicy) : URLPOLICY.ALLOW;
                bool hasContext = (cbContext >= unchecked((uint)Marshal.SizeOf(typeof(Guid))));
                Guid context = (hasContext) ? (Guid)Marshal.PtrToStructure(pContext, typeof(Guid)) : Guid.Empty;

                ProcessUrlActionEvent.SetParameters(pwszUrl, action, urlPolicy, context, flags, hasContext);
                ProcessUrlAction(this, ProcessUrlActionEvent);

                if (ProcessUrlActionEvent.handled && hasUrlPolicy)
                {
                    Marshal.WriteInt32(pPolicy, (int)ProcessUrlActionEvent.urlPolicy);
                    return (ProcessUrlActionEvent.Cancel) ? Hresults.S_FALSE : Hresults.S_OK;
                }
            }
            finally
            {
                ProcessUrlActionEvent.ResetParameters();
            }

            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.QueryCustomPolicy(string pwszUrl, ref Guid guidKey, out IntPtr ppPolicy, out uint pcbPolicy, IntPtr pContext, uint cbContext, uint dwReserved)
        {
            ppPolicy = IntPtr.Zero;
            pcbPolicy = 0;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.SetZoneMapping(uint dwZone, string lpszPattern, uint dwFlags)
        {
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        int IInternetSecurityManager.GetZoneMappings(uint dwZone, out IEnumString ppenumString, uint dwFlags)
        {
            ppenumString = null;
            return (int)WinInetErrors.INET_E_DEFAULT_ACTION;
        }

        #endregion

        #region IProtectFocus Members

        void IProtectFocus.AllowFocusChange(ref bool pfAllow)
        {
            if (AllowFocusChange != null)
            {
                AllowFocusChangeEvent.Cancel = false;
                AllowFocusChange(this, AllowFocusChangeEvent);
                if (AllowFocusChangeEvent.Cancel)
                    pfAllow = false;
            }
        }

        #endregion

        #region IHTMLOMWindowServices Members

        void IHTMLOMWindowServices.moveTo(int x, int y)
        {
            if (HTMLOMWindowServices_moveTo != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_moveTo(this, HTMLOMWindowServicesEvent);
            }
        }

        void IHTMLOMWindowServices.moveBy(int x, int y)
        {
            if (HTMLOMWindowServices_moveBy != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_moveBy(this, HTMLOMWindowServicesEvent);
            }
        }

        void IHTMLOMWindowServices.resizeTo(int x, int y)
        {
            if (HTMLOMWindowServices_resizeTo != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_resizeTo(this, HTMLOMWindowServicesEvent);
            }
        }

        void IHTMLOMWindowServices.resizeBy(int x, int y)
        {
            if (HTMLOMWindowServices_resizeBy != null)
            {
                HTMLOMWindowServicesEvent.SetParameters(x, y);
                HTMLOMWindowServices_resizeBy(this, HTMLOMWindowServicesEvent);
            }
        }

        #endregion

        #endregion //Interfaces Implementation

        #region Subclassing IEServer

        /// <summary>
        /// Class to enable this control to catch and react to a number of
        /// Webbrowser events which are not otherwise easily accessible.
        /// Example would be back and forward mouse buttons
        /// (calls webbrowser GoBack and GoForward methods).
        /// When focus is lost to deactivate , LButtonDown, LButtonUp, MouseMove.
        /// Initiated in IOleInPlaceSite.OnUIActivate
        /// Deactivated in OnUIDeactivate
        /// Contributed by logan1337 - Aug 13 2007
        /// http://www.codeproject.com/cs/miscctrl/csEXWB.asp?df=100&forumid=422031&select=2180453#xx2180453xx
        /// </summary>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        internal class IEServerWindow : NativeWindow
        {
            //Local variables
            private bool m_mouseclicked = false;
            private int m_LParam = 0;
            private int m_WParam = 0;
            private int m_clientx = 0;
            private int m_clienty = 0;
            private int m_offsetx = 0;
            private int m_offsety = 0;
            private bool m_ctrl = false;
            private bool m_shift = false;
            private string m_tagname = string.Empty;
            //Ref to our control
            private cEXWB browser;
            private int m_Attempts = 0;

            //Timer procedure
            private void TimerProc(object state)
            {
                System.Threading.Timer t = (System.Threading.Timer)state;

                if (!this.browser.IEServerHwnd.Equals(IntPtr.Zero))
                {
                    t.Dispose();
                    if (WinApis.IsWindow(this.browser.IEServerHwnd)
                        && (this.Handle.Equals(IntPtr.Zero)))
                        AssignHandle(this.browser.IEServerHwnd);
                }
                else
                {
                    m_Attempts++;
                    if (m_Attempts >= 5) //5 attempts
                        t.Dispose();
                    else
                        t.Change(2000, 0);
                }
            }

            public IEServerWindow(cEXWB wb)
            {
                this.browser = wb;
                SetupSubclassing();
            }

            internal void SetupSubclassing()
            {
                //This does not always succeed.
                //So I am using a timer to attempt to get
                //the IE server HWND after 2 seconds
                if (!this.browser.IEServerHwnd.Equals(IntPtr.Zero))
                {
                    if (WinApis.IsWindow(this.browser.IEServerHwnd)
                        && (this.Handle.Equals(IntPtr.Zero)))
                        AssignHandle(this.browser.IEServerHwnd);
                }
                else
                {

                    m_Attempts++;
                    //System.Windows.Forms.Timer tt = new System.Windows.Forms.Timer();
                    System.Threading.Timer m_timer = new System.Threading.Timer(TimerProc);
                    m_timer.Change(2000, 0);
                }
            }

            public void Release()
            {
                ReleaseHandle();
            }

            private bool FireMouseEvent(int ievent)
            {
                //Allow default processing
                bool result = false;

                IHTMLElement elem = null;
                m_offsetx = 0;
                m_offsety = 0;

                //Get client x + y coordinates of mouse
                m_clientx = WinApis.GET_X_LPARAM(m_LParam);
                m_clienty = WinApis.GET_Y_LPARAM(m_LParam);

                //Determine if Ctrl + Shift are down
                m_ctrl = ((m_WParam & (int)KeyStateMasks.MK_CONTROL) != 0);
                m_shift = ((m_WParam & (int)KeyStateMasks.MK_SHIFT) != 0);

                //Get the main document
                IHTMLDocument2 pdoc2 = browser.WebbrowserObject.Document as IHTMLDocument2;

                if (pdoc2 != null)
                {
                    elem = pdoc2.elementFromPoint(m_clientx, m_clienty);
                }

                //Get the tagname
                if (elem != null)
                    m_tagname = elem.tagName.ToLower();

                //Do we have a frame or iframe?
                if ((!string.IsNullOrEmpty(m_tagname)) &&
                    ((m_tagname == "frame") || (m_tagname == "iframe"))
                    )
                {
                    IHTMLElement offsetparent = elem.offsetParent;
                    IHTMLElement2 elem2 = null;

                    //Account for offsetLeft, offsetTop, scrollLeft, scrollTop

                    //First get the main document scrolltop and scrollleft
                    IHTMLDocument3 pdoc3 = browser.WebbrowserObject.Document as IHTMLDocument3;
                    if (pdoc3 != null)
                    {
                        elem2 = pdoc3.documentElement as IHTMLElement2;
                        if (elem2 != null)
                        {
                            m_offsetx -= elem2.scrollLeft;
                            m_offsety -= elem2.scrollTop;
                        }
                    }

                    //This is needed if we have a fame
                    elem2 = elem as IHTMLElement2;
                    if (elem2 != null)
                    {
                        m_offsetx -= elem2.scrollLeft;
                        m_offsety -= elem2.scrollTop;
                    }
                    m_offsetx += elem.offsetLeft;
                    m_offsety += elem.offsetTop;

                    //For frame+iframe
                    while (offsetparent != null)
                    {
                        m_offsetx += offsetparent.offsetLeft;
                        m_offsety += offsetparent.offsetTop;
                        offsetparent = offsetparent.offsetParent;
                    }

                    //Cast it to IWebBrowser2
                    IWebBrowser2 pwb = elem as IWebBrowser2;
                    if (pwb != null)
                    {
                        //Now get the document
                        //If you attempt to access the document via IHTMLFrameBase2.contentWindow
                        //you will get a "Access Denied" exception
                        pdoc2 = pwb.Document as IHTMLDocument2;

                        IHTMLElement loopelem = null;
                        if (pdoc2 != null)
                        {
                            elem = pdoc2.elementFromPoint(m_clientx - m_offsetx, m_clienty - m_offsety);
                            loopelem = elem;
                            //There is only one website that I know of that has so many nested frames
                            //MSDN archive website.
                            while ((loopelem != null) &&
                                (loopelem.tagName.ToLower() == "frame" ||
                                loopelem.tagName.ToLower() == "iframe"))
                            {
                                pwb = loopelem as IWebBrowser2;
                                if (pwb == null)
                                    break;
                                pdoc2 = pwb.Document as IHTMLDocument2;
                                if (pdoc2 == null)
                                    break;

                                if (elem.offsetParent != null)
                                {
                                    m_offsetx += elem.offsetParent.offsetLeft;
                                    m_offsety += elem.offsetParent.offsetTop;
                                }

                                m_offsetx += elem.offsetLeft;
                                m_offsety += elem.offsetTop;

                                loopelem = pdoc2.elementFromPoint(m_clientx - m_offsetx, m_clienty - m_offsety);
                                if (loopelem != null)
                                {
                                    elem = loopelem;
                                }
                            }
                        }
                    }
                }

                //Set up the event argument
                HTMLMouseEventArgs args = new HTMLMouseEventArgs(
                    elem, m_clientx, m_clienty, m_ctrl, m_shift, m_offsetx, m_offsety);

                //Generate the event
                switch (ievent)
                {
                    case 1: //LButtonDown
                        browser.WBLButtonDown(browser, args);
                        result = args.Handled;
                        break;
                    case 2: //LButtonUp
                        browser.WBLButtonUp(browser, args);
                        break;
                    case 3: //MouseMove
                        browser.WBMouseMove(browser, args);
                        result = args.Handled;
                        break;
                    default:
                        break;
                }

                return result;
            }

            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WindowsMessages.WM_XBUTTONDOWN:
                        if (m.WParam.ToInt32() >> 16 == 1) // back button
                        {
                            if (browser.CanGoBack)
                                browser.GoBack();
                            m.Result = IntPtr.Zero;
                            return;
                        }
                        else if (m.WParam.ToInt32() >> 16 == 2) // forward button
                        {
                            if (browser.CanGoForward)
                                browser.GoForward();
                            m.Result = IntPtr.Zero;
                            return;
                        }
                        break;
                    case WindowsMessages.WM_LBUTTONDOWN:
                        //This is needed as user may click and move the mouse
                        //out of the control and release it which result
                        //in no WM_LBUTTONUP being fired
                        m_mouseclicked = false;
                        if (browser.WBLButtonDown != null)
                        {
                            m_LParam = m.LParam.ToInt32();
                            m_WParam = m.WParam.ToInt32();
                            if (FireMouseEvent(1)) //If Client handled
                            {
                                m.Result = IntPtr.Zero;
                                return;
                            }
                        }
                        break;
                    case WindowsMessages.WM_LBUTTONUP:
                        if (m_mouseclicked)
                            break;
                        m_mouseclicked = true;
                        if (!browser.m_InternalHasFocus)
                        {
                            browser.Focus();
                            browser.ClickActiveElement();
                            ////Click the element under the mouse as there maybe no active element present
                            //IHTMLElement elem = browser.ElementFromPoint(WinApis.GET_X_LPARAM(m_LParam), WinApis.GET_Y_LPARAM(m_LParam));
                            //if (elem != null)
                            //{
                            //    IHTMLElement2 elem2 = elem as IHTMLElement2;
                            //    if(elem2 != null)
                            //        elem2.focus();
                            //    //Debug.Print("=========CLICKING");
                            //    elem.click();
                            //}
                        }
                        if (browser.WBLButtonUp != null)
                        {
                            m_LParam = m.LParam.ToInt32();
                            m_WParam = m.WParam.ToInt32();
                            FireMouseEvent(2);
                        }
                        break;
                    case WindowsMessages.WM_MOUSEMOVE:
                        if (browser.WBMouseMove != null)
                        {
                            m_LParam = m.LParam.ToInt32();
                            m_WParam = m.WParam.ToInt32();
                            if (FireMouseEvent(3)) //If Client handled
                            {
                                m.Result = IntPtr.Zero;
                                return;
                            }
                        }
                        break;
                    case WindowsMessages.WM_KILLFOCUS:
                        browser.m_InternalHasFocus = false;
                        //Added to resolve an issue with tabbing into this control
                        //and not seeing the cursor when in designmode == "on"
                        if (browser.m_WBOleInPlaceObject != null)
                            browser.m_WBOleInPlaceObject.UIDeactivate();
                        break;
                    //case WindowsMessages.WM_SETFOCUS:
                    //    break;
                    default:
                        break;
                }
                base.WndProc(ref m);
            }
        }

        #endregion

        #region Downloader via ComUtilitiesLib COM library

        private string m_DownloadDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar.ToString();
        private bool m_UseInternalDownloadManager = true;

        private ComUtilitiesLib.UtilManClass m_csexwbCOMLib = null;

        public event csExWB.FileDownloadExEventHandler FileDownloadExStart = null;
        public event csExWB.FileDownloadExEndEventHandler FileDownloadExEnd = null;
        public event csExWB.FileDownloadExProgressEventHandler FileDownloadExProgress = null;
        public event csExWB.FileDownloadExAuthenticateEventHandler FileDownloadExAuthenticate = null;
        public event csExWB.FileDownloadExErrorEventHandler FileDownloadExError = null;
        public event csExWB.FileDownloadExDownloadFileFullyWrittenEventHandler FileDownloadExDownloadFileFullyWritten = null;

        private FileDownloadExEventArgs FileDownloadExEventArg = new FileDownloadExEventArgs();
        private FileDownloadExEndEventArgs FileDownloadExEndEventArg = new FileDownloadExEndEventArgs();
        private FileDownloadExProgressEventArgs FileDownloadExProgressEventArg = new FileDownloadExProgressEventArgs();
        private FileDownloadExAuthenticateEventArgs FileDownloadExAuthenticateEventArg = new FileDownloadExAuthenticateEventArgs();
        private FileDownloadExErrorEventArgs FileDownloadExErrorEventArg = new FileDownloadExErrorEventArgs();
        private FileDownloadExDownloadFileFullyWrittenEventArgs FileDownloadExDownloadFileFullyWrittenArg = new FileDownloadExDownloadFileFullyWrittenEventArgs();

        [Category("ExWB"), Description("Set to true, default, to allow the control to take over file downloads. FileDownloadExxxx events are fired instead of FileDownload.")]
        public bool UseInternalDownloadManager
        {
            get
            {
                return m_UseInternalDownloadManager;
            }

            set
            {
                m_UseInternalDownloadManager = value;
            }
        }

        [Category("ExWB"), Description("Default file download directory. Set to MyDocuments by default. Used only if UseInternalDownloadManager property is set to true.")]
        public string FileDownloadDirectory
        {
            get
            {
                return m_DownloadDir;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                        m_DownloadDir = value;
                    else
                        m_DownloadDir = value + System.IO.Path.DirectorySeparatorChar;
                }
            }
        }

        /// <summary>
        /// Attempts to download a file asynch.
        /// FileDownloadExxxx events are used for notifications.
        /// </summary>
        /// <param name="Url"></param>
        /// <returns>A unique id assigned to this file download.
        /// Can be used to cancel a download.</returns>
        public int DownloadFile(string Url)
        {
            AddThisIEServerHwndToComLib();
            int i = 0;
            m_csexwbCOMLib.DownloadUrlAsync(Url, ref i);
            return i;
        }

        /// <summary>
        /// Stops a file download
        /// </summary>
        /// <param name="dlUID">Unique id for this file download</param>
        public void StopFileDownload(int dlUID)
        {
            if (m_csexwbCOMLib == null)
                return;
            m_csexwbCOMLib.CancelFileDownload(dlUID);
        }

        void dl_OnFileDLDownloadError(int dlUID, string sURL, string sErrorMsg)
        {
            if (FileDownloadExError != null)
            {
                FileDownloadExErrorEventArg.SetParameters(dlUID, sURL, sErrorMsg);
                FileDownloadExError(this, FileDownloadExErrorEventArg);
                FileDownloadExErrorEventArg.Reset();
            }
        }

        void m_DownloadManager_OnFileDLProgress(int dlUID, string sURL, int lProgress, int lProgressMax, ref bool CancelDl)
        {
            if (this.FileDownloadExProgress != null)
            {
                FileDownloadExProgressEventArg.SetParameters(dlUID, sURL, lProgress, lProgressMax);
                FileDownloadExProgress(this, FileDownloadExProgressEventArg);
                if (FileDownloadExProgressEventArg.Cancel)
                    CancelDl = FileDownloadExProgressEventArg.Cancel;
                FileDownloadExProgressEventArg.Reset();
            }
        }

        //Default value of Cancel = false
        void m_DownloadManager_OnFileDLAuthenticate(int dlUID, ref string sUsername, ref string sPassword, ref bool Cancel)
        {
            if (FileDownloadExAuthenticate != null)
            {
                FileDownloadExAuthenticateEventArg.SetParameters(dlUID);
                FileDownloadExAuthenticate(this, FileDownloadExAuthenticateEventArg);
                if (!FileDownloadExAuthenticateEventArg.Cancel)
                {
                    sUsername = FileDownloadExAuthenticateEventArg.username;
                    sPassword = FileDownloadExAuthenticateEventArg.password;
                }
                FileDownloadExAuthenticateEventArg.Reset();
            }
        }

        void dl_OnFileDLEndDownload(int dlUID, string sURL, string sSavedFilePath)
        {
            if (FileDownloadExEnd != null)
            {
                FileDownloadExEndEventArg.SetParameters(dlUID, sURL, sSavedFilePath);
                FileDownloadExEnd(this, FileDownloadExEndEventArg);
                FileDownloadExEndEventArg.Reset();
            }
            else
            {
                //Just let user know for now
                WinApis.MessageBox(this.Handle, "Download URL:\r\n" + sURL + "Saved To:\r\n" + sSavedFilePath, "File Download Completed", 0);
            }
        }

        void dl_FileDownloadEx(int dlUID, string sURL, string sFilename, string sExt, string sFileSize, string sExtraHeaders, string sRedirURL, ref bool SendProgressEvents, ref bool bStopDownload, ref string sPathToSave)
        {
            if (FileDownloadExStart != null)
            {
                FileDownloadExEventArg.SetParameters(dlUID, sURL, sFilename, sExt, sFileSize, sExtraHeaders, sRedirURL);
                FileDownloadExStart(this, FileDownloadExEventArg);
                if (!FileDownloadExEventArg.Cancel)
                {
                    //Otherwise file will be saved in the same dir as exe
                    //with the sFilename (file.zip)
                    if (!string.IsNullOrEmpty(FileDownloadExEventArg.m_PathToSave))
                        sPathToSave = FileDownloadExEventArg.m_PathToSave;
                    SendProgressEvents = FileDownloadExEventArg.m_SendProgressEvents;
                }
                else
                    bStopDownload = true;
                FileDownloadExEventArg.Reset();
            }
            else
            {
                SendProgressEvents = false;
                //Save it in the downloaddir
                if (!string.IsNullOrEmpty(m_DownloadDir)) //Users MyDocument
                    sPathToSave = m_DownloadDir + sFilename;
            }
        }

        void m_csexwbCOMLib_OnFileDLFileFullyWritten(int dlUID, string sURL, string sSavedFilePath)
        {
            if (FileDownloadExDownloadFileFullyWritten != null)
            {
                FileDownloadExDownloadFileFullyWrittenArg.SetParameters(dlUID, sURL, sSavedFilePath);
                FileDownloadExDownloadFileFullyWritten(this, FileDownloadExDownloadFileFullyWrittenArg);
                FileDownloadExDownloadFileFullyWrittenArg.Reset();
            }
        }

        //void m_DownloadManager_OnFileDLResponse(int dlUID, string sURL, int lResponseCode, string sResponseHeaders, ref bool CancelDl)
        //{
        //    //Check against WinInetErrors enum
        //    if( (lResponseCode == 301) || (lResponseCode > 399) ) //abort and notify the user 
        //}

        ////Only fired if file download is initiated using DownloadFile method
        ////gives the client a chnace to add extra headers. Example: resume header
        ////Syntax: Range: bytes=n-m
        ////bResuming = true;
        ////sAdditionalRequestHeaders = "Range: bytes=" + iLocalFileSize.ToString() + "-\r\n"
        //void m_DownloadManager_OnFileDLBeginningTransaction(int dlUID, string sURL, string sRequestHeaders, ref string sAdditionalRequestHeaders, ref bool bResuming, ref bool bCancel)
        //{
        //    
        //}

        #endregion

        #region Automation of webbrowser control

        //All elements are searched by id and name for a match
        //If frameset, it will search all frames for given element name or id.
        //Please refer to frmAutomation for an example of usage

        private enum AutomationTasks
        {
            ClickButton = 0,
            ClickLink,
            EnterData,
            EnterDataTextArea,
            SelectListItem,
            SelectRadioButton,
            SubmitForm,
            SelectRadioButton2
        }

        private bool GetElementByName(AutomationTasks task, string elemname, string data)
        {
            if ((this.m_WBWebBrowser2 == null) ||
                string.IsNullOrEmpty(elemname))
                return false;
            bool result = false;

            IHTMLDocument2 doc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            if (doc2 == null)
                return false;
            IHTMLElementCollection col = null;

            if (this.IsWBFrameset(doc2))
            {
                List<IWebBrowser2> frames = this.GetFrames(this.m_WBWebBrowser2);
                if (frames == null)
                    return false;
                foreach (IWebBrowser2 wb in frames)
                {
                    if (task == AutomationTasks.ClickLink)
                    {
                        IHTMLDocument2 framedoc = wb.Document as IHTMLDocument2;
                        if (framedoc == null)
                            continue;
                        col = framedoc.anchors as IHTMLElementCollection;
                    }
                    else if (task == AutomationTasks.SelectListItem)
                    {
                        IHTMLDocument3 doc3 = wb.Document as IHTMLDocument3;
                        if (doc3 == null)
                            continue;
                        col = doc3.getElementsByTagName("select") as IHTMLElementCollection;
                    }
                    else if (task == AutomationTasks.EnterDataTextArea)
                    {
                        IHTMLDocument3 doc3 = wb.Document as IHTMLDocument3;
                        if (doc3 == null)
                            continue;
                        col = doc3.getElementsByTagName("textarea") as IHTMLElementCollection;
                    }
                    else if (task == AutomationTasks.SubmitForm)
                    {
                        IHTMLDocument2 framedoc = wb.Document as IHTMLDocument2;
                        if (framedoc == null)
                            continue;
                        col = framedoc.forms as IHTMLElementCollection;
                    }
                    else
                    {
                        IHTMLDocument3 doc3 = wb.Document as IHTMLDocument3;
                        if (doc3 == null)
                            continue;
                        col = doc3.getElementsByTagName("input") as IHTMLElementCollection;
                    }

                    if (col == null)
                        continue;
                    result = this.PerformAutomationTask(col, task, elemname, data);
                    if (result)
                        return result;
                }
            }
            else
            {
                if (task == AutomationTasks.ClickLink)
                {
                    col = doc2.anchors as IHTMLElementCollection;
                    //IHTMLElement elem = col.item(elemname, 0) as IHTMLElement;
                    //if (elem != null)
                    //    elem.click();
                    //return true;
                }
                else if (task == AutomationTasks.SelectListItem)
                {
                    //IHTMLDocument2 framedoc = this.m_WBWebBrowser2.Document as IHTMLDocument2;
                    //if (framedoc == null)
                    //    return result;
                    //col = framedoc.all as IHTMLElementCollection;

                    //IHTMLElement elem = col.item(elemname, 0) as IHTMLElement;
                    //if (elem != null)
                    //{
                    //    IHTMLSelectElement selelem = elem as IHTMLSelectElement;
                    //    if (selelem != null)
                    //        selelem.value = data;
                    //}
                    //return true;
                    IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                    if (doc3 == null)
                        return result;
                    col = doc3.getElementsByTagName("select") as IHTMLElementCollection;
                }
                else if (task == AutomationTasks.EnterDataTextArea)
                {
                    IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                    if (doc3 == null)
                        return result;
                    col = doc3.getElementsByTagName("textarea") as IHTMLElementCollection;
                }
                else if (task == AutomationTasks.SubmitForm)
                {
                    IHTMLDocument2 framedoc = this.m_WBWebBrowser2.Document as IHTMLDocument2;
                    if (framedoc == null)
                        return result;
                    col = framedoc.forms as IHTMLElementCollection;
                }
                else
                {
                    IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                    if (doc3 == null)
                        return result;
                    col = doc3.getElementsByTagName("input") as IHTMLElementCollection;
                }
                if (col == null)
                    return result;
                result = this.PerformAutomationTask(col, task, elemname, data);
            }
            return result;
        }

        private bool PerformAutomationTask(IHTMLElementCollection col, AutomationTasks task, string elemname, string data)
        {
            bool bret = false;

            if (col == null) return bret;

            foreach (IHTMLElement elem in col)
            {
                if (elem != null)
                {
                    switch (task)
                    {
                        case AutomationTasks.ClickButton:
                            {
                                IHTMLInputElement btn = elem as IHTMLInputElement;
                                if ((btn != null) &&
                                    ((elem.id == elemname) || (btn.name == elemname))
                                    )
                                {
                                    elem.click();
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.ClickLink:
                            {
                                IHTMLAnchorElement anchor = elem as IHTMLAnchorElement;
                                if ((anchor != null) &&
                                    ((elem.id == elemname) || (anchor.name == elemname))
                                    )
                                {
                                    elem.click();
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.EnterData:
                            {
                                IHTMLInputElement inputelem = elem as IHTMLInputElement;
                                if ((inputelem != null) &&
                                    ((elem.id == elemname) || (inputelem.name == elemname))
                                    )
                                {
                                    inputelem.value = data;
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.EnterDataTextArea:
                            {
                                IHTMLTextAreaElement txtarea = elem as IHTMLTextAreaElement;
                                if ((txtarea != null) &&
                                    ((elem.id == elemname) || (txtarea.name == elemname))
                                    )
                                {
                                    txtarea.value = data;
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.SelectListItem:
                            {
                                IHTMLSelectElement selelem = elem as IHTMLSelectElement;
                                if ((selelem != null) &&
                                    ((elem.id == elemname) || (selelem.name == elemname))
                                    )
                                {
                                    //data can be value or text of the htmloptionelement
                                    // Obtain the number of option objects in the select object.
                                    int icount = selelem.length;
                                    IHTMLOptionElement optelem = null;
                                    for (int i = 0; i < icount; i++)
                                    {
                                        optelem = selelem.item(i, i) as IHTMLOptionElement;
                                        if (optelem != null)
                                        {
                                            if ((optelem.text == data) ||
                                                (optelem.value == data))
                                            {
                                                optelem.selected = true;
                                                return true;
                                            }
                                        }
                                    }
                                    return false;
                                }
                            }
                            break;
                        case AutomationTasks.SelectRadioButton:
                            {
                                IHTMLInputElement inputelem = elem as IHTMLInputElement;
                                if ((inputelem != null) &&
                                    ((elem.id == elemname) || (inputelem.name == elemname))
                                    )
                                {
                                    inputelem.checkeda = true;
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.SubmitForm:
                            {
                                IHTMLFormElement form = elem as IHTMLFormElement;
                                if ((form != null) &&
                                   ((elem.id == elemname) || (form.name == elemname))
                                    )
                                {
                                    form.submit();
                                    return true;
                                }
                            }
                            break;
                        case AutomationTasks.SelectRadioButton2:
                            {
                                IHTMLInputElement inputelem = elem as IHTMLInputElement;
                                if ((inputelem != null) &&
                                   (((elem.id == elemname) || (inputelem.name == elemname)) &&
                                    (inputelem.value == data))
                                    )
                                {
                                    inputelem.checkeda = true;
                                    return true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            } //End foreach

            return bret;
        }

        /// <summary>
        /// Performs a click on a Button element with given name
        /// </summary>
        /// <param name="elemname">Name of Button element</param>
        /// <returns></returns>
        public bool AutomationTask_PerformClickButton(string btnnameorid)
        {
            return this.GetElementByName(AutomationTasks.ClickButton, btnnameorid, string.Empty);
        }

        public bool AutomationTask_PerformClickLink(string linknameorid)
        {
            return this.GetElementByName(AutomationTasks.ClickLink, linknameorid, string.Empty);
        }

        public bool AutomationTask_PerformEnterData(string inputnameorid, string strValue)
        {
            return this.GetElementByName(AutomationTasks.EnterData, inputnameorid, strValue);
        }

        public bool AutomationTask_PerformEnterDataTextArea(string inputnameorid, string strValue)
        {
            return this.GetElementByName(AutomationTasks.EnterDataTextArea, inputnameorid, strValue);
        }

        /// <summary>
        /// Attempts to select an item from a selection list
        /// based on the item value or text
        /// </summary>
        /// <param name="selectnameorid"></param>
        /// <param name="listitemvalueortext"></param>
        /// <returns></returns>
        public bool AutomationTask_PerformSelectList(string selectnameorid, string listitemvalueortext)
        {
            return this.GetElementByName(AutomationTasks.SelectListItem, selectnameorid, listitemvalueortext);
        }

        public bool AutomationTask_PerformSelectRadio(string radionameorid)
        {
            return this.GetElementByName(AutomationTasks.SelectRadioButton, radionameorid, string.Empty);
        }

        /// <summary>
        /// Selects a radio/check based on name or id and value - Jake
        /// </summary>
        /// <param name="radionameorid"></param>
        /// <param name="value">value is the value parameter inside the <input> html tag</param>
        /// <returns></returns>
        public bool AutomationTask_PerformSelectRadio2(string radionameorid, string value)
        {
            return this.GetElementByName(AutomationTasks.SelectRadioButton2, radionameorid, value);
        }

        public bool AutomationTask_PerformSubmitForm(string formnameorid)
        {
            return this.GetElementByName(AutomationTasks.SubmitForm, formnameorid, string.Empty);
        }

        /// <summary>
        /// Attempts to scroll into view a link given it's name or id
        /// </summary>
        /// <param name="nameorid"></param>
        public bool AutomationTask_NamedLinkScrollIntoView(string nameorid)
        {
            IHTMLDocument2 pdoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
            if (pdoc2 != null)
            {
                IHTMLElementCollection hrefs = pdoc2.anchors as IHTMLElementCollection;

                if (hrefs != null)
                {
                    ////If there are two elements by the same name exists
                    ////we receive the item based on the index passed (0)
                    //IHTMLElement elem = hrefs.item(namedLink, 0) as IHTMLElement;
                    //if (elem != null)
                    //    elem.scrollIntoView(true);
                    foreach (IHTMLElement elem in hrefs)
                    {
                        if (elem != null)
                        {
                            IHTMLAnchorElement anchor = elem as IHTMLAnchorElement;
                            if ((anchor != null) &&
                                ((elem.id == nameorid) || (anchor.name == nameorid)))
                            {
                                elem.scrollIntoView(true);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Simulates a keystroke. The targetelement must have focus
        /// </summary>
        /// <param name="keycode">One of Keys enum</param>
        public void AutomationTask_SimulateKeyStroke(Keys keycode)
        {
            WinApis.keybd_event((byte)keycode, 0, 0, UIntPtr.Zero); //keydown
            WinApis.keybd_event((byte)keycode, 0, WinApis.KEYEVENTF_KEYUP, UIntPtr.Zero); //Keyup
        }

        /// <summary>
        /// Attempts to select all the items within a given select list
        /// </summary>
        /// <param name="selects">A List of MultiSelectHTMLList classes containning a list of
        /// items to select</param>
        public void AutomationTask_PerformMultiSelectListItems(List<MultiSelectHTMLList> selects)
        {
            if ((this.m_WBWebBrowser2 == null) ||
                (selects == null) || (selects.Count == 0))
                return;
            //throw new Exception("

            //get the select collection from IHTMLDocument3
            IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
            if (doc3 == null)
                return;
            IHTMLElementCollection col = doc3.getElementsByTagName("select") as IHTMLElementCollection;

            if (col == null)
                return;

            int icount = 0;
            int i = 0;
            IHTMLOptionElement optelem = null;
            IHTMLSelectElement selelem = null;

            //Loop through
            foreach (MultiSelectHTMLList list in selects)
            {
                if ((list != null) && (!string.IsNullOrEmpty(list.m_SelectNameOrId)) &&
                    (list.m_ListItemsNamesOrIds != null) && (list.m_ListItemsNamesOrIds.Count > 0))
                {
                    //find the list in the collection
                    foreach (IHTMLElement elem in col)
                    {
                        if (elem != null)
                        {
                            selelem = elem as IHTMLSelectElement;
                            if ((selelem != null) &&
                                ((elem.id == list.m_SelectNameOrId) || //check id
                                (selelem.name == list.m_SelectNameOrId)) //check name as well
                                )
                            {
                                //data can be value or text of the htmloptionelement
                                // Obtain the number of option objects in the select object.
                                icount = selelem.length;
                                //loop through all items
                                for (i = 0; i < icount; i++)
                                {
                                    optelem = selelem.item(i, i) as IHTMLOptionElement;
                                    if (optelem != null)
                                    {
                                        //see if this the one
                                        foreach (string data in list.m_ListItemsNamesOrIds)
                                        {
                                            if ((optelem.text == data) ||
                                                (optelem.value == data))
                                            {
                                                optelem.selected = true;
                                                //selected this item, break and
                                                //continue with the rest of the items
                                                break;
                                            }
                                        }
                                    }
                                }
                                //Checked this select, break and continue with the next select in the list
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to find two input fields given their name or id
        /// and fill them with given values
        /// This method accounts for frames and iframes, searchs all of them
        /// If bForceNewValue is true and the inputs already have a value then their values will be replaced with the given strings
        /// If bAutoSubmit is true the parent form is located and it's submit method is called
        /// </summary>
        /// <param name="txtUserNameOrId">Name or id of the username input</param>
        /// <param name="txtPasswordNameOrId">NAme or id of the password input</param>
        /// <param name="strUserName">Value to be entered into username input</param>
        /// <param name="strPassword">Value to be entered into password input</param>
        /// <param name="bForceNewValue">Set to true to overwrite any previous values in the input fields</param>
        /// <param name="bAutoSubmit">Set to true to have the parent form submit method called</param>
        /// <returns></returns>
        public bool AutomationTask_PerformAuthentication(string txtUserNameOrId, string txtPasswordNameOrId, string strUserName, string strPassword, bool bForceNewValue, bool bAutoSubmit)
        {
            bool result = false;
            bool doneusername = false;
            bool donepassword = false;
            //check
            if (this.m_WBWebBrowser2 == null)
                return result;

            if (this.IsFrameset())
            {
                List<IWebBrowser2> frames = this.GetFrames();
                IHTMLElementCollection col = null;
                IHTMLDocument3 doc3 = null;
                IHTMLInputElement inputelem = null;
                foreach (IWebBrowser2 wb in frames)
                {
                    doneusername = false;
                    donepassword = false;

                    doc3 = wb.Document as IHTMLDocument3;
                    if (doc3 == null)
                        continue;
                    col = doc3.getElementsByTagName("input") as IHTMLElementCollection;
                    if (col == null)
                        continue;

                    foreach (IHTMLElement elem in col)
                    {
                        if (elem != null)
                        {
                            inputelem = elem as IHTMLInputElement;
                            if (inputelem != null)
                            {
                                if ((elem.id == txtUserNameOrId) ||
                                    (inputelem.name == txtUserNameOrId))
                                {
                                    if ((string.IsNullOrEmpty(inputelem.value)) ||
                                        (bForceNewValue))
                                    {
                                        doneusername = true;
                                        inputelem.value = strUserName;
                                    }
                                }
                                else if ((elem.id == txtPasswordNameOrId) ||
                                    (inputelem.name == txtPasswordNameOrId))
                                {
                                    //To make sure this is the one we 
                                    //can also check for hidden or password 
                                    //value indicated by type property.
                                    if ((string.IsNullOrEmpty(inputelem.value)) ||
                                        (bForceNewValue))
                                    {
                                        donepassword = true;
                                        inputelem.value = strPassword;
                                    }
                                }
                            }
                            if ((doneusername) && (donepassword))
                                break;
                        }
                    } //End foreach (IHTMLElement elem in col)

                    if ((doneusername) && (donepassword))
                    {
                        //this.AutomationTask_SimulateKeyStroke(Keys.Enter);
                        if ((bAutoSubmit) && (inputelem != null) && (inputelem.form != null))
                        {
                            IHTMLFormElement form = inputelem.form as IHTMLFormElement;
                            if (form != null)
                                form.submit();
                        }
                        break;
                    }
                } //End foreach (IWebBrowser2 wb in frames) 
            }
            else
            {
                //get the select collection from IHTMLDocument3
                IHTMLDocument3 doc3 = this.m_WBWebBrowser2.Document as IHTMLDocument3;
                if (doc3 == null)
                    return result;
                IHTMLElementCollection col = doc3.getElementsByTagName("input") as IHTMLElementCollection;

                if (col == null)
                    return result;

                IHTMLInputElement inputelem = null;
                foreach (IHTMLElement elem in col)
                {
                    if (elem != null)
                    {
                        inputelem = elem as IHTMLInputElement;
                        if (inputelem != null)
                        {
                            if ((elem.id == txtUserNameOrId) ||
                                (inputelem.name == txtUserNameOrId))
                            {
                                if ((string.IsNullOrEmpty(inputelem.value)) ||
                                    (bForceNewValue))
                                {
                                    doneusername = true;
                                    inputelem.value = strUserName;
                                }
                            }
                            else if ((elem.id == txtPasswordNameOrId) ||
                                (inputelem.name == txtPasswordNameOrId))
                            {
                                //To make sure this is the one we 
                                //can also check for hidden or password 
                                //value indicated by type property.
                                if ((string.IsNullOrEmpty(inputelem.value)) ||
                                    (bForceNewValue))
                                {
                                    donepassword = true;
                                    inputelem.value = strPassword;
                                }
                            }
                        }
                        if ((doneusername) && (donepassword))
                            break;
                    }
                }
                if (((doneusername) && (donepassword)) && bAutoSubmit)
                {
                    //this.AutomationTask_SimulateKeyStroke(Keys.Enter);
                    if ((inputelem != null) && (inputelem.form != null))
                    {
                        IHTMLFormElement form = inputelem.form as IHTMLFormElement;
                        if (form != null)
                            form.submit();
                    }
                }
            } //End if (this.IsFrameset())

            return ((doneusername) && (donepassword)) ? true : false;
        }

        #endregion

        #region TravelLog - this webbrowser session history

        public enum TravelLogEntries
        {
            /// <summary>
            /// Returns current url
            /// Could return zero length strings for the current url
            /// </summary>
            CurrentEntry = 0x00000001,
            /// <summary>
            /// Returns all urls visited before current url.
            /// First item in the list is the first url before current
            /// </summary>
            BeforeCurrentEntry = 0x00000010,
            /// <summary>
            /// Returns all urls visited after current url.
            /// First item in the list is the first url after current
            /// </summary>
            AfterCurrentEntry = 0x00000020,
            //NonNavigatableEntries = 0x00000040,
            /// <summary>
            /// Returns all urls visited including current
            /// First item in the list is the first url visited.
            /// </summary>
            AllEntries = 0x00000031
        }

        private ITravelLogStg m_TravelLogStg = null;

        private bool GetHistorySession()
        {
            if (m_TravelLogStg != null)
                return true;
            //QI for serviceprovider
            IfacesEnumsStructsClasses.IServiceProvider psp = m_WBUnknown as IfacesEnumsStructsClasses.IServiceProvider;
            if (psp == null)
                return false;

            IntPtr oret = IntPtr.Zero;
            //QueryService for ITravelLogStg
            int hr = psp.QueryService(ref Iid_Clsids.SID_STravelLogCursor, ref Iid_Clsids.IID_ITravelLogStg, out oret);
            if ((oret == IntPtr.Zero) || (hr != Hresults.S_OK))
                return false;
            Marshal.ReleaseComObject(psp);
            m_TravelLogStg = Marshal.GetObjectForIUnknown(oret) as ITravelLogStg;
            return (m_TravelLogStg != null) ? true : false;
        }

        public int GetTravelLogCount()
        {
            int iret = 0;
            if (!GetHistorySession())
                return iret;
            m_TravelLogStg.GetCount((int)TLMENUF.TLEF_ABSOLUTE, out iret);
            return iret;
        }

        public List<TravelLogStruct> GetTravelLogEntries(TravelLogEntries flags)
        {
            List<TravelLogStruct> entries = new List<TravelLogStruct>();
            if (!GetHistorySession())
                return entries;

            //Enum the travel log entries
            IEnumTravelLogEntry penumtle = null;
            m_TravelLogStg.EnumEntries((int)flags, out penumtle);
            if (penumtle == null)
                return entries;

            int hr = 0;
            ITravelLogEntry ptle = null;
            int fetched = 0;
            IntPtr pTitle = IntPtr.Zero;
            IntPtr pUrl = IntPtr.Zero;
            const int MAX_FETCH_COUNT = 1;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pTitle = IntPtr.Zero;
                    pUrl = IntPtr.Zero;
                    ptle.GetTitle(out pTitle);
                    TravelLogStruct tlg = new TravelLogStruct();
                    if (pTitle != IntPtr.Zero)
                        tlg.Title = Marshal.PtrToStringUni(pTitle);
                    else
                        tlg.Title = string.Empty;

                    ptle.GetURL(out pUrl);
                    if (pUrl != IntPtr.Zero)
                        tlg.URL = Marshal.PtrToStringUni(pUrl);
                    else
                        tlg.URL = string.Empty;

                    entries.Add(tlg);
                    //We are responsible to free the memory
                    Marshal.FreeCoTaskMem(pTitle);
                    Marshal.FreeCoTaskMem(pUrl);
                    //http://msdn2.microsoft.com/en-us/library/aa753624.aspx
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);
            return entries;
        }

        /// <summary>
        /// Returns a list of all visited urls
        /// </summary>
        /// <returns></returns>
        public List<TravelLogStruct> GetTraveLogEntries()
        {
            return GetTravelLogEntries(TravelLogEntries.AllEntries);
        }

        public ITravelLogEntry AddTravelLogEntry(string url, string title)
        {
            ITravelLogEntry ptle = null;
            if (!GetHistorySession())
                return ptle;

            m_TravelLogStg.CreateEntry(url, title, null, true, out ptle);
            return ptle;
        }

        /// <summary>
        /// Removes all travel log entries for this webbrowser instance
        /// </summary>
        /// <returns></returns>
        public bool RemoveAllTravelLogEntries()
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pTitle = IntPtr.Zero;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pTitle = IntPtr.Zero;
                    ptle.GetTitle(out pTitle);
                    if (pTitle != IntPtr.Zero) //Current entry?
                    {
                        Marshal.FreeCoTaskMem(pTitle);
                        m_TravelLogStg.RemoveEntry(ptle);
                    }
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);
            return true;
        }

        /// <summary>
        /// Removes all entries matching given url
        /// The current entry cannot be deleted.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool RemoveTravelLogEntries(string url)
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pUrl = IntPtr.Zero;
            string targeturl = string.Empty;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pUrl = IntPtr.Zero;
                    ptle.GetURL(out pUrl);
                    if (pUrl != IntPtr.Zero)
                    {
                        targeturl = Marshal.PtrToStringUni(pUrl);
                        Marshal.FreeCoTaskMem(pUrl);
                        if ((!string.IsNullOrEmpty(targeturl)) &&
                            (targeturl == url))
                            m_TravelLogStg.RemoveEntry(ptle);
                    }
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);

            return true;
        }

        /// <summary>
        /// Removes first entry matching given url and title
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool RemoveTravelLogEntry(string url, string title)
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pTitle = IntPtr.Zero;
            IntPtr pUrl = IntPtr.Zero;
            string targeturl = string.Empty;
            string targettitle = string.Empty;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if (ptle != null)
                {
                    pTitle = IntPtr.Zero;
                    pUrl = IntPtr.Zero;
                    ptle.GetURL(out pUrl);
                    ptle.GetTitle(out pTitle);
                    if ((pUrl != IntPtr.Zero) &&
                        (pTitle != IntPtr.Zero))
                    {
                        targeturl = Marshal.PtrToStringUni(pUrl);
                        targettitle = Marshal.PtrToStringUni(pTitle);
                        Marshal.FreeCoTaskMem(pTitle);
                        Marshal.FreeCoTaskMem(pUrl);
                        if ((!string.IsNullOrEmpty(targettitle)) &&
                            (targettitle == title) &&
                            (!string.IsNullOrEmpty(targeturl)) &&
                            (targeturl == url))
                        {
                            m_TravelLogStg.RemoveEntry(ptle);
                            return true;
                        }
                    }
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);

            return false;
        }

        /// <summary>
        /// Removes one entry based on index
        /// Can not delete current entry
        /// </summary>
        /// <param name="index">0 based index</param>
        /// <returns></returns>
        public bool RemoveTravelLogEntry(int index)
        {
            if (!GetHistorySession())
                return false;

            int hr = 0;
            int fetched = 0;
            const int MAX_FETCH_COUNT = 1;
            IntPtr pTitle = IntPtr.Zero;
            ITravelLogEntry ptle = null;
            IEnumTravelLogEntry penumtle = null;
            //Find entries
            m_TravelLogStg.EnumEntries((int)TLMENUF.TLEF_ABSOLUTE, out penumtle);
            if (penumtle == null)
                return false;

            hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
            Marshal.ThrowExceptionForHR(hr);
            //while sucess, continue
            for (int i = 0; Hresults.S_OK == hr; i++)
            {
                if ((ptle != null) &&
                    (i == index))
                {
                    pTitle = IntPtr.Zero;
                    ptle.GetTitle(out pTitle);
                    if (pTitle != IntPtr.Zero) //Current entry?
                    {
                        Marshal.FreeCoTaskMem(pTitle);
                        m_TravelLogStg.RemoveEntry(ptle);
                        return true;
                    }
                    else
                        return false;
                }
                hr = penumtle.Next(MAX_FETCH_COUNT, out ptle, out fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.ReleaseComObject(penumtle);
            return false;
        }

        /// <summary>
        /// Navigates to an entry and changes the current position in the travel log to that entry
        /// </summary>
        /// <param name="index">Integer that specifies an offset relative to the current position
        /// Zero means current entry</param>
        /// <returns></returns>
        public bool TravelLogTravelTo(int index)
        {
            if (!GetHistorySession())
                return false;

            ITravelLogEntry item = null;
            m_TravelLogStg.GetRelativeEntry(index, out item);
            if (item == null)
                return false;

            return (m_TravelLogStg.TravelTo(item) == Hresults.S_OK) ? true : false;
        }

        #endregion

        #region IHTMLEditHost Members

        public event HTMLEditHostSnapRectEventHandler HTMLEditHostSnapRect = null;
        private HTMLEditHostSnapRectEventArgs HTMLEditHostSnapRectEvent = new HTMLEditHostSnapRectEventArgs();

        int IHTMLEditHost.SnapRect(IHTMLElement pIElement, ref tagRECT prcNew, int eHandle)
        {
            if (HTMLEditHostSnapRect != null)
            {
                HTMLEditHostSnapRectEvent.SetParameters(pIElement, prcNew, eHandle);
                HTMLEditHostSnapRect(this, HTMLEditHostSnapRectEvent);
                //if things changed
                prcNew = HTMLEditHostSnapRectEvent.ElemRect;
            }
            return Hresults.S_OK;
        }

        #endregion


        #region Browser Thumbnail and Image routines

        //        private class SaveBrowser
        //        {
        //            public SaveBrowser() { }

        //            public Bitmap m_bmp = null;
        //            public Point m_pt = new Point(0, 0);
        //            public IHTMLElement m_pFHtmlElement = null; //Frameset htmlelement (parent)
        //            public IHTMLFrameSetElement m_pFramesetElem = null; //FrameSet (parent)
        //            public IHTMLFrameBase m_pFrame = null; //Frame
        //            public IHTMLBodyElement m_pBodyElement = null;
        //            //public IHTMLWindow3 m_pWin3 = null;
        //            public int m_Width = 0;
        //            public int m_Height = 0;
        //            public string m_Scroll = string.Empty;
        //        }
        //        private bool ThumbnailCallback() { return false; }

        //        /// <summary>
        //        /// OBSOLETE
        //        /// Faster than DrawThumb, but
        //        /// does not work if a window is hidden
        //        /// or is not on top of the zorder
        //        /// </summary>
        //        /// <param name="W"></param>
        //        /// <param name="H"></param>
        //        /// <param name="pixFormat"></param>
        //        /// <returns></returns>
        //        public Image DrawThumb2(int W, int H, System.Drawing.Imaging.PixelFormat pixFormat)
        //        {
        //            if (WBIEServerHandle().Equals(IntPtr.Zero))
        //                return m_WBThumbImg;
        //            Bitmap bmp1 = null;
        //            try
        //            {
        //                if (m_WBThumbImg != null)
        //                {
        //                    m_WBThumbImg.Dispose();
        //                    m_WBThumbImg = null;
        //                }

        //                IntPtr wbhdc = WinApis.GetWindowDC(m_hWBServerHandle);
        //                if (wbhdc == IntPtr.Zero)
        //                    return m_WBThumbImg;

        //                bmp1 = new Bitmap(m_WBRect.Right, m_WBRect.Bottom, pixFormat);
        //                using (Graphics grl = Graphics.FromImage(bmp1))
        //                {
        //                    IntPtr ghdc = grl.GetHdc();
        //                    //blt it to the hdc
        //                    WinApis.BitBlt(ghdc, 0, 0, bmp1.Width, bmp1.Height,
        //                        wbhdc, 0, 0, TernaryRasterOperations.SRCCOPY);
        //                    grl.ReleaseHdc();
        //                }
        //                m_WBThumbImg = bmp1.GetThumbnailImage(W, H, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        //                bmp1.Dispose();
        //                bmp1 = null;
        //            }
        //            finally
        //            {
        //                if (bmp1 != null)
        //                    bmp1.Dispose();
        //            }
        //            return m_WBThumbImg;
        //        }

        //        /// <summary>
        //        /// Attempts to draw a thumbnail image of the browser and return
        //        /// the results as an image
        //        /// This method accounts for frames and works whether webbrowser
        //        /// is in front of the ZOrder or not!
        //        /// </summary>
        //        /// <param name="W"></param>
        //        /// <param name="H"></param>
        //        /// <param name="pixFormat"></param>
        //        /// <returns></returns>
        //        public Image DrawThumb(int W, int H, System.Drawing.Imaging.PixelFormat pixFormat)
        //        {
        //            Bitmap bmp = null;
        //            try
        //            {
        //                if (m_WBThumbImg != null)
        //                {
        //                    m_WBThumbImg.Dispose();
        //                    m_WBThumbImg = null;
        //                }
        //                if (m_WBWebBrowser2 == null)
        //                    return m_WBThumbImg;

        //                //Get doc2, and viewobject
        //                IHTMLDocument2 pDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
        //                if (pDoc2 == null)
        //                    return m_WBThumbImg;

        //                IViewObject pViewObject = pDoc2 as IViewObject;
        //                if (pViewObject == null)
        //                    return m_WBThumbImg;

        //                IHTMLBodyElement pBody = null;
        //                IHTMLElement pElem = null;
        //                IHTMLStyle pStyle = null;
        //                string strStyle = string.Empty;

        //                //get the IHtmlelement
        //                pElem = pDoc2.body;
        //                if (pElem != null)
        //                {
        //                    //Get the IHTMLStyle
        //                    pStyle = pElem.style;
        //                    //Get the borderstyle so we can reset it
        //                    strStyle = pStyle.borderStyle;
        //                    //Hide 3D border
        //                    pStyle.borderStyle = "none";

        //                    pBody = pElem as IHTMLBodyElement;
        //                    //No scrollbars
        //                    if (pBody != null)
        //                        pBody.scroll = "no";
        //                }
        //                //Create bmp
        //                bmp = new Bitmap(m_WBRect.Right, m_WBRect.Bottom, pixFormat);

        //                //draw
        //                int hr = Hresults.S_FALSE;

        //                using (Graphics gr = Graphics.FromImage(bmp))
        //                {
        //                    //get hdc
        //                    IntPtr hdc = gr.GetHdc();
        //                    hr = pViewObject.Draw(
        //                        (uint)DVASPECT.DVASPECT_CONTENT,
        //                        (int)-1, m_NullPointer, m_NullPointer,
        //                        m_NullPointer, hdc, ref m_WBRect, ref m_WBRect,
        //                        m_NullPointer, (uint)0);
        //                    //if (hr == Hresults.S_OK)
        //                    //{
        //                    //    //Transfer to target hdc - TargetHdc = picturebox.image hdc
        //                    //    StretchBlt(TargetHdc, X, Y, W, H,
        //                    //        hdc, 0, 0, bmp.Width, bmp.Height,
        //                    //        TernaryRasterOperations.SRCCOPY);
        //                    //}
        //                    gr.ReleaseHdc();
        //                    //gr.Dispose();
        //                }

        //                if (!string.IsNullOrEmpty(strStyle))
        //                    pStyle.borderStyle = strStyle;
        //                if (pBody != null)
        //                    pBody.scroll = "auto";

        //                //0 or -2147467259 = E_FAIL
        //                if (hr == Hresults.S_OK)
        //                {
        //                    m_WBThumbImg = bmp.GetThumbnailImage(W, H,
        //                        new Image.GetThumbnailImageAbort(ThumbnailCallback),
        //                        IntPtr.Zero);
        //                }

        //                bmp.Dispose();
        //                bmp = null;
        //            }
        //            finally
        //            {
        //                if (bmp != null)
        //                    bmp.Dispose();
        //            }
        //            return m_WBThumbImg;
        //        }

        //        public void SaveBrowserImage(string sFileName,
        //            System.Drawing.Imaging.PixelFormat pixFormat,
        //            System.Drawing.Imaging.ImageFormat format)
        //        {
        //            if (m_WBWebBrowser2 == null)
        //                return;
        //            Bitmap bmp = null;
        //            try
        //            {
        //                //Get doc2, doc3, and viewobject
        //                IHTMLDocument2 pDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
        //                if (pDoc2 == null) return;
        //                IHTMLDocument3 pDoc3 = m_WBWebBrowser2.Document as IHTMLDocument3;
        //                if (pDoc3 == null) return;
        //                IViewObject pViewObject = pDoc2 as IViewObject;
        //                if (pViewObject == null) return;

        //                IHTMLBodyElement pBody = null;
        //                IHTMLElement pElem = null;
        //                IHTMLElement2 pBodyElem = null;
        //                IHTMLStyle pStyle = null;
        //                string strStyle;
        //                int bodyHeight = 0;
        //                int bodyWidth = 0;
        //                int rootHeight = 0;
        //                int rootWidth = 0;
        //                int height = 0;
        //                int width = 0;

        //                //get the IHtmlelement
        //                pElem = pDoc2.body;

        //                //Get the IHTMLStyle
        //                if (pElem != null)
        //                    pStyle = pElem.style;

        //                //Get the borderstyle so we can reset it
        //                strStyle = pStyle.borderStyle;
        //                //Hide 3D border
        //                pStyle.borderStyle = "none";
        //                pBody = pElem as IHTMLBodyElement;
        //                //No scrollbars
        //                if (pBody != null)
        //                    pBody.scroll = "no";

        //                //Get root scroll h + w
        //                //QI for IHTMLElement2
        //                pBodyElem = pElem as IHTMLElement2;
        //                if (pBodyElem != null)
        //                {
        //                    bodyWidth = pBodyElem.scrollWidth;
        //                    bodyHeight = pBodyElem.scrollHeight;
        //                }

        //                //release
        //                pElem = null;
        //                pBodyElem = null;
        //                //Get docelem
        //                pElem = pDoc3.documentElement;
        //                //QI for IHTMLElement2
        //                if (pElem != null)
        //                {
        //                    pBodyElem = pElem as IHTMLElement2;
        //                    //Get scroll H + W
        //                    if (pBodyElem != null)
        //                    {
        //                        rootWidth = pBodyElem.scrollWidth;
        //                        rootHeight = pBodyElem.scrollHeight;
        //                    }
        //                    //calc actual W + H
        //                    width = rootWidth > bodyWidth ? rootWidth : bodyWidth;
        //                    height = rootHeight > bodyHeight ? rootHeight : bodyHeight;
        //                }
        //                //Set up a rect
        //                tagRECT rWPos = new tagRECT(0, 0, width, height);

        //                //Size browser
        //                if (m_WBOleInPlaceObject != null)
        //                    m_WBOleInPlaceObject.SetObjectRects(ref rWPos, ref rWPos);

        //                //Create bmp
        //                bmp = new Bitmap(width, height, pixFormat);

        //                //draw
        //                int hr = Hresults.S_FALSE;
        //                using (Graphics gr = Graphics.FromImage(bmp))
        //                {
        //                    //get hdc
        //                    IntPtr hdc = gr.GetHdc();
        //                    hr = pViewObject.Draw(
        //                        (uint)DVASPECT.DVASPECT_CONTENT,
        //                        (int)-1, m_NullPointer, m_NullPointer,
        //                        m_NullPointer, hdc, ref rWPos, ref rWPos,
        //                        m_NullPointer, (uint)0);
        //                    gr.ReleaseHdc(hdc);
        //                }

        //                //reset
        //                this.SetLocation();
        //                if (!string.IsNullOrEmpty(strStyle))
        //                    pStyle.borderStyle = strStyle;
        //                if (pBody != null)
        //                    pBody.scroll = "auto";

        //                if (hr == Hresults.S_OK)
        //                {
        //                    //save
        //                    bmp.Save(sFileName, format);
        //                }
        //                bmp.Dispose();
        //                bmp = null;
        //            }
        //            finally
        //            {
        //                if (bmp != null)
        //                    bmp.Dispose();
        //            }
        //        }

        //        //In progress....
        //        public void SaveBrowserImage2(string sFileName,
        //            System.Drawing.Imaging.PixelFormat pixFormat,
        //            System.Drawing.Imaging.ImageFormat format)
        //        {
        //            if (m_WBWebBrowser2 == null)
        //                return;
        //            if (!this.IsWBFrameset(this.m_WBWebBrowser2))
        //            {
        //                this.SaveBrowserImage(sFileName, pixFormat, format);
        //                return;
        //            }

        //            List<IWebBrowser2> frames = this.GetFrames(this.m_WBWebBrowser2);
        //            if (frames.Count == 0)
        //                return;

        //            //Get doc2, and viewobject which we use to draw all frames
        //            //yes, we only need the main frameset viewobject
        //            IHTMLDocument2 pMainDoc2 = m_WBWebBrowser2.Document as IHTMLDocument2;
        //            if (pMainDoc2 == null)
        //                return;

        //            //Main frameset element to determine rows/cols and for adjustment
        //            IHTMLFrameSetElement pMainFramesetElem = null;

        //            if (pMainDoc2.body != null)
        //                pMainFramesetElem = pMainDoc2.body as IHTMLFrameSetElement;
        //            //Do we cols or rows
        //            if (pMainFramesetElem != null)
        //            {
        //                //cols = pMainFramesetElem.cols;
        //                //rows = pMainFramesetElem.rows; //"30%,40%,30%"
        //            }

        //            IViewObject pViewObject = pMainDoc2 as IViewObject;
        //            if (pViewObject == null)
        //                return;

        //            try
        //            {
        //                //We don't know how big the image will be after we expand each
        //                //expandable frame to it's full size. So, we strat with the browser
        //                //width and height
        //                int finalWidth = 0;
        //                //int finalHeight = 0;
        //                //int hr = Hresults.S_FALSE;
        //                List<SaveBrowser> lisbmps = new List<SaveBrowser>();

        //                //First loop, we attempt to get the full sizes
        //                //of each frame and it's location
        //                //If needed we resize the browser window as well (Main frameset)
        //                //We also keep track of the actual size of the main frameset
        //                foreach (IWebBrowser2 wb in frames)
        //                {
        //                    IHTMLDocument2 pDoc2 = null;
        //                    IHTMLDocument3 pDoc3 = null;
        //                    IHTMLElement pBody = null;
        //                    IHTMLElement poffsetparent = null;
        //                    //IHTMLWindow2 pWin2 = null;
        //                    IHTMLElement pDocElem = null;
        //                    IHTMLElement2 pDocElem2 = null;
        //                    int bodyHeight = 0;
        //                    int bodyWidth = 0;
        //                    int rootHeight = 0;
        //                    int rootWidth = 0;

        //                    SaveBrowser sb = new SaveBrowser();

        //                    //Find parent FRAMESET
        //                    sb.m_pFHtmlElement = wb as IHTMLElement;
        //                    poffsetparent = sb.m_pFHtmlElement.parentElement;
        //                    while (poffsetparent != null)
        //                    {
        //                        if (poffsetparent.tagName.ToLower() == "frameset")
        //                        {
        //                            sb.m_pFramesetElem = poffsetparent as IHTMLFrameSetElement;
        //                            break;
        //                        }
        //                        poffsetparent = poffsetparent.parentElement;
        //                    }
        //                    poffsetparent = null;
        //                    //if ((sb.m_pFHtmlElement != null) && (sb.m_pFHtmlElement.parentElement != null))
        //                    //{
        //                    //    //And this frameset can be contained within another frameset
        //                    //    sb.m_pFramesetElem = sb.m_pFHtmlElement.parentElement as IHTMLFrameSetElement;
        //                    //}

        //                    sb.m_pFrame = wb as IHTMLFrameBase;

        //                    //Get doc2
        //                    pDoc2 = wb.Document as IHTMLDocument2;
        //                    if (pDoc2 == null)
        //                        continue;

        //                    pDoc3 = wb.Document as IHTMLDocument3;
        //                    if (pDoc3 == null)
        //                        continue;

        //                    pBody = pDoc2.body;
        //                    if (pBody == null)
        //                        continue;

        //                    //pWin2 = pDoc2.parentWindow as IHTMLWindow2;

        //                    //Need this to calculate real left and top
        //                    //coordinates of this frame window relevant to the document
        //                    //Walking up the DOM offsetParent
        //                    poffsetparent = sb.m_pFHtmlElement.offsetParent;
        //                    sb.m_pt.X = sb.m_pFHtmlElement.offsetLeft;
        //                    sb.m_pt.Y = sb.m_pFHtmlElement.offsetTop;
        //                    while (poffsetparent != null)
        //                    {
        //                        sb.m_pt.X += poffsetparent.offsetLeft;
        //                        sb.m_pt.Y += poffsetparent.offsetTop;
        //                        poffsetparent = poffsetparent.offsetParent;
        //                    }

        //                    //sb.m_pWin3 = pWin2 as IHTMLWindow3;

        //                    //if (sb.m_pWin3 != null)
        //                    //    sb.m_pt = this.PointToClient(new Point(sb.m_pWin3.screenLeft, sb.m_pWin3.screenTop));
        //                    //else
        //                    //    sb.m_pt = new Point(wb.Left, wb.Top);

        //                    sb.m_pBodyElement = pBody as IHTMLBodyElement;
        //                    if ((sb.m_pFrame != null) &&
        //                        (!string.IsNullOrEmpty(sb.m_pFrame.scrolling)) &&
        //                        (sb.m_pFrame.scrolling != "no"))
        //                    {
        //                        sb.m_Scroll = sb.m_pFrame.scrolling;
        //                        if (sb.m_pBodyElement != null)
        //                            sb.m_pBodyElement.scroll = "no";
        //                        else
        //                            sb.m_pFrame.scrolling = "no";
        //                    }

        //                    bodyWidth = pBody.offsetWidth;
        //                    bodyHeight = pBody.offsetHeight;
        //                    if ((bodyWidth <= 0) || (bodyHeight <= 0))
        //                        continue;

        //                    //find the actual w+h when frame expands fully
        //                    pDocElem = pDoc3.documentElement;
        //                    if ((pDocElem != null) && (!string.IsNullOrEmpty(sb.m_Scroll)))
        //                    {
        //                        pDocElem2 = pDocElem as IHTMLElement2;
        //                        //Get scroll H + W
        //                        if (pDocElem2 != null)
        //                        {
        //                            rootWidth = pDocElem2.scrollWidth;
        //                            rootHeight = pDocElem2.scrollHeight;
        //                        }
        //                        //calc actual W + H
        //                        sb.m_Width = rootWidth > bodyWidth ? rootWidth : bodyWidth;
        //                        sb.m_Height = rootHeight > bodyHeight ? rootHeight : bodyHeight;
        //                    }
        //                    else
        //                    {
        //                        sb.m_Width = bodyWidth;
        //                        sb.m_Width = bodyHeight;
        //                    }

        //                    ////this frame's frameset is contained in another frameset
        //                    //if ((sb.m_pFHtmlElement != null)
        //                    //    && (sb.m_pFHtmlElement.parentElement != null)
        //                    //    && (sb.m_pFHtmlElement.parentElement.parentElement != null)
        //                    //    && (sb.m_pFHtmlElement.parentElement.parentElement.tagName == "FRAMESET"))
        //                    //{
        //                    //    finalHeight += sb.m_Height;
        //                    //    finalWidth += sb.m_Width;
        //                    //}
        //                    //else
        //                    //{
        //                    //    finalHeight += sb.m_Height;
        //                    //}

        //                    //Add to list
        //                    lisbmps.Add(sb);
        //                }

        //                if (lisbmps.Count == 0)
        //                    return;

        //                if (finalWidth == 0) 
        //                    finalWidth = this.m_WBRect.Right;

        //                //tagRECT rWPos = new tagRECT(0, 0, finalWidth, finalHeight);
        //                //if (m_WBOleInPlaceObject != null)
        //                //    m_WBOleInPlaceObject.SetObjectRects(ref rWPos, ref rWPos);
        //                //int icounter = 0;
        //                //tagRECT rect;
        //                ////make a bitmap
        //                ////Bitmap img = new Bitmap(finalWidth, finalHeight, pixFormat);

        //                //foreach (SaveBrowser item in lisbmps)
        //                //{
        //                //    if (item.m_pWin3 != null)
        //                //        item.m_pt = this.PointToClient(new Point(item.m_pWin3.screenLeft, item.m_pWin3.screenTop));
        //                //    item.m_bmp = new Bitmap(item.m_Width , item.m_Height, pixFormat);
        //                //    rect = new tagRECT(item.m_pt.X, item.m_pt.Y , item.m_Width, item.m_Height);

        //                //    using (Graphics gr = Graphics.FromImage(item.m_bmp))
        //                //    {
        //                //        //get hdc
        //                //        IntPtr hdc = gr.GetHdc();
        //                //        hr = pViewObject.Draw(
        //                //            (uint)DVASPECT.DVASPECT_CONTENT,
        //                //            (int)-1, m_NullPointer, m_NullPointer,
        //                //            m_NullPointer, hdc, ref rect, ref rect,
        //                //            m_NullPointer, (uint)0);
        //                //        gr.ReleaseHdc();
        //                //    }
        //                //    item.m_bmp.Save("C:\\test" + icounter.ToString() + ".bmp", format);
        //                //    icounter++;
        //                //    item.m_bmp.Dispose();
        //                //    item.m_bmp = null;
        //                //}

        //                //this.SetLocation();

        //                ////img.Save(sFileName, format);
        //                ////img.Dispose();
        //                ////img = null;

        //            }
        //            catch (Exception ee)
        //            {
        //                Debug.Print("====\r\n" + ee.ToString());
        //            }

        //        }

        //        #region Misc
        //        ////m_CurWB.Navigate("http://msdn.microsoft.com/archive/default.asp?url=/archive/en-us/samples/internet/libraries/ie6_lib/default.asp");
        //        //IHTMLDocument2 pDoc2 = m_CurWB.WebbrowserObject.Document as IHTMLDocument2;
        //        //if (pDoc2 == null)
        //        //    return;

        //        //IHTMLFrameSetElement pframeset = pDoc2.body as IHTMLFrameSetElement;
        //        //if (pframeset != null)
        //        //{
        //        //    AllForms.m_frmLog.AppendToLog("Cols =" + pframeset.cols + " Rows =" + pframeset.rows);
        //        //    //pframeset.rows = "30%,40%,30%";
        //        //}
        //        //IHTMLElementCollection col = pDoc2.all as IHTMLElementCollection;
        //        //if (col == null)
        //        //    return;
        //        //IHTMLFrameSetElement frameset = null;

        //        //foreach (IHTMLElement elem in col)
        //        //{
        //        //    if (elem == null)
        //        //        continue;
        //        //    if (elem.tagName == "FRAMESET")
        //        //    {

        //        //        frameset = elem as IHTMLFrameSetElement;
        //        //        if (frameset != null)
        //        //        {
        //        //            AllForms.m_frmLog.AppendToLog("Cols =" + frameset.cols + " Rows =" + frameset.rows);
        //        //        }
        //        //    }
        //        //}


        //        //m_CurWB.execScript(true,
        //        //    "javascript:__doPostBack('NY,412800013,09/15/2007,10010,18,C,165,0','false')",
        //        //    "JavaScript");
        //        //if (!m_frmHTMLParser.Visible)
        //        //{
        //        //    m_frmHTMLParser.Show(this);
        //        //} 
        //        #endregion

        #endregion

        #region IManagedProtocolSink Members - Asynchronous pluggable protocols (APP), via ComUtilitiesLib COM library

        /// <summary>
        /// Event to notify the client of start method being called
        /// </summary>
        public event csExWB.AsynchDownloadRequestEventHandler DownloadRequestAsynch = null;
        public event csExWB.SynchDownloadRequestEventHandler DownloadRequestSynch = null;
        public event csExWB.ProtocolHandlerBeginTransactionEventHandler ProtocolHandlerBeginTransaction = null;
        public event csExWB.ProtocolHandlerOnResponseEventHandler ProtocolHandlerOnResponse = null;
        public event csExWB.ProtocolHandlerDataFullyAvailableEventHandler ProtocolHandlerDataFullyAvailable = null;
        public event csExWB.ProtocolHandlerDataFullyReadEventHandler ProtocolHandlerDataFullyRead = null;
        public event csExWB.ProtocolHandlerOperationFailedEventHandler ProtocolHandlerOperationFailed = null;

        //Using a number of temp variables in OnStartManagedAPP to speed things up
        //as this event is called many many times
        private int m_APPIndex = 0;
        private string m_AppUrl = string.Empty;
        private byte[] m_AppPostData = null;
        private string m_APPprotocol = string.Empty;
        private string m_AppReferer = string.Empty;
        /// <summary>
        /// Fired by an instance of IManagedAppBridge to notify this control
        /// of start method being called.
        /// bClientHandled = true (default)
        /// </summary>
        /// <param name="URL">Url of the request</param>
        /// <param name="RequestHeaders">Request headers</param>
        /// <param name="PostData">Post data. If this is a post request</param>
        /// <param name="PostDataMime">Post data MIME. If this is a post request</param>
        /// <param name="pDispManagedAppBrigde">An IDispatch pointer to IManagedAppBridge instance</param>
        void m_csexwbCOMLib_OnStartManagedAPP(string URL, string RequestHeaders, string PostData, string PostDataMime, object pDispManagedAppBrigde, bool bNeedFileName, ref string sLocalFileName, ref bool bClientHandled, bool bAsynchDownload, ref bool bCancelDownload)
        {
            if (!string.IsNullOrEmpty(PostData))
                PostData = PostData.Replace("Ì", "");

            if ((DownloadRequestAsynch == null) && (DownloadRequestSynch == null))
            {
                bClientHandled = false;
                return;
            }

            //Notify client
            m_AppUrl = URL;
            m_APPIndex = m_AppUrl.IndexOf(':');
            //Get the protocol
            if (m_APPIndex > 0)
                m_APPprotocol = m_AppUrl.Substring(0, m_APPIndex);
            else
                m_APPprotocol = string.Empty;
            //Set up post data if any present
            if (!string.IsNullOrEmpty(PostData))
                m_AppPostData = UTF8Encoding.UTF8.GetBytes(PostData);
            else
                m_AppPostData = null;

            //Get referer
            //Referer: http://www.google.ca/
            //Accept-Language: en-us
            if (!string.IsNullOrEmpty(RequestHeaders) &&
                (RequestHeaders.StartsWith("Referer", StringComparison.CurrentCultureIgnoreCase)))
                m_AppReferer = RequestHeaders.Split(':')[1].Trim();
            else
                m_AppReferer = string.Empty;

            if (bAsynchDownload)
            {
                if (DownloadRequestAsynch == null)
                    return;

                //Setup event arguments
                AsynchDownloadRequestEventArgs AsynchDownloadRequestEventArg =
                    new AsynchDownloadRequestEventArgs(m_APPprotocol,
                    m_AppUrl, m_AppReferer, m_AppPostData, PostDataMime, this, pDispManagedAppBrigde, bNeedFileName);

                //Fire event
                DownloadRequestAsynch(this, AsynchDownloadRequestEventArg);
                //Cancel download from here?
                if (AsynchDownloadRequestEventArg.CancelDownload)
                {
                    bCancelDownload = AsynchDownloadRequestEventArg.CancelDownload;
                    return;
                }
                //Set to false to have the default implementation download the resource
                //Default true
                bClientHandled = AsynchDownloadRequestEventArg.ClientHandled;
                return;
            }

            //Check
            if (DownloadRequestSynch == null)
            {
                bClientHandled = false;
                return;
            }

            SynchDownloadRequestEventArgs SynchDownloadRequestEventArg =
                new SynchDownloadRequestEventArgs(m_APPprotocol,
                m_AppUrl, m_AppReferer, m_AppPostData, PostDataMime, this, pDispManagedAppBrigde, bNeedFileName);
            //Fire event
            DownloadRequestSynch(this, SynchDownloadRequestEventArg);

            if (SynchDownloadRequestEventArg.CancelDownload)
            {
                bCancelDownload = SynchDownloadRequestEventArg.CancelDownload;
                return;
            }
            //Set to false to have the default implementation download the resource
            //Default true
            bClientHandled = SynchDownloadRequestEventArg.ClientHandled;

            //If this is not an Asynch download
            //we setup everything here
            if (bClientHandled)
            {
                ComUtilitiesLib.IManagedAppBridge appsink = pDispManagedAppBrigde as ComUtilitiesLib.IManagedAppBridge;
                if (appsink != null)
                {
                    //Do we need a filename (local filename, not necessarily IE cache)
                    if ((bNeedFileName) && (!string.IsNullOrEmpty(SynchDownloadRequestEventArg.CacheFileName)))
                        sLocalFileName = SynchDownloadRequestEventArg.CacheFileName;
                    else
                    {
                        object data = SynchDownloadRequestEventArg.DownloadData;

                        appsink.DownloadData = data;
                    }
                    appsink.URL = SynchDownloadRequestEventArg.Url;
                    appsink.DataMimeType = SynchDownloadRequestEventArg.DownloadDataMimeType;
                }
            }
        }

        void m_csexwbCOMLib_ManagedAppOnResponse(string sURL, string sResponseHeaders, string sRedirectedUrl, string sRedirectHeaders, ref bool Cancel)
        {
            if (ProtocolHandlerOnResponse != null)
            {
                ProtocolHandlerOnResponseEventArgs args = new ProtocolHandlerOnResponseEventArgs(sURL, sResponseHeaders, sRedirectedUrl, sRedirectHeaders);
                ProtocolHandlerOnResponse(this, args);
                Cancel = args.Cancel;
            }
        }

        void m_csexwbCOMLib_ManagedAppBeginningTransaction(string sURL, string sRequestHeaders, ref string sAdditionalHeaders, ref bool Cancel)
        {
            if (ProtocolHandlerBeginTransaction != null)
            {
                ProtocolHandlerBeginTransactionEventArgs args = new ProtocolHandlerBeginTransactionEventArgs(sURL, sRequestHeaders);
                ProtocolHandlerBeginTransaction(this, args);
                if (!string.IsNullOrEmpty(args.AdditionalHeadersToAdd))
                    sAdditionalHeaders = args.AdditionalHeadersToAdd;
                Cancel = args.Cancel;
            }
        }

        void m_csexwbCOMLib_ManagedAppDataFullyRead(string sURL)
        {
            if (ProtocolHandlerDataFullyRead != null)
            {
                ProtocolHandlerDataFullyReadEventArgs args =
                    new ProtocolHandlerDataFullyReadEventArgs(sURL);
                ProtocolHandlerDataFullyRead(this, args);
            }
        }

        void m_csexwbCOMLib_ManagedAppDataFullyAvailable(string sURL)
        {
            if (ProtocolHandlerDataFullyAvailable != null)
            {
                ProtocolHandlerDataFullyAvailableEventArgs args =
                    new ProtocolHandlerDataFullyAvailableEventArgs(sURL);
                ProtocolHandlerDataFullyAvailable(this, args);
            }
        }

        void m_csexwbCOMLib_ManagedAppOperationFailed(string sURL)
        {
            if (ProtocolHandlerOperationFailed != null)
            {
                ProtocolHandlerOperationFailedEventArgs args =
                    new ProtocolHandlerOperationFailedEventArgs(sURL);
                ProtocolHandlerOperationFailed(this, args);
            }
        }

        /// <summary>
        /// Called from DownloadCompleted method of DownloadRequestEventArgs
        /// event argument passed to client via ProtocolHandlerOnStart event
        /// </summary>
        /// <param name="data">Byte array representing downloaded data</param>
        /// <param name="redirectedUrl">Redirected url or the original</param>
        /// <param name="mimeType">Mime type of downloaded data</param>
        /// <param name="sink">IManagedAppBridge instance</param>
        void IManagedProtocolSink.ManagedAppDownloadCompletedAsynch(byte[] data, string Url, string mimeType, object sink)
        {
            if (sink != null)
            {
                //Convert IDispatch of ManagedAppBridge instance to ComUtilitiesLib.IManagedAppBridge interface
                ComUtilitiesLib.IManagedAppBridge appsink = sink as ComUtilitiesLib.IManagedAppBridge;
                if (appsink != null)
                {
                    object APPSinkData = data;
                    appsink.DownloadCompleteManaged(Url, mimeType, ref APPSinkData, data.Length);
                }
            }
        }

        void IManagedProtocolSink.ManagedAppDownloadCompletedAsynchNeedFileName(string Url, string mimeType, object sink, string CacheFileName)
        {
            if (sink != null)
            {
                ComUtilitiesLib.IManagedAppBridge appsink = sink as ComUtilitiesLib.IManagedAppBridge;
                if (appsink != null)
                {
                    appsink.DownloadCompleteManagedCache(Url, mimeType, CacheFileName);
                }
            }
        }

        /// <summary>
        /// Called from CancelDownloadRequest method of DownloadRequestEventArgs
        /// event argument passed to client via ProtocolHandlerOnStart event
        /// </summary>
        /// <param name="Inet_Error_Code">One of Inet_Error_xxxx errors. WinInetErrors enum can be used.</param>
        /// <param name="sink">IManagedAppBridge instance</param>
        void IManagedProtocolSink.ManagedAppAbortDownload(int Inet_Error_Code, object sink)
        {
            if (sink != null)
            {
                ComUtilitiesLib.IManagedAppBridge appsink = sink as ComUtilitiesLib.IManagedAppBridge;
                if (appsink != null)
                    appsink.DownloadAbortManaged(Inet_Error_Code);
            }
        }

        #endregion

        #region ICustomProtocolSink Members

        private string[] m_predefinedProtocols = {
            "http",
            "https",
            "file",
            "ftp",
            "gopher",
            "javascript",
            "mailto",
            "news",
            "res",
            "telnet",
            "view-source"};

        /// <summary>
        /// CLSID of the custom protocol handler
        /// </summary>
        private const string m_CustomProtocolHandlerClSID = "{AD6E5643-7B0C-46AA-95AD-9773FF2A857A}";
        /// <summary>
        /// Target registry key to add custom protocol
        /// </summary>
        private const string m_userRoot = "HKEY_CLASSES_ROOT\\PROTOCOLS\\Handler\\";
        /// <summary>
        /// Name of the subkey which its value is set to m_CustomProtocolHandlerClSID
        /// </summary>
        private const string m_AppCLSID = "CLSID";

        /// <summary>
        /// Setsup activation of a custom protocol handler
        /// This method needs to be called whether the protocol was activated previously or not
        /// as the IE server hwnd must be set so the COM library is able to notify the corresponding
        /// cEXWB instance to notify the client n turn.
        /// </summary>
        /// <param name="customprotocol"></param>
        public void StartCustomProtocol(string customprotocol)
        {
            //Check for default protocols and do not allow any to get through
            string tmp = customprotocol.ToLower();
            foreach (string item in m_predefinedProtocols)
            {
                if (item == tmp)
                    throw new Exception("Can not use pre-defined protocols with custom protocol handler.\r\nhttp https file ftp gopher javascript mailto news res telnet view-source");
            }

            AddThisIEServerHwndToComLib();
            string subkey = customprotocol; //mydata
            string keyName = m_userRoot + subkey;
            string clsidvalue = (string)Microsoft.Win32.Registry.GetValue(keyName, "CLSID", string.Empty);
            //Already set, just return
            if ((!string.IsNullOrEmpty(clsidvalue)) && (clsidvalue == m_CustomProtocolHandlerClSID))
                return;
            else
            {
                Microsoft.Win32.Registry.SetValue(keyName, "", customprotocol + ": Protocol Handler");
                Microsoft.Win32.Registry.SetValue(keyName, m_AppCLSID, m_CustomProtocolHandlerClSID);
            }
        }
        public void StopCustomProtocol(string customprotocol)
        {
            //Check for default protocols and do not allow any to get through
            string tmp = customprotocol.ToLower();
            foreach (string item in m_predefinedProtocols)
            {
                if (item == tmp)
                    throw new Exception("Can not use pre-defined protocols with custom protocol handler.\r\nhttp https file ftp gopher javascript mailto news res telnet view-source");
            }
            string keyName = m_userRoot + customprotocol;
            string clsidvalue = (string)Microsoft.Win32.Registry.GetValue(keyName, m_AppCLSID, string.Empty);
            //Already set, just return
            if ((!string.IsNullOrEmpty(clsidvalue)) && (clsidvalue == m_CustomProtocolHandlerClSID))
                Microsoft.Win32.Registry.ClassesRoot.DeleteSubKey("PROTOCOLS\\Handler\\" + customprotocol);
        }

        /// <summary>
        /// Event to notify client of invokation of protocol handler start method
        /// </summary>
        public event csExWB.CustomDownloadRequestEventHandler CustomDownloadRequest = null;
        void m_csexwbCOMLib_OnStartCustManagedApp(string URL, object pDispCustManagedApp)
        {
            if (CustomDownloadRequest != null)
            {
                m_AppUrl = URL;
                m_APPIndex = m_AppUrl.IndexOf(':');
                //Get the protocol
                if (m_APPIndex > 0)
                    m_APPprotocol = m_AppUrl.Substring(0, m_APPIndex);
                else
                    m_APPprotocol = string.Empty;
                CustomDownloadRequestEventArgs args = new CustomDownloadRequestEventArgs(m_APPprotocol, m_AppUrl, this, pDispCustManagedApp);
                CustomDownloadRequest(this, args);
            }
        }

        void ICustomProtocolSink.CustomAppDownloadCompleted(byte[] data, string Url, string mimeType, object sink)
        {
            if (sink != null)
            {
                ComUtilitiesLib.ICustManageApp custapp = sink as ComUtilitiesLib.ICustManageApp;
                if (custapp != null)
                {
                    object APPSinkData = data;
                    custapp.DownloadCompleteCustomApp(Url, mimeType, ref APPSinkData, data.Length);
                    //APPSinkData = null;
                }
            }
        }

        void ICustomProtocolSink.CustomAppAbortDownload(int Inet_Error_Code, object sink)
        {
            if (sink != null)
            {
                ComUtilitiesLib.ICustManageApp custapp = sink as ComUtilitiesLib.ICustManageApp;
                if (custapp != null)
                    custapp.DownloadAbortCustomApp(Inet_Error_Code);
            }
        }

        #endregion

        #region IHTMLChangeSink Members
        private IHTMLChangeLog m_pChangeLog = null;

        public IHTMLChangeLog PChangeLog
        {
            get { return m_pChangeLog; }
        }
        private uint m_pDirtyRangeCookie = 0;
        public event EventHandler WBOnDocumentChanged = null;
        private bool SetupDocumentChangeNotification(IHTMLDocument4 pDoc4)
        {//SetWinEventHook(EVENT_OBJECT_CREATE). könnte für DOM Changes auch hergenommen werden
            if (pDoc4 == null)
                return false;
            IMarkupContainer2 m_pMarkupContainer2 = pDoc4 as IMarkupContainer2;
            if (m_pMarkupContainer2 == null)
                return false;
            //To stop receiving change notifications, call Release on the IHTMLChangeLog pointer.
            //m_pChangeLog = null;
            int iret2 = m_pMarkupContainer2.CreateChangeLog(this, out m_pChangeLog, true, true);
            int iret = m_pMarkupContainer2.RegisterForDirtyRange(this, out m_pDirtyRangeCookie);
            return (iret == Hresults.S_OK) ? true : false;
        }

        private void RemoveDocumentChangeNotification()
        {
            if (m_pChangeLog != null)
                Marshal.ReleaseComObject(m_pChangeLog);
        }

        int IHTMLChangeSink.Notify()
        {
            if (WBOnDocumentChanged != null)
                WBOnDocumentChanged(this, EventArgs.Empty);
            return Hresults.S_OK;
        }

        /// <summary>
        /// Experimental, do not use!
        /// </summary>
        /// <returns></returns>
        public string GetDocumentScriptObjects()
        {
            string source = string.Empty;

            IHTMLDocument2 pdoc2 = this.m_WBWebBrowser2.Document as IHTMLDocument2;
            m_csexwbCOMLib.GetScriptObjects(pdoc2.Script, ref source);

            return source;
        }

        /*
//Default Webbrowser Global Script objects
onbeforeunload
onafterprint
top
location
parent
offscreenBuffering
frameElement
onerror
screen
event
clipboardData
onresize
defaultStatus
onblur
window
onload
onscroll
screenTop
onfocus
Option
length
onbeforeprint
frames
self
clientInformation
XMLHttpRequest
external
screenLeft
opener
onunload
document
closed
history
Image
navigator
status
onhelp
name
         */

        #endregion
    } //class cEXWB

} //csExWB



