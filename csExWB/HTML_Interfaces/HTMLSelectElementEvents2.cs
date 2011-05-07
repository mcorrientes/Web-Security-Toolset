using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

namespace IfacesEnumsStructsClasses
{
    #region HTMLSelectElementEvents2

    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f622-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLSelectElementEvents2
    {
        //    [id(DISPID_HTMLELEMENTEVENTS2_ONHELP)] VARIANT_BOOL onhelp([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onhelp([MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONCLICK)] VARIANT_BOOL onclick([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onclick(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK)] VARIANT_BOOL ondblclick([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondblclick([MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS)] VARIANT_BOOL onkeypress([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onkeypress(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN)] void onkeydown([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN)]
        void onkeydown(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONKEYUP)] void onkeyup([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYUP)]
        void onkeyup(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT)] void onmouseout([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT)]
        void onmouseout(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER)] void onmouseover([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER)]
        void onmouseover(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE)] void onmousemove([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE)]
        void onmousemove(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN)] void onmousedown([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN)]
        void onmousedown(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP)] void onmouseup([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP)]
        void onmouseup(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART)] VARIANT_BOOL onselectstart([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onselectstart(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE)] void onfilterchange([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE)]
        void onfilterchange(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART)] VARIANT_BOOL ondragstart([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragstart(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE)] VARIANT_BOOL onbeforeupdate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeupdate(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE)] void onafterupdate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE)]
        void onafterupdate(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE)] VARIANT_BOOL onerrorupdate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onerrorupdate(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONROWEXIT)] VARIANT_BOOL onrowexit([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWEXIT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onrowexit(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONROWENTER)] void onrowenter([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWENTER)]
        void onrowenter(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED)] void ondatasetchanged([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED)]
        void ondatasetchanged(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE)] void ondataavailable([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE)]
        void ondataavailable(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE)] void ondatasetcomplete([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE)]
        void ondatasetcomplete(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE)] void onlosecapture([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE)]
        void onlosecapture(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE)] void onpropertychange([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE)]
        void onpropertychange(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONSCROLL)] void onscroll([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSCROLL)]
        void onscroll(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONFOCUS)] void onfocus([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUS)]
        void onfocus(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBLUR)] void onblur([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBLUR)]
        void onblur(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONRESIZE)] void onresize([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZE)]
        void onresize(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDRAG)] VARIANT_BOOL ondrag([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAG)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondrag(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDRAGEND)] void ondragend([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGEND)]
        void ondragend(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER)] VARIANT_BOOL ondragenter([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragenter(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER)] VARIANT_BOOL ondragover([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragover(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE)] void ondragleave([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE)]
        void ondragleave(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDROP)] VARIANT_BOOL ondrop([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDROP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondrop(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT)] VARIANT_BOOL onbeforecut([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforecut(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONCUT)] VARIANT_BOOL oncut([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCUT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncut(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY)] VARIANT_BOOL onbeforecopy([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforecopy(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONCOPY)] VARIANT_BOOL oncopy([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCOPY)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncopy(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE)] VARIANT_BOOL onbeforepaste([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforepaste(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONPASTE)] VARIANT_BOOL onpaste([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPASTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onpaste(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU)] VARIANT_BOOL oncontextmenu([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontextmenu(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE)] void onrowsdelete([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE)]
        void onrowsdelete(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED)] void onrowsinserted([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED)]
        void onrowsinserted(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE)] void oncellchange([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE)]
        void oncellchange(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE)] void onreadystatechange([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE)]
        void onreadystatechange(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE)] void onlayoutcomplete([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE)]
        void onlayoutcomplete(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONPAGE)] void onpage([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPAGE)]
        void onpage(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER)] void onmouseenter([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER)]
        void onmouseenter(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE)] void onmouseleave([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE)]
        void onmouseleave(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONACTIVATE)] void onactivate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONACTIVATE)]
        void onactivate(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE)] void ondeactivate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE)]
        void ondeactivate(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE)] VARIANT_BOOL onbeforedeactivate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforedeactivate(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE)] VARIANT_BOOL onbeforeactivate([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeactivate(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN)] void onfocusin([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN)]
        void onfocusin(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT)] void onfocusout([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT)]
        void onfocusout(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOVE)] void onmove([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVE)]
        void onmove(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT)] VARIANT_BOOL oncontrolselect([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontrolselect(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOVESTART)] VARIANT_BOOL onmovestart([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVESTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmovestart(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOVEEND)] void onmoveend([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVEEND)]
        void onmoveend(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART)] VARIANT_BOOL onresizestart([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onresizestart(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND)] void onresizeend([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND)]
        void onresizeend(
[MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
);

        //    [id(DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL)] VARIANT_BOOL onmousewheel([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmousewheel(
        [MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj
        );

        //    [id(DISPID_HTMLSELECTELEMENTEVENTS2_ONCHANGE)] void onchange([in] IHTMLEventObj* pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLSELECTELEMENTEVENTS2_ONCHANGE)]
        void onchange([MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);

    } 
    #endregion

}
