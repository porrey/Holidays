//
// Copyright(C) 2013-2024, Daniel M. Porrey. All rights reserved.
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
	internal class NthWeekDayOfTheYear : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{		
				// The Year, Specific Day, 1 - 52 (example: 25th Monday of the Year)
				new() { Period = Period.The_Year, Division = Division.Sunday, N = Enumerable.Range(1, 52), INthCalculator = this },
				new() { Period = Period.The_Year, Division = Division.Monday, N = Enumerable.Range(1, 52), INthCalculator = this },
				new() { Period = Period.The_Year, Division = Division.Tuesday, N = Enumerable.Range(1, 52), INthCalculator = this },
				new() { Period = Period.The_Year, Division = Division.Wednesday, N = Enumerable.Range(1, 52), INthCalculator = this },
				new() { Period = Period.The_Year, Division = Division.Thursday, N = Enumerable.Range(1, 52), INthCalculator = this },
				new() { Period = Period.The_Year, Division = Division.Friday, N = Enumerable.Range(1, 52), INthCalculator = this },
				new() { Period = Period.The_Year, Division = Division.Saturday, N = Enumerable.Range(1, 52), INthCalculator = this }
			};
		}

		protected override DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Get the first of the year
			//
			returnValue = new DateTime(DateTime.Now.Year, 1, 1);

			//
			// Target day of week
			//
			int dayofweek = (int)division;

			//
			// Calculate the difference in days between today and n
			//
			int difference = (int)returnValue.DayOfWeek - dayofweek;

			//
			// Adjust the current day by the day difference
			// between today and n always going forward in
			// time.
			//
			if (difference < 0)
			{
				returnValue = returnValue.AddDays(difference);
			}
			else if (difference > 0)
			{
				returnValue = returnValue.AddDays(7 - difference);
			}

			//
			// Adjust for n
			//
			int numberOfDays = 7 * n;
			returnValue = returnValue.AddDays(numberOfDays).SetTime(time);

			//
			// Never return a day in the past
			//
			if (returnValue < DateTime.Now)
			{
				returnValue.AddMonths(1);
			}

			return returnValue;
		}

		protected override DateTime OnCalculateIndex(int n, DateTime next, int index)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Index adds/removes 52 weeks
			//
			int numberOfDays = 52 * 7 * index;
			returnValue = next.AddDays(numberOfDays).SetTime(next.TimeOfDay);

			return returnValue;
		}
	}
}
