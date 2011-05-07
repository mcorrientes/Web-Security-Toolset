using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    [ComVisible(true), ComImport,
    GuidAttribute("F164EDF1-CC7C-4f0d-9A94-34222625C393"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInternetSecurityManagerEx
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ProcessUrlActionEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            UInt32 dwAction,
            IntPtr pPolicy, UInt32 cbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwFlags,
            UInt32 dwReserved,
            IntPtr pdwOutFlags //See enum PUAF for details
            );

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetSecuritySite(
            [In] IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecuritySite(
            out IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MapUrlToZone(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            IntPtr pdwZone,
            [In] int dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecurityId(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            [Out] IntPtr pbSecurityId, [In, Out] ref UInt32 pcbSecurityId,
            [In] ref UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ProcessUrlAction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            UInt32 dwAction,
            IntPtr pPolicy, UInt32 cbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwFlags,
            UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryCustomPolicy(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            ref Guid guidKey,
            out IntPtr ppPolicy, out UInt32 pcbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetZoneMapping(
            UInt32 dwZone,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern,
            UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetZoneMappings(
            [In] UInt32 dwZone, //One or more of tagURLZONE enums
            out IEnumString ppenumString,
            [In] UInt32 dwFlags);
    }
}
