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
using Innovative.Tests.Shared;
using NUnit.Framework;

namespace Innovative.Holiday.Religious.Christian.Tests
{
	public class ReligiousChristianHolidayTests
	{
		[SetUp]
		public void Setup()
		{
			Holidays.MyHolidays.Clear();
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
			Holidays.MyHolidays.Add(new Christmas());
            Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void ChristmasYearTest(int year)
		{
			Christmas holiday = new Christmas();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("ChristmasObservedDays")]
		public void ChristmasObservedTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new Christmas());
            Assert2.IsTrue(value.IsHoliday(HolidayOccurrenceType.Observed));
		}

		[Test]
		[TestCaseSource("Years")]
		public void ChristmasObservedYearTest(int year)
		{
			Christmas holiday = new Christmas();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("ChristmasEveDays")]
		public void ChristmasEveTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new ChristmasEve());
            Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void ChristmasEveYearTest(int year)
		{
			ChristmasEve holiday = new ChristmasEve();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("EasterSundays")]
		public void EasterTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new Easter());
            Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void EasterYearTest(int year)
		{
			Easter holiday = new Easter();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("GoodFridays")]
		public void GoodFridayTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new GoodFriday());
            Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void GoodFridayYearTest(int year)
		{
			GoodFriday holiday = new GoodFriday();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("PalmSundays")]
		public void PalmSundayTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new PalmSunday());
            Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void PalmSundayYearTest(int year)
		{
			PalmSunday holiday = new PalmSunday();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		[Test]
		[TestCaseSource("NationalDayOfPrayerDays")]
		public void NationalDayOfPrayerTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new NationalDayOfPrayer());
            Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		public void NationalDayOfPrayerYearTest(int year)
		{
			NationalDayOfPrayer holiday = new NationalDayOfPrayer();
            Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		public static IEnumerable<DateTime> EasterSundayDays = new DateTime[] { new DateTime(2019, 4, 21), new DateTime(2020, 4, 12), new DateTime(2021, 4, 4) };

		[Test]
		[TestCaseSource("EasterSundayDays")]
		[System.Obsolete]
		public void EasterSundayDeprecatedTest(DateTime value)
		{
			Holidays.MyHolidays.Add(new EasterSunday());
			Assert2.IsTrue(value.IsHoliday());
		}

		[Test]
		[TestCaseSource("Years")]
		[System.Obsolete]
		public void EasterSundayDeprecatedYearTest(int year)
		{
			EasterSunday holiday = new EasterSunday();
			Assert2.AreEqual(year, holiday.GetByYear(year).Year);
		}

		public static IEnumerable<(int Year, int Month, int Day)> EasterCalculatorDates = new (int, int, int)[]
		{
			(2019, 4, 21),
			(2020, 4, 12),
			(2021, 4, 4),
			(2022, 4, 17),
			(2023, 4, 9),
			(2024, 3, 31)
		};

		[Test]
		[TestCaseSource("EasterCalculatorDates")]
		public void EasterSundayCalculatorTest((int Year, int Month, int Day) value)
		{
			EasterSundayCalculator calculator = new EasterSundayCalculator(value.Year);
			DateTime expected = new DateTime(value.Year, value.Month, value.Day);
			Assert2.AreEqual(expected, calculator.Date);
		}
	}
}