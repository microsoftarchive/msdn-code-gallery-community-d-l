using System.Collections.Generic;
using System.Windows.Forms;

namespace CreateDynamicTextBoxes_CS
{
    public static class LanguageExtensions
    {
        public static List<TextBox> TextBoxList(this Control sender)
        {
            List<TextBox> tbList = new List<TextBox>();

            Control ctrl = sender.GetNextControl(sender, true);

            while (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "Hello";
                    tbList.Add((TextBox)ctrl);
                }
                ctrl = sender.GetNextControl(ctrl, true);
            }

            return tbList;
        }
    }
}