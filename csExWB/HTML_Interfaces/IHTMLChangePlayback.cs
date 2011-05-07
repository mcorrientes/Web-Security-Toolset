using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComImport, ComVisible(true)]
    [Guid("3050f6e0-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHTMLChangePlayback
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ExecChange(IntPtr pbRecord, bool fForward);
    }
}
