<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    Codebehind="PdfPageBreaksControl.aspx.cs" Inherits="HiQPdf_Demo.PdfPageBreaksControl"
    Title="HTML to PDF - PDF Page Breaks Control" %>

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
                            In this demo you learn how to control the page breaks in the generated PDF document
                            using CSS styles. There are 3 styles controlling the page breaks that can be applied
                            to a HTML document:<br />
                            <br />
                            'page-break-before : always' style forces a page break in PDF right before the box
                            where the element is rendered<br />
                            'page-break-after : always' style forces a page break in PDF right after the box
                            where the element is rendered<br />
                            'page-break-inside : avoid' style will make the converter to generate the PDF such
                            that the element with this style is not cut between PDF pages if possible</td>
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
                                        HTML Code</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxHtmlCode" runat="server" TextMode="MultiLine" Height="270px"
                                            Width="590px">&lt;html&gt;
&lt;head&gt;
    &lt;title&gt;Page Breaks Control&lt;/title&gt;
    &lt;style type=&quot;text/css&quot;&gt;
        body
        {
            font-family: Times New Roman;
            font-size: 15px;
        }
    &lt;/style&gt;
&lt;/head&gt;
&lt;body style=&quot;margin: 1px&quot;&gt;
    &lt;div style=&quot;width: 750px&quot;&gt;
        &lt;table style=&quot;page-break-after: always; width: 100%; height: 300px; border: 1px solid black;
            background-color: #F5F5F5&quot;&gt;
            &lt;tr&gt;
                &lt;td style=&quot;vertical-align: middle; text-align: center&quot;&gt;
                    A page break will be forced in PDF right after this TABLE element
                &lt;/td&gt;
            &lt;/tr&gt;
        &lt;/table&gt;
        &lt;br /&gt;
        This text there is on a new PDF page because a page break was forced right after
        the TABLE above&lt;br /&gt;
        &lt;table style=&quot;page-break-before: always; width: 100%; height: 300px; border: 1px solid black;
            background-color: #F5F5F5&quot;&gt;
            &lt;tr&gt;
                &lt;td style=&quot;vertical-align: middle; text-align: center&quot;&gt;
                    A page break was forced in PDF right before this TABLE element
                &lt;/td&gt;
            &lt;/tr&gt;
        &lt;/table&gt;
        &lt;br /&gt;
        &lt;table style=&quot;page-break-before: always; width: 100%; border: 1px solid black; background-color: #F5F5F5&quot;&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
            &lt;tr&gt;
                &lt;td style=&quot;page-break-inside: avoid; border: 1px solid black;&quot;&gt;
                    &lt;b&gt;The text inside this table row should not be cut between PDF pages.&lt;/b&gt;&lt;br /&gt;
                    &lt;br /&gt;
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                &lt;/td&gt;
            &lt;/tr&gt;
        &lt;/table&gt;
    &lt;/div&gt;
&lt;/body&gt;
&lt;/html&gt;

                                        </asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 5px; font-weight: bold">
                                        HTML Code Base URL
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxBaseUrl" runat="server" Text="" Width="590px"></asp:TextBox></td>
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
                                        Browser Width:
                                    </td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxBrowserWidth" runat="server" Width="35px">800</asp:TextBox></td>
                                    <td style="width: 5px">
                                    </td>
                                    <td>
                                        px
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
