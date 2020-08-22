using System;
using System.Collections;
using System.Collections.Generic;
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

		public virtual DateTime GetAtInterval(int index)
		{
			return this[index];
		}
		#endregion

		#region IReadOnlyList
		public int Count
		{
			get
			{
				// ***
				// *** Limit the enumeration to 1000 years
				// ***
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
				_dateTimeInterval = dateTimeInterval;
			}

			public object Current
			{
				get
				{
					return _dateTimeInterval[_index];
				}
			}

			public bool MoveNext()
			{
				_index++;
				return (_index < ((IReadOnlyList<DateTime>)_dateTimeInterval).Count);
			}

			public void Reset()
			{
				_index = 0;
			}
		}

		public class Enumerator2 : IEnumerator<DateTime>
		{
			private int _index = 0;
			private IDateTimeInterval _dateTimeInterval = null;

			public Enumerator2(IDateTimeInterval dateTimeInterval)
			{
				_dateTimeInterval = dateTimeInterval;
			}

			public DateTime Current
			{
				get
				{
					return _dateTimeInterval[_index];
				}
			}

			public void Dispose()
			{

			}

			object IEnumerator.Current
			{
				get
				{
					return _dateTimeInterval[_index];
				}
			}

			public bool MoveNext()
			{
				_index++;
				return (_index < ((IReadOnlyList<DateTime>)_dateTimeInterval).Count);
			}

			public void Reset()
			{
				_index = 0;
			}
		}
		#endregion

		#region Overridden Members
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

			if (obj is IDateTimeInterval)
			{
				returnValue = ((IDateTimeInterval)obj).NextDateTime.CompareTo(this.NextDateTime);
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
