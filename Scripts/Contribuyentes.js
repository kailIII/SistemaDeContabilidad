﻿$(document).ready(function () {
    crearPopUpContribuyente("popUpContribuyente");
    crearPopUpInfoContribuyente("popUpInfoContribuyente");
    crearPopUpDeleteContribuyente("popUpDeleteContribuyente");
    
});

function crearPopUpContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 750
    }).parent().css('z-index', '1005');
}

function crearPopUpInfoContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 500
    }).parent().css('z-index', '1010');
}

function crearPopUpDeleteContribuyente(popUpId) {
    $("#" + popUpId).dialog({
        autoOpen: false,
        modal: true,
        appendTo: "form",
        width: 500
    }).parent().css('z-index', '1015');
}