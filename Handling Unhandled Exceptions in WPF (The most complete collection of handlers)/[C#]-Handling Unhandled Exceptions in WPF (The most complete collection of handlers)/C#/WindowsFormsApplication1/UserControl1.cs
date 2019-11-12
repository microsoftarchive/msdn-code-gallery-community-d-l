using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("Unhandled WinForm Exception!!", new ArgumentOutOfRangeException());
        }
    }
}
