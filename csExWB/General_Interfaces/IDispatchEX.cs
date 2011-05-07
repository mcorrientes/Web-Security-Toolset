using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Text;

namespace IfacesEnumsStructsClasses
{
    /// <summary><para><c>IDispatchEx</c> interface.</para></summary>
    [Guid("A6EF9860-C720-11D0-9337-00A0C90DCAA9")]
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4096)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IDispatchEx
    {
        /// <summary><para><c>GetDispID</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>GetDispID</c> method was the following:  <c>HRESULT GetDispID (BSTR bstrName, unsigned long grfdex, [out] long* pid)</c>;</para></remarks>
        // IDL: HRESULT GetDispID (BSTR bstrName, unsigned long grfdex, [out] long* pid);
        // VB6: Sub GetDispID (ByVal bstrName As String, ByVal grfdex As Long, pid As Long)
        [DispId(1610743808)]
        void GetDispID([MarshalAs(UnmanagedType.BStr)] string bstrName, uint grfdex, [Out] out int pid);

        /// <summary><para><c>RemoteInvokeEx</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>RemoteInvokeEx</c> method was the following:  <c>HRESULT RemoteInvokeEx (long id, unsigned long lcid, unsigned long dwFlags, [in] Interop.stdole.DISPPARAMS* pdp, [out] VARIANT* pvarRes, [out] Interop.stdole.EXCEPINFO* pei, IServiceProvider* pspCaller, unsigned int cvarRefArg, [in] unsigned int* rgiRefArg, [in, out] VARIANT* rgvarRefArg)</c>;</para></remarks>
        // IDL: HRESULT RemoteInvokeEx (long id, unsigned long lcid, unsigned long dwFlags, [in] Interop.stdole.DISPPARAMS* pdp, [out] VARIANT* pvarRes, [out] Interop.stdole.EXCEPINFO* pei, IServiceProvider* pspCaller, unsigned int cvarRefArg, [in] unsigned int* rgiRefArg, [in, out] VARIANT* rgvarRefArg);
        // VB6: Sub RemoteInvokeEx (ByVal id As Long, ByVal lcid As Long, ByVal dwFlags As Long, pdp As Interop.stdole.DISPPARAMS, pvarRes As Any, pei As Interop.stdole.EXCEPINFO, ByVal pspCaller As IServiceProvider, ByVal cvarRefArg As Long, rgiRefArg As Long, rgvarRefArg As Any)
        [DispId(1610743809)]
        void RemoteInvokeEx(int id, uint lcid, uint dwFlags, 
            [In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pdp, 
            [Out] out object pvarRes, 
            [Out] out System.Runtime.InteropServices.ComTypes.EXCEPINFO pei, 
            IServiceProvider pspCaller);
            //, uint cvarRefArg, [In] ref uint rgiRefArg, [In, Out] ref object rgvarRefArg);

        /// <summary><para><c>DeleteMemberByName</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>DeleteMemberByName</c> method was the following:  <c>HRESULT DeleteMemberByName (BSTR bstrName, unsigned long grfdex)</c>;</para></remarks>
        // IDL: HRESULT DeleteMemberByName (BSTR bstrName, unsigned long grfdex);
        // VB6: Sub DeleteMemberByName (ByVal bstrName As String, ByVal grfdex As Long)
        [DispId(1610743810)]
        void DeleteMemberByName([MarshalAs(UnmanagedType.BStr)] string bstrName, uint grfdex);

        /// <summary><para><c>DeleteMemberByDispID</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>DeleteMemberByDispID</c> method was the following:  <c>HRESULT DeleteMemberByDispID (long id)</c>;</para></remarks>
        // IDL: HRESULT DeleteMemberByDispID (long id);
        // VB6: Sub DeleteMemberByDispID (ByVal id As Long)
        [DispId(1610743811)]
        void DeleteMemberByDispID(int id);

        /// <summary><para><c>GetMemberProperties</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>GetMemberProperties</c> method was the following:  <c>HRESULT GetMemberProperties (long id, unsigned long grfdexFetch, [out] unsigned long* pgrfdex)</c>;</para></remarks>
        // IDL: HRESULT GetMemberProperties (long id, unsigned long grfdexFetch, [out] unsigned long* pgrfdex);
        // VB6: Sub GetMemberProperties (ByVal id As Long, ByVal grfdexFetch As Long, pgrfdex As Long)
        [DispId(1610743812)]
        void GetMemberProperties(int id, uint grfdexFetch, [Out] out uint pgrfdex);

        /// <summary><para><c>GetMemberName</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>GetMemberName</c> method was the following:  <c>HRESULT GetMemberName (long id, [out] BSTR* pbstrName)</c>;</para></remarks>
        // IDL: HRESULT GetMemberName (long id, [out] BSTR* pbstrName);
        // VB6: Sub GetMemberName (ByVal id As Long, pbstrName As String)
        [DispId(1610743813)]
        void GetMemberName(int id, [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

        /// <summary><para><c>GetNextDispID</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>GetNextDispID</c> method was the following:  <c>HRESULT GetNextDispID (unsigned long grfdex, long id, [out] long* pid)</c>;</para></remarks>
        // IDL: HRESULT GetNextDispID (unsigned long grfdex, long id, [out] long* pid);
        // VB6: Sub GetNextDispID (ByVal grfdex As Long, ByVal id As Long, pid As Long)
        [DispId(1610743814)]
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetNextDispID(uint grfdex, int id, [Out] out int pid);

        /// <summary><para><c>GetNameSpaceParent</c> method of <c>IDispatchEx</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>GetNameSpaceParent</c> method was the following:  <c>HRESULT GetNameSpaceParent ([out] IUnknown** ppunk)</c>;</para></remarks>
        // IDL: HRESULT GetNameSpaceParent ([out] IUnknown** ppunk);
        // VB6: Sub GetNameSpaceParent (ppunk As IUnknown)
        [DispId(1610743815)]
        void GetNameSpaceParent([Out, MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
    }

    public sealed class DispatchExFlags
    {
        // Input flags for GetDispID
        public const uint fdexNameCaseSensitive       =0x00000001;
        public const uint fdexNameEnsure              =0x00000002;
        public const uint fdexNameImplicit            =0x00000004;
        public const uint fdexNameCaseInsensitive     =0x00000008;
        public const uint fdexNameInternal            =0x00000010;
        public const uint fdexNameNoDynamicProperties = 0x00000020;

        // Output flags for GetMemberProperties]
        public const uint fdexPropCanGet              =0x00000001;
        public const uint fdexPropCannotGet           =0x00000002;
        public const uint fdexPropCanPut              =0x00000004;
        public const uint fdexPropCannotPut           =0x00000008;
        public const uint fdexPropCanPutRef           =0x00000010;
        public const uint fdexPropCannotPutRef        =0x00000020;
        public const uint fdexPropNoSideEffects       =0x00000040;
        public const uint fdexPropDynamicType         =0x00000080;
        public const uint fdexPropCanCall             =0x00000100;
        public const uint fdexPropCannotCall          =0x00000200;
        public const uint fdexPropCanConstruct        =0x00000400;
        public const uint fdexPropCannotConstruct     =0x00000800;
        public const uint fdexPropCanSourceEvents     =0x00001000;
        public const uint fdexPropCannotSourceEvents = 0x00002000;

        //Macros
        public const uint grfdexPropCanAll = (uint)(fdexPropCanGet | fdexPropCanPut | fdexPropCanPutRef | fdexPropCanCall | fdexPropCanConstruct | fdexPropCanSourceEvents);

        public const uint grfdexPropCannotAll = (uint)(fdexPropCannotGet | fdexPropCannotPut | fdexPropCannotPutRef | fdexPropCannotCall | fdexPropCannotConstruct | fdexPropCannotSourceEvents);

        public const uint grfdexPropExtraAll = (uint)(fdexPropNoSideEffects | fdexPropDynamicType);

        public const uint grfdexPropAll = (uint)(grfdexPropCanAll | grfdexPropCannotAll | grfdexPropExtraAll);

        // Input flags for GetNextDispID
        public const uint fdexEnumDefault = 0x00000001;
        public const uint fdexEnumAll     = 0x00000002;

        // Additional flags for Invoke - when object member is
        // used as a constructor.
        public const uint DISPATCH_CONSTRUCT = 0x4000;

        // Standard DISPIDs
        public const int DISPID_THIS = -613;
        public const int DISPID_STARTENUM = -1; //DISPID_UNKNOWN;
    }




}
