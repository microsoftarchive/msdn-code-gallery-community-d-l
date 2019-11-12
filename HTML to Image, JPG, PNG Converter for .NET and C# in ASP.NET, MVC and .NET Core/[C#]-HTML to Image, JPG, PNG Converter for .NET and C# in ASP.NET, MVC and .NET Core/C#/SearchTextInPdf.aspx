<%@ Page Title="Search Text in PDF Demo" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="SearchTextInPdf.aspx.cs" Inherits="HiQPdf_Demo.SearchTextInPdf" %>

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
                        <td>In this demo you can learn how to search a text in a PDF document. You can choose the text to search, you can choose to match 
                            or not the case or whole word only and you can choose the range of PDF pages where to search the text. The found text is highlighted 
                            in the original PDF.
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
                        <td style="font-weight: bold">Text to search:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="textBoxTextToSearch" runat="server" Text="HiQPdf" Width="373px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBoxTextToSearch" ErrorMessage="*"></asp:RequiredFieldValidator>
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
                                    <td>
                                        <asp:CheckBox ID="checkBoxMatchCase" runat="server" Text="Match Case" />
                                    </td>
                                    <td style="width: 20px;"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxMatchWholeWord" runat="server" Text="Match Whole Word" />
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
                            <asp:Button ID="buttonSearchText" runat="server" Text="Search" OnClick="buttonSearchText_Click" />
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
