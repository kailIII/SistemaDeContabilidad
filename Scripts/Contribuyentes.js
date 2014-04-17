$(document).ready(function () {
    crearPopUpContribuyente("popUpContribuyente");
    crearPopUpInfoContribuyente("popUpInfoContribuyente");
    crearPopUpDeleteContribuyente("popUpDeleteContribuyente");
    crearPopUpManagerContribuyente("ManageCustomerProveedorPopUp");
});

function crearPopUpContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 750,
        resizable: false
    }).parent().css('z-index', '1005');
}

function crearPopUpInfoContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 575,
        resizable: false
    }).parent().css('z-index', '1005');
}

function crearPopUpDeleteContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 500,
        resizable: false
    }).parent().css('z-index', '1005');
}

function crearPopUpManagerContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 1000,
        resizable: false
    }).parent().css('z-index', '1005');
}