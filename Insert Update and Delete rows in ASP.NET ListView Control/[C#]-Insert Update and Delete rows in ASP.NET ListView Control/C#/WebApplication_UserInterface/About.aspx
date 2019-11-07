<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication_UserInterface.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://code.msdn.microsoft.com/Insert-Update-Delete-rows-b0a2d4e2">More Samples from Sathiyamoorthy S in MSDN </asp:HyperLink>
    <br />
</asp:Content>
