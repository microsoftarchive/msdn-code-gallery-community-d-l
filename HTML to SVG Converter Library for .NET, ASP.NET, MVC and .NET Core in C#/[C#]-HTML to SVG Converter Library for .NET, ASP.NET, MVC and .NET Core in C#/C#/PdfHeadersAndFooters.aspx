<%@ Page Title="Headers and Footers in PDF Demo" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="PdfHeadersAndFooters.aspx.cs" Inherits="HiQPdf_Demo.PdfHeadersAndFooters" %>

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
                        <td>The HiQPdf HTML to PDF Converter offers a great flexibility in setting the PDF document
                            headers and footers. Per PDF page customization of header and footer can be done
                            in PdfPageCreating event handler.
                            <br />
                            <br />
                            Basically you can add anything in the header and footer from plain text to full
                            HTML documents, override the default document header and footer in any page with
                            a customized header and footer, hide the header and footer in any PDF page.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom: 5px; font-weight: bold">The URL of a HTML Document to Convert:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxUrl" runat="server" Text="" Width="590px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
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
                                    <td>
                                        <asp:CheckBox ID="checkBoxDisplayHeaderInFirstPage" runat="server" Checked="True"
                                            Text="Display header in first page" />
                                    </td>
                                    <td style="width: 85px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxDisplayFooterInFirstPage" runat="server" Checked="True"
                                            Text="Display footer in first pagee" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxDisplayHeaderInSecondPage" runat="server" Checked="True"
                                            Text="Display header in second page" />
                                    </td>
                                    <td style="width: 85px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxDisplayFooterInSecondPage" runat="server" Checked="True"
                                            Text="Display footer in second page" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:CheckBox ID="checkBoxCustomizedHeaderInSecondPage" runat="server" Checked="True"
                                            Text="Replace in second page the default document header with a customized header" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxDisplayPageNumbersInFooter" runat="server" Checked="True"
                                            Text="Display page numbers in footer" />
                                    </td>
                                    <td style="width: 85px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxPageNumbersInHtml" runat="server" Checked="False"
                                            Text="Page numbers in HTML" />
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
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF with Header and Footer"
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
