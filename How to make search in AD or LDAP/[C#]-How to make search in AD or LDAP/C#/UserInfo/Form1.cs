using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using UserInfo.DomainUsers;
using UserInfo.Properties;

namespace UserInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            var sb = new StringBuilder();

            if (e.KeyCode == Keys.Return && !String.IsNullOrWhiteSpace(txtUserName.Text))
                GetUser(sb);

            else if (e.KeyCode == Keys.Return && String.IsNullOrWhiteSpace(txtUserName.Text))
                MessageBox.Show(Resources.Form1_txtUserName_KeyDown_Entre_avec_un_nom_de_utilizator, Resources.Form1_txtUserName_KeyDown_Information, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
                return;
            }

            textBox1.Text = sb.ToString();
        }

        private void GetUser(StringBuilder sb)
        {
            var userInfo = new UserInformation();
            List<string> userInformation;

            userInfo.GetUserInfo(out userInformation, txtUserName.Text);
            foreach (var info in userInformation)
            {
                sb.AppendLine(info);
                sb.AppendLine();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
