using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace EmailSendingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(txt_smtpserver.Text);
            message.From = new MailAddress(txt_from.Text);
            message.To.Add(txt_to.Text);
            message.Subject = txt_subject.Text;
            message.Body = richTextBox1.Text;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(txt_from.Text, txt_password.Text);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(message);
        }
    }
}
