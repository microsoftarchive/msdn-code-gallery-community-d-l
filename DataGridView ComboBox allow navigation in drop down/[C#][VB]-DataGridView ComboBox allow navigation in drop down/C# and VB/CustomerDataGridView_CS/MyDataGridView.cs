using System.Windows.Forms;

namespace CustomerDataGridView_CS
{
    public class MyDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                if (this.EditingControl != null)
                {
                    if (this.EditingControl.GetType() ==
                    typeof(DataGridViewComboBoxEditingControl))
                    {
                        ComboBox control = this.EditingControl as ComboBox;
                        if (control.DropDownStyle !=
                        ComboBoxStyle.DropDownList)
                        {
                            switch (e.KeyData)
                            {
                                case Keys.Left:
                                    if (control.SelectionStart > 0)
                                    {
                                        control.SelectionStart--;
                                        return true;
                                    }
                                    break;

                                case Keys.Right:
                                    if (control.SelectionStart <
                                    control.Text.Length)
                                    {
                                        control.SelectionStart++;
                                        return true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            return base.ProcessDataGridViewKey(e);
        }
    }
}