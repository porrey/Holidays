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
				returnValue = (from tbl in Holidays.ObservedHolidays
							   where tbl.GetByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}
			if (holidayOccurrenceType == HolidayOccurrenceType.Observed)
			{
				returnValue = (from tbl in Holidays.ObservedHolidays
							   where tbl.GetObservedByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}
			else
			{
				returnValue = (from tbl in Holidays.ObservedHolidays
							   where tbl.GetByYear(value.Year) == value.Date || tbl.GetObservedByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}

			return returnValue;
		}

		public static Task<IEnumerable<IHoliday>> GetHolidayAsync(this DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
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
