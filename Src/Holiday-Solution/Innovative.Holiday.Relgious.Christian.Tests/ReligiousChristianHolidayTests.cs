using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Innovative.Holiday.Relgious.Christian.Tests
{
	public class ReligiousChristianHolidayTests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.ObservedHolidays.Clear();
		}

		public static IEnumerable<int> Years => Enumerable.Range(2000, 35);
		public static IEnumerable<DateTime> ChristmasDays = new DateTime[] { new DateTime(2019, 12, 25), new DateTime(2020, 12, 25), new DateTime(2021, 12, 25) };
		public static IEnumerable<DateTime> ChristmasObservedDays = new DateTime[] { new DateTime(2019, 12, 25), new DateTime(2020, 12, 25), new DateTime(2021, 12, 24) };
		public static IEnumerable<DateTime> ChristmasEveDays = new DateTime[] { new DateTime(2019, 12, 24), new DateTime(2020, 12, 24), new DateTime(2021, 12, 24) };
		public static IEnumerable<DateTime> EasterSundays = new DateTime[] { new DateTime(2019, 4, 21), new DateTime(2020, 4, 12), new DateTime(2021, 4, 4) };
		public static IEnumerable<DateTime> GoodFridays = new DateTime[] { new DateTime(2019, 4, 19), new DateTime(2020, 4, 10), new DateTime(2021, 4, 2) };
		public static IEnumerable<DateTime> PalmSundays = new DateTime[] { new DateTime(2019, 4, 14), new DateTime(2020, 4, 5), new DateTime(2021, 3, 28) };
		public static IEnumerable<DateTime> NationalDayOfPrayerDays = new DateTime[] { new DateTime(2019, 5, 2), new DateTime(2020, 5, 7), new DateTime(2021, 5, 6) };

		[Test]
		[TestCaseSource("ChristmasDays")]
		public void ChristmasTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Christmas());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void ChristmasYearTest(int year)
		{
			Christmas holiday = new Christmas();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("ChristmasObservedDays")]
		public void ChristmasObservedTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Christmas());
			Assert.IsTrue(value.IsHoliday(HolidayOccurrenceType.Observed));
		}

		[Test]
		[TestCaseSource("Years")]
		public void ChristmasObservedYearTest(int year)
		{
			Christmas holiday = new Christmas();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("ChristmasEveDays")]
		public void ChristmasEveTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new ChristmasEve());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void ChristmasEveYearTest(int year)
		{
			ChristmasEve holiday = new ChristmasEve();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("EasterSundays")]
		public void EasterTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Easter());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void EasterYearTest(int year)
		{
			Easter holiday = new Easter();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("GoodFridays")]
		public void GoodFridayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new GoodFriday());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void GoodFridayYearTest(int year)
		{
			GoodFriday holiday = new GoodFriday();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("PalmSundays")]
		public void PalmSundayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new PalmSunday());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void PalmSundayYearTest(int year)
		{
			PalmSunday holiday = new PalmSunday();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("NationalDayOfPrayerDays")]
		public void NationalDayOfPrayerTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new NationalDayOfPrayer());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void NationalDayOfPrayerYearTest(int year)
		{
			NationalDayOfPrayer holiday = new NationalDayOfPrayer();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}
	}
}