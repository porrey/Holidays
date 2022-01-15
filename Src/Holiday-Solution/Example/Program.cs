//
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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

namespace Innovative.Holiday.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			//
			// Register the holidays.
			//
			Holidays.Register(Us.Federal.All.Items, Us.Other.All.Items, Religious.Christian.All.Items);

			//
			// Create a date/time instance.
			//
			DateTime dt = new(2020, 9, 7);

			//
			// Check if the date is a holiday.
			//
			bool isHoliday = dt.IsHoliday(HolidayOccurrenceType.Observed);
			Console.WriteLine($"The date {dt.Date.ToShortDateString()} {(isHoliday ? "is" : " is NOT ")} a holiday.");

			IEnumerable<IHoliday> holidays = dt.GetHoliday(HolidayOccurrenceType.Actual);
			Console.WriteLine($"The holiday is {holidays.First().Name}");
		}
	}
}
