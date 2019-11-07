namespace EyeOpen.ViewModel.Test
{
	using System;
	using System.ComponentModel;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	public class ViewModelTest
	{
		protected void CheckPropertyChangedRaised<T>(Action<T> action, string propertyName)
			where T : INotifyPropertyChanged, new()
		{
			var eventRaised = false;

			var viewModel = new T();

			viewModel
				.PropertyChanged +=
					(s, e) => CheckPropertyName(ref eventRaised, e, propertyName);

			action(viewModel);

			Assert.IsTrue(eventRaised, "Event not raised.");
		}

		protected void CheckPropertyName(ref bool eventRaised, PropertyChangedEventArgs e, string propertyName)
		{
			eventRaised = true;

			Assert.AreEqual(e.PropertyName, propertyName);
		}
	}
}