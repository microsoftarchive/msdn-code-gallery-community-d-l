<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HiQPdf_Demo.Default" Title="Welcome to HiQPdf Demo Application" %>

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
                            Welcome to HiQPdf Demo Application
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td colspan="3">The HiQPdf demo application for ASP.NET comprises a set of samples for the most
                            important features of the software. You can select the desired sample from the tree
                            view at the left side.<br />
                            <br />
                            There are samples for HTML to PDF conversion, HTML to Image conversion, HTML to
                            SVG Conversion, PDF forms, PDF text, PDF images, PDF graphics, PDF outlines, attachments,
                            links, PDF edit and PDF merge, extract text and images from PDF documents, search text 
                            in PDF documents, rasterize PDF pages to images.</td>
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
