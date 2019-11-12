<%@ Page Title="PDF Open Action" Language="C#" MasterPageFile="~/DemoMaster.Master"
    AutoEventWireup="true" CodeBehind="PdfOpenAction.aspx.cs" Inherits="HiQPdf_Demo.PdfOpenAction" %>

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
                            In this demo you can learn how to set an action to be executed when the PDF document
                            is opened. There are 4 possible types of actions: execute a JavaScript, go to a
                            location in PDF, submit PDF document form and reset PDF document form.<br />
                            <br />
                            In this demo only the JavaScript and GoTo actions are exemplified. The JavaScript
                            action is used to display an alert message when the document is opened. The GoTo
                            Action is used to initially display a given page of the PDF document when the document
                            is opened.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="2" style="font-weight: bold">
                                        <asp:RadioButton ID="radioButtonJavaScript" GroupName="ActionType" runat="server"
                                            Text="Execute a JavaScript Action when the Document is Opened" Checked="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    Alert Message:
                                                </td>
                                                <td style="width: 10px">
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" Width="382px" ID="textBoxAlertMessage">Open Document JavaScript Action !!!</asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-weight: bold">
                                        <asp:RadioButton ID="radioButtonGoTo" GroupName="ActionType" runat="server" Text="Execute a GoTo Action when the Document is Opened"
                                            Checked="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    Initially Displayed Page:
                                                </td>
                                                <td style="width: 5px">
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="radioButtonPage1" GroupName="PageNumber" runat="server" Text="1" />
                                                            </td>
                                                            <td style="width: 20px">
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="radioButtonPage2" GroupName="PageNumber" runat="server" Text="2"
                                                                    Checked="True" />
                                                            </td>
                                                            <td style="width: 20px">
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="radioButtonPage3" GroupName="PageNumber" runat="server" Text="3" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 10px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Set Initial Zoom Level:
                                                </td>
                                                <td style="width: 5px">
                                                </td>
                                                <td>
                                                    <table cellpadding="0px" cellspacing="0px">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="textBoxZoomLevel" runat="server" Width="35px">111</asp:TextBox>
                                                            </td>
                                                            <td style="width: 5px">
                                                            </td>
                                                            <td>
                                                                %
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF with Open Action"
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
