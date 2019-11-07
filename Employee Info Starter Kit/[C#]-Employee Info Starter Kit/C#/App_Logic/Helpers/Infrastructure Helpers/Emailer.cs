/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

namespace Eisk.Helpers
{
    using System.IO;
    using System.Net.Mail;
    using System.Text;
    /// <summary>
    /// Utility class for sending email
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class Emailer
    {
        private Emailer()
        {
        }

        public static void SendMail(string subject, string to, 
            string from = null, string body = null, Stream attachment = null,
            int port = 25, string host = "localhost", bool isBodyHtml = true)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(from);
            mailMsg.To.Add(to);
            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = isBodyHtml;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.Body = body;
            mailMsg.Priority = MailPriority.Normal;

            //Message attahment
            if (attachment != null)
                mailMsg.Attachments.Add(new Attachment(attachment, "my.text"));

            // Smtp configuration
            SmtpClient client = new SmtpClient();
            //client.Credentials = new NetworkCredential("test", "test");
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = port; //use 465 or 587 for gmail           
            client.Host = host;//for gmail "smtp.gmail.com";
            client.EnableSsl = false;

            MailMessage message = mailMsg;
            
            client.Send(message);
            
        }

    }
}