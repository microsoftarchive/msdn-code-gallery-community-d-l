<%@ Page Title="PDF Images Demo" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="PdfImages.aspx.cs" Inherits="HiQPdf_Demo.PdfImages" %>

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
                            In this demo you can learn how to layout image objects in a PDF document. There
                            are basically four types of images that can be laid out in a PDF document which
                            are exemplified in this demo: PNG images with alpha transparency, opaque JPEG images,
                            vectorial SVG images and images resulted from HTML documents rasterization. From
                            this demo you can also learn how to layout a rotated image in PDF using rotations
                            and traslations of the coordinates system.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF with Images" 
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
