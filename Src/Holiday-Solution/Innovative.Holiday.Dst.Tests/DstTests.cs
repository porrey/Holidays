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