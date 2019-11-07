<%@ Page Title="Report of tenants move-in and payments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aspose.PDF.WebForm.Example._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>. <asp:Button ID="Button1" runat="server" Text="Get PDF" CssClass="btn btn-default" OnClick="Button1_Click" /></h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        CssClass="table table-stripped"
        DataSourceID="ObjectDataSource1" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
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

        <EditRowStyle BackColor="#2461BF" />

        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

        <PagerStyle HorizontalAlign="Center"
            CssClass="GridPager" BackColor="#2461BF" ForeColor="White" />

        <RowStyle BackColor="#EFF3FB" />

        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

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
