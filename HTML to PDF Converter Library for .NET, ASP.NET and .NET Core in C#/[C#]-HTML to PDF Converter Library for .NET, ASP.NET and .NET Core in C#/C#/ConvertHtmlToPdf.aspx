<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="ConvertHtmlToPdf.aspx.cs" Inherits="HiQPdf_Demo.ConvertHtmlToPdf"
    Title="Convert HTML to PDF Demo" %>

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
                        <td>In this demo you can convert an URL a custom HTML code to PDF. You can control the
                            PDF page size and orientation, PDF page margins, browser width, add header and footer
                            with page numbering, embed true type fonts in the generated PDF document.<br />
                            <br />
                            As a security option it is possible to set a password requested when the created
                            PDF document document is opened and it is possible to disable the document printing
                            when it is opened in a viewer.
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
                                        <asp:RadioButton ID="radioButtonConvertUrl" GroupName="UrlOrHtmlCode" runat="server"
                                            Text="Convert URL" Checked="True" OnCheckedChanged="radioButtonConvertUrl_CheckedChanged"
                                            AutoPostBack="True" Font-Bold="True" />
                                    </td>
                                    <td style="width: 50px"></td>
                                    <td>
                                        <asp:RadioButton ID="radioButtonConvertHtmlCode" GroupName="UrlOrHtmlCode" runat="server"
                                            Text="Convert HTML Code" OnCheckedChanged="radioButtonConvertHtmlCode_CheckedChanged"
                                            AutoPostBack="True" Font-Bold="True" />
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
                            <asp:Panel ID="panelUrl" runat="server">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-bottom: 5px">URL
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="textBoxUrl" runat="server" Text="http://www.google.com" Width="590px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="panelHtmlCode" runat="server" Visible="false">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>HTML
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="textBoxHtmlCode" runat="server" TextMode="MultiLine" Height="200px"
                                                Width="590px">&lt;/br&gt;
&lt;/br&gt;
Please enter the HTML code to convert and the base URL to access the external images, scripts and css having relative URLs in the HTML code to convert.
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td>Base URL
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="textBoxBaseUrl" runat="server" Text="" Width="590px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">PDF Settings
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>Page Size:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td style="width: 110px">
                                        <asp:DropDownList ID="dropDownListPageSizes" runat="server">
                                            <asp:ListItem>A0</asp:ListItem>
                                            <asp:ListItem>A1</asp:ListItem>
                                            <asp:ListItem>A2</asp:ListItem>
                                            <asp:ListItem>A3</asp:ListItem>
                                            <asp:ListItem>A4</asp:ListItem>
                                            <asp:ListItem>A5</asp:ListItem>
                                            <asp:ListItem>A6</asp:ListItem>
                                            <asp:ListItem>A7</asp:ListItem>
                                            <asp:ListItem>A8</asp:ListItem>
                                            <asp:ListItem>A9</asp:ListItem>
                                            <asp:ListItem>A10</asp:ListItem>
                                            <asp:ListItem>B0</asp:ListItem>
                                            <asp:ListItem>B1</asp:ListItem>
                                            <asp:ListItem>B2</asp:ListItem>
                                            <asp:ListItem>B3</asp:ListItem>
                                            <asp:ListItem>B4</asp:ListItem>
                                            <asp:ListItem>B5</asp:ListItem>
                                            <asp:ListItem>ArchA</asp:ListItem>
                                            <asp:ListItem>ArchB</asp:ListItem>
                                            <asp:ListItem>ArchC</asp:ListItem>
                                            <asp:ListItem>ArchD</asp:ListItem>
                                            <asp:ListItem>ArchE</asp:ListItem>
                                            <asp:ListItem>Flsa</asp:ListItem>
                                            <asp:ListItem>HalfLetter</asp:ListItem>
                                            <asp:ListItem>Ledger</asp:ListItem>
                                            <asp:ListItem>Legal</asp:ListItem>
                                            <asp:ListItem>Letter</asp:ListItem>
                                            <asp:ListItem>Letter11x17</asp:ListItem>
                                            <asp:ListItem>Note</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 45px"></td>
                                    <td>Page Orientation:
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
                                        <asp:CheckBox ID="checkBoxAddHeader" runat="server" Text="Add Header" />
                                    </td>
                                    <td style="width: 20px;"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddFooter" runat="server" Text="Add Footer" />
                                    </td>
                                    <td style="width: 20px;"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxFontEmbedding" runat="server" Text="Font Embedding" Checked="True" />
                                    </td>
                                    <td style="width: 20px;"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxPdfA" runat="server" Text="PDF/A" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Browser Settings
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>Browser Width:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxBrowserWidth" runat="server" Width="35px">1200</asp:TextBox>
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>px
                                    </td>
                                    <td style="width: 65px"></td>
                                    <td>Browser Height:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxBrowserHeight" runat="server" Width="35px"></asp:TextBox>
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>px
                                    </td>
                                    <td style="width: 65px"></td>
                                    <td>Timeout:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxLoadHtmlTimeout" runat="server" Width="30px">120</asp:TextBox>
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>sec
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 30px; font-weight: normal">Triggering Mode:
                                    </td>
                                    <td style="width: 5px; height: 30px;"></td>
                                    <td style="height: 30px;">
                                        <asp:DropDownList ID="dropDownListTriggeringMode" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="dropDownListTriggeringMode_SelectedIndexChanged">
                                            <asp:ListItem>Auto</asp:ListItem>
                                            <asp:ListItem>Manual</asp:ListItem>
                                            <asp:ListItem>WaitTime</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 28px; height: 30px;"></td>
                                    <td style="height: 30px">
                                        <asp:Panel ID="panelWaitTime" runat="server">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>Wait Time:
                                                    </td>
                                                    <td style="width: 5px"></td>
                                                    <td>
                                                        <asp:TextBox ID="textBoxWaitTime" runat="server" Width="30px">2</asp:TextBox>
                                                    </td>
                                                    <td style="width: 5px"></td>
                                                    <td>sec
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
                        <td style="font-weight: bold">Security
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>Set Open Password:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxOpenPassword" runat="server" Width="175px"></asp:TextBox>
                                    </td>
                                    <td style="width: 20px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAllowPrinting" runat="server" Text="Allow Printing" Checked="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkBoxOpenInline" runat="server" Text="Open PDF document inline in browser" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="buttonConvertToPdf" runat="server" Text="Convert to PDF" OnClick="buttonConvertToPdf_Click" />
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
