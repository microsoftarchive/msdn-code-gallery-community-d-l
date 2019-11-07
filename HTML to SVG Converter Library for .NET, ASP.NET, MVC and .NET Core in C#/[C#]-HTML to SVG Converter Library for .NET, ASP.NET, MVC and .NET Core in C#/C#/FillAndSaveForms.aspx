<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="FillAndSaveForms.aspx.cs" Inherits="HiQPdf_Demo.FillAndSaveForms"
    Title="PDF Forms - Fill and Save Forms" %>

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
                            In this demo you can learn how to load a PDF document with a form, enter some values
                            from code and then save the modified PDF document.<br />
                            <br />
                            After the PDF document was loaded you can iterate the fields in the Document.Form.Fields
                            collection or you can get a field from collection by index or by name.
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
                                    <td style="padding-bottom: 5px; font-weight: bold">
                                        PDF Document with Form to Fill
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxPdf" runat="server" Text="" Width="539px" 
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                    <td style="width:5px"></td>
                                    <td>
                                    <asp:HyperLink 
                                            ID="hyperLinkOpen" runat="server" Target="_blank">Open</asp:HyperLink>
                                        
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
                        <td style="font-weight: bold">
                            Enter the Form Fields Values
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkBoxChecked" runat="server" Font-Bold="False" Text="Check Box Field is Checked"
                                Checked="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Text Box Field Text:
                                    </td>
                                    <td style="width: 40px">
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="382px" ID="textBoxText">My text</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        List Box Field Value:
                                    </td>
                                    <td style="width: 38px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropDownListListBoxValue" runat="server">
                                            <asp:ListItem>List Value 1</asp:ListItem>
                                            <asp:ListItem>List Value 2</asp:ListItem>
                                            <asp:ListItem>List Value 3</asp:ListItem>
                                            <asp:ListItem>List Value 4</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Combo Box Field Value:
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                    


                                        <asp:DropDownList ID="dropDownListComboBoxValue" runat="server">
                                            <asp:ListItem>Combo Value 1</asp:ListItem>
                                            <asp:ListItem>Combo Value 2</asp:ListItem>
                                            <asp:ListItem>Combo Value 3</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Selected Radio Button:
                                    </td>
                                    <td style="width: 25px">
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radioButton1" GroupName="SelectedRadionButton" 
                                            runat="server" Text="Radio Button 1"
                                            Checked="True" />
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radioButton2" GroupName="SelectedRadionButton" runat="server" 
                                            Text="Radio Button 2" />
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
                            <asp:Button ID="buttonFillAndSavePdf" runat="server" Text="Fill and Save PDF" 
                                onclick="buttonFillAndSavePdf_Click" />
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
