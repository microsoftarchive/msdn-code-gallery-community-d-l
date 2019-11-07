# Email Sending in C#
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SMTP
- Windows Forms
- System.Net.Mail
- Email Processing in C#
## Topics
- C#
- Send Email
- SMTP
- Windows Forms
- Email
## Updated
- 05/04/2017
## Description

<p><span style="font-size:small"><strong>This is a simple email sending application that uses smtp server to send email</strong><strong>&nbsp;</strong></span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>&nbsp;</strong><strong>Building the Sample</strong></span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">Download sample and extract it.</span> </li><li><span style="font-size:small">open EmailSendingApp.sln file</span> </li><li><span style="font-size:small">build application and run</span> </li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Description</strong></span></p>
<p><span style="font-size:small">This is a simple applictaion that uses smtp (simple mail transfer protocol) method to send email.</span></p>
<p><span style="font-size:small">Fisrt of all I included following library in my code</span></p>
<p><span style="font-size:small"><strong>using System.Net.Mail;</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">then we initalize object of MailMessage Class</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>MailMessage message = new MailMessage();</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">then we need to define <strong>SmtpClient</strong> , means we need
</span><br>
<span style="font-size:small">to define which mailing server or smtp Server we are going to use for</span><br>
<span style="font-size:small">sending email</span></p>
<p><span style="font-size:small">e.g. <em>outlook, yahoo</em>,etc.</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>SmtpClient SmtpServer = new SmtpClient(&quot;smtp-mail.outlook.com&quot;);</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">different smtp server have different dns</span></p>
<p><span style="font-size:small">for example for sending mail via outlook we use</span><br>
<span style="font-size:small"><em>smtp-mail.outlook.com</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em><br>
<br>
</em></span></p>
<p><span style="font-size:small">now we need to define &quot;From&quot; (<em>your email address</em>)</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>message.From = new MailAddress(&quot;<em>sender@outlook.com</em>&quot;);</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">then we define</span><br>
<span style="font-size:small">&quot;To&quot; recpitent email address</span></p>
<p><br>
<br>
</p>
<p><span style="font-size:small"><strong>message.To.Add(&quot;reciever@outlook.com&quot;);</strong></span><br>
&nbsp;<br>
<span style="font-size:small">if you want to mention subject use this following line of code</span></p>
<p><strong><span style="font-size:small">message.Subject = &quot;subject&quot;;</span></strong></p>
<p>&nbsp;</p>
<p><span style="font-size:small">to add message body</span></p>
<p><span style="font-size:small"><strong>message.Body = &quot;body&quot;;</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">now define port&nbsp;</span></p>
<p><span style="font-size:small">if we are using smtp to send email, default port value is 25 but normally we use port 587</span></p>
<p><span style="font-size:small"><strong>SmtpServer.Port = 587;</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">now add credentials (username and password)</span></p>
<p><span style="font-size:small"><strong>SmtpServer.Credentials = new System.Net.NetworkCredential(&quot;username&quot;, &quot;password&quot;);</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">now specify whether the smtp Client uses Secure Sockets Layer (SSL) to encrypt the connection.</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p><span style="font-size:small"><strong>SmtpServer.EnableSsl = true;</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">now final step to send mail we use simple send function of SmtpClient and put the message object inside
<span style="text-decoration:underline">Send</span> function as argument</span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong></span><br>
<span style="font-size:small"><strong>SmtpServer.Send(message);</strong></span></p>
<p><strong><br>
</strong></p>
<p>&nbsp;</p>
<p><strong><br>
</strong></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong></span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><strong><span style="font-size:small"><br>
</span></strong></p>
<p><span style="font-size:small"><br>
</span></p>
<p>&nbsp;</p>
<p><br>
<br>
</p>
<p><strong><br>
</strong></p>
