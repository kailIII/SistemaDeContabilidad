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
        source: function (request, response) {
            $.ajax({
                url: "GetClientes.asmx/getArrayListForAutocomplete",
                data: "{ 'term': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item,
                            value: item
                        }
                    }))
                },
                error: function (a, b, c) {

                }
            });
        },
        minLength: 1
    });


}
