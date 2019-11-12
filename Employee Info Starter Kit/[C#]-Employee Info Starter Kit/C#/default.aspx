<%@ Page Language="C#" MasterPageFile="~/App_Resources/default.master" AutoEventWireup="true" Inherits="_Default" Title="Welcome User!" Codebehind="default.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContentPlaceholder" runat="Server">
    <h1 class="title-regular clearfix">
        EISK HOME</h1>
    <asp:Literal runat="server" EnableViewState="False" ID="labelMessage"></asp:Literal>
    <p>
        In a felis turpis. Vivamus a purus quis erat rutrum facilisis id viverra ligula.
        Suspendisse ac purus quam, et pellentesque sapien. Vivamus tempor orci ut justo
        condimentum non mattis urna sodales. Mauris laoreet dolor nec ipsum porta scelerisque
        tincidunt dui pharetra</p>
</asp:Content>
