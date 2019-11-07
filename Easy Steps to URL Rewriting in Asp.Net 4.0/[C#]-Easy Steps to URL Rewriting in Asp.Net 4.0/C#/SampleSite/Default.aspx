<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about various .Net technologies <a href="http://www.cshandler.com" title="CShandler blog">
           www.cshandler.com</a>.

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="EntityDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductCategoryID" HeaderText="ProductCategoryID" ReadOnly="True"
                    SortExpression="ProductCategoryID" />
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:HyperLink ID="hyplink" runat="server" Text='<%#Eval("Name")%>' NavigateUrl='<%#"~/Products/"+Eval("Name")%>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </p>
    <p>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=AdventureWorksEntities"
            DefaultContainerName="AdventureWorksEntities" EnableFlattening="False" EntitySetName="ProductCategories"
            EntityTypeFilter="ProductCategory" Select="it.[ProductCategoryID], it.[Name]">
        </asp:EntityDataSource>
    </p>
</asp:Content>
