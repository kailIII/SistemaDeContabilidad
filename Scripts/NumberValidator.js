function jsDecimals(e) {

    var evt = (e) ? e : window.event;
    var key = (evt.keyCode) ? evt.keyCode : evt.which;
    if (key != null) {
        key = parseInt(key, 10);
        if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
            if (!jsIsUserFriendlyChar(key, "Decimals")) {
                return false;
            }
        }
        else {
            if (evt.shiftKey) {
                return false;
            }
        }
    }
    return true;
}

// Function to check for user friendly keys  
//------------------------------------------
function jsIsUserFriendlyChar(val, step) {
    // Backspace, Tab, Enter, Insert, and Delete  
    if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
        return true;
    }
    // Ctrl, Alt, CapsLock, Home, End, and Arrows  
    if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
        return true;
    }
    if (step == "Decimals") {
        if (val == 190 || val == 110) {  //Check dot key code should be allowed
            return true;
        }
    }
    // The rest  
    return false;
}

function blurFunction(txtBox) {
    $(txtBox).val($.number($(txtBox).val(), 2));
    calcExempt($(txtBox).attr("id"));
    calcTaxed($(txtBox).attr("id"));
    calcTotal();
}

function calcTotal() {
    total = (replaceNumber($("#MainContent_txtSubExempt").val()) + replaceNumber($("#MainContent_txtSubTaxed").val()));
    $("#MainContent_txtTotal").val($.number(total, 2));
}

function calcExempt(exemptId) {
    if (exemptId == "MainContent_txtSubExempt") {
        exento = (replaceNumber($("#MainContent_txtSubExempt").val()) + replaceNumber($("#MainContent_txtDesExempt").val()));
        $("#MainContent_txtMontoExempt").val($.number(exento, 2));
    }
    else{
        montoExento = (replaceNumber($("#MainContent_txtMontoExempt").val()) - replaceNumber($("#MainContent_txtDesExempt").val()));
        $("#MainContent_txtSubExempt").val($.number(montoExento, 2));
    }
}

function calcTaxed(taxedId) {
    if (taxedId == "MainContent_txtIV") {
        montoGravado = (replaceNumber($("#MainContent_txtIV").val()) / 0.13) + replaceNumber($("#MainContent_txtDesTaxed").val());
        $("#MainContent_txtMontoTaxed").val($.number(montoGravado, 2));
        gravado = (replaceNumber($("#MainContent_txtMontoTaxed").val()) - replaceNumber($("#MainContent_txtDesTaxed").val()) + replaceNumber($("#MainContent_txtIV").val()));
        $("#MainContent_txtSubTaxed").val($.number(gravado, 2));
    }
    else if (taxedId == "MainContent_txtSubTaxed") {
        montoGravado = (replaceNumber($("#MainContent_txtSubTaxed").val()) / 1.13 + replaceNumber($("#MainContent_txtDesTaxed").val()));
        $("#MainContent_txtMontoTaxed").val($.number(montoGravado, 2));
        impuesto = (replaceNumber($("#MainContent_txtMontoTaxed").val()) - replaceNumber($("#MainContent_txtDesTaxed").val()))*0.13;
        $("#MainContent_txtIV").val($.number(impuesto, 2));
    }
    else {
        gravado = (replaceNumber($("#MainContent_txtMontoTaxed").val()) - replaceNumber($("#MainContent_txtDesTaxed").val()));
        impuesto = gravado * 0.13;
        gravado = gravado + impuesto;
        $("#MainContent_txtIV").val($.number(impuesto, 2));
        $("#MainContent_txtSubTaxed").val($.number(gravado, 2));
    }
}

function replaceNumber(stringNumber) {
    resultado = stringNumber.replace(',', '');
    return Number(resultado);
}

function updateDate() {
    days = Number($("#MainContent_txtTerm").val());
    addDays($("#MainContent_txtDate").val(), days);
}

function addDays(date, days) {
    fecha = moment(""+date, ["DD-MM-YYYY"]);
    nueva = moment(fecha).add('days', Number(days));
    $("#MainContent_txtExpiration").val(moment(nueva).format("DD/MM/YYYY"));
}


