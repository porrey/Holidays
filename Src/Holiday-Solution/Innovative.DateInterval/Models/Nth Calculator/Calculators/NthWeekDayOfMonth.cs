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
	internal class NthWeekDayOfMonth : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{		
				// January, Specific Day, 1 - 5 (example: 4th Monday of January)
				new() { Period = Period.January, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.January, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.January, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.January, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.January, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.January, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.January, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// February, Specific Day, 1 - 5 (example: 4th Monday of February)
				new() { Period = Period.February, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.February, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.February, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.February, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.February, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.February, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.February, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// March, Specific Day, 1 - 5 (example: 4th Monday of March)
				new() { Period = Period.March, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.March, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.March, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.March, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.March, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.March, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.March, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// April, Specific Day, 1 - 5 (example: 4th Monday of April)
				new() { Period = Period.April, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.April, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.April, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.April, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.April, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.April, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.April, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// May, Specific Day, 1 - 5 (example: 4th Monday of May)
				new() { Period = Period.May, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.May, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.May, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.May, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.May, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.May, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.May, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// June, Specific Day, 1 - 5 (example: 4th Monday of June)
				new() { Period = Period.June, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.June, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.June, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.June, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.June, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.June, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.June, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// July, Specific Day, 1 - 5 (example: 4th Monday of July)
				new() { Period = Period.July, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.July, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.July, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.July, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.July, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.July, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.July, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// August, Specific Day, 1 - 5 (example: 4th Monday of August)
				new() { Period = Period.August, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.August, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.August, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.August, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.August, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.August, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.August, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// September, Specific Day, 1 - 5 (example: 4th Monday of September)
				new() { Period = Period.September, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.September, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.September, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.September, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.September, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.September, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.September, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// October, Specific Day, 1 - 5 (example: 4th Monday of October)
				new() { Period = Period.October, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.October, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.October, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.October, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.October, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.October, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.October, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// November, Specific Day, 1 - 5 (example: 4th Monday of November)
				new() { Period = Period.November, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.November, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.November, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.November, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.November, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.November, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.November, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this },
				// December, Specific Day, 1 - 5 (example: 4th Monday of December)
				new() { Period = Period.December, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.December, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.December, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.December, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.December, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.December, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new() { Period = Period.December, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this }
			};
		}

		protected override DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Need to calculate these three values
			// to compute a date
			//
			int year = DateTime.Now.Year;
			int month = (int)period;
			int day = (int)division;

			if (month < DateTime.Now.Month)
			{
				year++;
			}

			//
			// Calculate the date
			//
			returnValue = this.GetDate(year, month, division, n).SetTime(time);

			//
			// Adjust if in the past
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

			int year = next.Year + index;
			int month = next.Month;
			Division division = (Division)(int)next.DayOfWeek;

			//
			// The next date needs to be recalculated
			//
			returnValue = this.GetDate(year, month, division, n).SetTime(next.TimeOfDay);

			return returnValue;
		}

		private DateTime GetDate(int year, int month, Division division, int n)
		{
			DateTime returnValue = DateTime.MinValue;
			//
			// Get the first day of the month and then adjust the date
			//
			DateTime firstDayOfMonth = new(year, month, 1);
			int dayOfWeek = (int)division;

			int dayDifference = 0;
			if ((int)firstDayOfMonth.DayOfWeek > dayOfWeek)
			{
				dayDifference = 7 - ((int)firstDayOfMonth.DayOfWeek - dayOfWeek);
				returnValue = firstDayOfMonth.Add(TimeSpan.FromDays(dayDifference));
			}
			else
			{
				dayDifference = dayOfWeek - (int)firstDayOfMonth.DayOfWeek;
				returnValue = firstDayOfMonth.Add(TimeSpan.FromDays(dayDifference));
			}

			//
			// Get the maximum number of DayOfWeek's in the month
			//
			int maxDayOfWeek = NthParser.DayOfWeekCount((DayOfWeek)dayOfWeek, month, year);
			int daysToAdd = 0;

			if (n > maxDayOfWeek)
			{
				daysToAdd = (maxDayOfWeek - 1) * 7;
			}
			else
			{
				daysToAdd = (n - 1) * 7;
			}

			//
			// Add the days to get the Nth occurrence
			//
			returnValue = returnValue.AddDays(daysToAdd);

			return returnValue;
		}
	}
}
