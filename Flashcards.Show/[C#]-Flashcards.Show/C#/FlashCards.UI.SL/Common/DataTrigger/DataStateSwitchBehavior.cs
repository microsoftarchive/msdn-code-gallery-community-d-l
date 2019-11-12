using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;
using Interactivity.Data;
using Interactivity.Data.Helpers;
using System.Windows.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Markup;

namespace Interactivity.Data {

    /// <summary>
    /// Code is based on the work by Pete Blois
    /// http://blois.us/blog/2009/04/datatrigger-bindings-on-non.html
    /// </summary>
    [ContentProperty("States")]
	public class DataStateSwitchBehavior : Behavior<FrameworkElement> {

		public static readonly DependencyProperty BindingProperty = DependencyProperty.Register("Binding", typeof(Binding), typeof(DataStateSwitchBehavior), new PropertyMetadata(null, DataStateSwitchBehavior.HandleBindingChanged));
		public static readonly DependencyProperty StatesProperty = DependencyProperty.Register("States", typeof(List<DataStateSwitchCase>), typeof(DataStateSwitchBehavior), new PropertyMetadata(null));

		private BindingListener listener;

		public DataStateSwitchBehavior() {
			this.listener = new BindingListener(this.HandleBindingValueChanged);
			this.States = new List<DataStateSwitchCase>();
		}

		public Binding Binding {
			get { return (Binding)this.GetValue(DataStateSwitchBehavior.BindingProperty); }
			set { this.SetValue(DataStateSwitchBehavior.BindingProperty, value); }
		}

		public List<DataStateSwitchCase> States {
			get { return (List<DataStateSwitchCase>)this.GetValue(DataStateSwitchBehavior.StatesProperty); }
			set { this.SetValue(DataStateSwitchBehavior.StatesProperty, value); }
		}

		private static void HandleBindingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
			((DataStateSwitchBehavior)sender).OnBindingChanged(e);
		}

		protected virtual void OnBindingChanged(DependencyPropertyChangedEventArgs e) {
			this.listener.Binding = (Binding)e.NewValue;
		}

		protected override void OnAttached() {
			base.OnAttached();

			this.listener.Element = this.AssociatedObject;
		}

		protected override void OnDetaching() {
			base.OnDetaching();

			this.listener.Element = null;
		}

		private void HandleBindingValueChanged(object sender, BindingChangedEventArgs e) {
			this.CheckState();
		}

		private void CheckState() {
			foreach (DataStateSwitchCase switchCase in this.States) {
				if (switchCase.IsValid(this.listener.Value)) {
					Control targetControl = DataStateSwitchBehavior.FindTargetControl(this.AssociatedObject);
					if (targetControl != null) {
                        bool ret = VisualStateManager.GoToState(targetControl, switchCase.State, true);
					}
					break;
				}
			}
		}

		private static Control FindTargetControl(FrameworkElement element) {
			FrameworkElement parent = element;
			bool foundVSM = false;

			while (parent != null) {
				if (!foundVSM) {
					IList vsgs = VisualStateManager.GetVisualStateGroups(parent);
					if (vsgs != null && vsgs.Count > 0)
						foundVSM = true;
				}

				if (foundVSM) {
					Control parentControl = parent as Control;
					if (parentControl != null)
						return parentControl;
				}
				parent = parent.Parent as FrameworkElement;
			}

			return null;
		}
	}

	public class DataStateSwitchCase {
		public string Value { get; set; }
		public string State { get; set; }

		public bool IsValid(object targetValue) {
			if (targetValue == null || this.Value == null)
				return object.Equals(targetValue, this.Value);

			object convertedValue = ConverterHelper.ConvertToType(this.Value, targetValue.GetType());
			return object.Equals(targetValue, ConverterHelper.ConvertToType(this.Value, targetValue.GetType()));
		}
	}
}