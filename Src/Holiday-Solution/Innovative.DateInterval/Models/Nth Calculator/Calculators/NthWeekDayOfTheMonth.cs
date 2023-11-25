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
using System;
using System.Linq;
using Innovative.SystemTime;

namespace Innovative.DateInterval
{
	internal class NthWeekDayOfTheMonth : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{
				// The Month, Specific Day, 1 - 5 (example: 4th Monday of the Month)
				new Combination() { Period = Period.The_Month, Division = Division.Sunday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new Combination() { Period = Period.The_Month, Division = Division.Monday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new Combination() { Period = Period.The_Month, Division = Division.Tuesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new Combination() { Period = Period.The_Month, Division = Division.Wednesday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new Combination() { Period = Period.The_Month, Division = Division.Thursday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new Combination() { Period = Period.The_Month, Division = Division.Friday, N = Enumerable.Range(1, 5), INthCalculator = this },
				new Combination() { Period = Period.The_Month, Division = Division.Saturday, N = Enumerable.Range(1, 5), INthCalculator = this }
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
			int month = DateTime.Now.Month;
			int day = (int)division;

			//
			// Calculate the date
			//
			returnValue = this._GetDate(year, month, division, n).SetTime(time);

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

			int year = next.Year;
			int month = next.Month + index;			
			Division division = (Division)((int)next.DayOfWeek);

			//
			// The next date needs to be recalculated
			//
			returnValue = this._GetDate(year, month, division, n).SetTime(next.TimeOfDay);

			return returnValue;
		}

		private DateTime _GetDate(int year, int month, Division division, int n)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Get the first day of the month and then adjust the date
			//
			DateTime firstDayOfMonth = new DateTime(year, month, 1);
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
