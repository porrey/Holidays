using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Innovative.Holiday.Us.Federal.Tests
{
	public class FederalHolidayTests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.ObservedHolidays.Clear();
		}

		public static IEnumerable<DatePair> ColumbusDays = new DatePair[] { DatePair.Create(2019, 10, 14, 14), DatePair.Create(2020, 10, 12, 12), DatePair.Create(2021, 10, 11, 11) };

		[Test]
		[TestCaseSource("ColumbusDays")]
		public void ColumbusDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new ColumbusDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> IndependenceDays = new DatePair[] { DatePair.Create(2019, 7, 4, 4), DatePair.Create(2020, 7, 4, 3), DatePair.Create(2021, 7, 4, 5) };

		[Test]
		[TestCaseSource("IndependenceDays")]
		public void IndependenceDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new IndependenceDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> LaborDays = new DatePair[] { DatePair.Create(2019, 9, 2, 2), DatePair.Create(2020, 9, 7, 7), DatePair.Create(2021, 9, 6, 6) };

		[Test]
		[TestCaseSource("LaborDays")]
		public void LaborDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new LaborDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> MartinLutherKingDays = new DatePair[] { DatePair.Create(2019, 1, 21, 21), DatePair.Create(2020, 1, 20, 20), DatePair.Create(2021, 1, 18, 18) };

		[Test]
		[TestCaseSource("MartinLutherKingDays")]
		public void MartinLutherKingDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new MartinLutherKingDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> MemorialDays = new DatePair[] { DatePair.Create(2019, 5, 27, 27), DatePair.Create(2020, 5, 25, 25), DatePair.Create(2021, 5, 31, 31) };

		[Test]
		[TestCaseSource("MemorialDays")]
		public void MemorialDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new MemorialDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> NewYearsDays = new DatePair[] { DatePair.Create(2017, 1, 1, 2), DatePair.Create(2018, 1, 1, 2), DatePair.Create(2019, 1, 1, 1), DatePair.Create(2020, 1, 1, 1), DatePair.Create(2021, 1, 1, 1), new DatePair() { Actual = new DateTime(2022, 1, 1), Observed = new DateTime(2021, 12, 31) } };

		[Test]
		[TestCaseSource("NewYearsDays")]
		public void NewYearsDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new NewYearsDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> ThanksgivingDays = new DatePair[] { DatePair.Create(2019, 11, 28, 28), DatePair.Create(2020, 11, 26, 26), DatePair.Create(2021, 11, 25, 25) };

		[Test]
		[TestCaseSource("ThanksgivingDays")]
		public void ThanksgivingDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new ThanksgivingDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> VeteransDays = new DatePair[] { DatePair.Create(2017, 11, 11, 10), DatePair.Create(2018, 11, 11, 12), DatePair.Create(2019, 11, 11, 11), DatePair.Create(2020, 11, 11, 11), DatePair.Create(2021, 11, 11, 11), DatePair.Create(2022, 11, 11, 11) };

		[Test]
		[TestCaseSource("VeteransDays")]
		public void VeteransDayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new VeteransDay());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}

		public static IEnumerable<DatePair> WashingtonsBirthdays = new DatePair[] { DatePair.Create(2019, 2, 18, 18), DatePair.Create(2020, 2, 17, 17), DatePair.Create(2021, 2, 15, 15) };

		[Test]
		[TestCaseSource("WashingtonsBirthdays")]
		public void WashingtonsBirthdayTest(DatePair value)
		{
			Holidays.ObservedHolidays.Add(new WashingtonsBirthday());
			Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
			Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
		}
	}
}
