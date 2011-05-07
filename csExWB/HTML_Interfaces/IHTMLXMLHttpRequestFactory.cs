using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3051040c-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLXMLHttpRequestFactory
    {
        //    [id(DISPID_IHTMLXMLHTTPREQUESTFACTORY_CREATE)] HRESULT create([retval, out] IHTMLXMLHttpRequest** );
        [DispId(HTMLDispIDs.DISPID_IHTMLXMLHTTPREQUESTFACTORY_CREATE)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLXMLHttpRequest create();
    }
}
