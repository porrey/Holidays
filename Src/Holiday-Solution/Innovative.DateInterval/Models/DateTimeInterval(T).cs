//
// Copyright(C) 2013-2025, Daniel M. Porrey. All rights reserved.
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
				return this._innerValue;
			}
			set
			{
				if (this.IsValidRange(value))
				{
					this._innerValue = value;
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
			//
			// The default implementation is to 
			// allow all values
			//
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
			List<K> returnValue = new();

			//
			// Parse the string
			//
			string[] items = list.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

			Type t = typeof(T);

			foreach (string item in items)
			{
				K iDateTimeInterval = new();
				((IValue<T>)iDateTimeInterval).Value = iDateTimeInterval.FromString(item);
				returnValue.Add(iDateTimeInterval);
			}

			return returnValue;
		}
	}
}
