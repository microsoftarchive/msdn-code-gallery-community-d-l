<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="HtmlElementsPositionInPdf.aspx.cs" Inherits="HiQPdf_Demo.ReplaceHtmlElements"
    Title="HTML to PDF - HTML Elements Position in PDF" %>

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
                            In this demo you can learn how to hide a HTML image from the generated PDF document
                            and how to place a different image in the same position. By default the CSS selector
                            selects all the images from HTML document for replacement. You can modify the CSS
                            selector to select an image with a given ID using a selector like #ImageID.<br />
                            <br />
                            A similar approach can be used for example to replace the HTML form elements with
                            PDF form elements in order to create interractive PDF forms.
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
                                        <asp:TextBox ID="textBoxUrl" runat="server" Text="http://www.google.com" Width="590px"></asp:TextBox></td>
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
                            Settings
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CSS Selector of the Images to Replace :
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="textBoxImageSelector" runat="server" Width="169px">IMG</asp:TextBox>
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
