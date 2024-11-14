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
using System.Collections;
using System.Runtime.Serialization;

namespace Innovative.DateInterval
{
	public abstract class DateTimeInterval : IDateTimeInterval, IComparable, IFormattable, ISerializable, IComparable<DateTime>, IEquatable<DateTime>, IReadOnlyList<DateTime>, IReadOnlyCollection<DateTime>, IEnumerable, IEnumerable<DateTime>
	{
		#region IDateTimeInterval
		public virtual DateTime NextDateTime
		{
			get
			{
				return this.OnGetDateTime(0);
			}
		}

		public virtual DateTime this[int index]
		{
			get
			{
				return this.OnGetDateTime(index);
			}
		}

		public virtual DateTime GetByIndex(int index)
		{
			return this[index];
		}

		public virtual DateTime GetByYear(int year)
		{
			int index = this.GetYearIndex(year);
			return this[index];
		}

		public virtual int GetYearIndex(int year)
		{
			int returnValue = 0;

			int nextHolidayYear = this.NextDateTime.Year;
			returnValue = year - nextHolidayYear;

			return returnValue;
		}
		#endregion

		#region IReadOnlyList
		public int Count
		{
			get
			{
				//
				// Limit the enumeration to 1000 years
				//
				return 1000;
			}
		}

		public IEnumerator<DateTime> GetEnumerator()
		{
			return new Enumerator2(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		public class Enumerator : IEnumerator
		{
			private int _index = 0;
			private IDateTimeInterval _dateTimeInterval = null;

			public Enumerator(IDateTimeInterval dateTimeInterval)
			{
				this._dateTimeInterval = dateTimeInterval;
			}

			public object Current
			{
				get
				{
					return this._dateTimeInterval[this._index];
				}
			}

			public bool MoveNext()
			{
				this._index++;
				return this._index < ((IReadOnlyList<DateTime>)this._dateTimeInterval).Count;
			}

			public void Reset()
			{
				this._index = 0;
			}
		}

		public class Enumerator2 : IEnumerator<DateTime>
		{
			private int _index = 0;
			private IDateTimeInterval _dateTimeInterval = null;

			public Enumerator2(IDateTimeInterval dateTimeInterval)
			{
				this._dateTimeInterval = dateTimeInterval;
			}

			public DateTime Current
			{
				get
				{
					return this._dateTimeInterval[this._index];
				}
			}

			public void Dispose()
			{

			}

			object IEnumerator.Current
			{
				get
				{
					return this._dateTimeInterval[this._index];
				}
			}

			public bool MoveNext()
			{
				this._index++;
				return this._index < ((IReadOnlyList<DateTime>)this._dateTimeInterval).Count;
			}

			public void Reset()
			{
				this._index = 0;
			}
		}
		#endregion

		#region Overridden Members
		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return this.NextDateTime.ToFullFormat();
		}

		public override bool Equals(object obj)
		{
			bool returnValue = false;

			if (obj is IDateTimeInterval)
			{
				returnValue = ((IDateTimeInterval)obj).NextDateTime.Equals(this.NextDateTime);
			}

			return returnValue;
		}

		public override int GetHashCode()
		{
			return this.NextDateTime.GetHashCode();
		}
		#endregion

		#region Public Members
		public int CompareTo(object obj)
		{
			int returnValue = -1;

			if (obj is IDateTimeInterval interval)
			{
				returnValue = interval.NextDateTime.CompareTo(this.NextDateTime);
			}

			return returnValue;
		}

		public int CompareTo(DateTime other)
		{
			return other.CompareTo(this.NextDateTime);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.NextDateTime.ToString(format, formatProvider);
		}

		[Obsolete("Formatter-based serialization is obsolete and should not be used.", DiagnosticId = "SYSLIB0050", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			((ISerializable)this.NextDateTime).GetObjectData(info, context);
		}

		public bool Equals(DateTime other)
		{
			return this.NextDateTime.Equals(other);
		}

		public DateTime Add(TimeSpan value)
		{
			return this.NextDateTime.Add(value);
		}

		public DateTime AddDays(double value)
		{
			return this.NextDateTime.AddDays(value);
		}

		public DateTime AddHours(double value)
		{
			return this.NextDateTime.AddHours(value);
		}

		public DateTime AddMilliseconds(double value)
		{
			return this.NextDateTime.AddMilliseconds(value);
		}

		public DateTime AddMinutes(double value)
		{
			return this.NextDateTime.AddMinutes(value);
		}

		public DateTime AddMonths(int months)
		{
			return this.NextDateTime.AddMonths(months);
		}

		public DateTime AddSeconds(double value)
		{
			return this.NextDateTime.AddSeconds(value);
		}

		public DateTime AddTicks(long value)
		{
			return this.NextDateTime.AddTicks(value);
		}

		public DateTime AddYears(int value)
		{
			return this.NextDateTime.AddYears(value);
		}
		#endregion

		#region Protected Members
		protected virtual DateTime OnGetDateTime(int index)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Static Members
		public static implicit operator DateTime(DateTimeInterval value)
		{
			return value.NextDateTime;
		}

		public static TimeSpan operator -(DateTimeInterval d1, DateTime d2)
		{
			return d1.NextDateTime.Subtract(d2);
		}

		public static DateTime operator -(DateTimeInterval d, TimeSpan t)
		{
			return d.NextDateTime.Subtract(t);
		}

		public static bool operator !=(DateTimeInterval d1, DateTime d2)
		{
			return !d1.NextDateTime.Equals(d2);
		}

		public static DateTime operator +(DateTimeInterval d, TimeSpan t)
		{
			return d.NextDateTime.Add(t);
		}

		public static bool operator <(DateTimeInterval d1, DateTime t2)
		{
			return d1.NextDateTime < t2;
		}

		public static bool operator <=(DateTimeInterval d1, DateTime t2)
		{
			return d1.NextDateTime <= t2;
		}

		public static bool operator ==(DateTimeInterval d1, DateTime d2)
		{
			return d1.NextDateTime == d2;
		}

		public static bool operator >(DateTimeInterval d1, DateTime t2)
		{
			return d1.NextDateTime > t2;
		}

		public static bool operator >=(DateTimeInterval d1, DateTime t2)
		{
			return d1 >= t2;
		}
		#endregion
	}
}
