<%@ Page Title="Import Excel Sheet into SQL Server" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportExcel_SqlServer._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
              
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Select File to Upload.</h5><br />
            <asp:FileUpload ID="FileUpload1" runat="server" /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

        </li>
        <li class="one">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        </li>
       
    </ol>
</asp:Content>
