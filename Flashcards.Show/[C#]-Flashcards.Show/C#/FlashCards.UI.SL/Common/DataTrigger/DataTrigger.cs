using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;
using Interactivity.Data.Helpers;

namespace Interactivity.Data {

    /// <summary>
    /// Code is based on the work by Pete Blois
    /// http://blois.us/blog/2009/04/datatrigger-bindings-on-non.html
    /// </summary>
    public class DataTrigger : TriggerBase<FrameworkElement>
    {

		private BindingListener listener;
		private object bindingValue;

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(DataTrigger), new PropertyMetadata(null, DataTrigger.HandleValueChanged));
		public static readonly DependencyProperty BindingProperty = DependencyProperty.Register("Binding", typeof(Binding), typeof(DataTrigger), new PropertyMetadata(null, DataTrigger.HandleBindingChanged));
		public static readonly DependencyProperty TriggerOnRisingProperty = DependencyProperty.Register("TriggerOnRising", typeof(bool), typeof(DataTrigger), new PropertyMetadata(true));


		public DataTrigger() {
			this.listener = new BindingListener(this.HandleBindingValueChanged);
		}

		public bool TriggerOnRising {
			get { return (bool)this.GetValue(DataTrigger.TriggerOnRisingProperty); }
			set { this.SetValue(DataTrigger.TriggerOnRisingProperty, value); }
		}

		public string Value {
			get { return (string)this.GetValue(DataTrigger.ValueProperty); }
			set { this.SetValue(DataTrigger.ValueProperty, value); }
		}

		public Binding Binding {
			get { return (Binding)this.GetValue(DataTrigger.BindingProperty); }
			set { this.SetValue(DataTrigger.BindingProperty, value); }
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
			this.bindingValue = e.EventArgs.NewValue;

			this.CheckState();
		}

		private static void HandleBindingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
			((DataTrigger)sender).OnBindingChanged(e);
		}

		protected virtual void OnBindingChanged(DependencyPropertyChangedEventArgs e) {
			this.listener.Binding = this.Binding;
		}


		private static void HandleValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
			((DataTrigger)sender).OnValueChanged(e);
		}

		protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e) {
			this.CheckState();
		}

		private void CheckState() {

			if (this.Value == null || this.bindingValue == null) {
				this.IsTrue = object.Equals(this.bindingValue, this.Value);
			}
			else {
				object convertedValue = ConverterHelper.ConvertToType(this.Value, this.bindingValue.GetType());
				this.IsTrue = object.Equals(this.bindingValue, ConverterHelper.ConvertToType(this.Value, this.bindingValue.GetType()));
			}
		}

		private bool isTrue;
		private bool IsTrue {
			get { return this.isTrue; }
			set {
				if (this.isTrue != value) {
					this.isTrue = value;

					if (this.IsTrue == this.TriggerOnRising)
						this.InvokeActions(this.bindingValue);
				}
			}
		}
	}
}
