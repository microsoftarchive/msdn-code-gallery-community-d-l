<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="ConvertHtmlPreservingState.aspx.cs" Inherits="HiQPdf_Demo.ConvertHtmlPreservingState" %>

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
                            When you convert a web page to PDF with the HiQPdf Library you have access to the
                            values filled in the HTML form and to the values stored in the ASP.NET session variables<br />
                            <br />
                            In this demo you can see how to convert the current web page or another web page
                            in this application preserving the values entered in the HTML form and the session
                            variables values.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Convert This Page to PDF Preserving HTML Form Values and ASP.NET Session Values
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 10px">
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td colspan="2" style="font-weight: normal">
                                                    Enter the values to appear in PDF:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5px">
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                Text Value:
                                                            </td>
                                                            <td style="width: 5px">
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textBoxText" runat="server" Width="322px">My text to appear in PDF</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Select a Value:
                                                            </td>
                                                            <td style="width: 5px">
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="dropDownListValues" runat="server">
                                                                    <asp:ListItem Value="1">My Value 1</asp:ListItem>
                                                                    <asp:ListItem Value="2">My Value 2</asp:ListItem>
                                                                    <asp:ListItem Value="3">My Value 3</asp:ListItem>
                                                                    <asp:ListItem Value="4">My Value 4</asp:ListItem>
                                                                    <asp:ListItem Value="5">My Value 5</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Session Variable:
                                                            </td>
                                                            <td style="width: 5px">
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textBoxCrtSessionVariable" runat="server" Width="322px">My session variable value</asp:TextBox>
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
                                                <td colspan="2">
                                                    <asp:Panel ID="panelSessionVariableValue" runat="server">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    Session variable value:
                                                                </td>
                                                                <td style="width: 5px">
                                                                </td>
                                                                <td style="color: Navy">
                                                                    <asp:Literal ID="litSessionVariableValue" runat="server"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div id="convertCrtPageDiv">
                                                        <asp:Button ID="buttonConvertCrtPage" runat="server" Text="Convert This Page to PDF"
                                                            OnClick="buttonConvertCrtPage_Click" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 40px">
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Convert Another Page in This Application to PDF Preserving ASP.NET Session Values
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
                                    <td style="width: 10px">
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td colspan="2" style="font-weight: normal">
                                                    Enter the values to appear in PDF:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5px">
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                Session Variable:
                                                            </td>
                                                            <td style="width: 5px">
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textBoxAnotherSessionVariable" runat="server" Width="322px">My session variable value</asp:TextBox>
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
                                                <td colspan="2">
                                                    <div id="convertAnotherPageDiv">
                                                        <asp:Button ID="buttonConvertAnotherPage" runat="server" Text="Convert Another Page in This Application to PDF"
                                                            OnClick="buttonConvertAnotherPage_Click" />
                                                    </div>
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
            <td>
                <!-- Footer -->
            </td>
        </tr>
    </table>
</asp:Content>
