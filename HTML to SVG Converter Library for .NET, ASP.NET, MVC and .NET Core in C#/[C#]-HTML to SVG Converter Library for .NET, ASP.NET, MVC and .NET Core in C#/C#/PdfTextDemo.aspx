<%@ Page Title="PDF Text Demo" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="PdfTextDemo.aspx.cs" Inherits="HiQPdf_Demo.PdfTextDemo" %>

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
                        <td>In this demo you can learn how to layout text objects in a PDF document with various
                            layouts and fonts. The generated PDF document will contain horizontal and rotated
                            text objects, text with true type fonts and text with PDF standard fonts.<br />
                            <br />
                            There are three main layouting options for the text exemplified in ths demo: the
                            text is rendered at a given location and has free width and height, the text is
                            limited in width or the text is limited both in width and height. There is also
                            an example where the text is automatically laid out on the next page when it gets
                            to the bottom of a PDF page.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF with Text"
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
