using System;
using System.Collections.Generic;
using System.Text;

namespace csExWB
{
    /// <summary>
    /// Implemented by cEXWB, provides a mechanism for the
    /// client to notify the protocol handler
    /// of completion of data retreival or cancellation.
    /// </summary>
    public interface IManagedProtocolSink
    {
        /// <summary>
        /// Called to notify protocol handler of completion of data retreival
        /// </summary>
        /// <param name="data">Byte array representing downloaded data</param>
        /// <param name="Url">Redirected url or the original</param>
        /// <param name="mimeType">MIME type of the downloaded resource</param>
        /// <param name="sink">Protocol handler object</param>
        void ManagedAppDownloadCompletedAsynch(byte[] data, string Url, string mimeType, object sink);

        /// <summary>
        /// Called to notify protocol handler of completion of data retreival
        /// Requireing a local file name
        /// </summary>
        /// <param name="Url">Redirected url or the original</param>
        /// <param name="mimeType">MIME type of the downloaded resource</param>
        /// <param name="sink">Protocol handler object</param>
        /// <param name="CacheFileName">A local filename</param>
        void ManagedAppDownloadCompletedAsynchNeedFileName(string Url, string mimeType, object sink, string CacheFileName);

        /// <summary>
        /// Called to notify protocol handler to cancel or abort operation.
        /// </summary>
        /// <param name="Inet_Error_Code">One of Inet_Error_xxxx errors</param>
        /// <param name="sink">Protocol handler object</param>
        void ManagedAppAbortDownload(int Inet_Error_Code, object sink);
    }
}
