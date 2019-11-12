<%@ Page Title="PDF Outlines and Links" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="PdfOutlinesAndLinks.aspx.cs" Inherits="HiQPdf_Demo.PdfOutlinesAndLinks" %>

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
                            In this demo you can learn how to create a simple table of contents. There are 2
                            chapters and each chapter has 2 subchapters. The demo will create in the first page
                            a table of contents with internal links to the chapters and subchapters. There are
                            also outlines in document for each chapter and subchapter.<br />
                            <br />
                            The table of contents also contains a HTTP link to visit the HiQPdf website and
                            a text note.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF with Outlines" 
                                onclick="buttonCreatePdf_Click" />
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
