using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3051040a-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLXMLHttpRequest
    {
        //    [propget, id(DISPID_IHTMLXMLHTTPREQUEST_READYSTATE)] HRESULT readyState([retval, out] long * p); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_READYSTATE)]
        int readyState { get;}

        //    [propget, id(DISPID_IHTMLXMLHTTPREQUEST_RESPONSEBODY)] HRESULT responseBody([retval, out] VARIANT * p); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_RESPONSEBODY)]
        object responseBody { get;}

        //    [propget, id(DISPID_IHTMLXMLHTTPREQUEST_RESPONSETEXT)] HRESULT responseText([retval, out] BSTR * p); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_RESPONSETEXT)]
        string responseText { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propget, id(DISPID_IHTMLXMLHTTPREQUEST_RESPONSEXML)] HRESULT responseXML([retval, out] IDispatch* * p); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_RESPONSEXML)]
        object responseXML { [return: MarshalAs(UnmanagedType.IDispatch)] get;}

        //    [propget, id(DISPID_IHTMLXMLHTTPREQUEST_STATUS)] HRESULT status([retval, out] long * p); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_STATUS)]
        int status { get;}

        //    [propget, id(DISPID_IHTMLXMLHTTPREQUEST_STATUSTEXT)] HRESULT statusText([retval, out] BSTR * p); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_STATUSTEXT)]
        string statusText { [return: MarshalAs(UnmanagedType.BStr)] get;}

        //    [propput, id(DISPID_IHTMLXMLHTTPREQUEST_ONREADYSTATECHANGE)] HRESULT onreadystatechange([in] VARIANT v); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_ONREADYSTATECHANGE)]
        object onreadystatechange { set;  get;}

        //    [id(DISPID_IHTMLXMLHTTPREQUEST_ABORT)] HRESULT abort();
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_ABORT)]
        void abort();

        //    [id(DISPID_IHTMLXMLHTTPREQUEST_OPEN)] HRESULT open([in] BSTR bstrMethod,[in] BSTR bstrUrl,[in] VARIANT varAsync,[optional, in] VARIANT varUser,[optional, in] VARIANT varPassword);
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_OPEN)]
        void open(
            [MarshalAs(UnmanagedType.BStr)] string bstrMethod,
            [MarshalAs(UnmanagedType.BStr)] string bstrUrl,
            object varAsync,
            object varUser,
            object varPassword
            );

        //    [id(DISPID_IHTMLXMLHTTPREQUEST_SEND)] HRESULT send([optional, in] VARIANT varBody); 
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_SEND)]
        void send(object varBody);

        //    [id(DISPID_IHTMLXMLHTTPREQUEST_GETALLRESPONSEHEADERS)] HRESULT getAllResponseHeaders([retval, out] BSTR* );
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_GETALLRESPONSEHEADERS)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string getAllResponseHeaders();

        //    [id(DISPID_IHTMLXMLHTTPREQUEST_GETRESPONSEHEADER)] HRESULT getResponseHeader([in] BSTR bstrHeader,[retval, out] BSTR* );
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_GETRESPONSEHEADER)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string getResponseHeader(
            [MarshalAs(UnmanagedType.BStr)] string bstrHeader
            );

        //    [id(DISPID_IHTMLXMLHTTPREQUEST_SETREQUESTHEADER)] HRESULT setRequestHeader([in] BSTR bstrHeader,[in] BSTR bstrValue);
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUEST_SETREQUESTHEADER)]
        void setRequestHeader(
        [MarshalAs(UnmanagedType.BStr)] string bstrHeader,
        [MarshalAs(UnmanagedType.BStr)] string bstrValue
        );

    }
}
