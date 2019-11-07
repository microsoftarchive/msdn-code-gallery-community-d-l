<%@ Page Title="Select a Target Media Type and Render HTML to PDF with Screen or Print Layout"
    Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="MediaTypeSelection.aspx.cs"
    Inherits="HiQPdf_Demo.MediaTypeSelection" %>

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
                            In this demo you learn how to change the CSS properties of a HTML document based
                            on media type selection. By default the HTML to PDF converter will render the HTML
                            document for 'screen', but this can be changed when another media type is assigned
                            to HtmlToPdf.MediaType property.
                            <br />
                            <br />
                            For example, when this property is set to 'print' the CSS properties defined by
                            the '@media print' rule will be used when the HTML is rendered instead of the CSS
                            properties defined by the '@media screen' rule.
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
                                        HTML Code
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxHtmlCode" runat="server" TextMode="MultiLine" Height="335px"
                                            Width="590px">
&lt;html&gt; 
&lt;head&gt; 
    &lt;title&gt;
        HTML to PDF Rendering Changes Based on Selected Media Type
    &lt;/title&gt; 
    &lt;style type=&quot;text/css&quot;&gt; 
        body { 
            font-family: &#39;Arial&#39;; 
            font-size: 16px; 
        } 
        
        @media screen 
        { 
            p 
            { 
                font-family: Verdana; 
                font-size: 14px; 
                font-style: italic; 
                color: Green; 
            } 
        } 
        @media print 
        { 
            p 
            { 
                font-family: &#39;Courier New&#39;;
                font-size: 12px; 
                color: Black; 
            } 
        } 
        @media screen,print 
        { 
            p 
            { 
                font-weight: bold; 
            } 
        } 
    &lt;/style&gt; 
&lt;/head&gt; 
&lt;body&gt; 
    &lt;br /&gt;&lt;br /&gt; 
    The style of the paragraph below is changed based on 
        the selected media type:
    &lt;br /&gt;&lt;br /&gt; 
    &lt;p&gt; 
        This is a media type selection test. When viewing on screen
        the text is bigger, italic and green. When printing the 
        text is smaller, normal and black.
    &lt;/p&gt; 
&lt;/body&gt; 
&lt;/html&gt;
                                        </asp:TextBox>
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
                            <table cellpadding="0px" cellspacing="0px">
                                <tr>
                                    <td>
                                        <b>Select Media Type:</b>
                                    </td>
                                    <td style="width: 8px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropDownListMediaType" runat="server" Width="80px">
                                            <asp:ListItem>screen</asp:ListItem>
                                            <asp:ListItem>print</asp:ListItem>
                                        </asp:DropDownList>
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
                            <asp:Button ID="buttonCreatePdf" runat="server" Text="Create PDF" OnClick="buttonCreatePdf_Click" />
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
