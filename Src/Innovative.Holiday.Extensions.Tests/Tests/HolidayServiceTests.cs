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
using Innovative.Holiday.Us.Federal;
using Innovative.Tests.Shared;
using NUnit.Framework;

namespace Innovative.Holiday.Extensions.Tests
{
	public class HolidayServiceTests
	{
		//
		// NewYearsDay 2019: January 1 (Tuesday) → observed January 1 (no roll needed)
		// VeteransDay 2017: November 11 (Saturday) → observed November 10 (Friday)
		//
		private static readonly DateTime NewYears2019Actual = new DateTime(2019, 1, 1);
		private static readonly DateTime VeteransDay2017Actual = new DateTime(2017, 11, 11);
		private static readonly DateTime VeteransDay2017Observed = new DateTime(2017, 11, 10);
		private static readonly DateTime NonHolidayDate = new DateTime(2019, 4, 15);

		private static HolidayList BuildList(params IHoliday[] holidays)
		{
			return new HolidayList(holidays);
		}

		[Test]
		public void HolidayServiceDefaultConstructorTest()
		{
			HolidayService service = new HolidayService();
			Assert2.AreEqual(false, service.IsHoliday(NewYears2019Actual));
		}

		[Test]
		public void GetHolidayActualDateReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = service.GetHoliday(NewYears2019Actual, HolidayOccurrenceType.Actual);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void GetHolidayNonHolidayReturnsEmptyTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = service.GetHoliday(NonHolidayDate, HolidayOccurrenceType.Actual);
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public void GetHolidayObservedDateReturnsHolidayTest()
		{
			HolidayList list = BuildList(new VeteransDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = service.GetHoliday(VeteransDay2017Observed, HolidayOccurrenceType.Observed);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void GetHolidayObservedNonHolidayReturnsEmptyTest()
		{
			HolidayList list = BuildList(new VeteransDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = service.GetHoliday(NonHolidayDate, HolidayOccurrenceType.Observed);
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public void GetHolidayAnyActualDateReturnsHolidayTest()
		{
			HolidayList list = BuildList(new VeteransDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = service.GetHoliday(VeteransDay2017Actual, HolidayOccurrenceType.Any);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void GetHolidayAnyObservedDateReturnsHolidayTest()
		{
			HolidayList list = BuildList(new VeteransDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = service.GetHoliday(VeteransDay2017Observed, HolidayOccurrenceType.Any);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void IsHolidayActualDateReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			Assert2.IsTrue(service.IsHoliday(NewYears2019Actual, HolidayOccurrenceType.Actual));
		}

		[Test]
		public void IsHolidayNonHolidayReturnsFalseTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			Assert2.AreEqual(false, service.IsHoliday(NonHolidayDate, HolidayOccurrenceType.Actual));
		}

		[Test]
		public void IsHolidayObservedDateReturnsTrueTest()
		{
			HolidayList list = BuildList(new VeteransDay());
			HolidayService service = new HolidayService(list);

			Assert2.IsTrue(service.IsHoliday(VeteransDay2017Observed, HolidayOccurrenceType.Observed));
		}

		// Nullable DateTime overloads
		[Test]
		public void GetHolidayNullableDateTimeNullReturnsEmptyTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTime? nullDate = null;
			IEnumerable<IHoliday> result = service.GetHoliday(nullDate);
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public void GetHolidayNullableDateTimeWithValueReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTime? date = NewYears2019Actual;
			IEnumerable<IHoliday> result = service.GetHoliday(date);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void IsHolidayNullableDateTimeNullReturnsFalseTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTime? nullDate = null;
			Assert2.AreEqual(false, service.IsHoliday(nullDate));
		}

		[Test]
		public void IsHolidayNullableDateTimeWithValueReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTime? date = NewYears2019Actual;
			Assert2.IsTrue(service.IsHoliday(date));
		}

		// DateTimeOffset overloads
		[Test]
		public void GetHolidayDateTimeOffsetReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			IEnumerable<IHoliday> result = service.GetHoliday(date, HolidayOccurrenceType.Actual);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void IsHolidayDateTimeOffsetReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			Assert2.IsTrue(service.IsHoliday(date, HolidayOccurrenceType.Actual));
		}

		// Nullable DateTimeOffset overloads
		[Test]
		public void GetHolidayNullableDateTimeOffsetNullReturnsEmptyTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? nullDate = null;
			IEnumerable<IHoliday> result = service.GetHoliday(nullDate);
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public void GetHolidayNullableDateTimeOffsetWithValueReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			IEnumerable<IHoliday> result = service.GetHoliday(date);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public void IsHolidayNullableDateTimeOffsetNullReturnsFalseTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? nullDate = null;
			Assert2.AreEqual(false, service.IsHoliday(nullDate));
		}

		[Test]
		public void IsHolidayNullableDateTimeOffsetWithValueReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			Assert2.IsTrue(service.IsHoliday(date));
		}

		// Async overloads
		[Test]
		public async Task GetHolidayAsyncDateTimeReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			IEnumerable<IHoliday> result = await service.GetHolidayAsync(NewYears2019Actual, HolidayOccurrenceType.Actual);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public async Task IsHolidayAsyncDateTimeReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			bool result = await service.IsHolidayAsync(NewYears2019Actual, HolidayOccurrenceType.Actual);
			Assert2.IsTrue(result);
		}

		[Test]
		public async Task GetHolidayAsyncNullableDateTimeNullReturnsEmptyTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTime? nullDate = null;
			IEnumerable<IHoliday> result = await service.GetHolidayAsync(nullDate);
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public async Task IsHolidayAsyncNullableDateTimeNullReturnsFalseTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTime? nullDate = null;
			bool result = await service.IsHolidayAsync(nullDate);
			Assert2.AreEqual(false, result);
		}

		[Test]
		public async Task GetHolidayAsyncDateTimeOffsetReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			IEnumerable<IHoliday> result = await service.GetHolidayAsync(date, HolidayOccurrenceType.Actual);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public async Task IsHolidayAsyncDateTimeOffsetReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			bool result = await service.IsHolidayAsync(date, HolidayOccurrenceType.Actual);
			Assert2.IsTrue(result);
		}

		[Test]
		public async Task GetHolidayAsyncNullableDateTimeOffsetNullReturnsEmptyTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? nullDate = null;
			IEnumerable<IHoliday> result = await service.GetHolidayAsync(nullDate);
			Assert2.AreEqual(0, result.Count());
		}

		[Test]
		public async Task IsHolidayAsyncNullableDateTimeOffsetNullReturnsFalseTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? nullDate = null;
			bool result = await service.IsHolidayAsync(nullDate);
			Assert2.AreEqual(false, result);
		}

		[Test]
		public async Task GetHolidayAsyncNullableDateTimeOffsetWithValueReturnsHolidayTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			IEnumerable<IHoliday> result = await service.GetHolidayAsync(date);
			Assert2.AreEqual(1, result.Count());
		}

		[Test]
		public async Task IsHolidayAsyncNullableDateTimeOffsetWithValueReturnsTrueTest()
		{
			HolidayList list = BuildList(new NewYearsDay());
			HolidayService service = new HolidayService(list);

			DateTimeOffset? date = new DateTimeOffset(NewYears2019Actual, TimeSpan.Zero);
			bool result = await service.IsHolidayAsync(date);
			Assert2.IsTrue(result);
		}
	}
}
