<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="CreateAndSubmitForms.aspx.cs" Inherits="HiQPdf_Demo.CreateAndSubmitForms"
    Title="PDF Forms - Create and Submit Forms" %>

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
                        <td>In this demo you can learn how to create a PDF form with various fields and how
                            to submit the values entered in the form to a web page. You can choose what type
                            of fields to include in form and also the URL where to GET or POST the values entered
                            in form.<br />
                            <br />
                            When the Submit button of the PDF form is pressed, the PDF viewer will make a GET
                            or a POST request to the URL below function of the selected method.<br />
                            <br />
                            When the selected method is GET the form fields names and values will be added as
                            key-value pairs in the query string of the URL and they can be accessed in ASP.NET
                            using the Request.QueryString collection.<br />
                            <br />
                            When the selected method is POST the form fields names and values will be posted
                            as key-value pairs to the URL and they can be accessed in ASP.NET using the Request.Form
                            collection.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddCheckBox" runat="server" Font-Bold="True" Text="Add Check Box field"
                                            Checked="True" />
                                    </td>
                                    <td style="width: 40px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxCheckedState" runat="server" Checked="True" Text="Initial checked state" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddTextBox" runat="server" Font-Bold="True" Text="Add Text Box field"
                                            Checked="True" />
                                    </td>
                                    <td style="width: 50px"></td>
                                    <td>Initial Text:
                                    </td>
                                    <td style="width: 5px"></td>
                                    <td>
                                        <asp:TextBox runat="server" Width="290px" ID="textBoxInitialText">Please enter some text</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td colspan="3">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="margin-left: 40px">
                                                    <asp:CheckBox ID="checkBoxMultiline" runat="server" Font-Bold="False" Text="Multiline Text Box"
                                                        Checked="True" />
                                                </td>
                                                <td style="width: 10px"></td>
                                                <td>
                                                    <asp:CheckBox ID="checkBoxIsPassword" runat="server" Font-Bold="False" Text="Is Password" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddListBox" runat="server" Font-Bold="True" Text="Add List Box field"
                                            Checked="True" />
                                    </td>
                                    <td style="width: 53px"></td>
                                    <td>Values:
                                    </td>
                                    <td style="width: 30px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxListBoxValues" runat="server" Width="290px">List Value 1,List Value 2,List Value 3,List Value 4</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxAddComboBox" runat="server" Font-Bold="True" Text="Add Combo Box field"
                                            Checked="True" />
                                    </td>
                                    <td style="width: 35px"></td>
                                    <td>Values:
                                    </td>
                                    <td style="width: 30px"></td>
                                    <td style="margin-left: 40px">
                                        <asp:TextBox ID="textBoxComboBoxValues" runat="server" Width="290px">Combo Value 1,Combo Value 2,Combo Value 3</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td colspan="3">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="checkBoxEditableCombo" runat="server" Font-Bold="False" Text="Editable Combo Box"
                                                        Checked="True" />
                                                </td>
                                                <td style="width: 10px"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkBoxAddRadioButtons" runat="server" Font-Bold="True" Text="Add Radio Buttons Group field"
                                Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkBoxAddResetButton" runat="server" Font-Bold="True" Text="Add Form Reset Button"
                                Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom: 5px; font-weight: bold">Submit URL
                                    </td>
                                    <td style="width: 50px"></td>
                                    <td>
                                        <asp:TextBox ID="textBoxSubmitUrl" runat="server" Text="http://www.hiqpdf.com/formsubmitaction/" Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="font-weight: bold">Submit Method:
                                    </td>
                                    <td style="width: 25px"></td>
                                    <td>
                                        <asp:RadioButton ID="radioButtonPost" GroupName="SubmitMethod" runat="server" Text="POST"
                                            Checked="True" />
                                    </td>
                                    <td style="width: 40px"></td>
                                    <td>
                                        <asp:RadioButton ID="radioButtonGet" GroupName="SubmitMethod" runat="server"
                                            Text="GET" />
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
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF"
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
