<%@ Page Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true"
    CodeBehind="ConversionTriggeringMode.aspx.cs" Inherits="HiQPdf_Demo.ConversionTriggeringMode"
    Title="HTML to PDF - Conversion Triggering Mode" %>

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
                            In this demo you learn about the conversion triggering modes. There are three conversion
                            triggering modes: Auto, WaitTime and Manual.<br />
                            <br />
                            In the sample script we provide, a ticks counter is incremented each 30 ms after
                            the document was loaded. When the ticks count reached 100 in about 3 seconds the
                            startConversion() is called.<br />
                            <br />
                            When the triggering mode is Manual the call to startConversion() will trigger the
                            conversion.
                            <br />
                            When the triggering mode is WaitTime a wait time of 5 seconds is sufficient to allow
                            the ticks count reach 100.
                            <br />
                            When the triggering mode is Auto the conversion will start before the counter reached
                            100.
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
                                        <asp:TextBox ID="textBoxHtmlCode" runat="server" TextMode="MultiLine" Height="200px"
                                            Width="590px">&lt;html&gt;
&lt;head&gt;
    &lt;title&gt;Conversion Triggering Mode&lt;/title&gt;
&lt;/head&gt;
&lt;body&gt;
    &lt;br /&gt;
    &lt;br /&gt;
    &lt;span style=&quot;font-family: Times New Roman; font-size: 10pt&quot;&gt;When the triggering mode
        is &#39;Manual&#39; the conversion is triggered by the call to &lt;b&gt;hiqPdfConverter.startConversion()&lt;/b&gt;
        from JavaScript.&lt;br /&gt;
        In this example document the startConversion() method is called when the ticks count
        reached 100 which happens in about 3 seconds.&lt;/span&gt;
    &lt;br /&gt;
    &lt;br /&gt;
    &lt;b&gt;Ticks Count:&lt;/b&gt; &lt;span style=&quot;color: Red&quot; id=&quot;ticks&quot;&gt;0&lt;/span&gt;
    &lt;br /&gt;
    &lt;br /&gt;
    &lt;!-- display HiQPdf HTML converter version if the document is loaded in converter--&gt;
    &lt;span style=&quot;font-family: Times New Roman; font-size: 10pt&quot;&gt;HiQPdf Info:
        &lt;script type=&quot;text/javascript&quot;&gt;
            // check if the document is loaded in HiQPdf HTML to PDF Converter
            if (typeof hiqPdfInfo == &quot;undefined&quot;) {
                // hiqPdfInfo object is not defined and the document is loaded in a browser
                document.write(&quot;Not in HiQPdf&quot;);
            }
            else {
                // hiqPdfInfo object is defined and the document is loaded in converter
                document.write(hiqPdfInfo.getVersion());
            }
        &lt;/script&gt;
    &lt;/span&gt;
    &lt;br /&gt;
    &lt;script type=&quot;text/javascript&quot;&gt;
        var ticks = 0;
        function tick() {
            // increment ticks count
            ticks++;

            var ticksElement = document.getElementById(&quot;ticks&quot;);
            // set ticks count
            ticksElement.innerHTML = ticks;
            if (ticks == 100) {
                // trigger conversion
                ticksElement.style.color = &quot;green&quot;;
                if (typeof hiqPdfConverter != &quot;undefined&quot;)
                     hiqPdfConverter.startConversion();
            }
            else {
                // wait one more tick
                setTimeout(&quot;tick()&quot;, 30);
            }
        }

        tick();
    &lt;/script&gt;
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 30px; font-weight: bold">
                                        Conversion Triggering Mode:
                                    </td>
                                    <td style="width: 5px; height: 30px;">
                                    </td>
                                    <td style="height: 30px;">
                                        <asp:DropDownList ID="dropDownListTriggeringMode" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="dropDownListTriggeringMode_SelectedIndexChanged">
                                            <asp:ListItem>Auto</asp:ListItem>
                                            <asp:ListItem>Manual</asp:ListItem>
                                            <asp:ListItem>WaitTime</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20px; height: 30px;">
                                    </td>
                                    <td style="height: 30px">
                                        <asp:Panel ID="panelWaitTime" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Wait Time:
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textBoxWaitTime" runat="server" Width="30px">5</asp:TextBox>
                                                    </td>
                                                    <td style="width: 5px">
                                                    </td>
                                                    <td>
                                                        sec
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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
