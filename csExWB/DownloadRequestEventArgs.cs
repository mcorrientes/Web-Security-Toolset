using System;
using System.Windows.Forms;

namespace csExWB
{
    public delegate void AsynchDownloadRequestEventHandler(object sender, AsynchDownloadRequestEventArgs e);
    public delegate void SynchDownloadRequestEventHandler(object sender, SynchDownloadRequestEventArgs e);
    public delegate void ProtocolHandlerBeginTransactionEventHandler(object sender, ProtocolHandlerBeginTransactionEventArgs e);
    public delegate void ProtocolHandlerOnResponseEventHandler(object sender, ProtocolHandlerOnResponseEventArgs e);
    public delegate void ProtocolHandlerDataFullyAvailableEventHandler(object sender, ProtocolHandlerDataFullyAvailableEventArgs e);
    public delegate void ProtocolHandlerDataFullyReadEventHandler(object sender, ProtocolHandlerDataFullyReadEventArgs e);
    public delegate void ProtocolHandlerOperationFailedEventHandler(object sender, ProtocolHandlerOperationFailedEventArgs e);

    /// <summary>
    /// Event arguments for DownloadRequestBeginTransactionEventHandler delegate.
    /// </summary>
    public class ProtocolHandlerBeginTransactionEventArgs : System.ComponentModel.CancelEventArgs
    {
        public ProtocolHandlerBeginTransactionEventArgs(string _url, string _requestheaders)
        {
            m_URL = _url;
            m_RequestHeaders = _requestheaders;
            m_AdditionalHeadersToAdd = string.Empty;
        }
        private string m_URL;
        private string m_RequestHeaders;
        private string m_AdditionalHeadersToAdd;
        public string URL
        {
            get { return m_URL; }
        }
        public string RequestHeaders
        {
            get { return m_RequestHeaders; }
        }
        public string AdditionalHeadersToAdd
        {
            get { return m_AdditionalHeadersToAdd; }
            set { m_AdditionalHeadersToAdd = value; }
        }
    }

    /// <summary>
    /// Event arguments for DownloadRequestOnResponseEventHandler delegate.
    /// </summary>
    public class ProtocolHandlerOnResponseEventArgs : System.ComponentModel.CancelEventArgs
    {
        public ProtocolHandlerOnResponseEventArgs(string _url, string _responseheaders, string _redirectedurl, string _redirectheaders)
        {
            m_URL = _url;
            m_ResponseHeaders = _responseheaders;
            m_RedirectHeaders = _redirectheaders;
            m_RedirectedUrl = _redirectedurl;
        }
        private string m_URL = string.Empty;
        private string m_ResponseHeaders = string.Empty;
        private string m_RedirectedUrl = string.Empty;
        private string m_RedirectHeaders = string.Empty;
        public string URL
        {
            get { return m_URL; }
        }
        public string ResponseHeaders
        {
            get { return m_ResponseHeaders; }
        }
        public string RedirectedUrl
        {
            get { return m_RedirectedUrl; }
        }
        public string RedirectHeaders
        {
            get { return m_RedirectHeaders; }
        }
    }

    public class ProtocolHandlerDataFullyAvailableEventArgs : System.EventArgs
    {
        public ProtocolHandlerDataFullyAvailableEventArgs(string _url)
        {
            m_URL = _url;
        }
        private string m_URL = string.Empty;
        public string URL
        {
            get { return m_URL; }
        }
    }

    public class ProtocolHandlerDataFullyReadEventArgs : System.EventArgs
    {
        public ProtocolHandlerDataFullyReadEventArgs(string _url)
        {
            m_URL = _url;
        }
        private string m_URL = string.Empty;
        public string URL
        {
            get { return m_URL; }
        }
    }

    public class ProtocolHandlerOperationFailedEventArgs : System.EventArgs
    {
        public ProtocolHandlerOperationFailedEventArgs(string _url)
        {
            m_URL = _url;
        }
        private string m_URL = string.Empty;
        public string URL
        {
            get { return m_URL; }
        }
    }

    /// <summary>
    /// Event arguments for SynchDownloadRequestEventHandler delegate.
    /// </summary>
    public class SynchDownloadRequestEventArgs : System.EventArgs
    {
        public SynchDownloadRequestEventArgs(string protocol, string url, string referer, byte[] post, string PostDataMimeType, object browser, object sink, bool needfilename)
        {
            m_Protocol = protocol;
            m_Url = url;
            m_Referer = referer;
            m_Post = post;
            m_PostDataMimeType = PostDataMimeType;
            m_Browser = browser;
            m_Sink = sink;
            m_NeedFileName = needfilename;
        }

        private object m_Sink;
        private object m_Browser = null;
        private string m_Url = string.Empty;
        private string m_Protocol = string.Empty;
        private string m_Referer = string.Empty;
        private byte[] m_Post = null;
        private string m_PostDataMimeType = string.Empty;
        private bool m_ClientHandled = true;
        private bool m_NeedFileName = false;
        private string m_CacheFileName = string.Empty;
        private string m_DownloadDataMimeType = string.Empty;
        private byte[] m_DownloadData = null;
        private bool m_CancelDownload = false;

