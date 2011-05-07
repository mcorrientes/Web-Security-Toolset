
/*
 Contributed by mailto:wangzq@gmail.com
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region IHTMLLinkElement interface
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]  // TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f205-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLLinkElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_REL)]
        string rel { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_REV)]
        string rev { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_TYPE)]
        string type { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_ONREADYSTATECHANGE)]
        object onreadystatechange { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_ONLOAD)]
        object onload { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_ONERROR)]
        object onerror { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_STYLESHEET)]
        IHTMLStyleSheet styleSheet { get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLLINKELEMENT_MEDIA)]
        string media { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
    #endregion
}
