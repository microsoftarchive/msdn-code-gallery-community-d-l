<%@ Page Title="HTML to PDF - Auto Create PDF Forms" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="AutoCreatePdfForms.aspx.cs" Inherits="HiQPdf_Demo.AutoCreatePdfForms" %>

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
                        <td>In this demo you learn how to automatically create a PDF form from a HTML form. You can fill and submit the generated PDF form.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom: 5px; font-weight: bold">HTML Code</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxHtmlCode" runat="server" TextMode="MultiLine" Height="270px"
                                            Width="590px">&lt;!DOCTYPE html&gt;
&lt;html&gt;
&lt;head&gt;
    &lt;meta charset=&quot;utf-8&quot; /&gt;
    &lt;title&gt;Auto Create PDF Forms from HTML Forms&lt;/title&gt;
&lt;/head&gt;
&lt;body style=&quot;font-family: &#39;Times New Roman&#39;; font-size: 14px&quot;&gt;
    &lt;form name=&quot;subscrForm&quot; action=&quot;http://www.hiqpdf.com/formsubmitaction/&quot; method=&quot;post&quot;&gt;
        Name:&lt;br /&gt;
        &lt;input style=&quot;width: 200px&quot; type=&quot;text&quot; name=&quot;subscrName&quot;&gt;
        &lt;br /&gt;
        &lt;br /&gt;
        Email :&lt;br /&gt;
        &lt;input style=&quot;width: 200px&quot; type=&quot;text&quot; name=&quot;subscrEmail&quot;&gt;&lt;br /&gt;
        &lt;br /&gt;
        Website:&lt;br /&gt;
        &lt;input style=&quot;width: 200px&quot; type=&quot;text&quot; name=&quot;subscrWebsite&quot;&gt;&lt;br /&gt;
        &lt;br /&gt;
        Password:&lt;br /&gt;
        &lt;input style=&quot;width: 200px&quot; type=&quot;password&quot; name=&quot;subscrPassword&quot;&gt;&lt;br /&gt;
        &lt;br /&gt;
        Gender:&amp;nbsp;
        &lt;input type=&quot;radio&quot; name=&quot;subscrGender&quot; value=&quot;male&quot; checked=&quot;checked&quot;&gt;Male
        &lt;input type=&quot;radio&quot; name=&quot;subscrGender&quot; value=&quot;female&quot;&gt;Female&lt;br /&gt;
        &lt;br /&gt;
        Domains of interest:&amp;nbsp;
        &lt;select name=&quot;subscrDomains&quot;&gt;
            &lt;option value=&quot;science&quot; selected=&quot;selected&quot;&gt;Science&lt;/option&gt;
            &lt;option value=&quot;culture&quot;&gt;Culture&lt;/option&gt;
            &lt;option value=&quot;music&quot;&gt;Music&lt;/option&gt;
        &lt;/select&gt;&lt;br /&gt;
        &lt;br /&gt;
        Newsletter:&amp;nbsp;&lt;input type=&quot;checkbox&quot; name=&quot;receiveNewsletterEmail&quot; value=&quot;email&quot; checked=&quot;checked&quot;&gt;By email
                    &lt;input type=&quot;checkbox&quot; name=&quot;receiveNewsletterPost&quot; value=&quot;post&quot;&gt;By post
        &lt;br /&gt;
        &lt;br /&gt;
        Short description:&lt;br /&gt;
        &lt;textarea name=&quot;subscrDescription&quot; style=&quot;width: 300px; height: 100px&quot;&gt;&lt;/textarea&gt;
        &lt;br /&gt;
        &lt;br /&gt;
        &lt;input type=&quot;submit&quot; name=&quot;submitButton&quot; value=&quot;Submit Form&quot;&gt;
    &lt;/form&gt;
&lt;/body&gt;
&lt;/html&gt;

                                        </asp:TextBox></td>
                                </tr>
                            </table>
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
                                        <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF" OnClick="buttonCreatePdf_Click" Style="height: 26px" />
                                    </td>
                                    <td style="width: 50px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxCreateForm" runat="server" Checked="True" Text="Auto Create PDF Form" />
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
