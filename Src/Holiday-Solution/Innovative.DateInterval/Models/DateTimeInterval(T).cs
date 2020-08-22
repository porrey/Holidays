using System;
using System.Collections.Generic;

namespace Innovative.DateInterval
{
	public abstract class DateTimeInterval<T> : DateTimeInterval, IValue<T>, IDateTimeIntervalStringConverter<T>
	{
		T _innerValue = default(T);

		public DateTimeInterval()
		{
			this.Value = this.OnGetDefaultValue();
		}

		public DateTimeInterval(T value)
		{
			this.Value = value;
		}

		public DateTimeInterval(string value)
		{
			this.Value = this.FromString(value);
		}

		#region IValue
		public virtual T Value
		{
			get
			{
				return _innerValue;
			}
			set
			{
				if (this.IsValidRange(value))
				{
					_innerValue = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public virtual bool IsValidRange(T value)
		{
			return this.OnGetIsValidRange(value);
		}

		public virtual T DefaultValue
		{
			get
			{
				return this.OnGetDefaultValue();
			}
		}

		public virtual T FromString(string value)
		{
			return this.OnGetFromString(value);
		}

		protected virtual T OnGetFromString(string value)
		{
			return (T)this.OnConvertFromString(value);
		}

		protected virtual bool OnGetIsValidRange(T value)
		{
			// ***
			// *** The default implementation is to 
			// *** allow all values
			// ***
			return true;
		}

		protected virtual T OnGetDefaultValue()
		{
			return default(T);
		}
		#endregion

		#region IDateTimeIntervalConverter
		public virtual bool IsValidString(string value)
		{
			return this.OnIsValidString(value);
		}

		public virtual string ConvertToString()
		{
			return this.ConvertToString();
		}

		public T ConvertFromString(string value)
		{
			return this.OnConvertFromString(value);
		}
		#endregion

		#region Protected Members
		protected virtual bool OnIsValidString(string value)
		{
			throw new NotImplementedException();
		}

		protected virtual string OnConvertToString()
		{
			throw new NotImplementedException();
		}

		protected virtual T OnConvertFromString(string value)
		{
			throw new NotImplementedException();
		}
		#endregion

		public static IEnumerable<K> ParseList<K>(string list) where K : DateTimeInterval<T>, new()
		{
			List<K> returnValue = new List<K>();

			// ***
			// *** Parse the string
			// ***
			string[] items = list.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

			Type t = typeof(T);

			foreach (string item in items)
			{
				K iDateTimeInterval = new K();
				((IValue<T>)iDateTimeInterval).Value = iDateTimeInterval.FromString(item);
				returnValue.Add(iDateTimeInterval);
			}

			return returnValue;
		}
	}
}
