using System;
using Innovative.Holiday;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Holidays.ObservedHolidays.AddRange(Innovative.Holiday.Us.Federal.All.Items);
			Holidays.ObservedHolidays.Add(new Christmas());

			DateTime d = new DateTime(2020, 7, 4);
			bool isHoliday = d.IsHoliday(HolidayOccurrenceType.Any);

			LaborDay ld = new LaborDay();
			DateTime dt1 = ld.NextObservedDateTime;

			GoodFriday gf = new GoodFriday();
			DateTime dt2 = gf.NextObservedDateTime;

			EasterSunday es = new EasterSunday();
			DateTime dt3 = es.NextObservedDateTime;
		}
	}
}
