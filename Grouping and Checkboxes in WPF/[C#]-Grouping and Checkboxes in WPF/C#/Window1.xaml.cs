using System;
using System.Windows;

using GroupingToggleButtons;

namespace GroupingCheckboxes
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ToggleButtonExtensions.SetGroupName(Group2Box1, "NewGroupName");
			ToggleButtonExtensions.SetGroupName(Group2Box2, "NewGroupName");
		}

		private void UnGroupButton_Click(object sender, RoutedEventArgs e)
		{
			ToggleButtonExtensions.SetGroupName(Group2Box1, String.Empty);
			ToggleButtonExtensions.SetGroupName(Group2Box2, String.Empty);
		}
	}
}