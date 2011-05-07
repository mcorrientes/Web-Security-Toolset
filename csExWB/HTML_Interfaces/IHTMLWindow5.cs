using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3051040e-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLWindow5
    {
        //    [propput, id(DISPID_IHTMLWINDOW5_XMLHTTPREQUEST)] HRESULT XMLHttpRequest([in] VARIANT v);
        //    [propget, id(DISPID_IHTMLWINDOW5_XMLHTTPREQUEST)] HRESULT XMLHttpRequest([retval, out] VARIANT * p);
        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW5_XMLHTTPREQUEST)]
        object XMLHttpRequest { set;  get;}

    }
}
