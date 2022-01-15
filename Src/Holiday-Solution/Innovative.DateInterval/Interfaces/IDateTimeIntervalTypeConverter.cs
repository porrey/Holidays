//
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
//
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
