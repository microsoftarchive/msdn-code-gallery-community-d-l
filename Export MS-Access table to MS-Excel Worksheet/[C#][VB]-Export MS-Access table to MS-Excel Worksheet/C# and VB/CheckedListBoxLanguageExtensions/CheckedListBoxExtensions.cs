using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
///  Written for my CheckListBox code sample
/// </summary>
public static class CheckedListBoxExtensions
{
    public static List<CheckedItemList> IndexList(this CheckedListBox sender)
    {
        return 
            (
                from T in sender.Items.Cast<string>()
                    .Select(
                    (d, i) => 
                        new CheckedItemList 
                        { 
                            Text = d, 
                            Index = i 
                        }
                    )
                    .Where((x) => sender.GetItemChecked(x.Index)) 
                select T
            ).ToList();
    }
    public static List<CheckedItemList> IndexList(this CheckedListBox sender, bool checkStatus)
    {
        return
            (
                from item in sender.Items.Cast<string>()
                    .Select(
                    (text, position) =>
                        new CheckedItemList
                        {
                            Text = text,
                            Index = position
                        }
                    )
                    .Where((item) => sender.GetItemChecked(item.Index) == checkStatus)
                select item
            ).ToList();
    }
    /// <summary>
    /// Find item, set check state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="Text">text to locate case insensitive</param>
    /// <param name="Checked">set check state to</param>
    /// <remarks></remarks>
    public static void FindItemAndSetChecked(this CheckedListBox sender, string Text, bool Checked)
    {
        // Result is declared with var as it's a anonymous type
        var Result =
            (
                from @this in sender.Items.Cast<string>().Select(
                    (item, index) => new
                        {
                            Item = item,
                            Index = index
                        }
                    )
                where @this.Item.ToLower() == Text.ToLower()
                select @this
            ).FirstOrDefault();

        if (Result != null)
        {
            sender.SetItemChecked(Result.Index, Checked);
        }
    }
    public static string[] CheckedItems(this CheckedListBox sender)
    {
        return sender.CheckedItemsList().ToArray();
    }
    public static string SelectColumns(this CheckedListBox sender)
    {
        return string.Join(",", sender.CheckedItemsList().ToArray());
    }
    public static List<string> CheckedItemsList(this CheckedListBox sender)
	{
        var Result = from T in sender.Items.OfType<string>().Where(
                         (item, index) => 
                         { 
                             return sender.GetItemChecked(index); 
                         }
                     )
                     select T;

        return Result.ToList<string>();
	}
}