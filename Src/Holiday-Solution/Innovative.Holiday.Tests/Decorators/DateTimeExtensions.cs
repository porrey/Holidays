using System;

namespace Innovative.Holiday.Tests
{
	public static class DateTimeExtensions
	{
		public static DateTime NextDayOfWeek(this DateTime value, DayOfWeek dayOfWeek)
		{
			DateTime returnValue = value;

			int adjustment = (7 + (int)dayOfWeek - (int)value.DayOfWeek) % 7;
			returnValue = value.AddDays(adjustment);

			// ***
			// *** All dates must be in the future.
			// ***
			if (returnValue.Date <= DateTime.Now.Date)
			{
				returnValue = returnValue.AddDays(7);
			}

			return returnValue;
		}

		public static DateTimeOffset NextDayOfWeek(this DateTimeOffset value, DayOfWeek dayOfWeek)
		{
			DateTimeOffset returnValue = value;

			int adjustment = (7 + (int)dayOfWeek - (int)value.DayOfWeek) % 7;
			returnValue = value.AddDays(adjustment);

			// ***
			// *** All dates must be in the future.
			// ***
			if (returnValue.Date <= DateTimeOffset.Now.Date)
			{
				returnValue = returnValue.AddDays(7);
			}

			return returnValue;
		}
	}
}
