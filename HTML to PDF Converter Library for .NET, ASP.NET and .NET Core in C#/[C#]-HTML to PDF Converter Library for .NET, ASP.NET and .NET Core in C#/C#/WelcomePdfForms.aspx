<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="WelcomePdfForms.aspx.cs" Inherits="HiQPdf_Demo.WelcomePdfForms" Title="PDF Forms Demo" %>

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
                            PDF Forms Demo
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            This section comprises two demo applications. In the first demo application a new
                            PDF form with various types of fields is created. The values entered in the fields
                            can be posted to a web page on the server when a Submit button is pressed.<br />
                            <br />
                            In the second demo application a PDF document containing a form is loaded, the fields
                            are assigned with some values and the modfied document is saved.
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
