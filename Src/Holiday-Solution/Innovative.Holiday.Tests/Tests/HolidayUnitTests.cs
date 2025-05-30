//
// Copyright(C) 2013-2025, Daniel M. Porrey. All rights reserved.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
//
using System;
using System.Collections.Generic;
using System.Linq;
using Innovative.Holiday.Tests.Mocks;
using Innovative.Tests.Shared;
using NUnit.Framework;

namespace Innovative.Holiday.Tests
{
	public class HolidayUnitTests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.MyHolidays.Clear();
		}

		[Test]
		public void HolidayTest()
		{
			//
			// Create a holiday tomorrow.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Monday);

			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
                Assert2.IsTrue(holidayDate.IsHoliday());
                Assert2.AreEqual(holiday.NextDateTime.Date, holidayDate.Date);
			});
		}

		[Test]
		public void HolidayObservedNoRollForwardTest()
		{
			//
			// Create a holiday next Sunday.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Sunday);

			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
                Assert2.IsTrue(holidayDate.IsHoliday());
                Assert2.AreEqual(holiday.NextDateTime.Date, holidayDate.Date);
			});
		}

		[Test]
		public void HolidayObservedNoRollBackTest()
		{
			//
			// Create a holiday next Saturday.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);

			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
                Assert2.IsTrue(holidayDate.IsHoliday());
                Assert2.AreEqual(holiday.NextDateTime.Date, holidayDate.Date);
			});
		}

		[Test]
		public void FederalHolidayTest()
		{
			//
			// Create a holiday next Monday.
			//
			DateTime holidayDate = DateTime.Now.AddDays(1);

			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
                Assert2.IsTrue(holiday is IObservedHoliday);
                Assert2.IsTrue(holidayDate.IsHoliday());
                Assert2.AreEqual(holiday.NextDateTime.Date, holidayDate.Date);
			});
		}

		[Test]
		public void FederalHolidayObservedRoolForwardTest()
		{
			//
			// Create a holiday next Sunday.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Sunday);
			DateTime observedDate = holidayDate.AddDays(1);

			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
                Assert2.IsTrue(holiday is IObservedHoliday);
                Assert2.IsTrue(holidayDate.IsHoliday());
                Assert2.AreEqual(holiday.NextDateTime.Date, holidayDate.Date);
                Assert2.AreEqual(holiday.NextObserved.Date, observedDate.Date);
			});
		}

		[Test]
		public void FederalHolidayObservedRollBackTest()
		{
			//
			// Create a holiday next Saturday.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);
			DateTime observedDate = holidayDate.Subtract(TimeSpan.FromDays(1));

			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
                Assert2.IsTrue(holiday is IObservedHoliday);
                Assert2.IsTrue(holidayDate.IsHoliday());
				Assert2.AreEqual(holiday.NextDateTime.Date, holidayDate.Date);
				Assert2.AreEqual(holiday.NextObserved.Date, observedDate.Date);
			});
		}

		[Test]
		public void HolidayListAddTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"2/1");
			list.Add(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, list.Count());
				Assert2.AreEqual(holiday, list.First());
			});
		}

		[Test]
		public void HolidayListAddRangeTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday($"2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday($"3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday($"4/1");
			MockDayOfYearHoliday holiday4 = new MockDayOfYearHoliday($"5/1");

			list.AddRange(new IHoliday[] { holiday1, holiday2, holiday3, holiday4 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(4, list.Count());
				Assert2.AreEqual(holiday1, list.First());
				Assert2.AreEqual(holiday4, list.Last());
			});
		}

		[Test]
		public void HolidayListRemoveTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"2/1");
			list.Add(holiday);
			list.Remove(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(0, list.Count());
			});
		}

		[Test]
		public void ObservedHolidaysAddTest()
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"2/1");
			Holidays.MyHolidays.Add(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday, Holidays.MyHolidays.First());
			});
		}

		[Test]
		public void ObservedHolidaysAddRangeTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday($"2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday($"3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday($"4/1");
			MockDayOfYearHoliday holiday4 = new MockDayOfYearHoliday($"5/1");

			Holidays.MyHolidays.AddRange(new IHoliday[] { holiday1, holiday2, holiday3, holiday4 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(4, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday1, Holidays.MyHolidays.First());
				Assert2.AreEqual(holiday4, Holidays.MyHolidays.Last());
			});
		}

		[Test]
		public void ObservedHolidaysRemoveTest()
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"2/1");
			Holidays.MyHolidays.Add(holiday);
			Holidays.MyHolidays.Remove(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(0, Holidays.MyHolidays.Count());
			});
		}

		[Test]
		public void DateTimeOffsetIsHoliday()
		{
			//
			// Create a holiday tomorrow.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Monday);

			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			//
			// Get a DateTimeOffset with the same date as the holiday.
			//
			DateTimeOffset checkdate = DateTimeOffset.Now.NextDayOfWeek(DayOfWeek.Monday);

			Assert2.IsTrue(checkdate.IsHoliday());
		}

		[Test]
		public void DateTimeOffsetGetHoliday()
		{
			//
			// Create a holiday tomorrow.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Monday);

			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			//
			// Get a DateTimeOffset with the same date as the holiday.
			//
			DateTimeOffset checkdate = DateTimeOffset.Now.NextDayOfWeek(DayOfWeek.Monday);

			Assert2.AreSame(checkdate.GetHoliday().Single(), holiday);
		}

		[Test]
		public void IsHolidayActual()
		{
			//
			// Create a holiday tomorrow.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);

			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			//
			// Get a DateTimeOffset with the same date as the holiday.
			//
			DateTime checkdate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);

			Assert2.IsTrue(checkdate.IsHoliday(HolidayOccurrenceType.Actual));
		}

		[Test]
		public void IsHolidayObserved()
		{
			//
			// Create a holiday tomorrow.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);

			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			//
			// Get a DateTimeOffset with the same date as the holiday.
			//
			DateTime checkdate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday).Subtract(TimeSpan.FromDays(1));

			Assert2.IsTrue(checkdate.IsHoliday(HolidayOccurrenceType.Observed));
		}

		[Test]
		public void IsHolidayAny()
		{
			//
			// Create a holiday tomorrow.
			//
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);

			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			//
			// Get a DateTimeOffset with the same date as the holiday.
			//
			DateTime checkdate1 = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday).Subtract(TimeSpan.FromDays(1));
			DateTime checkdate2 = DateTime.Now.NextDayOfWeek(DayOfWeek.Saturday);

			Assert2.IsTrue(checkdate1.IsHoliday(HolidayOccurrenceType.Any));
			Assert2.IsTrue(checkdate2.IsHoliday(HolidayOccurrenceType.Any));
		}

		public static IEnumerable<int> Years = new int[] { 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024 };

		[Test]
		[TestCaseSource("Years")]
		public void DayOfYearGetByYearTest(int year)
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("1/1");
			DateTime dateByYear = holiday.GetByYear(year);
			Assert2.AreEqual(dateByYear.Year, year);
		}

		[Test]
		[TestCaseSource("Years")]
		public void DayOfYearGetObservedByYearTest(int year)
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("1/1");
			DateTime dateByYear = holiday.GetByYear(year);
			Assert2.AreEqual(dateByYear.Year, year);
		}
	}
}