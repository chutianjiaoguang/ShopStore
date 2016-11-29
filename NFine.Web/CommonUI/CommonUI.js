/********************************************选择供应商***********************************************/
/**
* data: 传入参数
* Mult:是否允许选择多个checkbox，默认是true
* callBack: 选择之后的回调函数
**/
; (function ($) {
    $.fn.SupplierDialog = function (options) {
        var defaultOption = {
            data: {},
            Mult: true,
            EventName: "dblclick",
            callBack: undefined
        };
        defaultOption = $.extend(defaultOption, options);
        var submit = function (v, h, f) {
            if (v == 1) {
                var result = undefined;
                h.find("input[type='checkbox'][name='product_item']").each(function (i, item) {
                    var flag = $(item).attr("checked");
                    if (flag || flag == "checked") {
                        var data = $(item).attr("data-value");
                        if (!git.IsEmpty(data)) {
                            result = JSON.parse(unescape(data));
                        }
                    }
                });
                if (defaultOption.callBack != undefined && typeof (defaultOption.callBack) == "function") {
                    defaultOption.callBack(result);
                }
            }
        };
        $(this).bind(defaultOption.EventName, function () {
            $.jBox.open("get:/StoreManage/Store/StoreDialog", "选择仓库", 850, 500, {
                buttons: { "选择": 1, "关闭": 2 }, submit: submit, loaded: function (h) {

                }
            });
        });
    };
})(jQuery);