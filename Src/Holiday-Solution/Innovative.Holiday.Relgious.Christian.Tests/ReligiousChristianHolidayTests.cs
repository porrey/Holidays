using System;
using System.Collections.Generic;
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

		public static IEnumerable<DateTime> ChristmasDays = new DateTime[] { new DateTime(2019, 12, 25), new DateTime(2020, 12, 25), new DateTime(2021, 12, 25) };

		[Test]
		[TestCaseSource("ChristmasDays")]
		public void ChristmasTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Christmas());
			Assert.IsTrue(value.IsHoliday());
		}

		public static IEnumerable<DateTime> ChristmasObservedDays = new DateTime[] { new DateTime(2019, 12, 25), new DateTime(2020, 12, 25), new DateTime(2021, 12, 24) };

		[Test]
		[TestCaseSource("ChristmasObservedDays")]
		public void ChristmasObservedTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Christmas());
			Assert.IsTrue(value.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DateTime> ChristmasEveDays = new DateTime[] { new DateTime(2019, 12, 24), new DateTime(2020, 12, 24), new DateTime(2021, 12, 24) };

		[Test]
		[TestCaseSource("ChristmasEveDays")]
		public void ChristmasEveTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new ChristmasEve());
			Assert.IsTrue(value.IsHoliday());
		}

		public static IEnumerable<DateTime> EasterSundays = new DateTime[] { new DateTime(2019, 4, 21), new DateTime(2020, 4, 12), new DateTime(2021, 4, 4) };

		[Test]
		[TestCaseSource("EasterSundays")]
		public void EasterSundayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new EasterSunday());
			Assert.IsTrue(value.IsHoliday());
		}

		public static IEnumerable<DateTime> GoodFridays = new DateTime[] { new DateTime(2019, 4, 19), new DateTime(2020, 4, 10), new DateTime(2021, 4, 2) };

		[Test]
		[TestCaseSource("GoodFridays")]
		public void GoodFridayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new GoodFriday());
			Assert.IsTrue(value.IsHoliday());
		}

		public static IEnumerable<DateTime> PalmSundays = new DateTime[] { new DateTime(2019, 4, 14), new DateTime(2020, 4, 5), new DateTime(2021, 3, 28) };

		[Test]
		[TestCaseSource("PalmSundays")]
		public void PalmSundayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new PalmSunday());
			Assert.IsTrue(value.IsHoliday());
		}

		public static IEnumerable<DateTime> NationalDayOfPrayerDays = new DateTime[] { new DateTime(2019, 5, 2), new DateTime(2020, 5, 7), new DateTime(2021, 5, 6) };

		[Test]
		[TestCaseSource("NationalDayOfPrayerDays")]
		public void NationalDayOfPrayerTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new NationalDayOfPrayer());
			Assert.IsTrue(value.IsHoliday());
		}
	}
}