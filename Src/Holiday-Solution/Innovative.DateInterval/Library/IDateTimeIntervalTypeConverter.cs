using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Innovative.DateInterval
{
	[TypeConverter(typeof(IDateTimeInterval))]
	[Serializable]
	public class IDateTimeIntervalTypeConverter<T> : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return (sourceType == typeof(string));
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return (destinationType == typeof(T));
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			object returnValue = null;

			if (destinationType == typeof(string))
			{
				returnValue = ((IDateTimeIntervalStringConverter<T>)returnValue).ToString();
			}
			
			return returnValue;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			object returnValue = null;

			if (value.GetType() == typeof(T))
			{
				returnValue = ((IDateTimeIntervalStringConverter<T>)value).ConvertFromString((string)value);				
			}

			return returnValue;
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return false;
		}

		public override bool IsValid(ITypeDescriptorContext context, object value)
		{
			bool returnValue = false;

			if (value.GetType() == typeof(T))
			{
				returnValue = ((IDateTimeIntervalStringConverter<T>)value).IsValidString((string)value);
			}

			return returnValue;
		}
	}
}
