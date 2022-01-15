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
using System.Runtime.Serialization;
#if !NET5_0 && !NET6_0
using System.Security.Permissions;
#endif

namespace Innovative.SystemTime
{
	[Serializable]
	public struct Time : IComparable, IComparable<Time>, IFormattable, IEquatable<Time>, ICloneable, ISerializable
	{
		public Time(TimeSpan value)
		{
			this.TimeSpan = value;
		}

		public Time(DateTime value)
		{
			this.TimeSpan = value.TimeOfDay;
		}

		public Time(string value)
		{
			Time t = Time.Parse(value);
			this.TimeSpan = t.TimeSpan;
		}

		public Time(SerializationInfo info, StreamingContext context)
		{
			if (info != null)
			{
				this.TimeSpan = (TimeSpan)info.GetValue("InnerValue", typeof(TimeSpan));
			}
			else
			{
				throw new ArgumentNullException("info");
			}
		}

		public TimeSpan TimeSpan { get; set; }

		public DateTime Date
		{
			get
			{
				return DateTime.Now.Date.Add(this.TimeSpan);
			}
		}

		public override string ToString()
		{
			return ((DateTime)this).ToLongTimeString();
		}

		public override bool Equals(object obj)
		{
			bool returnValue = false;

			if (obj is Time time)
			{
				returnValue = this.TimeSpan.Equals(time.TimeSpan);
			}

			return returnValue;
		}

		public override int GetHashCode()
		{
			return this.TimeSpan.GetHashCode();
		}

#region Static Members
		public static Time Parse(string s)
		{
			Time returnValue = Time.Empty;

			if (!Time.TryParse(s, out returnValue))
			{
				throw new FormatException();
			}

			return returnValue;
		}

		public static bool TryParse(string s, out Time result)
		{
			bool returnValue = false;
			result = Time.Empty;

			if (DateTime.TryParse(s, out DateTime parsedValue))
			{
				result = new Time(parsedValue.TimeOfDay);
				returnValue = true;
			}

			return returnValue;
		}

		public static bool CanParse(string s)
		{
			return Time.TryParse(s, out Time _);
		}

		public static Time Empty
		{
			get
			{
				return new Time();
			}
		}

#region Implicit Conversions
		public static implicit operator string(Time value)
		{
			return value.ToString();
		}

		public static implicit operator Time(string value)
		{
			return new Time(value);
		}

		public static implicit operator DateTime(Time value)
		{
			return value.Date;
		}

		public static implicit operator Time(DateTime value)
		{
			return new Time(value);
		}

		public static implicit operator TimeSpan(Time value)
		{
			return value.TimeSpan;
		}

