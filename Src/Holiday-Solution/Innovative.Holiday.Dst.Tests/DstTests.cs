using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Innovative.Holiday.Dst.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.ObservedHolidays.Clear();
		}

		public static IEnumerable<DateTime> StartDstDays = new DateTime[] { new DateTime(2019, 3, 8), new DateTime(2020, 3, 8), new DateTime(2021, 3, 8) };

		[Test]
		[TestCaseSource("StartDstDays")]
		public void StartDstTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new StartDst());
			Assert.IsTrue(value.IsHoliday());
		}

		public static IEnumerable<DateTime> EndDstDays = new DateTime[] { new DateTime(2019, 11, 1), new DateTime(2020, 11, 1), new DateTime(2021, 11, 1) };

		[Test]
		[TestCaseSource("EndDstDays")]
		public void EndDstTest(DateTime value)
		{
			Holidays.ObservedHolidays.Add(new EndDst());
			Assert.IsTrue(value.IsHoliday());
		}
	}
}