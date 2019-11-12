<%@ Page Language="C#" MasterPageFile="~/App_Resources/default.master" AutoEventWireup="true" Inherits="Public_Log_On" Title="log-in please" Codebehind="log-in.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContentPlaceholder" runat="Server">
    <h1 class="title-regular clearfix">
        EISK Login</h1>
    <asp:Literal runat="server" EnableViewState="False" ID="labelMessage"></asp:Literal>
    <p>
        In a felis turpis. Vivamus a purus quis erat rutrum facilisis id viverra ligula.
        Suspendisse ac purus quam, et pellentesque sapien. Vivamus tempor orci ut justo
        condimentum non mattis urna sodales. Mauris laoreet dolor nec ipsum porta scelerisque
        tincidunt dui pharetra</p>
    <div class="notice">
        Demo Username: any. Demo Password: any</div>
    <p class="inline">
        <label for="name">
            Username
        </label>
        <br />
        <input runat="server" name="name" id="txtUserName" type="text" class="text" /><br />
        <label for="password">
            Password</label><br />
        <input runat="server" name="password" id="txtPassword" type="password" class="text" /><br />
        <label for="check1">
            <input runat="server" title="remember" type="checkbox" name="checkboxRemember" id="checkBoxRemember"
                value="" />
            Remember me</label><br />
    </p>
    <p>
        <asp:Button ID="buttonLogOn" SkinID="AltButton" runat="server" Text="Log in as Member"
            OnClick="ButtonLogOn_Click" />
        <asp:Button ID="buttonAdminLogOn" SkinID="Button" runat="server" Text="Log in as Admin"
            OnClick="ButtonAdminLogOn_Click" />
    </p>
    <hr />
</asp:Content>
