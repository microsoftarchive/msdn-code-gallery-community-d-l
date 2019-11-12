using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           
        }
        //Enter code here for your version of username and userpassword
        Login login = new Login("admin", "1234");
        

        private void button1_Click(object sender, EventArgs e)
        {
            //define local variables from the user inputs
            string user = nametxtbox.Text;
            string pass = pwdtxtbox.Text;
            //check if eligible to be logged in
            if(login.IsLoggedIn(user,pass))
            {
                MessageBox.Show("You are logged in successfully");
            }
            else
            {
                //show default login error message
                MessageBox.Show("Login Error!");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //enter your code for forget password case
            MessageBox.Show("Under development");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Enter your code for registration form of your choice
            MessageBox.Show("Under development");
        }
    }
}
