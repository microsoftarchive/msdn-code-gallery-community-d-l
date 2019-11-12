# E-Mails mit C#/F#/VB.NET/C++/CLI versenden
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET
- F#
- VB.Net
- C++/CLI
## Topics
- e-mail
- Email
- SmtpClient
- MailMessage
- AlternateView
- LinkedResource
- MailAdress
## Updated
- 02/08/2013
## Description

<h1>Einleitung</h1>
<p>Viele Programme bieten es an aus dem Men&uuml; heraus eine E-Mail an den Hersteller zu senden. Die Grunds&auml;tzliche Vorgehensweise m&ouml;chte ich hier zeigen.</p>
<h1><span>Was wird ben&ouml;tigt<br>
</span></h1>
<p>Visual Studio 2010 Service Pack 1 oder h&ouml;her<em>.</em></p>
<p><em>Das Beispiel ist in den Programmiersprachen C#, VB.NET, F# und C&#43;&#43;/CLI verf&uuml;gbar<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Der Code</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span><span class="hidden">fsharp</span>




<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/de-DE/library/System.Net.Mail.aspx" target="_blank" title="Auto generated link to System.Net.Mail">System.Net.Mail</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;EMail_versenden&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MailMessage&nbsp;mail&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mail.From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;koopakiller@live.de&quot;</span>);&nbsp;<span class="cs__com">//Absender</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mail.To.Add(<span class="cs__string">&quot;koopakiller@live.de&quot;</span>);&nbsp;<span class="cs__com">//Empf&auml;nger</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mail.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Das&nbsp;ist&nbsp;der&nbsp;Betreff&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mail.Body&nbsp;=&nbsp;<span class="cs__string">&quot;Der&nbsp;Inhalt&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//mail.IsBodyHtml&nbsp;=&nbsp;true;&nbsp;//Nur&nbsp;wenn&nbsp;Body&nbsp;HTML&nbsp;Quellcode&nbsp;ist&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SmtpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SmtpClient(<span class="cs__string">&quot;smtp.live.com&quot;</span>,&nbsp;<span class="cs__number">25</span>);&nbsp;<span class="cs__com">//SMTP&nbsp;Server&nbsp;von&nbsp;Hotmail&nbsp;und&nbsp;Outlook.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.Credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/de-DE/library/System.Net.NetworkCredential.aspx" target="_blank" title="Auto generated link to System.Net.NetworkCredential">System.Net.NetworkCredential</a>(<span class="cs__string">&quot;koopakiller@live.de&quot;</span>,&nbsp;<span class="cs__string">&quot;Passwort&quot;</span>);<span class="cs__com">//Anmeldedaten&nbsp;f&uuml;r&nbsp;den&nbsp;SMTP&nbsp;Server</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.EnableSsl&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<span class="cs__com">//Die&nbsp;meisten&nbsp;Anbieter&nbsp;verlangen&nbsp;eine&nbsp;SSL-Verschl&uuml;sselung</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.Send(mail);&nbsp;<span class="cs__com">//Senden</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;E-Mail&nbsp;wurde&nbsp;versendet&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Fehler&nbsp;beim&nbsp;Senden&nbsp;der&nbsp;E-Mail\n\n{0}&quot;</span>,&nbsp;ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Indem Sie mit der <a href="http://msdn.microsoft.com/de-de/library/ms132404.aspx">
Add-Methode</a> E-Mail-Adressen zur <a href="http://msdn.microsoft.com/de-de/library/system.net.mail.mailmessage.to.aspx">
To-Eigenschaft</a> hinzuf&uuml;gen, dan wird diese E-Mail an alle gelisteten Adressen gesendet.</p>
<p>Wenn Sie den Inhalt formatieren m&ouml;chten, dann k&ouml;nnen Sie als <a href="http://msdn.microsoft.com/de-de/library/system.net.mail.mailmessage.body.aspx">
Body</a> einen HTML-Code verwenden. Damit alles richtig dargestellt wird, muss noch die
<a href="http://msdn.microsoft.com/de-de/library/system.net.mail.mailmessage.isbodyhtml.aspx">
Eigenschaft IsHTML</a> auf true gestellt werden.</p>
<p>E-Mail Anbieter, die SMTP unterst&uuml;tzen, haben normalerweise auf Ihrer Webseite stehen, was Sie als Server und Port verwenden sollen. Ihr Passwort und der Anmeldename sind dien Daten, die zu Ihrem E-Mail Konto geh&ouml;hren.<br>
Sollte der Server eine SSL Verschl&uuml;sselung erfordern, dann muss die <a href="http://msdn.microsoft.com/de-de/library/system.net.mail.smtpclient.enablessl.aspx">
EnableSsl-Eigenschaft</a> auf true stellen.</p>
<p>Um eine Antwortadresse festzulegen, setzen Sie die <a href="http://msdn.microsoft.com/de-de/library/system.net.mail.mailmessage.replyto.aspx">
ReplyTo</a>-Eigenschaft. Alternativ k&ouml;nnen Sie auch Addressen in die <a href="http://msdn.microsoft.com/de-de/library/system.net.mail.mailmessage.replytolist.aspx">
ReplyToList</a> eintragen, dann wird die Antwortmail an mehrere Adressen gesendet.</p>
<h2>Anlagen</h2>
<p>Wenn Sie Anlagen mit der E-Mail versenden m&ouml;chten, dann k&ouml;nnen Sie die
<a href="http://msdn.microsoft.com/de-de/library/system.net.mail.mailmessage.attachments.aspx">
Atachments-Eigenschaft</a> &auml;ndern:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span><span class="hidden">fsharp</span>




