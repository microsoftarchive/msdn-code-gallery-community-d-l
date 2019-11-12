namespace EyeOpen.Mvvm
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq.Expressions;
	using EyeOpen.Extensions;

	public abstract class ViewModelBase<T> 
		: INotifyPropertyChanged
	{
		private readonly IDictionary<object, string> expressionDictionary = 
			new Dictionary<object, string>();

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected void SetProperty<TProperty>(ref TProperty field, TProperty value, Expression<Func<T, TProperty>> expression)
		{
			field = value;

			OnPropertyChanged(expression);
		}

		private void OnPropertyChanged<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			if (!expressionDictionary.ContainsKey(expression))
			{
				var propertyName =
					TypeExtensions<T>
						.GetProperty(expression);

				expressionDictionary.Add(expression, propertyName);
			}

			OnPropertyChanged(expressionDictionary[expression]);
		}
	}
}