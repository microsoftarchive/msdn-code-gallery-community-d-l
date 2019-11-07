$(function () {
    $(".drag_drop_grid").sortable({
        items: 'tr:not(tr:first-child)',
        cursor: 'crosshair',
        connectWith: '.drag_drop_grid',
        axis: 'x,y',
        dropOnEmpty: true,
        receive: function (e, ui) {
            $(this).find("tbody").append(ui.item);
            //Aqui puede actualizar la informacion de dataset o base de datos 
            //mediante web metodos o una WebApi
            // var objeto = {};
            //objeto.Id = $("[id*=gvDest] tr:last").find("td:nth-child(1)").html();
            //objeto.Value = $("[id*=gvDest] tr:last").find("td:nth-child(2)").html();
            //$.ajax({
            //    type: "POST",
            //    url: "url Web Metodo o WebApi",
            //    data: '{objeto: ' + JSON.stringify(objeto) + '}',
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (response) {
            //        alert("Accion realizada correctamente");
            //    }
            //});
            return false;
        }
    });
    $("[id*=gvDest] tr:not(tr:first-child)").remove();
});