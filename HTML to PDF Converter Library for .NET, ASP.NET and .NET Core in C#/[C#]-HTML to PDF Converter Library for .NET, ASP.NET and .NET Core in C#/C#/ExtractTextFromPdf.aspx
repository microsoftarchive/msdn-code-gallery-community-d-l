<%@ Page Title="Extract Text from PDF Demo" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="ExtractTextFromPdf.aspx.cs" Inherits="HiQPdf_Demo.ExtractTextFromPdf" %>

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
                        <td>In this demo you can learn how to extract the text from a PDF document. You can choose the text extraction mode and 
                            the range of PDF pages from where to extract the text.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">PDF document:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hyperLinkOpenPdf" runat="server" Target="_blank">Open the Input PDF Document</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Settings
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>Extraction Mode:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:DropDownList ID="dropDownListExtractMode" runat="server">
                                            <asp:ListItem>Keep Positioning</asp:ListItem>
                                            <asp:ListItem>Keep Reading Order</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Page Range
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>From:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxFromPage" runat="server" Width="35px">1</asp:TextBox>
                                    </td>
                                    <td style="width: 30px"></td>
                                    <td>To:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxToPage" runat="server" Width="35px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="buttonExtractText" runat="server" Text="Extract Text" OnClick="buttonExtractText_Click" />
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
