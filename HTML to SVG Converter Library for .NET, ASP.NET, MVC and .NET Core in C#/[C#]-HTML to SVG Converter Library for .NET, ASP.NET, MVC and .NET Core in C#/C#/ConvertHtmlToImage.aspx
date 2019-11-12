<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="ConvertHtmlToImage.aspx.cs" Inherits="HiQPdf_Demo.ConvertHtmlToImage"
    Title="Convert HTML to Image" %>

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
                        <td>In this demo you can convert an URL or a HTML code to an image. You can select the
                            image format (PNG, JPG, BMP) and the browser width in pixels. When the selected
                            image format is PNG it is also possible to choose if the image background is transparent
                            when the HTML document does not have a background.
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
                        <td style="font-weight: bold">Settings
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 96px">Image Format:
                                    </td>
                                    <td style="width: 8px"></td>
                                    <td style="width: 103px">
                                        <asp:DropDownList ID="dropDownListImageFormat" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="dropDownListImageFormat_SelectedIndexChanged">
                                            <asp:ListItem>PNG</asp:ListItem>
                                            <asp:ListItem>JPG</asp:ListItem>
                                            <asp:ListItem>BMP</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 7px"></td>
                                    <td style="height: 30px">
                                        <asp:CheckBox ID="checkBoxTransparentImage" runat="server" Text="Create Transparent Background (PNG only)"
                                            Checked="True" />
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
                        <td>
                            <asp:Button ID="buttonConvertToImage" runat="server" Text="Convert to Image" OnClick="buttonConvertToImage_Click" />
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
