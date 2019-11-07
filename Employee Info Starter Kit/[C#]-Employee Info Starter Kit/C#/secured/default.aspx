<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/default.master"
    AutoEventWireup="true" Inherits="secured_default" CodeBehind="default.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="Server">
    <h1 class="title-regular clearfix">
        Security Demo</h1>
    <p>
        This section of Employee Starter Kit simply shows how you can handle role based
        security. Just try to access any of the role specific pages (Public, Member or Admin)
        from left menu. You will be asked for and required appropriate log-in to gain the
        corresponding access.</p>
</asp:Content>
