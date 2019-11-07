# How to create HTML email with embedded images from RTF in .Net C# - step by step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Microsoft Azure
- .NET Framework
- .NET Framework 4.0
- HTML5
- Visual C#
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- custom controls
- Web Services
- How to
- Networking
- Cloud
- Windows web services
## Updated
- 11/23/2016
## Description

<h1>Introduction</h1>
<p><span>In this article you will find how to create a simple .Net/C# application which converts RTF document to HTML email with embedded images and sends it using MS Outlook programmatically.</span></p>
<p>Let&rsquo;s make a C# code satisfying of these conditions:</p>
<ol>
<li><span>Acceptable for any .Net application: ASP.NET, Windows Forms, WPF, Console, Web Service, SilverLight etc.</span>
</li><li><span>Works at 32-bit and 64-bit Windows machines.</span> </li><li><span>Compatible with .NET 2.0, 3.5 , 4.0, 4.5 frameworks and even higher if such will appear.</span>
</li></ol>
<p><span>To make converting of RTF to HTML email with images at server-side we&rsquo;ll use&nbsp;</span><a href="http://www.sautinsoft.com/convert-rtf-to-html/rtf-to-html-component-asp.net.php"><span><em><strong>RTF-to-HTML&nbsp;DLL .Net</strong></em></span></a><span>library.&nbsp;It&rsquo;s
 .Net component which will provides API to convert RTF to HTML with all images which we&rsquo;ll get in a list after converting. We need these images extracted from RTF to further adding them into email as attachments.</span></p>
<p><span><br>
</span></p>
<p><span><img id="163911" src="163911-rtftoemail-300x225.png" alt="" width="300" height="225" style="display:block; margin-left:auto; margin-right:auto"></span></p>
<p><span></p>
<div></div>
<div><span>Further, please unpack the archive (see att. file). We&rsquo;ll need the file &ldquo;SautinSoft.RtfToHtml.dll&rdquo; from the package.</span></div>
<div><span>Create a new C# Console Application named RtfToHtmlEmail. Next add references to the &ldquo;SautinSoft.RtfToHtml.dll&rdquo;, &ldquo;Microsoft Outlook Library&rdquo; and &ldquo;Microsoft.CSharp&rdquo; as shown on pictures below:</span></div>
<div><span><br>
</span></div>
<img id="163912" src="163912-add-reference-to-outlook-300x206.png" alt="" width="300" height="206" style="display:block; margin-left:auto; margin-right:auto"></span>
<p></p>
<p><span><img id="163913" src="163913-solution-explorer-outlook.png" alt="" width="355" height="439" style="display:block; margin-left:auto; margin-right:auto"><br>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.IO;
using System.Collections;
using Outlook = Microsoft.Office.Interop.Outlook;
 
