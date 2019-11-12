<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestJqGrid.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head id="Head">
    <title>Demonstration how use jqGrid to call ASMX-WebService  rows</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="/Content/css/ui-darkness/jquery-ui-1.8.21.custom.css" />
    <link rel="stylesheet" type="text/css" href="/Content/themes/ui.jqgrid.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.8.21.custom.min.js"></script>
    <script type="text/javascript" src="/Scripts/trirand/i18n/grid.locale-en.js"></script>
    <script type="text/javascript" src="/Scripts/trirand/jquery.jqGrid.min.js"></script>
    <script type="text/javascript">
    //<![CDATA[
        jQuery(document).ready(function () {
            $("#contactsList").jqGrid({
                url: '/WsDataProvider.asmx/GetGridDataOrder',
                datatype: 'json',
                mtype: 'POST',
                ajaxGridOptions: { contentType: 'application/json; charset=utf-8' },
                serializeGridData: function (postData) {
                    return JSON.stringify(postData);
                },
                jsonReader: { repeatitems: false, root: "d.rows", page: "d.page", total: "d.total", records: "d.records" },
                colModel: [
                    { name: 'ID', label: 'ID', key: true, width: 60, sortable: true, align: "center", hidden: false },
                    { name: 'FechaPago', label: 'Fecha', width: 80, sortable: true, hidden: false, formatter: 'date', formatoptions: { srcformat: 'm/d/Y h:i:s', newformat: 'd-m-Y'} },
                    { name: 'Concepto', label: 'Concepto', width: 180, sortable: true, hidden: false },
                    { name: 'Importe', label: 'Importe', width: 180, sortable: true, align: "center", hidden: false, formatter:currencyFmatter },
                    { name: 'Tasas', label: 'Tasa', key: true, width: 60, sortable: true, align: "center", hidden: false, formatter: currencyFmatter },
                    { name: 'Total', label: 'Total', width: 80, sortable: true, align: "center", hidden: false, formatter: currencyFmatter },
                    { name: 'Notas', label: 'Notas', width: 180, sortable: false, hidden: false }
                ],
                rowNum: 10,
                rowList: [10, 20, 30],
                pager: "#gridpager",
                viewrecords: true,
                gridview: true,
                rownumbers: true,
                height: 420, width: 980,
                caption: 'Lista de Pagos'
            }).jqGrid('navGrid', '#gridpager', { 
                edit: true, add: true, del: false, search: true
            }).jqGrid('navButtonAdd', '#gridpager', {
                caption: '<span class="ui-pg-button-text">Export</span>',
                buttonicon: "ui-icon-extlink",
                title: "Export To Excel",
                onClickButton: function () {
                    window.location = 'Export2Excel.aspx';
                }
            });
        });

    function currencyFmatter (cellvalue, options, rowObject)
    {

        return cellvalue + " €";
    }
    //]]>

    </script>
</head>

<body>

<table id="contactsList"></table>
<div id="gridpager"></div>

</body>
</html>