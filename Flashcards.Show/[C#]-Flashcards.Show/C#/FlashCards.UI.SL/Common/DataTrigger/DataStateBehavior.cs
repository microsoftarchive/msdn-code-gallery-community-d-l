
using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;
using Interactivity.Data;
using Interactivity.Data.Helpers;
using System.Windows.Controls;
using System.Collections;

namespace Interactivity.Data {

    /// <summary>
    /// Code is based on the work by Pete Blois
    /// http://blois.us/blog/2009/04/datatrigger-bindings-on-non.html
    /// </summary>
    public class DataStateBehavior : Behavior<FrameworkElement>
    {

		public static readonly DependencyProperty BindingProperty = DependencyProperty.Register("Binding", typeof(Binding), typeof(DataStateBehavior), new PropertyMetadata(null, DataStateBehavior.HandleBindingChanged));
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(DataStateBehavior), new PropertyMetadata(null, DataStateBehavior.HandleValueChanged));
		public static readonly DependencyProperty TrueStateProperty = DependencyProperty.Register("TrueState", typeof(string), typeof(DataStateBehavior), new PropertyMetadata(null));
		public static readonly DependencyProperty FalseStateProperty = DependencyProperty.Register("FalseState", typeof(string), typeof(DataStateBehavior), new PropertyMetadata(null));

		private BindingListener listener;

		public DataStateBehavior() {
			this.listener = new BindingListener(this.HandleBindingValueChanged);
		}

		public Binding Binding {
			get { return (Binding)this.GetValue(DataStateBehavior.BindingProperty); }
			set { this.SetValue(DataStateBehavior.BindingProperty, value); }
		}

		public string Value {
			get { return (string)this.GetValue(DataStateBehavior.ValueProperty); }
			set { this.SetValue(DataStateBehavior.ValueProperty, value); }
		}

		public string FalseState {
			get { return (string)this.GetValue(DataStateBehavior.FalseStateProperty); }
			set { this.SetValue(DataStateBehavior.FalseStateProperty, value); }
		}

		public string TrueState {
			get { return (string)this.GetValue(DataStateBehavior.TrueStateProperty); }
			set { this.SetValue(DataStateBehavior.TrueStateProperty, value); }
		}

		private static void HandleBindingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
			((DataStateBehavior)sender).OnBindingChanged(e);
		}

		protected virtual void OnBindingChanged(DependencyPropertyChangedEventArgs e) {
			this.listener.Binding = (Binding)e.NewValue;
		}

		private static void HandleValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
			((DataStateBehavior)sender).OnValueChanged(e);
		}

		protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e) {
			this.CheckState();
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

			if (this.Value == null || this.listener.Value == null) {
				this.IsTrue = object.Equals(this.listener.Value, this.Value);
			}
			else {
				object convertedValue = ConverterHelper.ConvertToType(this.Value, this.listener.Value.GetType());
				this.IsTrue = object.Equals(this.listener.Value, ConverterHelper.ConvertToType(this.Value, this.listener.Value.GetType()));
			}
		}

		private bool? isTrue;
		private bool? IsTrue {
			get { return this.isTrue; }
			set {
				if (this.isTrue != value) {
					this.isTrue = value;

					if (this.IsTrue.HasValue) {
						Control targetControl = DataStateBehavior.FindTargetControl(this.AssociatedObject);
						if (targetControl == null)
							this.IsTrue = null;
						else if (this.IsTrue.Value)
							VisualStateManager.GoToState(targetControl, this.TrueState, true);
						else
							VisualStateManager.GoToState(targetControl, this.FalseState, true);
					}
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
}