        /// <summary>
        /// Downloaded data.
        /// Used in Synch downloads
        /// </summary>
        public byte[] DownloadData
        {
            get { return m_DownloadData; }
            set { m_DownloadData = value; }
        }

        /// <summary>
        /// Underlying protocol of the download request (e.g. HTTP, HTTPS).
        /// </summary>
        public string Protocol
        {
            get { return m_Protocol; }
        }

        /// <summary>
        /// Url of the data to be downloaded.
        /// Can be set during an Synch download
        /// </summary>
        public string Url
        {
            get { return m_Url; }
            set { m_Url = value; }
        }

        /// <summary>
        /// Referer for the resource to be downloaded.
        /// </summary>
        public string Referer
        {
            get { return m_Referer; }
        }

        /// <summary>
        /// Reference to the cEXWB control that initiated the download request.
        /// </summary>
        public object Browser
        {
            get { return m_Browser; }
        }

        /// <summary>
        /// Optional post data (null for GET request).
        /// </summary>
        public byte[] Post
        {
            get { return m_Post; }
        }

        /// <summary>
        /// Post data Mime type
        /// </summary>
        public string PostDataMimeType
        {
            get { return m_PostDataMimeType; }
        }

        /// <summary>
        /// Set to false to have the default implementation download the resource
        /// Default = true
        /// </summary>
        public bool ClientHandled
        {
            get { return m_ClientHandled; }
            set { m_ClientHandled = value; }
        }

        /// <summary>
        /// The implementation requires a file name
        /// </summary>
        public bool NeedFileName
        {
            get { return m_NeedFileName; }
        }

        /// <summary>
        /// Cache file name which must be returned by client
        /// if NeedFileName property is true
        /// </summary>
        public string CacheFileName
        {
            get { return m_CacheFileName; }
            set { m_CacheFileName = value; }
        }

        /// <summary>
        /// Downloaded data Mime Type
        /// Used in Synch downloads
        /// </summary>
        public string DownloadDataMimeType
        {
            get { return m_DownloadDataMimeType; }
            set { m_DownloadDataMimeType = value; }
        }

        /// <summary>
        /// Set to true to cancel the current download
        /// without calling CancelDownloadRequest
        /// </summary>
        public bool CancelDownload
        {
            get { return m_CancelDownload; }
            set { m_CancelDownload = value; }
        }

    }

    /// <summary>
    /// Event arguments for AsynchDownloadRequestEventHandler delegate.
    /// </summary>
    public class AsynchDownloadRequestEventArgs : System.EventArgs
    {
        public AsynchDownloadRequestEventArgs(string protocol, string url, string referer, byte[] post, string PostDataMimeType, object browser, object sink, bool needfilename)
        {
            m_Protocol = protocol;
            m_Url = url;
            m_Referer = referer;
            m_Post = post;
            m_PostDataMimeType = PostDataMimeType;
            m_Browser = browser;
            m_Sink = sink;
            m_NeedFileName = needfilename;
        }

        private object m_Sink;
        private object m_Browser = null;
        private string m_Url = string.Empty;
        private string m_Protocol = string.Empty;
        private string m_Referer = string.Empty;
        private byte[] m_Post = null;
        private string m_PostDataMimeType = string.Empty;
        private bool m_ClientHandled = true;
        private bool m_NeedFileName = false;
        private string m_DownloadDataMimeType = string.Empty;
        private bool m_CancelDownload = false;

        /// <summary>
        /// Underlying protocol of the download request (e.g. HTTP, HTTPS).
        /// </summary>
        public string Protocol
        {
            get { return m_Protocol; }
        }

        /// <summary>
        /// Url of the data to be downloaded.
        /// Can be set during an Synch download
        /// </summary>
        public string Url
        {
            get { return m_Url; }
        }

        /// <summary>
        /// Referer for the resource to be downloaded.
        /// </summary>
        public string Referer
        {
            get { return m_Referer; }
        }

        /// <summary>
        /// Reference to the cEXWB control that initiated the download request.
        /// </summary>
        public object Browser
        {
            get { return m_Browser; }
        }

        /// <summary>
        /// Optional post data (null for GET request).
        /// </summary>
        public byte[] Post
        {
            get { return m_Post; }
        }

        /// <summary>
        /// Post data Mime type
        /// </summary>
        public string PostDataMimeType
        {
            get { return m_PostDataMimeType; }
        }

        /// <summary>
        /// Set to false to have the default implementation download the resource
        /// Default = true
        /// </summary>
        public bool ClientHandled
        {
            get { return m_ClientHandled; }
            set { m_ClientHandled = value; }
        }

        /// <summary>
        /// The implementation requires a file name
        /// </summary>
        public bool NeedFileName
        {
            get { return m_NeedFileName; }
        }

