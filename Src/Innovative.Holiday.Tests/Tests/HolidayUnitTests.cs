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
using System.Threading.Tasks;
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

		[Test]
		public void HolidayListConstructorFromEnumerableTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			HolidayList list = new HolidayList(new IHoliday[] { holiday1, holiday2 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(2, list.Count());
				Assert2.AreEqual(holiday1, list.First());
				Assert2.AreEqual(holiday2, list.Last());
			});
		}

		[Test]
		public void HolidayListConstructorFromParamsTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			HolidayList list = new HolidayList(holiday1, holiday2);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(2, list.Count());
				Assert2.AreEqual(holiday1, list.First());
				Assert2.AreEqual(holiday2, list.Last());
			});
		}

		[Test]
		public async Task HolidayListAddAsyncTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("2/1");
			await list.AddAsync(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, list.Count());
				Assert2.AreEqual(holiday, list.First());
			});
		}

		[Test]
		public async Task HolidayListAddRangeAsyncTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday("4/1");
			await list.AddRangeAsync(new IHoliday[] { holiday1, holiday2, holiday3 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(3, list.Count());
				Assert2.AreEqual(holiday1, list.First());
				Assert2.AreEqual(holiday3, list.Last());
			});
		}

		[Test]
		public void HolidayListAddRangesTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday("4/1");
			MockDayOfYearHoliday holiday4 = new MockDayOfYearHoliday("5/1");
			list.AddRanges(new IHoliday[] { holiday1, holiday2 }, new IHoliday[] { holiday3, holiday4 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(4, list.Count());
				Assert2.AreEqual(holiday1, list.First());
				Assert2.AreEqual(holiday4, list.Last());
			});
		}

		[Test]
		public async Task HolidayListAddRangesAsyncTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday("4/1");
			MockDayOfYearHoliday holiday4 = new MockDayOfYearHoliday("5/1");
			await list.AddRangesAsync(new IHoliday[] { holiday1, holiday2 }, new IHoliday[] { holiday3, holiday4 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(4, list.Count());
				Assert2.AreEqual(holiday1, list.First());
				Assert2.AreEqual(holiday4, list.Last());
			});
		}

		[Test]
		public async Task HolidayListRemoveAsyncTest()
		{
			HolidayList list = new HolidayList();
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("2/1");
			list.Add(holiday);
			bool result = await list.RemoveAsync(holiday);

			Assert.Multiple(() =>
			{
				Assert2.IsTrue(result);
				Assert2.AreEqual(0, list.Count());
			});
		}

		[Test]
		public void HolidaysRegisterSingleTest()
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("2/1");
			Holidays.Register(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday, Holidays.MyHolidays.First());
			});
		}

		[Test]
		public void HolidaysRegisterEnumerableTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			Holidays.Register(new IHoliday[] { holiday1, holiday2 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(2, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday1, Holidays.MyHolidays.First());
				Assert2.AreEqual(holiday2, Holidays.MyHolidays.Last());
			});
		}

		[Test]
		public void HolidaysRegisterMultipleRangesTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday("4/1");
			MockDayOfYearHoliday holiday4 = new MockDayOfYearHoliday("5/1");
			Holidays.Register(new IHoliday[] { holiday1, holiday2 }, new IHoliday[] { holiday3, holiday4 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(4, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday1, Holidays.MyHolidays.First());
				Assert2.AreEqual(holiday4, Holidays.MyHolidays.Last());
			});
		}

		[Test]
		public async Task HolidaysRegisterAsyncSingleTest()
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("2/1");
			await Holidays.RegisterAsync(holiday);

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday, Holidays.MyHolidays.First());
			});
		}

		[Test]
		public async Task HolidaysRegisterAsyncEnumerableTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			await Holidays.RegisterAsync(new IHoliday[] { holiday1, holiday2 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(2, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday1, Holidays.MyHolidays.First());
				Assert2.AreEqual(holiday2, Holidays.MyHolidays.Last());
			});
		}

		[Test]
		public async Task HolidaysRegisterAsyncMultipleRangesTest()
		{
			MockDayOfYearHoliday holiday1 = new MockDayOfYearHoliday("2/1");
			MockDayOfYearHoliday holiday2 = new MockDayOfYearHoliday("3/1");
			MockDayOfYearHoliday holiday3 = new MockDayOfYearHoliday("4/1");
			MockDayOfYearHoliday holiday4 = new MockDayOfYearHoliday("5/1");
			await Holidays.RegisterAsync(new IHoliday[] { holiday1, holiday2 }, new IHoliday[] { holiday3, holiday4 });

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(4, Holidays.MyHolidays.Count());
				Assert2.AreEqual(holiday1, Holidays.MyHolidays.First());
				Assert2.AreEqual(holiday4, Holidays.MyHolidays.Last());
			});
		}

		[Test]
		public void HolidayToStringTest()
		{
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday("7/4");
			string result = holiday.ToString();
			Assert2.IsTrue(result.Contains("Mock Holiday"));
		}

		[Test]
		public void ObservedHolidayToStringTest()
		{
			MockDayOfYearFederalHoliday holiday = new MockDayOfYearFederalHoliday("7/4");
			string result = holiday.ToString();
			Assert2.IsTrue(result.Contains("Mock Federal Holiday"));
		}

		[Test]
		public void FederalHolidayRuleMondayNoChangeTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime monday = new DateTime(2019, 7, 1); // Monday
			Assert2.AreEqual(monday, rule.AdjustedDate(monday));
		}

		[Test]
		public void FederalHolidayRuleTuesdayNoChangeTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime tuesday = new DateTime(2019, 7, 2); // Tuesday
			Assert2.AreEqual(tuesday, rule.AdjustedDate(tuesday));
		}

		[Test]
		public void FederalHolidayRuleWednesdayNoChangeTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime wednesday = new DateTime(2019, 7, 3); // Wednesday
			Assert2.AreEqual(wednesday, rule.AdjustedDate(wednesday));
		}

		[Test]
		public void FederalHolidayRuleThursdayNoChangeTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime thursday = new DateTime(2019, 7, 4); // Thursday
			Assert2.AreEqual(thursday, rule.AdjustedDate(thursday));
		}

		[Test]
		public void FederalHolidayRuleFridayNoChangeTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime friday = new DateTime(2019, 7, 5); // Friday
			Assert2.AreEqual(friday, rule.AdjustedDate(friday));
		}

		[Test]
		public void FederalHolidayRuleSaturdayRollBackTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime saturday = new DateTime(2019, 7, 6); // Saturday
			DateTime expectedFriday = new DateTime(2019, 7, 5); // Friday
			Assert2.AreEqual(expectedFriday, rule.AdjustedDate(saturday));
		}

		[Test]
		public void FederalHolidayRuleSundayRollForwardTest()
		{
			FederalHolidayRule rule = new FederalHolidayRule();
			DateTime sunday = new DateTime(2019, 7, 7); // Sunday
			DateTime expectedMonday = new DateTime(2019, 7, 8); // Monday
			Assert2.AreEqual(expectedMonday, rule.AdjustedDate(sunday));
		}

		[Test]
		public void NullableDateTimeIsHolidayNullTest()
		{
			DateTime? nullDate = null;

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(false, nullDate.IsHoliday());
				Assert2.AreEqual(false, nullDate.IsHoliday(HolidayOccurrenceType.Any));
			});
		}

		[Test]
		public void NullableDateTimeIsHolidayWithValueTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTime? nullableDate = holidayDate;
			Assert2.IsTrue(nullableDate.IsHoliday());
		}

		[Test]
		public void NullableDateTimeGetHolidayNullTest()
		{
			DateTime? nullDate = null;
			IEnumerable<IHoliday> result = nullDate.GetHoliday();
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public void NullableDateTimeGetHolidayWithValueTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTime? nullableDate = holidayDate;
			IEnumerable<IHoliday> result = nullableDate.GetHoliday();

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, result.Count());
				Assert2.AreSame(result.Single(), holiday);
			});
		}

		[Test]
		public async Task DateTimeIsHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Wednesday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			bool result = await holidayDate.IsHolidayAsync();
			Assert2.IsTrue(result);
		}

		[Test]
		public async Task DateTimeGetHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Wednesday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			IEnumerable<IHoliday> result = await holidayDate.GetHolidayAsync();

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, result.Count());
				Assert2.AreSame(result.Single(), holiday);
			});
		}

		[Test]
		public void NullableDateTimeOffsetIsHolidayNullTest()
		{
			DateTimeOffset? nullDate = null;
			Assert2.AreEqual(false, nullDate.IsHoliday());
		}

		[Test]
		public void NullableDateTimeOffsetIsHolidayWithValueTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Thursday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTimeOffset? nullableDate = new DateTimeOffset(holidayDate, TimeSpan.Zero);
			Assert2.IsTrue(nullableDate.IsHoliday());
		}

		[Test]
		public void NullableDateTimeOffsetGetHolidayNullTest()
		{
			DateTimeOffset? nullDate = null;
			IEnumerable<IHoliday> result = nullDate.GetHoliday();
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public void NullableDateTimeOffsetGetHolidayWithValueTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Thursday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTimeOffset? nullableDate = new DateTimeOffset(holidayDate, TimeSpan.Zero);
			IEnumerable<IHoliday> result = nullableDate.GetHoliday();
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public async Task DateTimeOffsetIsHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Friday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTimeOffset checkDate = new DateTimeOffset(holidayDate, TimeSpan.Zero);
			bool result = await checkDate.IsHolidayAsync();
			Assert2.IsTrue(result);
		}

		[Test]
		public async Task DateTimeOffsetGetHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Friday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTimeOffset checkDate = new DateTimeOffset(holidayDate, TimeSpan.Zero);
			IEnumerable<IHoliday> result = await checkDate.GetHolidayAsync();
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public async Task NullableDateTimeIsHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTime? nullableDate = holidayDate;
			bool result = await nullableDate.IsHolidayAsync();
			Assert2.IsTrue(result);
		}

		[Test]
		public async Task NullableDateTimeGetHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTime? nullableDate = holidayDate;
			IEnumerable<IHoliday> result = await nullableDate.GetHolidayAsync();

			Assert.Multiple(() =>
			{
				Assert2.AreEqual(1, result.Count());
				Assert2.AreSame(result.Single(), holiday);
			});
		}

		[Test]
		public async Task NullableDateTimeOffsetIsHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Thursday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTimeOffset? nullableDate = new DateTimeOffset(holidayDate, TimeSpan.Zero);
			bool result = await nullableDate.IsHolidayAsync();
			Assert2.IsTrue(result);
		}

		[Test]
		public async Task NullableDateTimeOffsetGetHolidayAsyncTest()
		{
			DateTime holidayDate = DateTime.Now.NextDayOfWeek(DayOfWeek.Thursday);
			MockDayOfYearHoliday holiday = new MockDayOfYearHoliday($"{holidayDate.Month}/{holidayDate.Day}");
			Holidays.MyHolidays.Add(holiday);

			DateTimeOffset? nullableDate = new DateTimeOffset(holidayDate, TimeSpan.Zero);
			IEnumerable<IHoliday> result = await nullableDate.GetHolidayAsync();
			Assert2.AreEqual(1, result.Count());
		}
	}
}