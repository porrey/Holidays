//
// Copyright(C) 2013-2024, Daniel M. Porrey. All rights reserved.
// 
// program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with program. If not, see http://www.gnu.org/licenses/.
//
namespace Innovative.Holiday.Extensions
{
	public class HolidayService : IHolidayService
	{
		public HolidayService()
		{
			this.HolidayList = [];
		}

		public HolidayService(HolidayList holidayList)
		{
			this.HolidayList = holidayList;
		}

		protected HolidayList HolidayList { get; set; }

		public IEnumerable<IHoliday> GetHoliday(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			IEnumerable<IHoliday> returnValue = Array.Empty<IHoliday>();

			if (holidayOccurrenceType == HolidayOccurrenceType.Actual)
			{
				returnValue = (from tbl in this.HolidayList
							   where tbl.GetByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}
			if (holidayOccurrenceType == HolidayOccurrenceType.Observed)
			{
				returnValue = (from tbl in this.HolidayList
							   where tbl is IObservedHoliday holiday &&
							   holiday.GetObservedByYear(value.Year) == value.Date
							   select tbl).ToArray();
			}
			else
			{
				returnValue = (from tbl in this.HolidayList
							   where tbl.GetByYear(value.Year) == value.Date ||
							  (tbl is IObservedHoliday holiday && holiday.GetObservedByYear(value.Year) == value.Date)
							   select tbl).ToArray();
			}

			return returnValue;
		}

		public Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.GetHoliday(value, holidayOccurrenceType));
		}

		public IEnumerable<IHoliday> GetHoliday(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			IEnumerable<IHoliday> returnValue = Array.Empty<IHoliday>();

			if (value.HasValue)
			{
				returnValue = this.GetHoliday(value.Value, holidayOccurrenceType);
			}

			return returnValue;
		}

		public Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.GetHoliday(value, holidayOccurrenceType));
		}

		public bool IsHoliday(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return this.GetHoliday(value, holidayOccurrenceType).Any();
		}

		public Task<bool> IsHolidayAsync(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.IsHoliday(value, holidayOccurrenceType));
		}

		public bool IsHoliday(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			bool returnValue = false;

			if (value.HasValue)
			{
				returnValue = this.IsHoliday(value.Value, holidayOccurrenceType);
			}

			return returnValue;
		}

		public Task<bool> IsHolidayAsync(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.IsHoliday(value.Value, holidayOccurrenceType));
		}

		public IEnumerable<IHoliday> GetHoliday(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return this.GetHoliday(value.Date, holidayOccurrenceType);
		}

		public Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.GetHoliday(value, holidayOccurrenceType));
		}

		public IEnumerable<IHoliday> GetHoliday(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			IEnumerable<IHoliday> returnValue = Array.Empty<IHoliday>();

			if (value.HasValue)
			{
				returnValue = this.GetHoliday(value.Value, holidayOccurrenceType);
			}

			return returnValue;
		}

		public Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.GetHoliday(value, holidayOccurrenceType));
		}

		public bool IsHoliday(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return this.GetHoliday(value, holidayOccurrenceType).Any();
		}

		public Task<bool> IsHolidayAsync(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.IsHoliday(value, holidayOccurrenceType));
		}

		public bool IsHoliday(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			bool returnValue = false;

			if (value.HasValue)
			{
				returnValue = this.IsHoliday(value.Value, holidayOccurrenceType);
			}

			return returnValue;
		}

		public Task<bool> IsHolidayAsync(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual)
		{
			return Task.FromResult(this.IsHoliday(value, holidayOccurrenceType));
		}
	}
}