        /// <summary>
        /// Set to true to cancel the current download
        /// without calling CancelDownloadRequest
        /// </summary>
        public bool CancelDownload
        {
            get { return m_CancelDownload; }
            set { m_CancelDownload = value; }
        }

        /// <summary>
        /// Call this method to transfer the downloaded data and finish the download request.
        /// Call can either happen on the same thread as the OnStart event was raised on,
        /// or on a backgroud thread.
        /// This method can only be invoked once.
        /// </summary>
        /// <param name="data">Downloaded data (payload)</param>
        /// <param name="Url">Url of downloaded data, use to signal redirected downloads</param>
        /// <param name="mimeType">Mime type reported by server, leave blank if none</param>
        /// <param name="CacheFileName">Local file name for the downloaded resource, if needed</param>
        /// <remarks>
        /// Method can be invoked either on the same thread as the ProtocolHandlerOnStart event was raised on,
        /// or on a backgroud thread. This method can only be invoked once.
        /// </remarks>
        public void DownloadCompleted(byte[] data, string Url, string mimeType)
        {
            //This can be done here using m_Sink object
            if (m_Browser != null)
            {
                if (string.IsNullOrEmpty(mimeType))
                    mimeType = "text/html";
                ((IManagedProtocolSink)m_Browser).ManagedAppDownloadCompletedAsynch(data, Url, mimeType, m_Sink); //, m_CacheFileName);
            }
        }

        public void DownloadCompletedNeedFileName(string Url, string mimeType, string CacheFileName)
        {
            if (m_Browser != null)
            {
                if (string.IsNullOrEmpty(mimeType))
                    mimeType = "text/html";
                ((IManagedProtocolSink)m_Browser).ManagedAppDownloadCompletedAsynchNeedFileName(Url, mimeType, m_Sink, CacheFileName);
            }
        }

        /// <summary>
        /// Call this method to cancel a download request from the CExWb browser control.
        /// </summary>
        /// <remarks>
        /// Method can be invoked either on the same thread as the ProtocolHandlerOnStart event was raised on,
        /// or on a backgroud thread. This method can only be invoked once.
        /// </remarks>
        public void CancelDownloadRequest(int Inet_Error_Code)
        {
            if (m_Browser != null)
            {
                ((IManagedProtocolSink)m_Browser).ManagedAppAbortDownload(Inet_Error_Code, m_Sink);
            }
        }

    }

    public delegate void CustomDownloadRequestEventHandler(object sender, CustomDownloadRequestEventArgs e);
    public class CustomDownloadRequestEventArgs : System.EventArgs
    {
        private object m_Sink;
        private object m_Browser = null;
        private string m_Url = string.Empty;
        private string m_Protocol = string.Empty;

        public CustomDownloadRequestEventArgs(string protocol, string url, object browser, object sink)
        {
            m_Protocol = protocol;
            m_Url = url;
            m_Browser = browser;
            m_Sink = sink;
        }

        /// <summary>
        /// Reference to the cEXWB control that initiated the download request.
        /// </summary>
        public object Browser
        {
            get { return m_Browser; }
        }

        /// <summary>
        /// Url of the data to be downloaded.
        /// </summary>
        public string Url
        {
            get { return m_Url; }
        }

        /// <summary>
        /// Underlying custom protocol of the download request (e.g. data).
        /// </summary>
        public string Protocol
        {
            get { return m_Protocol; }
        }

        /// <summary>
        /// Call this method to transfer the downloaded data and finish the download request.
        /// Call can either happen on the same thread as the ProtocolHandlerOnStart event was raised on,
        /// or on a backgroud thread.
        /// This method can only be invoked once.
        /// </summary>
        /// <param name="data">Downloaded data (payload)</param>
        /// <param name="redirectedUrl">Url of downloaded data, use to signal redirected downloads</param>
        /// <param name="mimeType">Mime type reported by server, leave blank if none</param>
        /// <remarks>
        /// Method can be invoked either on the same thread as the ProtocolHandlerOnStart event was raised on,
        /// or on a backgroud thread. This method can only be invoked once.
        /// </remarks>
        public void DownloadCompleted(byte[] data, string redirectedUrl, string mimeType)
        {
            //This can be done here using m_Sink object
            if (m_Browser != null)
            {
                if (string.IsNullOrEmpty(mimeType))
                    mimeType = "text/html";
                ((ICustomProtocolSink)m_Browser).CustomAppDownloadCompleted(data, redirectedUrl, mimeType, m_Sink);
            }
        }
        /// <summary>
        /// Call this method to cancel a download request from the CExWb browser control.
        /// </summary>
        /// <remarks>
        /// Method can be invoked either on the same thread as the ProtocolHandlerOnStart event was raised on,
        /// or on a backgroud thread. This method can only be invoked once.
        /// </remarks>
        public void CancelDownloadRequest(int Inet_Error_Code)
        {
            if (m_Browser != null)
            {
                ((ICustomProtocolSink)m_Browser).CustomAppAbortDownload(Inet_Error_Code, m_Sink);
            }
        }

    }
}