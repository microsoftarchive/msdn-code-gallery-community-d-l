<%@ Page Title="Merge PDF Demo" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="MergePdf.aspx.cs" Inherits="HiQPdf_Demo.MergePdf" %>

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
                            In this demo you can learn how to merge multiple PDF document into a single PDF
                            document. Initially is created an empty document which will become the final document.
                            Then the two PDF files are loaded into two PdfDocument objects which are added
                            to the empty document.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hyperLinkOpenPdf1" runat="server" Target="_blank">Open the First PDF Document to Merge</asp:HyperLink>
                                    </td>
                                    <td style="width: 50px">
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hyperLinkOpenPdf2" runat="server" Target="_blank">Open the Second PDF Document to Merge</asp:HyperLink>
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
                            <asp:Button ID="buttonMergePdf" runat="server" Text="Merge PDF" OnClick="buttonCreatePdf_Click" />
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
