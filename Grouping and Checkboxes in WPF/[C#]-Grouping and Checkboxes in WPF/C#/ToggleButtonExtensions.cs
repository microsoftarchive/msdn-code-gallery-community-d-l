using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace GroupingToggleButtons
{
	public class ToggleButtonExtensions : DependencyObject
	{
		public static Dictionary<ToggleButton, String> ElementToGroupNames = new Dictionary<ToggleButton, String>();

		public static readonly DependencyProperty GroupNameProperty =
			DependencyProperty.RegisterAttached("GroupName",
			                                    typeof(String),
			                                    typeof(ToggleButtonExtensions),
			                                    new PropertyMetadata(String.Empty, OnGroupNameChanged));

		public static void SetGroupName(ToggleButton element, String value)
		{
			element.SetValue(GroupNameProperty, value);
		}

		public static String GetGroupName(ToggleButton element)
		{
			return element.GetValue(GroupNameProperty).ToString();
		}

		private static void OnGroupNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			//Add an entry to the group name collection
			var toggleButton = d as ToggleButton;
			if (toggleButton != null)
			{
				String newGroupName = e.NewValue.ToString();
				String oldGroupName = e.OldValue.ToString();
				if (String.IsNullOrEmpty(newGroupName))
				{
					//Removing the toggle button from grouping
					RemoveCheckboxFromGrouping(toggleButton);
				}
				else
				{
					//Switching to a new group
					if (newGroupName != oldGroupName)
					{
						if (!String.IsNullOrEmpty(oldGroupName))
						{
							//Remove the old group mapping
							RemoveCheckboxFromGrouping(toggleButton);
						}
						ElementToGroupNames.Add(toggleButton, e.NewValue.ToString());
						toggleButton.Checked += ToggleButtonChecked;
					}
				}
			}
		}

		private static void RemoveCheckboxFromGrouping(ToggleButton checkBox)
		{
			ElementToGroupNames.Remove(checkBox);
			checkBox.Checked -= ToggleButtonChecked;
		}


		static void ToggleButtonChecked(object sender, RoutedEventArgs e)
		{
			var toggleButton = e.OriginalSource as ToggleButton;
			foreach(var item in ElementToGroupNames)
			{
				if (item.Key != toggleButton && item.Value == GetGroupName(toggleButton))
				{
					item.Key.IsChecked = false;
				}
			}
		}

	}
}