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
using Innovative.SystemTime;

namespace System
{
	public enum SpecificDayBehavior
	{
		AdjustForLast,
		ThrowException
	}

	public static class DateTimeExtensions
	{
		public static string ToFullFormat(this DateTime item)
		{
			return String.Format("{0} at {1}", item.ToLongDateString(), item.ToLongTimeString());
		}

		public static DateTime SpecifyDayOfMonth(this DateTime item, int day, SpecificDayBehavior behavior)
		{
			DateTime returnValue = item;

			//
			// Get the maximum days for a given month
			//
			int maximumDays = DateTime.DaysInMonth(item.Year, item.Month);

			//
			// Normalize keeps the value with the
			// allowable range
			//
			if (day < 1 || day > maximumDays)
			{
				if (behavior == SpecificDayBehavior.AdjustForLast)
				{
					if (day < 1)
					{
						day = 1;
					}

					if (day > maximumDays)
					{
						day = maximumDays;
					}
				}
				else
				{
					throw new ArgumentOutOfRangeException("day");
				}
			}

			//
			// Create the date
			//
			returnValue = new DateTime(item.Year, item.Month, day);

			return returnValue;
		}

		public static DayOfWeek AddDays(this DayOfWeek dayOfWeek, int days)
		{
			DayOfWeek returnValue = dayOfWeek;

			int daysToAdd = days % 7;
			int newDay = ((int)dayOfWeek + 1) + daysToAdd;

			if (newDay > 7)
			{
				newDay %= 7;
			}

			returnValue = (DayOfWeek)(newDay - 1);

			return returnValue;
		}

		public static DateTime SetTime(this DateTime date, Time time)
		{
			return date.Date.Add(time.TimeSpan);
		}
	}
}
