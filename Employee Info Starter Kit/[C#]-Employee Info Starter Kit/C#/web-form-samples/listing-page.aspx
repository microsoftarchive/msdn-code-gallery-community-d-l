<%@ Page Language="C#" MasterPageFile="~/App_Resources/default.master" AutoEventWireup="true"
    Inherits="Listing_Page" Title="Employee Listing Page | EISK" MetaKeywords="ASP.NET,Employees,HR,Management"
    MetaDescription="In this page you will be able to view the list of all employess. Click on the appropriate buttons to view, insert or update an employee."
    CodeBehind="listing-page.aspx.cs" %>

<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function SelectAll(frmId, id) {
            var frm = document.getElementById(frmId);
            for (i = 1; i < frm.rows.length; i++) {
                var checkbox = frm.rows[i].cells[0].childNodes[1];
                if (checkbox != null)
                    checkbox.checked = document.getElementById(id).checked;
            }
        };
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="BodyContentPlaceholder" runat="Server">
    <h1 class="title-regular">
        Employees</h1>
    <p>
        In this page you will be able to view the list of all employess. Click on the appropriate
        buttons to view, insert or update an employee.
    </p>
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="grid_10 alpha">
                <asp:DropDownList ID="dropDownListEmployee" runat="server" AppendDataBoundItems="true"
                    AutoPostBack="true" DataSourceID="odsEmployeeList" DataTextField="FirstName"
                    DataValueField="EmployeeId" EnableViewState="true">
                    <asp:ListItem Text="Select Supervisor" Value="0"></asp:ListItem>
                    <asp:ListItem Text="No Supervisor" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsEmployeeList" runat="server" TypeName="Eisk.BusinessLogicLayer.EmployeeBLL"
                    EnableViewState="true" SelectMethod="GetAllEmployees" />
            </div>
            <div class="grid_9 omega align-right">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img src="../App_Resources/images/loader-life.gif" alt="Loading Data" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div class="grid-viewer grid_19 clearfix">
                <asp:Literal EnableViewState="false" runat="server" ID="ltlMessage"></asp:Literal>
                <asp:GridView ID="gridViewEmployees" runat="server" SkinID="GridView" DataSourceID="odsEmployeeListing"
                    ClientIDMode="Static" DataKeyNames="EmployeeId">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEmployeeSelector" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkSelectAll" ClientIDMode="Static" onclick="SelectAll('gridViewEmployees','chkSelectAll')" />
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="True" SortExpression="LastName" />
                        <asp:BoundField DataField="Country" HeaderText="Country" ReadOnly="True" SortExpression="Country" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="<%# Page.GetRouteUrl("employee-details", new {edit_mode = "view", employee_id = Eval("EmployeeId")}) %>"
                                    class="GridIcon ico-view"></a>
                            </ItemTemplate>
                            <HeaderTemplate>
                                View
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="<%# Page.GetRouteUrl("employee-details", new {edit_mode = "edit", employee_id = Eval("EmployeeId")}) %>"
                                    class="GridIcon ico-edit"></a>
                            </ItemTemplate>
                            <HeaderTemplate>
                                Edit
                            </HeaderTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="clearfix">
                <asp:ObjectDataSource ID="odsEmployeeListing" runat="server" TypeName="Eisk.BusinessLogicLayer.EmployeeBLL"
                    SelectMethod="GetEmployeesByReportsToPaged" SelectCountMethod="GetTotalCountForAllEmployeesByReportsTo"
                    SortParameterName="orderby" MaximumRowsParameterName="maximumRows" StartRowIndexParameterName="startRowIndex"
                    EnablePaging="True">
                    <SelectParameters>
                        <asp:ControlParameter Name="reportsTo" ControlID="dropDownListEmployee" />
                        <asp:Parameter Name="orderBy" Type="String" />
                        <asp:Parameter Name="startRowIndex" Type="Int32" />
                        <asp:Parameter Name="maximumRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div class="clearfix align-right">
                <asp:LinkButton SkinID="LinkButton" runat="server" ID="lbtAddNewEmployee" Text="Add New Employee"
                    OnClick="ButtonAddNewEmployee_Click" />
                <asp:LinkButton SkinID="AltLinkButton" OnClientClick="return confirm('Are you sure you want to delete all items?');"
                    runat="server" ID="buttonDeleteSelected" Text="Delete Selected" OnClick="ButtonDeleteSelected_Click" /></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
