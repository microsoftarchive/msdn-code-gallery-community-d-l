<%@ Page language="C#" MasterPageFile="~masterurl/default.master" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>




<%-- The markup and script in the following Content element will be placed in the <head> of the page --%>
<WebPartPages:AllowFraming runat="server" />
 
<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
    <SharePoint:ScriptLink name="sp.js" runat="server" OnDemand="true" LoadAfterUI="true" Localizable="false" />

        <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>

    <!-- Add your CSS styles to the following file -->
    <link rel="Stylesheet" type="text/css" href="../Content/App.css" />

    <!-- Add your JavaScript to the following file -->
    <script type="text/javascript" src="../Scripts/App.js"></script>

    <!-- FullCalcendar  CSS styles to the following file -->
<link href='../Content/fullcalendar.css' rel='stylesheet' />
<link href='../Content/fullcalendar.print.css' rel='stylesheet' media='print' />
    <!-- JQuery to the following file -->
<script src='../Scripts/jquery-1.9.1.min.js'></script>
<script src='../Scripts/jquery-ui-1.10.2.custom.min.js'></script>
    <!-- FullCalendar  JavaScript API to the following file -->
    <script src='../Scripts/fullcalendar.min.js'></script>

    
    <!-- FullCalendar  JavaScript API to the following file -->
        <script src="../Scripts/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>
    
    <!-- The following script runs when the DOM is ready. The inline code uses a SharePoint feature to ensure -->
    <!-- The SharePoint script file sp.js is loaded and will then execute the sharePointReady() function in App.js -->
    <script   type="text/javascript"  src="//ajax.aspnetcdn.com/ajax/4.0/1/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="_layouts/15/sp.js"></script>'

        <SharePoint:ScriptLink name="sp.js" runat="server" OnDemand="true" LoadAfterUI="true" Localizable="false" />


    <script type="text/javascript">

      

        $(document).ready(function () {
            
           


            var options = { html: $('#updatedialog').html(), width: 400, height: 300 };
            SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
            
            SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () {
                //sharePointReady();
            });
        });
    </script>
</asp:Content>
<%-- The markup and script in the following Content element will be placed in the <body> of the page --%>


<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderMain" runat="server">
   
<WebPartPages:AllowFraming ID="AllowFraming2" runat="server" />
     
   <div id='calendar'></div>
            

    </asp:Content>