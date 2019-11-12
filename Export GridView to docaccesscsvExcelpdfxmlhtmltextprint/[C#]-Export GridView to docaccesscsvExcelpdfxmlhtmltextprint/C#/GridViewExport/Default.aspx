<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GridViewExport._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
    function PrintGridData() {
        var printGrid = document.getElementById('<%=GridView1.ClientID %>');
        var printwin = window.open('', 'PrintGridView',
'left=100,top=100,width=400,height=400,tollbar=0,scrollbars=1,status=0,resizable=1');
        printwin.document.write(printGrid.outerHTML);
        printwin.document.close();
        printwin.focus();
        printwin.print();
        printwin.close();
    }
   </script> 
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Export GridView Data in a Different File Format.
    </h2>
   <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        GridLines="None" AutoGenerateColumns="false">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        <Columns>
                 <asp:BoundField DataField="Student_ID" HeaderText="Student ID" />
                 <asp:BoundField DataField="Student_Name" HeaderText="Student Name" />
                 <asp:BoundField DataField="Education" HeaderText="Education" />
                 <asp:BoundField DataField="City" HeaderText="City" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnWord" runat="server" onclick="btnWord_Click" 
        Text="DOC" />
    <asp:Button ID="btnAccess" runat="server" onclick="btnAccess_Click" 
        Text="Access" />
    <asp:Button ID="btnExportImage" runat="server" 
        Text="Image" onclick="btnExportImage_Click" />
    <asp:Button ID="btnExportCSV" runat="server" onclick="btnExportCSV_Click" 
        Text="CSV" />
    <asp:Button ID="btnExcelExport" runat="server" Text="Excel" 
    onclick="btnExcelExport_Click" />
    <asp:Button ID="btnExportPDF" runat="server" onclick="btnExportPDF_Click" 
        Text="PDF" />
    <asp:Button ID="btnXML" runat="server" onclick="btnXML_Click" Text="XML" />
    <asp:Button ID="btnHTML" runat="server" onclick="btnHTML_Click" Text="HTML" />
    <asp:Button ID="btnText" runat="server" onclick="btnText_Click" Text="Text" />
    <asp:Button ID="btnPrint" runat="server" OnClientClick="PrintGridData();" Text="Print" />
</asp:Content>
