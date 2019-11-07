<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="Feedback.aspx.cs" Inherits="HiQPdf_Demo.Feedback" Title="Feedback" %>

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
                            Thank You for Using HiQPdf Software
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            If you have any questions about using the HiQPdf software or if you want to report
                            a problem with our software or with this demo application please don't hesitate
                            to contact us. The support email address can be found on the contact page of the
                            HiQPdf website.
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
