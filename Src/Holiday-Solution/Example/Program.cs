using System;
using System.Collections.Generic;
using Innovative.SystemTime;

namespace Innovative.Holiday.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Holidays.Register(Us.Federal.All.Items, Us.Other.All.Items, Religious.Christian.All.Items);

			DateTimeOffset? dt = new DateTimeOffset(new DateTime(2020, 9, 7), TimeSpan.FromHours(-5));

			bool isHoliday = dt.IsHoliday(HolidayOccurrenceType.Observed);
			IEnumerable<IHoliday> holidays = dt.GetHoliday(HolidayOccurrenceType.Observed);
		}
	}
}
