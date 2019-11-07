using System.Windows.Forms;

public static class DataGridViewExtensions
{
    /// <summary>
    /// Resize all columns to see longest item in each column
    /// </summary>
    /// <param name="sender"></param>
    public static void ExpandColumns(this DataGridView sender)
    {
        foreach (DataGridViewColumn col in sender.Columns)
        {
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}