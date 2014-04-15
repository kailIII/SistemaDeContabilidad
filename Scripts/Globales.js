$(document).ready(function () {
    $("#popUpMensaje").dialog({
        autoOpen: false,
        modal: true,
        width: 500,
        open: function () {
            $(".ui-widget-overlay.ui-front").css('z-index', '1049');
        },
        close: function () {
            $(".ui-widget-overlay.ui-front").css('z-index', '100');
        },
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
            }
        }
    }).parent().css('z-index', '1050');
});

function crearPopUp(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 500
    }).parent().css('z-index', '1005');
}

function crearPopUpDelete(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 500
    }).parent().css('z-index', '1010');
}


function abrirPopUp(popUpId, titulo) {
    $("#" + popUpId).dialog("open");
    $("#" + popUpId).dialog({ title: titulo });
}

function cerrarPopUp(popUpId) {
    $("#" + popUpId).dialog("close");
}

function abrirPopUpPersonalizado(popUpId, titulo, mensaje) {
    $("#" + popUpId).dialog("open");
    $("#" + popUpId).text(mensaje);
    $("#" + popUpId).dialog({ title: titulo });
}

function enterBuscar(e, idBoton) {
    if (e.keyCode == 13) {
        $("#" + idBoton).click();
        e.preventDefault();
    }
}