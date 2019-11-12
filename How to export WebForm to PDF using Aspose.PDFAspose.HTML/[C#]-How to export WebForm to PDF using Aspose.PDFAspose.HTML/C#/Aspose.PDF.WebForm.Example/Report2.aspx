<%@ Page Title="Report of tenants move-in and payments (v2)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report2.aspx.cs" Inherits="Aspose.PDF.WebForm.Example.Report2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>. <asp:Button ID="Button1" runat="server" Text="Get PDF" CssClass="btn btn-default" OnClick="Button1_Click" /></h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        CssClass="table table-stripped"
        DataSourceID="ObjectDataSource1" Caption="Report of tenants move-in and payments" AllowPaging="True">
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

    </asp:GridView>
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