		public static implicit operator Time(TimeSpan value)
		{
			return new Time(value);
		}
#endregion

#region Time/Time
		public static Time operator +(Time t1, Time t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = t1.Date + t2.TimeSpan;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static Time operator -(Time t1, Time t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = t1.Date - t2.TimeSpan;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static bool operator ==(Time t1, Time t2)
		{
			return (t1.TimeSpan == t2.TimeSpan);
		}

		public static bool operator !=(Time t1, Time t2)
		{
			return (t1.TimeSpan != t2.TimeSpan);
		}

		public static bool operator <(Time t1, Time t2)
		{
			return (t1.TimeSpan < t2.TimeSpan);
		}

		public static bool operator <=(Time t1, Time t2)
		{
			return (t1.TimeSpan <= t2.TimeSpan);
		}

		public static bool operator >(Time t1, Time t2)
		{
			return (t1.TimeSpan > t2.TimeSpan);
		}

		public static bool operator >=(Time t1, Time t2)
		{
			return (t1.TimeSpan >= t2.TimeSpan);
		}
#endregion

#region Time/TimeSpan
		public static Time operator +(Time t1, TimeSpan t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = t1.Date + t2;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static Time operator -(Time t1, TimeSpan t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = t1.Date - t2;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static bool operator ==(Time t1, TimeSpan t2)
		{
			return (t1.TimeSpan == t2);
		}

		public static bool operator !=(Time t1, TimeSpan t2)
		{
			return (t1.TimeSpan != t2);
		}

		public static bool operator <(Time t1, TimeSpan t2)
		{
			return (t1.TimeSpan < t2);
		}

		public static bool operator <=(Time t1, TimeSpan t2)
		{
			return (t1.TimeSpan <= t2);
		}

		public static bool operator >(Time t1, TimeSpan t2)
		{
			return (t1.TimeSpan > t2);
		}

		public static bool operator >=(Time t1, TimeSpan t2)
		{
			return (t1.TimeSpan >= t2);
		}
#endregion

#region TimeSpan/Time
		public static Time operator +(TimeSpan t1, Time t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = DateTime.Now.Add(t1) + t2.TimeSpan;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static Time operator -(TimeSpan t1, Time t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = DateTime.Now.Add(t1) - t2.TimeSpan;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static bool operator ==(TimeSpan t1, Time t2)
		{
			return (t1 == t2.TimeSpan);
		}

		public static bool operator !=(TimeSpan t1, Time t2)
		{
			return (t1 != t2.TimeSpan);
		}

		public static bool operator <(TimeSpan t1, Time t2)
		{
			return (t1 < t2.TimeSpan);
		}

		public static bool operator <=(TimeSpan t1, Time t2)
		{
			return (t1 <= t2.TimeSpan);
		}

		public static bool operator >(TimeSpan t1, Time t2)
		{
			return (t1 > t2.TimeSpan);
		}

		public static bool operator >=(TimeSpan t1, Time t2)
		{
			return (t1 >= t2.TimeSpan);
		}
#endregion

#region Time/DateTime
		public static Time operator +(Time t1, DateTime t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = t1.Date + t2.TimeOfDay;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static Time operator -(Time t1, DateTime t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = t1.Date - t2.TimeOfDay;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static bool operator ==(Time t1, DateTime t2)
		{
			return (t1.TimeSpan == t2.TimeOfDay);
		}

		public static bool operator !=(Time t1, DateTime t2)
		{
			return (t1.TimeSpan != t2.TimeOfDay);
		}

		public static bool operator <(Time t1, DateTime t2)
		{
			return (t1.TimeSpan < t2.TimeOfDay);
		}

		public static bool operator <=(Time t1, DateTime t2)
		{
			return (t1.TimeSpan <= t2.TimeOfDay);
		}

		public static bool operator >(Time t1, DateTime t2)
		{
			return (t1.TimeSpan > t2.TimeOfDay);
		}

		public static bool operator >=(Time t1, DateTime t2)
		{
			return (t1.TimeSpan >= t2.TimeOfDay);
		}
#endregion

#region DateTime/Time
		public static Time operator +(DateTime d1, Time t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = d1 + t2.TimeSpan;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static Time operator -(DateTime d1, Time t2)
		{
			Time returnValue = Time.Empty;

			DateTime d = d1 - t2.TimeSpan;
			returnValue = new Time(d.TimeOfDay);

			return returnValue;
		}

		public static bool operator ==(DateTime d1, Time t2)
		{
			return (d1.TimeOfDay == t2.TimeSpan);
		}

		public static bool operator !=(DateTime d1, Time t2)
		{
			return (d1.TimeOfDay != t2.TimeSpan);
		}

		public static bool operator <(DateTime d1, Time t2)
		{
			return (d1.TimeOfDay < t2.TimeSpan);
		}

		public static bool operator <=(DateTime d1, Time t2)
		{
			return (d1.TimeOfDay <= t2.TimeSpan);
		}

		public static bool operator >(DateTime d1, Time t2)
		{
			return (d1.TimeOfDay > t2.TimeSpan);
		}

		public static bool operator >=(DateTime d1, Time t2)
		{
			return (d1.TimeOfDay >= t2.TimeSpan);
		}
#endregion
#endregion

#region IComparable
		public int CompareTo(object obj)
		{
			int returnValue = -1;

			if (obj is Time time)
			{
				returnValue = this.TimeSpan.CompareTo(time.TimeSpan);
			}

			return returnValue;
		}
#endregion

#region IFormattable
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.Date.ToString(format, formatProvider);
		}
#endregion

#region IComparable<Time>
		public int CompareTo(Time other)
		{
			return this.TimeSpan.CompareTo(other.TimeSpan);
		}
#endregion

#region IEquatable<Time>
		public bool Equals(Time other)
		{
			return this.Equals(other);
		}
#endregion

#region ICloneable
		public object Clone()
		{
			return new Time(this.TimeSpan);
		}
#endregion region

#region ISerializable
#if !NET5_0 && !NET6_0
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
#endif
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info != null)
			{
				info.AddValue("InnerValue", this.TimeSpan);
			}
			else
			{
				throw new ArgumentNullException("info");
			}
		}
#endregion
	}
}
