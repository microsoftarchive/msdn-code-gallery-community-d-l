namespace HRApp
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    ///     Provides extension methods for dealing with <see cref="Binding"/> objects
    /// </summary>
    public static class DataBindingExtensions
    {
        /// <summary>
        ///     Creates a new <see cref="Binding"/> whose <see cref="Binding.Source"/>
        ///     is the object in which this method is being called, whose <see cref="Binding.Path"/> 
        ///     property is initialized from <see cref="propertyPath"/>
        /// </summary>
        public static Binding CreateOneWayBinding(this INotifyPropertyChanged bindingSource, string propertyPath)
        {
            return bindingSource.CreateOneWayBinding(propertyPath, null);
        }

        /// <summary>
        ///     Creates a new <see cref="Binding"/> whose <see cref="Binding.Source"/>
        ///     is the object in which this method is being called, whose <see cref="Binding.Path"/> 
        ///     property is initialized from <see cref="propertyPath"/> and whose <see cref="Binding.Converter"/>
        ///     property is a one-way <see cref="LambdaValueConverter"/> object whose converter
        ///     is given by <paramref name="converter"/>
        /// </summary>
        public static Binding CreateOneWayBinding(this INotifyPropertyChanged bindingSource, string propertyPath, IValueConverter converter)
        {
            Binding binding = new Binding();

            binding.Source = bindingSource;
            binding.Path = new PropertyPath(propertyPath);
            binding.Converter = converter;

            return binding;
        }

        /// <summary>
        ///     Creates a new <see cref="Binding"/> object by copying all properties
        ///     from another <see cref="Binding"/> object
        /// </summary>
        /// <param name="binding"><see cref="Binding"/> from which property values will be copied</param>
        public static Binding CreateCopy(this Binding binding)
        {
            if (binding == null)
            {
                throw new ArgumentNullException("binding");
            }

            Binding newBinding = new Binding()
            {
                BindsDirectlyToSource = binding.BindsDirectlyToSource,
                Converter = binding.Converter,
                ConverterParameter = binding.ConverterParameter,
                ConverterCulture = binding.ConverterCulture,
                Mode = binding.Mode,
                NotifyOnValidationError = binding.NotifyOnValidationError,
                Path = binding.Path,
                UpdateSourceTrigger = binding.UpdateSourceTrigger,
                ValidatesOnExceptions = binding.ValidatesOnExceptions
            };

            if (binding.ElementName != null)
            {
                newBinding.ElementName = binding.ElementName;
            }
            else if (binding.RelativeSource != null)
            {
                newBinding.RelativeSource = binding.RelativeSource;
            }
            else
            {
                newBinding.Source = binding.Source;
            }

            return newBinding;
        }
    }
}