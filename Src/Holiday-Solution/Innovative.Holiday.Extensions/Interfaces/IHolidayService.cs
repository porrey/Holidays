﻿//
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
namespace Innovative.Holiday.Extensions
{
	public interface IHolidayService
	{
		IEnumerable<IHoliday> GetHoliday(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		IEnumerable<IHoliday> GetHoliday(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		bool IsHoliday(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<bool> IsHolidayAsync(DateTime value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		bool IsHoliday(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<bool> IsHolidayAsync(DateTime? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		IEnumerable<IHoliday> GetHoliday(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		IEnumerable<IHoliday> GetHoliday(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<IEnumerable<IHoliday>> GetHolidayAsync(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		bool IsHoliday(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<bool> IsHolidayAsync(DateTimeOffset value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		bool IsHoliday(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
		Task<bool> IsHolidayAsync(DateTimeOffset? value, HolidayOccurrenceType holidayOccurrenceType = HolidayOccurrenceType.Actual);
	}
}