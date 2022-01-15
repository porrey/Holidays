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
using System.Linq;
using System.Threading.Tasks;

namespace Innovative.Holiday
{
	public static class DateTimeExtensions
	{
		public static IEnumerable<IHoliday> GetHoliday(this DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			IEnumerable<IHoliday> returnValue = new IHoliday[0];

			if (holidayOccurrenceType == HolidayOccurrenceType.Actual)
			{
				returnValue = (from tbl in Holidays.MyHolidays
							   where tbl.GetByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}
			if (holidayOccurrenceType == HolidayOccurrenceType.Observed)
			{
				returnValue = (from tbl in Holidays.MyHolidays
							   where tbl is IObservedHoliday &&
							   ((IObservedHoliday)tbl).GetObservedByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}
			else
			{
				returnValue = (from tbl in Holidays.MyHolidays
							   where tbl.GetByYear(value.Year) == value.Date ||
							  (tbl is IObservedHoliday && ((IObservedHoliday)tbl).GetObservedByYear(value.Year) == value.Date)
							   select tbl).ToArray();
			}

			return returnValue;
		}

		public static Task<IEnumerable<IHoliday>> GetHolidayAsync(this DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.GetHoliday(holidayOccurrenceType));
		}

		public static IEnumerable<IHoliday> GetHoliday(this DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			IEnumerable<IHoliday> returnValue = new IHoliday[0];

			if (value.HasValue)
			{
				returnValue = value.Value.GetHoliday(holidayOccurrenceType);
			}

			return returnValue;
		}

		public static Task<IEnumerable<IHoliday>> GetHolidayAsync(this DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.GetHoliday(holidayOccurrenceType));
		}

		public static bool IsHoliday(this DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return (value.GetHoliday(holidayOccurrenceType).Any());
		}

		public static Task<bool> IsHolidayAsync(this DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.IsHoliday(holidayOccurrenceType));
		}

		public static bool IsHoliday(this DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			bool returnValue = false;

			if (value.HasValue)
			{
				returnValue = value.Value.IsHoliday(holidayOccurrenceType);
			}

			return returnValue;
		}

		public static Task<bool> IsHolidayAsync(this DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.IsHoliday(holidayOccurrenceType));
		}
	}
}
