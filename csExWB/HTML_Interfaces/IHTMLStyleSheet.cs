
/*
 Contributed by mailto:wangzq@gmail.com
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{

    #region IHTMLStyleSheet
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2e3-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLStyleSheet
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_TITLE)]
        string title { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_PARENTSTYLESHEET)]
        IHTMLStyleSheet parentStyleSheet { get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_OWNINGELEMENT)]
        IHTMLElement owningElement { get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_READONLY)]
        bool readOnly { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_IMPORTS)]
        IHTMLStyleSheetsCollection imports { get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_ID)]
        string id { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_ADDIMPORT)]
        int addImport(string bstrURL, int lIndex);
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_ADDRULE)]
        int addRule(string bstrSelector, string bstrRule, int lIndex);
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_REMOVEIMPORT)]
        void removeImport(int lIndex);
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_REMOVERULE)]
        void removeRule(int lIndex);
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_MEDIA)]
        string media { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_CSSTEXT)]
        string cssText { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEET_RULES)]
        object rules { [return: MarshalAs(UnmanagedType.IDispatch)] get; }   // TODO: should be IHTMLStyleSheetRulesCollection
    }
    #endregion
}
