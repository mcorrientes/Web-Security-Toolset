using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLTextRangeMetrics Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f40b-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLTextRangeMetrics
    {
        //    [propget, id(DISPID_IHTMLTEXTRANGEMETRICS_OFFSETTOP)] HRESULT offsetTop([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS_OFFSETTOP)]
        int offsetTop { get;}

        //    [propget, id(DISPID_IHTMLTEXTRANGEMETRICS_OFFSETLEFT)] HRESULT offsetLeft([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS_OFFSETLEFT)]
        int offsetLeft { get;}

        //    [propget, id(DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGTOP)] HRESULT boundingTop([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGTOP)]
        int boundingTop { get;}

        //    [propget, id(DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGLEFT)] HRESULT boundingLeft([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGLEFT)]
        int boundingLeft { get;}

        //    [propget, id(DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGWIDTH)] HRESULT boundingWidth([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGWIDTH)]
        int boundingWidth { get;}

        //    [propget, id(DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGHEIGHT)] HRESULT boundingHeight([retval, out] long * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS_BOUNDINGHEIGHT)]
        int boundingHeight { get;}

    } 
    #endregion

    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f4a6-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLTextRangeMetrics2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS2_GETCLIENTRECTS)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLRectCollection getClientRects();

        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTRANGEMETRICS2_GETBOUNDINGCLIENTRECT)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLRect getBoundingClientRect();
    }

}
