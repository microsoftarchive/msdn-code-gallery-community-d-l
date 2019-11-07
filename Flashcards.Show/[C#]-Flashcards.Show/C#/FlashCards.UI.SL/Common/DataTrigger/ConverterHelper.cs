using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Interactivity.Data.Helpers {

    /// <summary>
    /// Code is based on the work by Pete Blois
    /// http://blois.us/blog/2009/04/datatrigger-bindings-on-non.html
    /// </summary>
    public static class ConverterHelper
    {

		public static object ConvertToType(object value, Type type) {
			if (value == null)
				return null;

			if (type.IsAssignableFrom(value.GetType()))
				return value;

			TypeConverter converter = ConverterHelper.GetTypeConverter(type);

			if (converter != null && converter.CanConvertFrom(value.GetType())) {

				value = converter.ConvertFrom(value);
				return value;
			}

			return null;
		}

		public static TypeConverter GetTypeConverter(Type type) {
			TypeConverterAttribute attribute = (TypeConverterAttribute)Attribute.GetCustomAttribute(type, typeof(TypeConverterAttribute), false);
			if (attribute != null) {
				try {
					Type converterType = Type.GetType(attribute.ConverterTypeName, false);
					if (converterType != null) {
						return (Activator.CreateInstance(converterType) as TypeConverter);
					}
				}
				catch {
				}
			}
			return new ConvertFromStringConverter(type);
		}
	}

	public class ConvertFromStringConverter : TypeConverter {

		private Type type;

		public ConvertFromStringConverter(Type type) {
			this.type = type;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			string stringValue = value as string;
			if (stringValue != null) {
				if (this.type == typeof(bool)) {
					return bool.Parse(stringValue);
				}
				if (this.type.IsEnum) {
					return Enum.Parse(this.type, stringValue, false);
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("<ContentControl xmlns='http://schemas.microsoft.com/client/2007' xmlns:c='" + ("clr-namespace:" + this.type.Namespace + ";assembly=" + this.type.Assembly.FullName.Split(new char[] { ',' })[0]) + "'>\n");
				stringBuilder.Append("<c:" + this.type.Name + ">\n");
				stringBuilder.Append(stringValue);
				stringBuilder.Append("</c:" + this.type.Name + ">\n");
				stringBuilder.Append("</ContentControl>");
				ContentControl instance = XamlReader.Load(stringBuilder.ToString()) as ContentControl;
				if (instance != null) {
					return instance.Content;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
