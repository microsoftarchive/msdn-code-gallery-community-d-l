<%@ Page Title="Edit PDF Demo" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="EditPdf.aspx.cs" Inherits="HiQPdf_Demo.EditPdf" %>

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
                        <td>In this demo you can learn how to load a PDF document from a file and layout various
                            PDF objects on top of the existing content.<br />
                            <br />
                            The demo will make two changes to the PDF document to edit: will create an orange
                            border for each PDF page of the loaded document and will create a canvas whose content
                            is automatically repeated on each PDF page. The content from a HTML document will
                            be laid out in the repeated canvas.<br />
                            <br />
                            The HTML document does not have a background which makes visible the existing content
                            from PDF and even more, the PNG image used in HTML is also transparent to create
                            a very special effect.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hyperLinkOpenPdf" runat="server" Target="_blank">Open the PDF Document to Edit</asp:HyperLink>
                                    </td>
                                    <td style="width: 50px"></td>
                                    <td>
                                        <asp:HyperLink ID="hyperLinkOpenHtml" runat="server" Target="_blank">Open the HTML to Layout on Each PDF Page</asp:HyperLink>
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
                            <asp:Button ID="buttonEditPdf" runat="server" Text="Edit PDF" OnClick="buttonCreatePdf_Click" />
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
