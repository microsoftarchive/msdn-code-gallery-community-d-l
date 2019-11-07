using System.Data;
using System.Windows.Forms;

namespace Example_cs.Exensions
{
    static class Extensions
    {
        public static bool IsComboBoxCell(this DataGridViewCell sender)
        {
            bool Result = false;
            if (sender.EditType != null)
            {
                if (sender.EditType == typeof(DataGridViewComboBoxEditingControl))
                {
                    Result = true;
                }
            }
            return Result;
        }
        public static string ColorMessage(this BindingSource sender, int ColorId)
        {
            int index = sender.Find("Id", ColorId);
            if (index == -1)
            {
                // this means someone messed with the database table
                return "";
            }
            else
            {
                sender.Position = index;
                return ((DataRowView)sender.Current).Row.Field<string>("Text");
            }
        }
        public static int ColorIdFromPerson(this BindingSource sender)
        {
            return ((DataRowView)sender.Current).Row.Field<int>("ColorId");
        }
        public static int ColorId(this BindingSource sender)
        {
            return ((DataRowView)sender.Current).Row.Field<int>("ColorId");
        }
        public static int Identifier(this BindingSource sender)
        {
            return ((DataRowView)sender.Current).Row.Field<int>("Id");
        }
    }
}
