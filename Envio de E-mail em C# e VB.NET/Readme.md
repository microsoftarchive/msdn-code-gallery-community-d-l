# Envio de E-mail em C# e VB.NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- VB.Net
## Topics
- C#
- ASP.NET
- Windows Forms
- Console Application
- Windows web services
## Updated
- 07/06/2013
## Description

<h1>Introdu&ccedil;&atilde;o</h1>
<p><em>Venho percebendo, que &nbsp;apesar de enviar e-mail's atrav&eacute;s do C# e VB.NET &nbsp;seja uma coisa simples, muitas pessoas ainda possuem certa dificuldade em realizar tal procedimento, por esse motivo estou disponibilizando para voc&ecirc;s, um
 exemplo bem simples de como enviar e-mail's utilizando o C# e oVB.NET.</em></p>
<p><em>Estou postando de uma maneira bem simples, mas o c&oacute;digo pode ser customizado para atividades mais complexas.</em></p>
<h1><span>Referencias Necess&aacute;rias</span></h1>
<p><em>Para que consiga enviar e-mails, &eacute; necess&aacute;rio incluir as referencias:</em></p>
<p><em>using System.Net.Mail;</em></p>
<p><em>using System.Net;</em></p>
<p>&nbsp;</p>
<p><em>Para VB.Net:</em></p>
<p><em><span style="color:blue">Imports&nbsp;</span><span>System.Net.Mail<br>
</span><span style="color:blue">Imports&nbsp;</span><span>System.Net</span><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Descri&ccedil;&atilde;o</span></p>
<p><em>Enviar e-mails &eacute; uma tarefa bem simples,para come&ccedil;ar, voc&ecirc; deve instanciar a classe MailMessage, pois ser&aacute; nela que voc&ecirc; atribuir&aacute; os dados do e-mail, como por exemplo:</em></p>
<p><em>From: Endere&ccedil;o que enviou o e-mail,</em></p>
<p><em>To: Endere&ccedil;o para que o e-mail ser&aacute; enviado,</em></p>
<p><em>Subject: Assunto do e-mail que est&aacute; sendo enviado,</em></p>
<p><em>Body: Corpo do e-mail,</em></p>
<p><em>Priority: Define a prioridade do e-mail,</em></p>
<p>IsBodyHtml: essa propriedade, define se seu e-mail est&aacute; sendo enviado em HTML ou n&atilde;o, caso voc&ecirc; defina como true, o .net ir&aacute; reidenrizar seu e-mail como HTML, ou seja, ele aceita tag's HTML, possibilitando que voc&ecirc; envie
 e-mail's bem elaborados, n&atilde;o apenas contendo textos.</p>
