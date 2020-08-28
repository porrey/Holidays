using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Innovative.Holiday.Us.Others.Tests
{
	public class UsHolidaysTests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.ObservedHolidays.Clear();
		}

		public static IEnumerable<int> Years => Enumerable.Range(2000, 35);
		public static IEnumerable<DateTime> AprilFoolsDays = new DateTime[] { new DateTime(2019, 4, 1), new DateTime(2020, 4, 1), new DateTime(2021, 4, 1) };
		public static IEnumerable<DateTime> ArmedForcesDays = new DateTime[] { new DateTime(2019, 5, 18), new DateTime(2020, 5, 16), new DateTime(2021, 5, 15) };
		public static IEnumerable<DateTime> CincoDeMayoDays = new DateTime[] { new DateTime(2019, 5, 5), new DateTime(2020, 5, 5), new DateTime(2021, 5, 5) };
		public static IEnumerable<DateTime> FathersDays = new DateTime[] { new DateTime(2019, 6, 16), new DateTime(2020, 6, 21), new DateTime(2021, 6, 20) };
		public static IEnumerable<DateTime> FlagDays = new DateTime[] { new DateTime(2019, 6, 14), new DateTime(2020, 6, 14), new DateTime(2021, 6, 14) };
		public static IEnumerable<DateTime> GroundhogDays = new DateTime[] { new DateTime(2019, 2, 2), new DateTime(2020, 2, 2), new DateTime(2021, 2, 2) };
		public static IEnumerable<DateTime> HalloweenDays = new DateTime[] { new DateTime(2019, 10, 31), new DateTime(2020, 10, 31), new DateTime(2021, 10, 31) };
		public static IEnumerable<DateTime> JuneteenthDays = new DateTime[] { new DateTime(2019, 6, 19), new DateTime(2020, 6, 19), new DateTime(2021, 6, 19) };
		public static IEnumerable<DateTime> MothersDays = new DateTime[] { new DateTime(2019, 5, 12), new DateTime(2020, 5, 10), new DateTime(2021, 5, 9) };
		public static IEnumerable<DateTime> NewYearsEveDays = new DateTime[] { new DateTime(2019, 12, 31), new DateTime(2020, 12, 31), new DateTime(2021, 12, 31) };
		public static IEnumerable<DateTime> SaintPatricksDays = new DateTime[] { new DateTime(2019, 3, 17), new DateTime(2020, 3, 17), new DateTime(2021, 3, 17) };
		public static IEnumerable<DateTime> ValentinesDays = new DateTime[] { new DateTime(2019, 2, 14), new DateTime(2020, 2, 14), new DateTime(2021, 2, 14) };

		[Test]
		[TestCaseSource("AprilFoolsDays")]
		public void AprilFoolsDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new AprilFoolsDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void AprilFoolsDayYearTest(int year)
		{
			AprilFoolsDay holiday = new AprilFoolsDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("ArmedForcesDays")]
		public void ArmedForcesDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new ArmedForcesDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void ArmedForcesDayYearTest(int year)
		{
			ArmedForcesDay holiday = new ArmedForcesDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("CincoDeMayoDays")]
		public void CincoDeMayoTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new CincoDeMayo());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void CincoDeMayoYearTest(int year)
		{
			CincoDeMayo holiday = new CincoDeMayo();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("FathersDays")]
		public void FathersDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new FathersDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void FathersDayYearTest(int year)
		{
			FathersDay holiday = new FathersDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("FlagDays")]
		public void FlagDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new FlagDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void FlagDayYearTest(int year)
		{
			FlagDay holiday = new FlagDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("GroundhogDays")]
		public void GroundhogDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new GroundhogDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void GroundhogDayYearTest(int year)
		{
			GroundhogDay holiday = new GroundhogDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("HalloweenDays")]
		public void HalloweenTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Halloween());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void HalloweenYearTest(int year)
		{
			Halloween holiday = new Halloween();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("JuneteenthDays")]
		public void JuneteenthTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new Juneteenth());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void JuneteenthYearTest(int year)
		{
			Juneteenth holiday = new Juneteenth();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("MothersDays")]
		public void MothersDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new MothersDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void MothersDayYearTest(int year)
		{
			MothersDay holiday = new MothersDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("NewYearsEveDays")]
		public void NewYearsEveTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new NewYearsEve());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void NewYearsEveYearTest(int year)
		{
			NewYearsEve holiday = new NewYearsEve();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("SaintPatricksDays")]
		public void SaintPatricksDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new SaintPatricksDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void SaintPatricksDayYearTest(int year)
		{
			SaintPatricksDay holiday = new SaintPatricksDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}

		[Test]
		[TestCaseSource("ValentinesDays")]
		public void ValentinesDayTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new ValentinesDay());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void ValentinesDayYearTest(int year)
		{
			ValentinesDay holiday = new ValentinesDay();

			Assert.Multiple(() =>
			{
				Assert.AreEqual(year, holiday.GetByYear(year).Year);
				Assert.AreEqual(year, holiday.GetObservedByYear(year).Year);
			});
		}
	}
}