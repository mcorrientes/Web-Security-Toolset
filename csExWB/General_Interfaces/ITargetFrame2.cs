using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("86D52E11-94A8-11d0-82AF-00C04FD5AE38")]
    public interface ITargetFrame2
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetFrameName([MarshalAs(UnmanagedType.LPWStr)] string pszFrameName);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetFrameName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppszFrameName);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetParentFrame([Out, MarshalAs(UnmanagedType.IUnknown)] object ppunkParent);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetFrameSrc([MarshalAs(UnmanagedType.LPWStr)] string pszFrameSrc);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetFrameSrc([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppszFrameSrc);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetFramesContainer([Out, MarshalAs(UnmanagedType.Interface)] 
            object ppContainer); //IOleContainer
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetFrameOptions(int dwFlags);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetFrameOptions([Out] int pdwFlags);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetFrameMargins(int dwWidth, int dwHeight);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetFrameMargins([Out] int dwWidth, [Out] int dwHeight);
        
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int FindFrame([MarshalAs(UnmanagedType.LPWStr)] string pszTargetName, int dwFlags,
            [Out, MarshalAs(UnmanagedType.IUnknown) ] object ppunkTargetFrame);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetTargetAlias([MarshalAs(UnmanagedType.LPWStr)] string  pszTargetName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder  ppszTargetAlias);

}
}