<p>&nbsp;</p>
<p>&Eacute; necess&aacute;rio tamb&eacute;m, que voc&ecirc; configure os dados de acesso do e-mail, como SMTP, usuario e senha, para isso &eacute; necess&aacute;rio instanciar a classe SmtpClient.</p>
<p>Quando voc&ecirc; instanciar a classe SmtpClient, &eacute; necess&aacute;rio informar o endere&ccedil;o do Servidor SMTP atrav&eacute;s de parametros, como por exemplo:</p>
<p>SmtpClient smtpClient = new SmtpClient(&quot;smtp.seudominio.com&quot;);</p>
<p>A classe SmtpClient, possui os seguintes parametros que s&atilde;o necess&aacute;rios para o envio de e-mail:</p>
<p>EnableSsl = Informa se &eacute; necess&aacute;rio uma conex&atilde;o segura para conectar no servidor SMTP informado</p>
<p>Credentials = &eacute; utilizado para informar as credenciais do e-mail de saida pelo smtp, sendo necess&aacute;rio realizar da seguinte maneira:&nbsp;</p>
<p>smtpClient.Credentials = new NetworkCredential(&quot;email@seudominio.com&quot;, &quot;senhadoemail&quot;);</p>
<p>e por utilto Send, onde voc&ecirc; deve passar a instancia da classe MailMessage que voc&ecirc; realizou anteriormente.</p>
<p>&nbsp;</p>
<p>Ap&oacute;s realizar tudo isso, e se os dados estiverem corretos, voc&ecirc; ter&aacute; enviado o e-mail.</p>
<p><em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using System.Net.Mail;
using System.Net;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(&quot;______________________________________________&quot;);
            Console.WriteLine(&quot;Exemplo de Envio de E-mail's MSDN&quot;);
            Console.WriteLine(&quot;______________________________________________&quot;);

            if (EnviarEmail(&quot;SendMail&quot;, &quot;email@outlook.com&quot;, &quot;E-mail de Teste para o MSDN&quot;))
                Console.WriteLine(&quot;E-mail enviado com sucesso&quot;);
            else
                Console.WriteLine(&quot;Erro ao enviar e-mail&quot;);

            Console.WriteLine(&quot;Pressione uma tecla para continuar&quot;);
            Console.ReadKey();

        }

        static bool EnviarEmail(string assunto, string destinatario, string mensagem)
        {
            try
            {
                

                MailMessage mailMessage = new MailMessage();
                //Endere&ccedil;o que ir&aacute; aparecer no e-mail do usu&aacute;rio
                mailMessage.From = new MailAddress(&quot;email@seudominio.com&quot;, &quot;Fale Conosco&quot;);
                //destinatarios do e-mail, para incluir mais de um basta separar por ponto e virgula 
                mailMessage.To.Add(destinatario);
                mailMessage.Subject = assunto;
                mailMessage.IsBodyHtml = true;
                //conteudo do corpo do e-mail
                mailMessage.Body = mensagem;
                mailMessage.Priority = MailPriority.High;
                //smtp do e-mail que ir&aacute; enviar
                SmtpClient smtpClient = new SmtpClient(&quot;smtp.seudominio.com&quot;);
                smtpClient.EnableSsl = false;
                //credenciais da conta que utilizar&aacute; para enviar o e-mail
                smtpClient.Credentials = new NetworkCredential(&quot;email@seudominio.com&quot;, &quot;senhadoemail&quot;);
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
</pre>
<pre class="hidden">Imports System.Net.Mail
Imports System.Net

Namespace SendMail
    
    Class Program
        
        Private Shared Sub Main(ByVal args() As String)
            Console.WriteLine(&quot;______________________________________________&quot;)
            Console.WriteLine(&quot;Exemplo de Envio de E-mail's MSDN&quot;)
            Console.WriteLine(&quot;______________________________________________&quot;)
            If EnviarEmail(&quot;SendMail&quot;, &quot;email@outlook.com&quot;, &quot;E-mail de Teste para o MSDN&quot;) Then
                Console.WriteLine(&quot;E-mail enviado com sucesso&quot;)
            Else
                Console.WriteLine(&quot;Erro ao enviar e-mail&quot;)
            End If
            Console.WriteLine(&quot;Pressione uma tecla para continuar&quot;)
            Console.ReadKey
        End Sub
        
        Private Shared Function EnviarEmail(ByVal assunto As String, ByVal destinatario As String, ByVal mensagem As String) As Boolean
            Try 
                Dim mailMessage As MailMessage = New MailMessage
                'Endere&ccedil;o que ir&aacute; aparecer no e-mail do usu&aacute;rio
                mailMessage.From = New MailAddress(&quot;email@seudominio.com&quot;, &quot;Fale Conosco&quot;)
                'destinatarios do e-mail, para incluir mais de um basta separar por ponto e virgula 
                mailMessage.To.Add(destinatario)
                mailMessage.Subject = assunto
                mailMessage.IsBodyHtml = true
                'conteudo do corpo do e-mail
                mailMessage.Body = mensagem
                mailMessage.Priority = MailPriority.High
                'smtp do e-mail que ir&aacute; enviar
                Dim smtpClient As SmtpClient = New SmtpClient(&quot;smtp.seudominio.com&quot;)
                smtpClient.EnableSsl = false
                'credenciais da conta que utiliza para enviar o e-mail
                smtpClient.Credentials = New NetworkCredential(&quot;email@seudominio.com&quot;, &quot;senhadoemail&quot;)
                smtpClient.Send(mailMessage)
                Return true
            Catch  As System.Exception
                Return false
            End Try
        End Function
    End Class
End Namespace</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Net.Mail;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SendMail&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;______________________________________________&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Exemplo&nbsp;de&nbsp;Envio&nbsp;de&nbsp;E-mail's&nbsp;MSDN&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;______________________________________________&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(EnviarEmail(<span class="cs__string">&quot;SendMail&quot;</span>,&nbsp;<span class="cs__string">&quot;email@outlook.com&quot;</span>,&nbsp;<span class="cs__string">&quot;E-mail&nbsp;de&nbsp;Teste&nbsp;para&nbsp;o&nbsp;MSDN&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;E-mail&nbsp;enviado&nbsp;com&nbsp;sucesso&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Erro&nbsp;ao&nbsp;enviar&nbsp;e-mail&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Pressione&nbsp;uma&nbsp;tecla&nbsp;para&nbsp;continuar&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;EnviarEmail(<span class="cs__keyword">string</span>&nbsp;assunto,&nbsp;<span class="cs__keyword">string</span>&nbsp;destinatario,&nbsp;<span class="cs__keyword">string</span>&nbsp;mensagem)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MailMessage&nbsp;mailMessage&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Endere&ccedil;o&nbsp;que&nbsp;ir&aacute;&nbsp;aparecer&nbsp;no&nbsp;e-mail&nbsp;do&nbsp;usu&aacute;rio</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailMessage.From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;email@seudominio.com&quot;</span>,&nbsp;<span class="cs__string">&quot;Fale&nbsp;Conosco&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//destinatarios&nbsp;do&nbsp;e-mail,&nbsp;para&nbsp;incluir&nbsp;mais&nbsp;de&nbsp;um&nbsp;basta&nbsp;separar&nbsp;por&nbsp;ponto&nbsp;e&nbsp;virgula&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailMessage.To.Add(destinatario);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailMessage.Subject&nbsp;=&nbsp;assunto;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailMessage.IsBodyHtml&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//conteudo&nbsp;do&nbsp;corpo&nbsp;do&nbsp;e-mail</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailMessage.Body&nbsp;=&nbsp;mensagem;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailMessage.Priority&nbsp;=&nbsp;MailPriority.High;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//smtp&nbsp;do&nbsp;e-mail&nbsp;que&nbsp;ir&aacute;&nbsp;enviar</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SmtpClient&nbsp;smtpClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SmtpClient(<span class="cs__string">&quot;smtp.seudominio.com&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtpClient.EnableSsl&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//credenciais&nbsp;da&nbsp;conta&nbsp;que&nbsp;utilizar&aacute;&nbsp;para&nbsp;enviar&nbsp;o&nbsp;e-mail</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtpClient.Credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NetworkCredential(<span class="cs__string">&quot;email@seudominio.com&quot;</span>,&nbsp;<span class="cs__string">&quot;senhadoemail&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtpClient.Send(mailMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>SendMail #1 - c&oacute;digo fonte para envio de e-mail's em C#</em> </li></ul>
<h1>Mais Informa&ccedil;&otilde;es</h1>
<p><em>Para mais informa&ccedil;&otilde;es sobre como enviar e-mails acesse:</em></p>
<p><em><a title="MailMessage" href="http://msdn.microsoft.com/pt-br/library/system.net.mail.mailmessage.aspx">http://msdn.microsoft.com/pt-br/library/system.net.mail.mailmessage.aspx</a></em></p>
<p><em><a href="http://msdn.microsoft.com/pt-br/library/system.net.mail.smtpclient.aspx">http://msdn.microsoft.com/pt-br/library/system.net.mail.smtpclient.aspx</a><br>
</em></p>
