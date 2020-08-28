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
			Holidays.MyHolidays.Clear();
		}

		public static IEnumerable<int> Years => Enumerable.Range(2000, 35);
		public static IEnumerable<DatePair> ColumbusDays = new DatePair[] { DatePair.Create(2019, 10, 14, 14), DatePair.Create(2020, 10, 12, 12), DatePair.Create(2021, 10, 11, 11) };
		public static IEnumerable<DatePair> IndependenceDays = new DatePair[] { DatePair.Create(2019, 7, 4, 4), DatePair.Create(2020, 7, 4, 3), DatePair.Create(2021, 7, 4, 5) };
		public static IEnumerable<DatePair> LaborDays = new DatePair[] { DatePair.Create(2019, 9, 2, 2), DatePair.Create(2020, 9, 7, 7), DatePair.Create(2021, 9, 6, 6) };
		public static IEnumerable<DatePair> MartinLutherKingDays = new DatePair[] { DatePair.Create(2019, 1, 21, 21), DatePair.Create(2020, 1, 20, 20), DatePair.Create(2021, 1, 18, 18) };
		public static IEnumerable<DatePair> MemorialDays = new DatePair[] { DatePair.Create(2019, 5, 27, 27), DatePair.Create(2020, 5, 25, 25), DatePair.Create(2021, 5, 31, 31) };
		public static IEnumerable<DatePair> NewYearsDays = new DatePair[] { DatePair.Create(2017, 1, 1, 2), DatePair.Create(2018, 1, 1, 2), DatePair.Create(2019, 1, 1, 1), DatePair.Create(2020, 1, 1, 1), DatePair.Create(2021, 1, 1, 1), new DatePair() { Actual = new DateTime(2022, 1, 1), Observed = new DateTime(2021, 12, 31) } };
		public static IEnumerable<DatePair> ThanksgivingDays = new DatePair[] { DatePair.Create(2019, 11, 28, 28), DatePair.Create(2020, 11, 26, 26), DatePair.Create(2021, 11, 25, 25) };
		public static IEnumerable<DatePair> VeteransDays = new DatePair[] { DatePair.Create(2017, 11, 11, 10), DatePair.Create(2018, 11, 11, 12), DatePair.Create(2019, 11, 11, 11), DatePair.Create(2020, 11, 11, 11), DatePair.Create(2021, 11, 11, 11), DatePair.Create(2022, 11, 11, 11) };
		public static IEnumerable<DatePair> WashingtonsBirthdays = new DatePair[] { DatePair.Create(2019, 2, 18, 18), DatePair.Create(2020, 2, 17, 17), DatePair.Create(2021, 2, 15, 15) };

		[Test]
		[TestCaseSource("ColumbusDays")]
		public void ColumbusDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new ColumbusDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void ColumbusDayYearTest(int year)
		{
			ColumbusDay holiday = new ColumbusDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("IndependenceDays")]
		public void IndependenceDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new IndependenceDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void IndependenceDayYearTest(int year)
		{
			IndependenceDay holiday = new IndependenceDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("LaborDays")]
		public void LaborDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new LaborDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void LaborDayYearTest(int year)
		{
			LaborDay holiday = new LaborDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("MartinLutherKingDays")]
		public void MartinLutherKingDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new MartinLutherKingDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void MartinLutherKingDayYearTest(int year)
		{
			MartinLutherKingDay holiday = new MartinLutherKingDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("MemorialDays")]
		public void MemorialDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new MemorialDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void MemorialDayYearTest(int year)
		{
			MemorialDay holiday = new MemorialDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("NewYearsDays")]
		public void NewYearsDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new NewYearsDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void NewYearsDayYearTest(int year)
		{
			NewYearsDay holiday = new NewYearsDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("ThanksgivingDays")]
		public void ThanksgivingDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new ThanksgivingDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void ThanksgivingDayYearTest(int year)
		{
			ThanksgivingDay holiday = new ThanksgivingDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("VeteransDays")]
		public void VeteransDayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new VeteransDay());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void VeteransDayYearTest(int year)
		{
			VeteransDay holiday = new VeteransDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("WashingtonsBirthdays")]
		public void WashingtonsBirthdayTest(DatePair value)
		{
			Holidays.MyHolidays.Add(new WashingtonsBirthday());

			Assert.Multiple(() =>
			{
				Assert.IsTrue(value.Actual.IsHoliday(HolidayOccurrenceType.Actual));
				Assert.IsTrue(value.Observed.IsHoliday(HolidayOccurrenceType.Observed));
			});
		}

		[Test]
		[TestCaseSource("Years")]
		public void WashingtonsBirthdayYearTest(int year)
		{
			WashingtonsBirthday holiday = new WashingtonsBirthday();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}
	}
}
