using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace DownloadFileSharePointOnline
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private SecureString _password;
        
        public string SiteUrl
        {
            get { return textBox1.Text.Trim(); }
        }

        string UserName
        {
            get { return textBox2.Text.Trim(); }
        }
        SecureString Password
        {
            get {

                if (_password == null)
                {
                    _password = GetPasswordFromConsoleInput(textBox3.Text.Trim());
                }

                return _password;
            }
        }

        string FileUrl
        {
            get { return textBox4.Text.Trim(); }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Stream filestrem = GetFile();
                string fileName = System.IO.Path.GetFileName(FileUrl);
                string filepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), fileName);

                FileStream fileStream = System.IO.File.Create(filepath, (int)filestrem.Length);
                // Initialize the bytes array with the stream length and then fill it with data
                byte[] bytesInStream = new byte[filestrem.Length];
                filestrem.Read(bytesInStream, 0, bytesInStream.Length);
                // Use write method to write to the file specified above
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                MessageBox.Show("file downloaded successfully at" + Environment.NewLine + filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured" + ex.Message);
            }
        }

        /// <summary>
        /// Get file information from Sharepoint.
        /// </summary>
        /// <param name="documentUrl">Document Url.</param>
        /// <returns>Returns file information object.</returns>
        public Stream GetFile()
        {
            using (ClientContext clientContext = GetContextObject())
            {

                Web web = clientContext.Web;
                clientContext.Load(web, website => website.ServerRelativeUrl);
                clientContext.ExecuteQuery();
                Regex regex = new Regex(SiteUrl, RegexOptions.IgnoreCase);
                string strSiteRelavtiveURL = regex.Replace(FileUrl, string.Empty);
                string strServerRelativeURL = CombineUrl(web.ServerRelativeUrl, strSiteRelavtiveURL);

                Microsoft.SharePoint.Client.File oFile = web.GetFileByServerRelativeUrl(strServerRelativeURL);
                clientContext.Load(oFile);
                ClientResult<Stream> stream = oFile.OpenBinaryStream();
                clientContext.ExecuteQuery();
                return this.ReadFully(stream.Value);
            }
        }

        private ClientContext GetContextObject()
        {
            ClientContext context = new ClientContext(SiteUrl);
            context.Credentials = new SharePointOnlineCredentials(UserName, Password);
            return context;
        }

        private static SecureString GetPasswordFromConsoleInput(string password)
        {
            //Get the user's password as a SecureString
            SecureString securePassword = new SecureString();
            char[] arrPassword = password.ToCharArray();
            foreach (char c in arrPassword)
            {
                securePassword.AppendChar(c);
            }

            return securePassword;
        }

        public  string CombineUrl(string path1, string path2)
        {
            
            return path1.TrimEnd('/') + '/' + path2.TrimStart('/');
        }

        private Stream ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return new MemoryStream(ms.ToArray()); ;
            }
        }
    }
}