namespace RtfToHtmlEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            // This application converts RTF file to HTML email with embedded images
            // and send the email using Outlook
 
            // Here we'll specify settings variables
            string pathToRtf = @&quot;c:\Book.rtf&quot;;
            // We need this folder to store image attachments temporary.
            // Images will be deleted after sending the email.
            string pathToStoreTempAttachments = @&quot;c:\temp&quot;;
            string from = &quot;bob@bobsite.com&quot;;
            string to = &quot;john@johnsite.com&quot;;
            string subject = &quot;Testing message from Bob to John using Outlook&quot;;            
 
            // 1. Convert RTF to HTML and place all images to list
            string rtf = File.ReadAllText(pathToRtf);
            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
            r.ImageStyle.IncludeImageInHtml = false;
            ArrayList imageList = new ArrayList();
 
            // 2. After launching this method we'll get our RTF document in HTML format
            // and list of all images.
            string html = r.ConvertString(rtf, imageList);
 
            // 3. Create an instance of MS Outlook            
            //Type outlookApp = Type.GetTypeFromProgID(&quot;Outlook.Application&quot;);
            //object objOutlookApp = Activator.CreateInstance(outlookApp);
            Outlook.Application application = new Outlook.Application();
 
            // 4. Create a new MailItem and set the To, Subject, and Body properties.
            Outlook.MailItem newMail = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
            newMail.To = to;
            newMail.Subject = subject;            
            newMail.HTMLBody = html;
            newMail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
 
            // 5. Retrieve the account that has the specific SMTP address.
            // Use this account to send the e-mail.            
            Outlook.Account account = GetAccountForEmailAddress(application, from);
 
            // 6. Attach images to the email using cid
            // And send the email
            foreach (SautinSoft.RtfToHtml.SautinImage si in imageList)
            {
                string imageCid = si.Cid.Replace(&quot;cid:&quot;, &quot;&quot;);
                string pathToImage = Path.Combine(pathToStoreTempAttachments, imageCid);
                si.Img.Save(Path.Combine(pathToImage));
                Outlook.Attachment attachment = newMail.Attachments.Add(pathToImage, Outlook.OlAttachmentType.olEmbeddeditem, null, imageCid);
                attachment.PropertyAccessor.SetProperty(&quot;http://schemas.microsoft.com/mapi/proptag/0x3712001E&quot;, imageCid);
                File.Delete(pathToImage);
            }
 
            newMail.SendUsingAccount = account;
            newMail.Send();
        }
        public static Outlook.Account GetAccountForEmailAddress(Outlook.Application application, string smtpAddress)
        {
 
            // Loop over the Accounts collection of the current Outlook session.
            Outlook.Accounts accounts = application.Session.Accounts;
            foreach (Outlook.Account account in accounts)
            {
                // When the e-mail address matches, return the account.
                if (account.SmtpAddress == smtpAddress)
                {
                    return account;
                }
            }
            throw new System.Exception(string.Format(&quot;No Account with SmtpAddress: {0} exists!&quot;, smtpAddress));
        }
 
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Outlook&nbsp;=&nbsp;Microsoft.Office.Interop.Outlook;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RtfToHtmlEmail&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;application&nbsp;converts&nbsp;RTF&nbsp;file&nbsp;to&nbsp;HTML&nbsp;email&nbsp;with&nbsp;embedded&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;and&nbsp;send&nbsp;the&nbsp;email&nbsp;using&nbsp;Outlook</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Here&nbsp;we'll&nbsp;specify&nbsp;settings&nbsp;variables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pathToRtf&nbsp;=&nbsp;@<span class="cs__string">&quot;c:\Book.rtf&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;We&nbsp;need&nbsp;this&nbsp;folder&nbsp;to&nbsp;store&nbsp;image&nbsp;attachments&nbsp;temporary.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Images&nbsp;will&nbsp;be&nbsp;deleted&nbsp;after&nbsp;sending&nbsp;the&nbsp;email.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pathToStoreTempAttachments&nbsp;=&nbsp;@<span class="cs__string">&quot;c:\temp&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;from&nbsp;=&nbsp;<span class="cs__string">&quot;bob@bobsite.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;to&nbsp;=&nbsp;<span class="cs__string">&quot;john@johnsite.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;subject&nbsp;=&nbsp;<span class="cs__string">&quot;Testing&nbsp;message&nbsp;from&nbsp;Bob&nbsp;to&nbsp;John&nbsp;using&nbsp;Outlook&quot;</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;1.&nbsp;Convert&nbsp;RTF&nbsp;to&nbsp;HTML&nbsp;and&nbsp;place&nbsp;all&nbsp;images&nbsp;to&nbsp;list</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;rtf&nbsp;=&nbsp;File.ReadAllText(pathToRtf);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.RtfToHtml&nbsp;r&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.RtfToHtml();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.ImageStyle.IncludeImageInHtml&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ArrayList&nbsp;imageList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ArrayList();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;2.&nbsp;After&nbsp;launching&nbsp;this&nbsp;method&nbsp;we'll&nbsp;get&nbsp;our&nbsp;RTF&nbsp;document&nbsp;in&nbsp;HTML&nbsp;format</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;and&nbsp;list&nbsp;of&nbsp;all&nbsp;images.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;html&nbsp;=&nbsp;r.ConvertString(rtf,&nbsp;imageList);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;3.&nbsp;Create&nbsp;an&nbsp;instance&nbsp;of&nbsp;MS&nbsp;Outlook&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Type&nbsp;outlookApp&nbsp;=&nbsp;Type.GetTypeFromProgID(&quot;Outlook.Application&quot;);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//object&nbsp;objOutlookApp&nbsp;=&nbsp;Activator.CreateInstance(outlookApp);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Outlook.Application&nbsp;application&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Outlook.Application();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;4.&nbsp;Create&nbsp;a&nbsp;new&nbsp;MailItem&nbsp;and&nbsp;set&nbsp;the&nbsp;To,&nbsp;Subject,&nbsp;and&nbsp;Body&nbsp;properties.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Outlook.MailItem&nbsp;newMail&nbsp;=&nbsp;(Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newMail.To&nbsp;=&nbsp;to;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newMail.Subject&nbsp;=&nbsp;subject;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newMail.HTMLBody&nbsp;=&nbsp;html;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newMail.BodyFormat&nbsp;=&nbsp;Outlook.OlBodyFormat.olFormatHTML;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;5.&nbsp;Retrieve&nbsp;the&nbsp;account&nbsp;that&nbsp;has&nbsp;the&nbsp;specific&nbsp;SMTP&nbsp;address.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;this&nbsp;account&nbsp;to&nbsp;send&nbsp;the&nbsp;e-mail.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Outlook.Account&nbsp;account&nbsp;=&nbsp;GetAccountForEmailAddress(application,&nbsp;from);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;6.&nbsp;Attach&nbsp;images&nbsp;to&nbsp;the&nbsp;email&nbsp;using&nbsp;cid</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;And&nbsp;send&nbsp;the&nbsp;email</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(SautinSoft.RtfToHtml.SautinImage&nbsp;si&nbsp;<span class="cs__keyword">in</span>&nbsp;imageList)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;imageCid&nbsp;=&nbsp;si.Cid.Replace(<span class="cs__string">&quot;cid:&quot;</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pathToImage&nbsp;=&nbsp;Path.Combine(pathToStoreTempAttachments,&nbsp;imageCid);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;si.Img.Save(Path.Combine(pathToImage));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Outlook.Attachment&nbsp;attachment&nbsp;=&nbsp;newMail.Attachments.Add(pathToImage,&nbsp;Outlook.OlAttachmentType.olEmbeddeditem,&nbsp;<span class="cs__keyword">null</span>,&nbsp;imageCid);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;attachment.PropertyAccessor.SetProperty(<span class="cs__string">&quot;http://schemas.microsoft.com/mapi/proptag/0x3712001E&quot;</span>,&nbsp;imageCid);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.Delete(pathToImage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newMail.SendUsingAccount&nbsp;=&nbsp;account;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newMail.Send();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Outlook.Account&nbsp;GetAccountForEmailAddress(Outlook.Application&nbsp;application,&nbsp;<span class="cs__keyword">string</span>&nbsp;smtpAddress)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Loop&nbsp;over&nbsp;the&nbsp;Accounts&nbsp;collection&nbsp;of&nbsp;the&nbsp;current&nbsp;Outlook&nbsp;session.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Outlook.Accounts&nbsp;accounts&nbsp;=&nbsp;application.Session.Accounts;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Outlook.Account&nbsp;account&nbsp;<span class="cs__keyword">in</span>&nbsp;accounts)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;When&nbsp;the&nbsp;e-mail&nbsp;address&nbsp;matches,&nbsp;return&nbsp;the&nbsp;account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(account.SmtpAddress&nbsp;==&nbsp;smtpAddress)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;account;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Exception(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;No&nbsp;Account&nbsp;with&nbsp;SmtpAddress:&nbsp;{0}&nbsp;exists!&quot;</span>,&nbsp;smtpAddress));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1>Source Code Files</h1>
<p>&nbsp;<em>Related Links:</em></p>
<div><em><br>
Website:&nbsp;<a href="http://sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/convert-rtf-to-html/rtf-to-html-component-asp.net.php">RTF to HTML.Net</a><br>
Download:&nbsp;<a href="http://sautinsoft.com/convert-rtf-to-html/download.php"><em>RTF to HTML.Net</em></a><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that RTFtoHTML.Net is entirely written in managed C#, which makes it absolutely
 standalone and an independent library</em></p>