<div class="preview">
<pre class="csharp"><span class="cs__com">//Anlage&nbsp;hinzuf&uuml;gen</span>&nbsp;
mail.Attachments.Add(<span class="cs__keyword">new</span>&nbsp;Attachment(@<span class="cs__string">&quot;C:\attachment.jpg&quot;</span>));&nbsp;<span class="cs__com">//Kopieren&nbsp;Sie&nbsp;die&nbsp;Datei&nbsp;aus&nbsp;dem&nbsp;Projektmappenordner</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Bilder</h2>
<div class="endscriptcode">Um ein Bild einzuf&uuml;gen haben Sie 2 m&ouml;glichkeiten. Die erste ist, das Bild im Web zu speichern und einfach entsprechend zu verlinken. Die 2. und oftmals praktischerere Methode ist, das Bild direkt mit in die E-Mail zu verpacken.</div>
<div class="endscriptcode">Um ein Bild aus dem Web einzuf&uuml;gen k&ouml;nnen Sie folgenden HTML Code verwenden:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;img&nbsp;alt=<span class="js__string">&quot;Bilder&nbsp;deaktiviert?&quot;</span>&nbsp;src=<span class="js__string">&quot;http://example.com/img.jpg&quot;</span>/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Wenn Sie das Bild in der E-Mail mitsenden m&ouml;chten, dann geht das &uuml;ber eine LinkedResource. In diesem Fall d&uuml;rfen Sie kein Body festlegen. Dieser wird anders festgelegt:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span><span class="hidden">fsharp</span>




<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AlternateView&nbsp;html&nbsp;=&nbsp;AlternateView.CreateAlternateViewFromString(<span class="cs__string">&quot;HTML&nbsp;Inhalt&quot;</span>,&nbsp;Encoding.UTF8,&nbsp;<span class="cs__string">&quot;text/html&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LinkedResource&nbsp;img&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LinkedResource(@<span class="cs__string">&quot;C:\image.jpg&quot;</span>);<span class="cs__com">//Kopieren&nbsp;Sie&nbsp;die&nbsp;Datei&nbsp;aus&nbsp;dem&nbsp;Projektmappenordner</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.ContentId&nbsp;=&nbsp;<span class="cs__string">&quot;imgID&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;html.LinkedResources.Add(img);&nbsp;<span class="cs__com">//Bild&nbsp;zu&nbsp;den&nbsp;Resourcen&nbsp;des&nbsp;HTML&nbsp;hinzuf&uuml;gen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mail.AlternateViews.Add(html);&nbsp;<span class="cs__com">//HTML&nbsp;zur&nbsp;E-Mail&nbsp;hinzuf&uuml;gen</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Um dieses Bild verwenden zu k&ouml;nnen, k&ouml;nnen Sie folgenden HTML Code verwenden:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;cid:imgID&quot;</span>&nbsp;<span class="html__attr_name">alt</span>=<span class="html__attr_value">&quot;Bilder&nbsp;deaktiviert?&quot;</span><span class="html__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&quot;<em>cid:</em>&quot; gibt dabei an, das es sich um eine eingebettete Resource handelt. &quot;<em>imgID</em>&quot; ist die ContentId des Bildes.</div>
</div>
</div>
<h1 class="endscriptcode">Quellcodedateien</h1>
<div class="endscriptcode">
<ul>
<li>EMail versenden.sln - Projektmappe </li><li>Programm.cs - C# Quellcode </li><li>Module1.vb - VB.NET Quellcode </li><li>EMail versenden CppCli.cpp - C&#43;&#43;/CLI Quellcode </li><li>Program.fs - F# Quellcode </li></ul>
</div>
</div>
