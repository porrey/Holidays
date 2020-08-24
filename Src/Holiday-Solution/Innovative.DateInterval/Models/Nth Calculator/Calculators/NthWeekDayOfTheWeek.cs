using System;
using System.Linq;
using Innovative.SystemTime;

namespace Innovative.DateInterval
{
	internal class NthWeekDayOfTheWeek : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{		
				// *** The Week, Specific Day, 1 (example: 1st Monday of the Week) [Not very useful but valid; like saying "every Monday"]
				new Combination() { Period = Period.The_Week, Division = Division.Sunday, N = Enumerable.Range(1, 1), INthCalculator = this },
				new Combination() { Period = Period.The_Week, Division = Division.Monday, N = Enumerable.Range(1, 1), INthCalculator = this },
				new Combination() { Period = Period.The_Week, Division = Division.Tuesday, N = Enumerable.Range(1, 1), INthCalculator = this },
				new Combination() { Period = Period.The_Week, Division = Division.Wednesday, N = Enumerable.Range(1, 1), INthCalculator = this },
				new Combination() { Period = Period.The_Week, Division = Division.Thursday, N = Enumerable.Range(1, 1), INthCalculator = this },
				new Combination() { Period = Period.The_Week, Division = Division.Friday, N = Enumerable.Range(1, 1), INthCalculator = this },
				new Combination() { Period = Period.The_Week, Division = Division.Saturday, N = Enumerable.Range(1, 1), INthCalculator = this }
			};
		}

		protected override DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			DateTime returnValue = DateTime.Now.SetTime(time);

			// ***
			// *** Target day of week
			// ***
			int dayofweek = (int)division;

			// ***
			// *** Calculate the difference in days between today and n
			// ***
			int difference = ((int)returnValue.DayOfWeek - dayofweek);

			// ***
			// *** Adjust the current day by the day difference
			// *** between today and n always going forward in
			// *** time.
			// ***
			if (difference < 0)
			{
				returnValue = returnValue.AddDays(difference);
			}
			else if (difference > 0)
			{
				returnValue = returnValue.AddDays(7 - difference);
			}

			// ***
			// *** Never return a day in the past
			// ***
			if (returnValue < DateTime.Now)
			{
				returnValue.AddMonths(1);
			}

			return returnValue;
		}

		protected override DateTime OnCalculateIndex(int n, DateTime next, int index)
		{
			DateTime returnValue = DateTime.MinValue;

			// ***
			// *** Index adds/removes 7 days
			// ***
			int numberOfDays = index * 7;
			returnValue = next.AddDays(numberOfDays);

			return returnValue;
		}
	}
}
