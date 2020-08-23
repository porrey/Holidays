using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innovative.Holiday
{
	public static class DateTimeOffsetExtensions
	{
		public static IEnumerable<IHoliday> GetHoliday(this DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return value.Date.GetHoliday(holidayOccurrenceType);
		}

		public static Task<IEnumerable<IHoliday>> GetHolidayAsync(this DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.GetHoliday(holidayOccurrenceType));
		}

		public static IEnumerable<IHoliday> GetHoliday(this DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			IEnumerable<IHoliday> returnValue = new IHoliday[0];

			if (value.HasValue)
			{
				returnValue = value.Value.GetHoliday(holidayOccurrenceType);
			}

			return returnValue;
		}

		public static Task<IEnumerable<IHoliday>> GetHolidayAsync(this DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.GetHoliday(holidayOccurrenceType));
		}

		public static bool IsHoliday(this DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return value.GetHoliday(holidayOccurrenceType).Any();
		}

		public static Task<bool> IsHolidayAsync(this DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.IsHoliday(holidayOccurrenceType));
		}

		public static bool IsHoliday(this DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			bool returnValue = false;

			if (value.HasValue)
			{
				returnValue = value.Value.IsHoliday(holidayOccurrenceType);
			}

			return returnValue;
		}

		public static Task<bool> IsHolidayAsync(this DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(value.IsHoliday(holidayOccurrenceType));
		}
	}
}
