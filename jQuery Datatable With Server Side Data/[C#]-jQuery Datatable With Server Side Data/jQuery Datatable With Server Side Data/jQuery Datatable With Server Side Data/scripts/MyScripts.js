$(document).ready(function () {
    $('#myGrid').DataTable({
        "ajax": {
            "url": "../Home/GetGata/",
            "dataSrc": ""
        },
        "columns": [
        { "data": "SalesOrderID" },
        { "data": "SalesOrderDetailID" },
        { "data": "CarrierTrackingNumber" },
        { "data": "OrderQty" },
        { "data": "ProductID" },
        { "data": "UnitPrice" }]        
    });
});