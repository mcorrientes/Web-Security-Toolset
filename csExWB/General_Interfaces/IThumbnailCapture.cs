using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    //Does not work??? Always returns S_FALSE
    //Type shelluitype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_HTML_Thumbnail_Extractor, true);
    ////Using Activator inplace of CoCreateInstance, returns IUnknown
    //IThumbnailCapture uihelper = System.Activator.CreateInstance(shelluitype) as IThumbnailCapture;
    //if (uihelper == null)
    //    return hr;
    //IHTMLDocument2 doc = (IHTMLDocument2)m_WBWebBrowser2.Document;
    //IntPtr pdoc2 = Marshal.GetIUnknownForObject(doc);
    //if (pdoc2 != null)
    //{
    //    using (Bitmap img = new Bitmap(m_WBRect.Right, m_WBRect.Bottom, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
    //    {
    //        IntPtr hbmp = img.GetHbitmap();
    //        tagSIZE bounds = new tagSIZE();
    //        bounds.cx = m_WBRect.Right;
    //        bounds.cy = m_WBRect.Bottom;
    //        int hr = uihelper.CaptureThumbnail(ref bounds, pdoc2, out hbmp);
    //        img.Save("C:\\test2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
    //    }
    //    Marshal.Release(pdoc2);
    //}

    [ComVisible(true), ComImport()]
    [GuidAttribute("4ea39266-7211-409f-b622-f63dbd16c533")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IThumbnailCapture
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CaptureThumbnail(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagSIZE pMaxSize, //SIZE *
           IntPtr pHTMLDoc2, //IUnknown *
           out IntPtr phbmThumbnail); //HBITMAP *
    }
}
