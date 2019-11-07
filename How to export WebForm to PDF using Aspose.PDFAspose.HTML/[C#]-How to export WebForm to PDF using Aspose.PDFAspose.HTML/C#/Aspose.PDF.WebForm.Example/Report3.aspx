<%@ Page Title="Report of tenants move-in and payments (v3)" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Report3.aspx.cs" Inherits="Aspose.PDF.WebForm.Example.Report3" %>
<%@ Register TagPrefix="aspose" Namespace="Aspose.Pdf.GridViewExport" Assembly="Aspose.Pdf.GridViewExport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <aspose:ExportGridViewToPdf ID="ExportGridViewToPdf1" ExportButtonText="Export to Pdf"
            CssClass="table table-hover table-bordered" ExportButtonCssClass="btn btn-primary ExportButton"
            ExportInLandscape="True" ExportOutputPathOnServer="c:\\temp" 
            Caption="Report of tenants move-in and payments"
            ExportFileHeading="<h1>Report of tenants move-in and payments</h1>"
            PageSize="10" AllowPaging="True"
            LicenseFilePath="c:\inetpub\Aspose.Total.lic" runat="server" CellPadding="4"
            ForeColor="#333333" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName" />
            <asp:BoundField DataField="RentalPropertyAddress" HeaderText="Rental Property Address" SortExpression="RentalPropertyAddress" />
            <asp:BoundField DataField="MoveInDate" HeaderText="Move-in Date" SortExpression="MoveInDate" DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="LeaseEndDate" HeaderText="Lease-end Date" SortExpression="LeaseEndDate" DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="MonthlyPayment" HeaderText="Monthly Payment" SortExpression="MonthlyPayment" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <PagerSettings Mode="Numeric"
            Position="Bottom"
            PageButtonCount="10" />

        <PagerStyle HorizontalAlign="Center"
            CssClass="GridPager" />
        </aspose:ExportGridViewToPdf>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteTenant" InsertMethod="CreateTenant"
        SelectMethod="GetAllTenants" TypeName="WebForms.Example.Models.Tenant" UpdateMethod="EditTenant">
        <DeleteParameters>
            <asp:Parameter Name="tenantId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="fullname" Type="String" />
            <asp:Parameter Name="rentalPropertyAddress" Type="String" />
            <asp:Parameter Name="moveInDate" Type="DateTime" />
            <asp:Parameter Name="leaseEndDate" Type="DateTime" />
            <asp:Parameter Name="monthlyPayment" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="fullname" Type="String" />
            <asp:Parameter Name="rentalPropertyAddress" Type="String" />
            <asp:Parameter Name="moveInDate" Type="DateTime" />
            <asp:Parameter Name="leaseEndDate" Type="DateTime" />
            <asp:Parameter Name="monthlyPayment" Type="Decimal" />
        </UpdateParameters>
    </asp:ObjectDataSource>    
</asp:Content>

