<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="AutoOutlinesAndLinks.aspx.cs" Inherits="HiQPdf_Demo.AutoOutlinesAndLinks"
    Title="HTML to PDF - Auto Outlines and Links" %>

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
                        <td>In this demo you learn how to automatically create outlines, HTTP and internal links
                            in PDF and how to force a HTML element to start on a new page in PDF.<br />
                            <br />
                            The demo creates a simple table of contents with internal links to chapters and
                            a HTTP link to HiQPdf website. For each chapter there is also an outline in document
                            outlines and each chapter is forced to start on a new PDF page using the page-break-before
                            : always style.
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
    &lt;title&gt;Auto Outlines and Links&lt;/title&gt;
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
                                        <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF" OnClick="buttonCreatePdf_Click" />
                                    </td>
                                    <td style="width: 50px"></td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxHierarchical" runat="server" Checked="True" Text="Hierarchical Outlines" />
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
