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
using Innovative.SystemTime;

namespace Innovative.DateInterval
{
	internal class NthDayOfTheYear : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{		
				// The Year, Day, 1 -366 (example: 55th Day of the Year)
				new() { Period = Period.The_Year, Division = Division.Day, N = Enumerable.Range(1, 366), INthCalculator = this }
			};
		}

		protected override DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Calculate the year
			//
			int year = DateTime.Now.Year;

			//
			// Start with the first day of the year
			//
			returnValue = new DateTime(year, 1, 1).SetTime(time);

			//
			// Adjust N for a leap year
			//
			if (n == 366 && !DateTime.IsLeapYear(year))
			{
				n = 365;
			}

			//
			// Add n days to the start of the year
			//
			returnValue = returnValue.AddDays(n - 1);

			//
			// Always return a day in the future unless n is negative
			//
			if (returnValue < DateTime.Now)
			{
				returnValue = returnValue.AddYears(1);
			}

			return returnValue;
		}

		protected override DateTime OnCalculateIndex(int n, DateTime next, int index)
		{
			DateTime returnValue = DateTime.MinValue;

			int year = next.Year + index;

			//
			// Adjust N for a leap year
			//
			if (n == 366 && !DateTime.IsLeapYear(year))
			{
				n = 365;
			}

			//
			// Calculate the date
			//
			returnValue = new DateTime(year, 1, 1).AddDays(n - 1).SetTime(next.TimeOfDay);

			return returnValue;
		}
	}
}
