using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace Interactivity.Data.Helpers {

    /// <summary>
    /// Code is based on the work by Pete Blois
    /// http://blois.us/blog/2009/04/datatrigger-bindings-on-non.html
    /// </summary>
	public class BindingListener {

		private static List<DependencyPropertyListener> freeListeners = new List<DependencyPropertyListener>();

		public delegate void ChangedHandler(object sender, BindingChangedEventArgs e);

		private DependencyPropertyListener listener;
		private ChangedHandler changedHandler;
		private Binding binding;
		private FrameworkElement target;
		private object value;

		public BindingListener(ChangedHandler changedHandler) {
			this.changedHandler = changedHandler;
		}

		public Binding Binding {
			get { return this.binding; }
			set {
				this.binding = value;
				this.Attach();
			}
		}

		public FrameworkElement Element {
			get { return this.target; }
			set {
				this.target = value;
				this.Attach();
			}
		}

		public object Value {
			get { return this.value; }
		}


		private void Attach() {
			this.Detach();

			if (this.target != null && this.binding != null) {
				this.listener = this.GetListener();
				this.listener.Attach(target, binding);
			}
		}

		private void Detach() {
			if (this.listener != null)
				this.ReturnListener();
		}

		private DependencyPropertyListener GetListener() {
			DependencyPropertyListener listener;

			if (BindingListener.freeListeners.Count != 0) {
				listener = BindingListener.freeListeners[BindingListener.freeListeners.Count - 1];
				BindingListener.freeListeners.RemoveAt(BindingListener.freeListeners.Count - 1);

				return listener;
			}
			else
				listener = new DependencyPropertyListener();

			listener.Changed += this.HandleValueChanged;

			return listener;
		}

		private void ReturnListener() {
			this.listener.Changed -= this.HandleValueChanged;

			BindingListener.freeListeners.Add(this.listener);

			this.listener = null;
		}

		private void HandleValueChanged(object sender, BindingChangedEventArgs e) {
			this.value = e.EventArgs.NewValue;

			this.changedHandler(this, e);
		}
	}

	public class DependencyPropertyListener {

		private DependencyProperty property;
		public event EventHandler<BindingChangedEventArgs> Changed;

		private static int index = 0;
		private FrameworkElement target;

		public DependencyPropertyListener() {
			this.property = DependencyProperty.RegisterAttached("DependencyPropertyListener" + index++, typeof(object), typeof(DependencyPropertyListener), new PropertyMetadata(null, this.HandleValueChanged));
		}

		private void HandleValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {

			if (this.Changed != null)
				this.Changed(this, new BindingChangedEventArgs(e));
		}

		public void Attach(FrameworkElement element, Binding binding) {
			if (this.target != null)
				throw new Exception("Cannot attach an already attached listener");

			this.target = element;

			this.target.SetBinding(this.property, binding);
		}

		public void Detach() {
			this.target.ClearValue(this.property);
			this.target = null;
		}
	}

	public class BindingChangedEventArgs : EventArgs {
		public BindingChangedEventArgs(DependencyPropertyChangedEventArgs e) {
			this.EventArgs = e;
		}

		public DependencyPropertyChangedEventArgs EventArgs { get; private set; }
	}
}
