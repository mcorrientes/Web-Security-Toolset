using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLElementRender Interface

    /*
        int hr = Hresults.S_FALSE; //1
        //http://msdn.microsoft.com/archive/default.asp?url=/archive/en-us/samples/internet/libraries/ie6_lib/default.asp
        IHTMLDocument2 doc = (IHTMLDocument2)m_WBWebBrowser2.Document;
        IHTMLElement body = doc.body;
        Bitmap img = new Bitmap(m_WBRect.Right, m_WBRect.Bottom, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        using (Graphics gr = Graphics.FromImage(img))
        {
            IntPtr hdc = gr.GetHdc();
            IHTMLElementRender render = (IHTMLElementRender)body;
            hr = render.DrawToDC(hdc);
            gr.ReleaseHdc(hdc);
            gr.Dispose();
        }
        img.Save("C:\\test2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        img.Dispose();
        return hr;
     */

    [Guid("3050f669-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true), ComImport]
    public interface IHTMLElementRender
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DrawToDC([In] IntPtr hDC);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetDocumentPrinter([In, MarshalAs(UnmanagedType.BStr)] string
        bstrPrinterName, [In] IntPtr hDC);
    }
    #endregion
}