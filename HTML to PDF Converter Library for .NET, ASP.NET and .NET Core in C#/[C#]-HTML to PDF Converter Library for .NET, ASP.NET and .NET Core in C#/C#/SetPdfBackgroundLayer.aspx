<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="SetPdfBackgroundLayer.aspx.cs" Inherits="HiQPdf_Demo.SetPdfBackgroundLayer"
    Title="HTML to PDF - Set PDF Background Color" %>

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
                            In this demo you learn how to add a custom background content to the PDF pages created
                            by the converter in the PageLayoutingEvent event handler called right before rendering
                            the main HTML content in PDF page.<br />
                            <br />
                            The PageLayoutingEvent event handler parameter contains the PdfPage object being
                            rendered and the rectangle inside the page that will be rendered. The PDF objects
                            added to the PdfPage in this event handler will be rendered in the background of
                            the main HTML content.
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
                                    <td style="padding-bottom: 5px; font-weight: bold">
                                        HTML Document URL</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxUrl" runat="server" Text="http://www.google.com" Width="590px"></asp:TextBox></td>
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
                            Set PDF background color components as values from 0 to 255:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Red:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxR" runat="server" Width="30px">192</asp:TextBox></td>
                                    <td style="width: 40px">
                                    </td>
                                    <td>
                                        Green:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxG" runat="server" Width="30px">255</asp:TextBox></td>
                                    <td style="width: 40px">
                                    </td>
                                    <td>
                                        Blue:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxB" runat="server" Width="30px">192</asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Page Margins:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Left:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxLeftMargin" runat="server" Width="30px">0</asp:TextBox></td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        pt</td>
                                    <td style="width: 22px">
                                    </td>
                                    <td>
                                        Right:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxRightMargin" runat="server" Width="30px">0</asp:TextBox></td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        pt</td>
                                    <td style="width: 25px">
                                    </td>
                                    <td>
                                        Top:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxTopMargin" runat="server" Width="30px">0</asp:TextBox></td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        pt</td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        Bottom:</td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxBottomMargin" runat="server" Width="30px">0</asp:TextBox></td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        pt</td>
                                </tr>
                            </table>
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
