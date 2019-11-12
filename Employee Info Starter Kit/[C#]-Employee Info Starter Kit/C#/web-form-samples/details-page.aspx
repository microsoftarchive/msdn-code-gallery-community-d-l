<%@ Page Language="C#" MasterPageFile="~/App_Resources/default.master" AutoEventWireup="false"
    Inherits="Details_Page" Title="Employee Details Page | EISK" MetaKeywords="ASP.NET, Employee,Details"
    MetaDescription="In this page, you will be able to see details of an employee."
    CodeBehind="details-page.aspx.cs" %>

<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script src='<%# ResolveUrl ("~/App_Resources/client-scripts/framework/jquery.ui.core.js") %>'
        type="text/javascript"></script>
    <script src='<%# ResolveUrl ("~/App_Resources/client-scripts/framework/jquery.ui.datepicker.js") %>'
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker({
                changeMonth: true,
                changeYear: true,
                showOn: "both",
                buttonImage: "../../App_Resources/images/ico-cal.png",
                buttonImageOnly: true,
                showAnim: 'slideDown'
            });
        });
    </script>
    <script type="text/javascript">

        $("#anim").change(function () {
            $("#datepicker").datepicker("option", "showAnim", $(this).val());
        });

    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="BodyContentPlaceholder" runat="Server">
    <asp:Literal EnableViewState="False" runat="server" ID="ltlMessage"></asp:Literal>
    <asp:FormView SkinID="FormView" ID="formViewEmployee" runat="server" DataSourceID="odsEmployeeDetails"
        DataKeyNames="EmployeeId" EnableViewState="true" OnItemUpdating="FormViewEmployee_ItemUpdating"
        OnItemUpdated="formViewEmployee_ItemUpdated" OnItemInserting="FormViewEmployee_ItemInserting"
        OnItemInserted="formViewEmployee_ItemInserted" OnDataBound="FormViewEmployee_DataBound">
        <EmptyDataTemplate>
            <h1 class="title-regular clearfix">
                No Employee Found</h1>
            <div class="notice">
                Sorry, no employee available with this ID.</div>
            <asp:Button ID="btnBack" CausesValidation="false" runat="server" Text="Back to listing page"
                OnClick="ButtonGoToListPage_Click" SkinID="Button" />
        </EmptyDataTemplate>
        <ItemTemplate>
            <h1 class="title-regular clearfix">
                <span class="grid_15 alpha">
                    <%# Eval("FirstName") %>
                    <%# Eval("LastName") %></span> <span class="grid_3 omega align-right">
                        <asp:LinkButton ID="LinkButton1" OnClientClick="print()" runat="server" Text="Print Info"
                            CssClass="button small white"></asp:LinkButton></span></h1>
            <div class="grid_5 alpha">
                <img id="Img1" class="grid_5" alt="employee image" runat="server" src='<%# "image-loader.ashx?ImageBinary=" + Eval("employeeId").ToString() %>' /></div>
            <div class="grid_12 prefix_1 omega">
                <strong>Title:</strong>
                <%# Eval("Title") %></label><br />
                <strong>Title Of Courtesy:</strong>
                <%# Eval("TitleOfCourtesy") %><br />
                <strong>Date of Birth:</strong>
                <%# Eval("BirthDate", "{0:M-dd-yyyy}")%><br />
                <strong>Hire Date: </strong>
                <%# Eval("HireDate", "{0:M-dd-yyyy}")%><br />
                <hr />
                <strong>Country:</strong>
                <%# Eval("Country") %><br />
                <strong>Address: </strong>
                <%# Eval("Address") %><br />
                <strong>City: </strong>
                <%# Eval("City") %><br />
                <strong>Region</strong>
                <%# Eval("Region") %><br />
                <strong>Postal Code</strong>
                <%# Eval("PostalCode")%><br />
                <strong>Home Phone</strong>
                <%# Eval("HomePhone")%><br />
                <strong>Extension</strong>
                <%# Eval("Extension")%><br />
                <hr />
                <%# Eval("Notes") %>
                <hr />
                <asp:Button CausesValidation="false" ID="btnBack" runat="server" Text="Back" OnClick="ButtonGoToListPage_Click"
                    SkinID="AltButton" />
                <asp:Button ID="Button2" runat="server" Text="Edit" OnClick="ButtonEdit_Click" SkinID="Button" />
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <h1 class="title-regular clearfix">
                <%# ((FormView)Container).CurrentMode == FormViewMode.Insert ? "New Employee" : Eval("FirstName") + " " + Eval("LastName") %>
            </h1>
            <div class="grid_10 inline alpha">
                <label>
                    First Name:</label>
                <span class="required-field-indicator">*</span><br />
                <asp:TextBox ID="txtFirstName" Text='<%# Bind("FirstName") %>' runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required"
                    CssClass="validator" ControlToValidate="txtFirstName" Display="Dynamic"></asp:RequiredFieldValidator><br />
                <label>
                    Last Name:</label>
                <span class="required-field-indicator">*</span><br />
                <asp:TextBox ID="txtLastName" Text='<%# Bind("LastName") %>' runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
                    CssClass="validator" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator><br />
                <label>
                    Reports To:</label><br />
                <asp:DropDownList ID="ddlReportsTo" runat="server" AppendDataBoundItems="true" DataSourceID="odsEmployeeList"
                    SelectedValue='<%# Bind("ReportsTo") %>' DataTextField="FirstName" DataValueField="EmployeeId">
                    <asp:ListItem Text="None" Value=""></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:ObjectDataSource ID="odsEmployeeList" runat="server" TypeName="Eisk.BusinessLogicLayer.EmployeeBLL"
                    SelectMethod="GetAllEmployees" />
                <label>
                    Title:</label><br />
                <asp:TextBox ID="txtTitle" Text='<%# Bind("Title") %>' runat="server" CssClass="text"></asp:TextBox><br />
                <label>
                    Title Of Courtesy:</label>
                <asp:TextBox ID="txtTitleOfCourtesy" Text='<%# Bind("TitleOfCourtesy") %>' runat="server"
                    CssClass="text"></asp:TextBox><br />
                <label>
                    Country:</label>
                <span class="required-field-indicator">*</span><br />
                <asp:DropDownList runat="server" ID="ddlCountry" SelectedValue='<%# Bind("Country") %>'>
                    <asp:ListItem Value="">None</asp:ListItem>
                    <asp:ListItem>Bangladesh</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                    ControlToValidate="ddlCountry" InitialValue="" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator><br />
                <label>
                    Birth Date:</label><br />
                <asp:TextBox ID="txtnewBirthDate" runat="server" Text='<%# Bind("BirthDate", "{0:MM/dd/yyyy}")%>'
                    CssClass="datepicker grid_5 text"></asp:TextBox><br />
                <br />
                <label>
                    Hire Date:</label>
                <span class="required-field-indicator">*</span><br />
                <asp:TextBox ID="txtHireDate" Text='<%# Bind("HireDate", "{0:MM/dd/yyyy}") %>' runat="server"
                    CssClass="datepicker grid_5 text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                    ControlToValidate="txtHireDate" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>
                <br class="clear" />
                <label>
                    Address:</label>
                <span class="required-field-indicator">*</span><br />
                <asp:TextBox ID="txtAddress" Text='<%# Bind("Address") %>' runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                    ControlToValidate="txtAddress" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator><br />
                <label>
                    City:</label><br />
                <asp:TextBox ID="txtCity" Text='<%# Bind("City") %>' runat="server" CssClass="text"></asp:TextBox><br />
                <label>
                    Region:</label><br />
                <asp:TextBox ID="txtRegion" Text='<%# Bind("Region") %>' runat="server" CssClass="text"></asp:TextBox><br />
                <label>
                    Postal Code:</label><br />
                <asp:TextBox ID="txtPostalCode" Text='<%# Bind("PostalCode") %>' runat="server" CssClass="text"></asp:TextBox><br />
            </div>
            <div class="grid_9 inline omega">
                <label>
                    Home Phone:</label>
                <span class="required-field-indicator">*</span><br />
                <asp:TextBox ID="txtHomePhone" Text='<%# Bind("HomePhone") %>' runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required"
                    ControlToValidate="txtHomePhone" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator><br />
                <label>
                    Extension:</label><br />
                <asp:TextBox ID="txtExtension" Text='<%# Bind("Extension") %>' runat="server" CssClass="text"></asp:TextBox><br />
                <label>
                    Picture</label><br />
                <img id="Img1" alt="employee image" runat="server" src='<%# "image-loader.ashx?ImageBinary=" + Eval("employeeId") %>'
                    width="200" /><br />
                <label>
                    Upload Image:</label><br />
                <asp:FileUpload ID="fuPhotoUpload" runat="server"></asp:FileUpload>
                <asp:Panel ID="Panel1" runat="server" Visible='<%# Eval("Photo")==null?false:true %>'>
                    OR
                    <asp:CheckBox runat="server" ID="chkRemoveOldImage" Text="Remove Image" />
                </asp:Panel>
                <label>
                    <br />
                    Notes:</label><br />
                <asp:TextBox ID="txtNotes" Text='<%# Bind("Notes") %>' runat="server" TextMode="MultiLine"></asp:TextBox>
                <p>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="ButtonSave_Click" SkinID="Button" />
                    <asp:Button ID="btnBack" CausesValidation="false" runat="server" Text="Back" OnClick="ButtonGoToListPage_Click"
                        SkinID="AltButton" /></p>
                <em>Required fields are marked with <span class="required-field-indicator">*</span></em>
            </div>
        </EditItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="odsEmployeeDetails" runat="server" SelectMethod="GetEmployeeByEmployeeId"
        InsertMethod="CreateNewEmployee" UpdateMethod="UpdateEmployee" DataObjectTypeName="Eisk.BusinessEntities.Employee"
        TypeName="Eisk.BusinessLogicLayer.EmployeeBLL" OnSelecting="OdsEmployeeDetails_Selecting"
        OnInserted="OdsEmployeeDetails_Inserted">
        <UpdateParameters>
            <asp:ControlParameter Name="EmployeeId" ControlID="formViewEmployee" />
            <asp:Parameter Name="LastName" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="FirstName" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Title" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="TitleOfCourtesy" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="BirthDate" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="HireDate" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Address" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="City" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Region" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="PostalCode" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Country" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="HomePhone" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Extension" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Photo" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Notes" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="ReportsTo" Type="Int32" ConvertEmptyStringToNull="true" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="LastName" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="FirstName" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Title" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="TitleOfCourtesy" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="BirthDate" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="HireDate" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Address" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="City" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Region" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="PostalCode" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Country" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="HomePhone" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Extension" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Photo" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Notes" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="ReportsTo" Type="Int32" ConvertEmptyStringToNull="true" />
        </InsertParameters>
        <SelectParameters>
            <asp:RouteParameter Name="employeeId" RouteKey="employee_id" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
