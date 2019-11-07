using System;
using System.Reflection;
using System.Windows;

namespace FlashCards.UI.Common
{
    /// <summary>
    /// Code is based on the work by Morten Nielsen
    /// http://www.sharpgis.net/post/2009/05/04/Using-surrogate-binders-in-Silverlight.aspx
    /// </summary>
	public static class SurrogateBind
	{
		public static readonly DependencyProperty TargetProperty =
			DependencyProperty.RegisterAttached("Target", typeof(string), typeof(SurrogateBind), null);

		public static string GetTarget(DependencyObject d)
		{
			return (string)d.GetValue(TargetProperty);
		}

		public static void SetTarget(DependencyObject d, string value)
		{
			d.SetValue(TargetProperty, value);
		}

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.RegisterAttached("Value", typeof(object), typeof(SurrogateBind),
			new PropertyMetadata(OnValueChanged));

		public static object GetValue(DependencyObject d)
		{
			return (object)d.GetValue(ValueProperty);
		}

		public static void SetValue(DependencyObject d, object value)
		{
			d.SetValue(ValueProperty, value);
		}

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			string path = GetTarget(d);
			if (String.IsNullOrEmpty(path)) return;
			string[] pathElements = path.Split(new char[] { '.' });
			PropertyInfo propertyInfo = null;
			object o = d;
			for (int i = 0; i < pathElements.Length; i++)
			{
				if (o == null) break;
				string s = pathElements[i];
				int begin = s.LastIndexOf('[');
				bool isIndexed = s.EndsWith("]") && begin >= 0;
				propertyInfo = o.GetType().GetProperty(isIndexed ? s.Substring(0, s.LastIndexOf('[')) : s);
				if (propertyInfo == null) break;
				if (i < pathElements.Length - 1)
				{
					object[] index = null;
					if (isIndexed)
					{
						index = new object[] { int.Parse(s.Substring(begin + 1, s.LastIndexOf(']') - begin - 1)) };
					}
					o = propertyInfo.GetValue(o, index);
				}
			}
			if (propertyInfo != null && propertyInfo.PropertyType == e.NewValue.GetType())
			{
				propertyInfo.SetValue(o, e.NewValue, null);
			}
		}
	}
}