<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="ConvertHtmlRegionToPdf.aspx.cs" Inherits="HiQPdf_Demo.ConvertHtmlPartToPdf"
    Title="HTML to PDF - Convert a Part of HTML to PDF" %>

<%@ MasterType VirtualPath="~/DemoMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <!-- Header -->
            </td>
        </tr>
        <tr>
            <td>
                <!-- Body -->
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            In this demo you can learn how to convert to PDF only the HTML element selected
                            by a CSS selector. By default the CSS selector selects the DIV having the 'Content'
                            ID from HTML document. You can modify the CSS selector to select another HTML element.
                            For example, you can set #Header to convert to PDF only the header of the HTML document
                            or #Footer to convert only the footer of the HTML document to PDF.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3" style="padding-bottom: 5px; font-weight: bold">
                                        HTML Document URL</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxUrl" runat="server" Text="" Width="590px"></asp:TextBox></td>
                                    <td style="width: 5px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            CSS Selector of the HTML Element to Convert
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="textBoxConvertedHtmlElementSelector" runat="server" Width="590px">#Content</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF" OnClick="buttonCreatePdf_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <!-- Footer -->
            </td>
        </tr>
    </table>
</asp:Content>
