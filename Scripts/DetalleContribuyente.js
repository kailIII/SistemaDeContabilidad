$(document).ready(function () {
    crearPopUpSelectDate("popUpSelectDateVentas");
    crearPopUpSelectDate("popUpSelectDateCompras");
});

function crearPopUpSelectDate(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 500,
        resizable: false,
        open: function () {                         // open event handler
            $(this)                                // the element being dialogged
                .parent()                          // get the dialog widget element
                .find(".ui-dialog-titlebar-close") // find the close button for this dialog
                .hide();                           // hide it
        }
    }).parent().css('z-index', '1005');
}

function pageLoad(sender, args) {
    $(function () {
        $('#MainContent_TextFechaVentas').datepicker({
            monthNamesShort: [ "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" ],
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'mm/yy',
            onClose: function (dateText, inst) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).datepicker('setDate', new Date(year, month, 1));
                $("#MainContent_hfDateVentas").val($(this).datepicker({ dateFormat: 'mm/yy' }).val());
            }
        });
    });

    $(function () {
        $('#MainContent_TextFechaCompras').datepicker({
            monthNamesShort: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"],
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'mm/yy',
            onClose: function (dateText, inst) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).datepicker('setDate', new Date(year, month, 1));
                $("#MainContent_hfDateCompras").val($(this).datepicker({ dateFormat: 'mm/yy' }).val());
            }
        });
    });
}