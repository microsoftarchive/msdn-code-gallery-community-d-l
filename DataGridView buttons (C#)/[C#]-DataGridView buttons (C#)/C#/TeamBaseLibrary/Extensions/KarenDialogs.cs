using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamBaseLibrary
{
    public static class KarenDialogs
    {
        public static bool Question(string Text)
        {
            return (MessageBox.Show(Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
    }
}
