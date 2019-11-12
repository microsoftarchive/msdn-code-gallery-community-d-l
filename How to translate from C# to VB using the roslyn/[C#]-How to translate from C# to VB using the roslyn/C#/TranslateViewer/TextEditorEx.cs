using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Gekka.Roslyn.TranslateViewer
{
	class TextEditorEx : ICSharpCode.AvalonEdit.TextEditor
	{
		public static Selection GetSelection(DependencyObject obj)
		{
			return (Selection)obj.GetValue(SelectionProperty);
		}

		public static void SetSelection(DependencyObject obj, Selection value)
		{
			obj.SetValue(SelectionProperty, value);
		}

		public static readonly DependencyProperty SelectionProperty =
			DependencyProperty.RegisterAttached
			("Selection"
			, typeof(Selection)
			, typeof(TextEditorEx)
			, new FrameworkPropertyMetadata
				(default(Selection), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
				 , new PropertyChangedCallback(OnSelectionPropertyChanged)));

		private static void OnSelectionPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
		{
			var target = dpo as ICSharpCode.AvalonEdit.TextEditor;
			if (target != null)
			{
				Selection newValue = (Selection)e.NewValue;
				Selection oldValue = (Selection)e.OldValue;
				if (!newValue.Equals(oldValue))
				{
					if (target.SelectionStart != newValue.Start) target.SelectionStart = newValue.Start;
					if (target.SelectionLength != newValue.Length) target.SelectionLength = newValue.Length;
					var pos=target.TextArea.Selection.StartPosition;
					target.ScrollTo(pos.Line, pos.Column);
				}
			}
		}

	}

	public class Selection
	{
		public Selection(int start, int length)
		{
			Start = start;
			Length = length;
			End = start + length;
		}
		public readonly int Start;
		public readonly int Length;
		public readonly int End;
		public override bool Equals(object obj)
		{
			return obj is Selection ? this.Equals((Selection)obj) : false;
		}
		public bool Equals(Selection other)
		{
			return other != null && this.Start == other.Start && this.Length == other.Length;
		}
		public override int GetHashCode()
		{
			return this.Start.GetHashCode() ^ this.Length.GetHashCode();
		}
		public static bool operator ==(Selection a,Selection b)
		{
			if (object.ReferenceEquals(a, null))
			{
				return object.ReferenceEquals(b, null);
			}
			return a.Equals(b);
		}
		public static bool operator !=(Selection a, Selection b)
		{
			return !(a == b);
		}
	}
}
