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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Innovative.DateInterval
{
	public class WeekDay : DateTimeInterval<DayOfWeek>
	{
		public WeekDay()
			: base()
		{
		}

		public WeekDay(DayOfWeek value)
			: base(value)
		{
		}

		public WeekDay(DateTime value)
		{
			this.Value = value.DayOfWeek;
		}

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			int dayValue = (int)this.Value;
			int currentDayValue = (int)DateTime.Now.DayOfWeek;

			if (currentDayValue > dayValue)
			{
				int dayDifference = 7 - (currentDayValue - dayValue) - 1;
				returnValue = DateTime.Now.Date.Add(TimeSpan.FromDays(dayDifference));
			}
			else
			{
				int dayDifference = dayValue - currentDayValue;
				returnValue = DateTime.Now.Date.Add(TimeSpan.FromDays(dayDifference));
			}

			if (index > 0)
			{
				long delta = (7 * index) + 1;
				returnValue = returnValue.Add(TimeSpan.FromDays(delta));
			}

			return returnValue;
		}

		protected override DayOfWeek OnGetDefaultValue()
		{
			return WeekDay.Default.Value;
		}

		#region IDateTimeIntervalConverter
		protected override DayOfWeek OnConvertFromString(string value)
		{
			return (DayOfWeek)Enum.Parse(typeof(WeekDay), value);
		}

		protected override string OnConvertToString()
		{
			return this.Value.ToString();
		}

		protected override bool OnIsValidString(string value)
		{
			bool returnValue = false;

			DayOfWeek parsedValue = DayOfWeek.Sunday;
			returnValue = Enum.TryParse<DayOfWeek>(value, out parsedValue);

			return returnValue;
		}
		#endregion

		#region Predefined Values
		public static WeekDay Default
		{
			get
			{
				return WeekDay.First;
			}
		}

		public static WeekDay First
		{
			get
			{
				return new WeekDay(DayOfWeek.Sunday);
			}
		}

		public static WeekDay Second
		{
			get
			{
				return new WeekDay(DayOfWeek.Monday);
			}
		}

		public static WeekDay Third
		{
			get
			{
				return new WeekDay(DayOfWeek.Tuesday);
			}
		}

		public static WeekDay Fourth
		{
			get
			{
				return new WeekDay(DayOfWeek.Wednesday);
			}
		}

		public static WeekDay Fifth
		{
			get
			{
				return new WeekDay(DayOfWeek.Thursday);
			}
		}

		public static WeekDay Sixth
		{
			get
			{
				return new WeekDay(DayOfWeek.Friday);
			}
		}

		public static WeekDay Seventh
		{
			get
			{
				return new WeekDay(DayOfWeek.Saturday);
			}
		}

		public static WeekDay Sunday
		{
			get
			{
				return new WeekDay(DayOfWeek.Sunday);
			}
		}

		public static WeekDay Monday
		{
			get
			{
				return new WeekDay(DayOfWeek.Monday);
			}
		}

		public static WeekDay Tuesday
		{
			get
			{
				return new WeekDay(DayOfWeek.Tuesday);
			}
		}

		public static WeekDay Wednesday
		{
			get
			{
				return new WeekDay(DayOfWeek.Wednesday);
			}
		}

		public static WeekDay Thursday
		{
			get
			{
				return new WeekDay(DayOfWeek.Thursday);
			}
		}

		public static WeekDay Friday
		{
			get
			{
				return new WeekDay(DayOfWeek.Friday);
			}
		}

		public static WeekDay Saturday
		{
			get
			{
				return new WeekDay(DayOfWeek.Saturday);
			}
		}
		#endregion
	}	
}