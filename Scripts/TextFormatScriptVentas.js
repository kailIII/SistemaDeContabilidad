﻿function pageLoad(sender, args) {
    $(function () {
        $("#MainContent_txtCust").autocomplete({
            source: function (request, response) {
                var parameters = '{"prefix": "' + request.term + '","cedulaContribuyente": "' + $("#MainContent_hfCedulaContribuyente").val() + '"}';
                $.ajax({
                    url: "ServiceCliente.asmx/GetList",
                    data: parameters,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },

                    error: function (a, b, c) {

                    }
                });
            },
            select: function (e, i) {
                $("#MainContent_hfCustomerName").val(i.item.val);
            },
            minLength: 1
        });

        jQuery(document).ready(function ($) {
            $(".dateField").mask("99/99/9999");
        });


    });
}