using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComImport, ComVisible(true)]
    [Guid("3050f649-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHTMLChangeLog
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetNextChange(IntPtr pbBuffer, int nBufferSize, [Out] out int pnRecordLength);
    }
}
