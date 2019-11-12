using System.IO;
using System.Windows;

namespace FileShortcutHelper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool _IsClean;

		public MainWindow()
		{
			InitializeComponent();
			_IsClean = true;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			string filePath = FilePath.Text;

			if(File.Exists(filePath))
			{
				_IsClean = false;

				if(ShortcutHelper.IsShortcut(filePath))
				{
					IsShortcut.Text = "True";
					ResolvedFilePath.Text = ShortcutHelper.ResolveShortcut(filePath);
				}
				else
				{
					IsShortcut.Text = "False";
				}
			}
			else
			{
				MessageBox.Show("File path does not exists");
			}
		}

		private void FilePath_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			if(!_IsClean)
			{
				IsShortcut.Text = string.Empty;
				ResolvedFilePath.Text = string.Empty;
				_IsClean = true;
			}
		}
	}
}
