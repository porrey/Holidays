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
	internal class NthDayOfMonth : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{		
				// The Month, Day, 1 - 31 (example: 3rd Day of the Month)
				new Combination() { Period = Period.The_Month, Division = Division.Day, N = Enumerable.Range(1, 31), INthCalculator = this }
			};
		}

		protected override DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Start with the current year and (month + index)
			//
			int year = DateTime.Now.Year;
			int month = DateTime.Now.Month;

			//
			// AdjustForLast will adjust for a month with less than n days (for
			// example if n = 31 it will use 30)
			//
			returnValue = (new DateTime(year, month, 1).SpecifyDayOfMonth(n, SpecificDayBehavior.AdjustForLast)).SetTime(time);

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

			int year = next.Year;
			int month = next.Month + index;
			int day = n;

			if (n > DateTime.DaysInMonth(year, month))
			{
				n = DateTime.DaysInMonth(year, month);
			}

			//
			// Calculate the date
			//
			returnValue = new DateTime(year, month, day).SetTime(next.TimeOfDay);

			return returnValue;
		}
	}
}
