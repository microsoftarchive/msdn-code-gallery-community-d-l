using ListViewDemo.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xamformsdemo.iOS.CustomControls;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace xamformsdemo.iOS.CustomControls
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as CustomViewCell;
            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = view.SelectedItemBackgroundColor.ToUIColor(),
            };

            return cell;
        }
    }
}