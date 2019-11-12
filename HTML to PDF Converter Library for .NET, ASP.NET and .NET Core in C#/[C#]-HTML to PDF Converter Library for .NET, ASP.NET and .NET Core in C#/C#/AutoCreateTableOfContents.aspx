<%@ Page Title="HTML to PDF - Auto Create Table of Contents" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="AutoCreateTableOfContents.aspx.cs" Inherits="HiQPdf_Demo.AutoCreateTableOfContents" %>

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
                        <td>In this demo you learn how to automatically create a table of contents in the beginning of the generated PDF document 
                            based on the H1 to H6 tags found in HTML document.
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
                                            Width="590px">&lt;html&gt;
&lt;head&gt;
    &lt;title&gt;Auto Create Table of Contents&lt;/title&gt;
&lt;/head&gt;
&lt;body&gt;
    &lt;br /&gt;
    &lt;br /&gt;
    &lt;h1 class=&quot;pdf_outlines&quot;&gt;Contents&lt;/h1&gt;
    &lt;a href=&quot;#Chapter1&quot;&gt;Go To Chapter 1&lt;/a&gt;
    &lt;br /&gt;
    &lt;a href=&quot;#Chapter2&quot;&gt;Go To Chapter 2&lt;/a&gt;
    &lt;br /&gt;
    &lt;a href=&quot;#Chapter3&quot;&gt;Go To Chapter 3&lt;/a&gt;
    &lt;br /&gt;
    &lt;a href=&quot;http://www.hiqpdf.com&quot;&gt;Visit Website&lt;/a&gt;
    &lt;h2 class=&quot;pdf_outlines&quot; style=&quot;page-break-before: always&quot; id=&quot;Chapter1&quot;&gt;Chapter 1&lt;/h2&gt;
    This is the chapter 1 content.
    &lt;h2 class=&quot;pdf_outlines&quot; style=&quot;page-break-before: always&quot; id=&quot;Chapter2&quot;&gt;Chapter 2&lt;/h2&gt;
    This is the chapter 2 content.
    &lt;h2 class=&quot;pdf_outlines&quot; style=&quot;page-break-before: always&quot; id=&quot;Chapter3&quot;&gt;Chapter 3&lt;/h2&gt;
    This is the chapter 3 content.
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
                                        <asp:CheckBox ID="checkBoxCreateTOC" runat="server" Checked="True" Text="Auto Create Table of Contents" />
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
