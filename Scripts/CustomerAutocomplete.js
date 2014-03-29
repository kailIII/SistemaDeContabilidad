/*$(document).ready(function () {
    $(".autocomplete").autocomplete({
        source: 'http://localhost:51609/SistemaDeContabilidad/GetClientes.asmx?op=getAllClientes',
        minLength: 1

    });

});*/

$(document).ready(function() {
    SearchText();
});
function SearchText() {
    $(".autocomplete").autocomplete({
        source: function(request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "GetClientes.asmx/getAllClientes",
                data: "{'term':'" + document.getElementById('MainContent_txtCustomerName').value + "'}",
                dataType: "json",
                success: function(data) {
                    response(data.d);
                },
                error: function(result) {
                    alert("Error");
                }
            });
        }
    });
}
