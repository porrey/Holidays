using System;
using System.Collections.Generic;
using Innovative.Holiday;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Holidays.ObservedHolidays.AddRange(Innovative.Holiday.Us.Federal.All.Items);
			Holidays.ObservedHolidays.Add(new Christmas());

			// 9/8/2020 12:00:00 AM -05:00
			DateTimeOffset? dt = new DateTimeOffset(new DateTime(2020, 9, 8), TimeSpan.FromHours(-5));

			bool isHoliday = dt.IsHoliday(HolidayOccurrenceType.Observed);
			IEnumerable<IHoliday> holidays = dt.GetHoliday(HolidayOccurrenceType.Observed);
		}
	}
}
