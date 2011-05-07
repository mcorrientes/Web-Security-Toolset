using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComImport, ComVisible(true)]
    [Guid("3050f648-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMarkupContainer2
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OwningDoc([Out] out IHTMLDocument2 ppDoc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateChangeLog(IHTMLChangeSink pChangeSink,[Out] out IHTMLChangeLog ppChangeLog, bool fForward, bool fBackward);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RegisterForDirtyRange(IHTMLChangeSink pChangeSink,[Out] out uint pdwCookie);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int UnRegisterForDirtyRange(uint dwCookie);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetAndClearDirtyRange(uint dwCookie, IMarkupPointer pIPointerBegin, IMarkupPointer pIPointerEnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetVersionNumber();
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMasterElement([Out] out IHTMLElement ppElementMaster);
    }
}
