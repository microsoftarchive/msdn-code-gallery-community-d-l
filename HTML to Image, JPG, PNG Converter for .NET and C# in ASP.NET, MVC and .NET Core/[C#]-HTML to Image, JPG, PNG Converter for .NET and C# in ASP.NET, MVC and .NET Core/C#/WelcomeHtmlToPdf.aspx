<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="WelcomeHtmlToPdf.aspx.cs" Inherits="HiQPdf_Demo.WelcomeHtmlToPdf"
    Title="HTML to PDF Conversion Demo" %>

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
                <table>
                    <tr>
                        <td style="width: 100px">
                            <!-- Left -->
                            <img alt="HiQPdf Logo" src="DemoFiles/Images/HiQPdfLogo.png" style="width: 100px" />
                        </td>
                        <td style="width: 5px">
                            <!-- Middle -->
                        </td>
                        <td style="vertical-align: middle; font-weight: bold; font-size: 24px">
                            <!-- Right -->
                            HTML to PDF Conversion Demo
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            This section comprises a set of samples for the main features of the HTML to PDF
                            converter. The HTML to PDF converter is a key component of the HiQPdf software.
                            It allows you to quickly create high quality PDF documents from existing HTML documents.<br />
                            <br />
                            To run a HTML to PDF sample please select it from the tree view at the left. There
                            are samples for converting URLs and HTML code to PDF, layout and overlay multiple
                            HTML objects in the same PDF document, replace the images from HTML with other images,
                            set a background color for the PDF pages, automatically generated outlines and links,
                            repeated HTML table header, page breaks control.
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
