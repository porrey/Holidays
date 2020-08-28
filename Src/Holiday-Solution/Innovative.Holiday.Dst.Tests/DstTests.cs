using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Innovative.Holiday.Dst.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.MyHolidays.Clear();
		}

		public static IEnumerable<int> Years => Enumerable.Range(2000, 35);
		public static IEnumerable<DateTime> StartDstDays = new DateTime[] { new DateTime(2019, 3, 8), new DateTime(2020, 3, 8), new DateTime(2021, 3, 8) };
		public static IEnumerable<DateTime> EndDstDays = new DateTime[] { new DateTime(2019, 11, 1), new DateTime(2020, 11, 1), new DateTime(2021, 11, 1) };

		[Test]
		[TestCaseSource("StartDstDays")]
		public void StartDstTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new StartDst());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void StartDstTest(int year)
		{
			StartDst holiday = new StartDst();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("EndDstDays")]
		public void EndDstTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new EndDst());
			Assert.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void EndDstYearTest(int year)
		{
			EndDst holiday = new EndDst();
			Assert.AreEqual(year, holiday.GetByYear(year).Year);
		}

	}
}