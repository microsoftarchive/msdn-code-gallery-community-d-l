<%@ Page Title="HTML with Web Fonts Conversion to PDF Demo" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="WebFonts.aspx.cs" Inherits="HiQPdf_Demo.WebFonts" %>

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
                            The Web Fonts can be used in a HTML document without being installed on the local
                            computer. The location from where they can be downloaded is given in the CSS3 @font-face
                            rule. The HiQPdf HTML to PDF Converter has the capacity to convert HTML documents
                            with true type Web Fonts.<br />
                            <br />
                            This application demonstrates the converter support for WOFF (Web Open Font Format).
                            Please note that your browser must support the WOFF format. The browsers currently
                            supporting WOFF are IE 9 or later, Google Chrome, Mozilla Firefox and Apple Safari.
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
                                        The URL of a HTML Document to Convert:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxUrl" runat="server" Text="" Width="590px"></asp:TextBox>
                                    </td>
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
                        <td>
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF with Web Fonts"
                                OnClick="buttonCreatePdf_Click" />
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
