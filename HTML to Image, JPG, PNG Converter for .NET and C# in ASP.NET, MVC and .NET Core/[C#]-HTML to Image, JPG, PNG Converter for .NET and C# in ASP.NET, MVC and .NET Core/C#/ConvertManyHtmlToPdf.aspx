<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="ConvertManyHtmlToPdf.aspx.cs" Inherits="HiQPdf_Demo.MultipleHtmlLayers"
    Title="HTML to PDF - Convert Many HTML Documents into a Single PDF" %>

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
                        <td>In this demo you can learn how to layout and overlay multiple HTML objects in the
                            same PDF document.<br />
                            <br />
                            The HTML from URL 1 is laid out at the beginning of the PDF document and the URL
                            2 is laid out immediately after first HTML or on a new page if 'Layout on New Page'
                            option is on. If the second HTML is laid out on a new page then there is the option
                            to change the orientation of the new pages.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom: 5px; font-weight: bold">URL 1
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxUrl1" runat="server" Text="http://www.google.com" Width="590px"></asp:TextBox>
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom: 5px; font-weight: bold">URL 2
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxUrl2" runat="server" Text="http://www.cnn.com" Width="590px"></asp:TextBox>
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxNewPage" runat="server" Text="Layout URL 2 on New Page"
                                            AutoPostBack="True" OnCheckedChanged="checkBoxNewPage_CheckedChanged" />
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td style="width: 250px">
                                        <asp:Panel ID="panelNewPageOrientation" runat="server" Width="100%">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>New Page Orientation:
                                                    </td>
                                                    <td style="width: 5px"></td>
                                                    <td>
                                                        <asp:DropDownList ID="dropDownListPageOrientations" runat="server">
                                                            <asp:ListItem>Portrait</asp:ListItem>
                                                            <asp:ListItem>Landscape</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddHeader" runat="server" Text="Add Header" />
                                    </td>
                                    <td style="width: 40px;"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddFooter" runat="server" Text="Add Footer" />
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
