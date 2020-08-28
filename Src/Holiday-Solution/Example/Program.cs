using System;
using System.Collections.Generic;
using Innovative.Holiday;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Holidays.MyHolidays.AddRangesAsync(Innovative.Holiday.Us.Federal.All.Items, Innovative.Holiday.Us.Other.All.Items);
			Holidays.MyHolidays.Add(new Christmas());

			DateTimeOffset? dt = new DateTimeOffset(new DateTime(2020, 9, 7), TimeSpan.FromHours(-5));

			bool isHoliday = dt.IsHoliday(HolidayOccurrenceType.Observed);
			IEnumerable<IHoliday> holidays = dt.GetHoliday(HolidayOccurrenceType.Observed);
		}
	}
}
