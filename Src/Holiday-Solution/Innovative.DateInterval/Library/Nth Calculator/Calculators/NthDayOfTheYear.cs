using System;
using System.Linq;

namespace Innovative.DateInterval
{
	internal class NthDayOfTheYear : NthCalculatorBase
	{
		protected override void OnLoadCombinations()
		{
			this.ValidCombinations = new Combination[]
			{		
				// *** The Year, Day, 1 -366 (example: 55th Day of the Year)
				new Combination() { Period = Period.The_Year, Division = Division.Day, N = Enumerable.Range(1, 366), INthCalculator = this }
			};
		}

		protected override DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			// ***
			// *** Calculate the year
			// ***
			int year = DateTime.Now.Year;

			// ***
			// *** Start with the first day of the year
			// ***
			returnValue = (new DateTime(year, 1, 1)).SetTime(time);

			// ***
			// *** Adjust N for a leap year
			// ***
			if (n == 366 && !DateTime.IsLeapYear(year))
			{
				n = 365;
			}

			// ***
			// *** Add n days to the start of the year
			// ***
			returnValue = returnValue.AddDays(n - 1);

			// ***
			// *** Always return a day in the future unless n is negative
			// ***
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

			// ***
			// *** Adjust N for a leap year
			// ***
			if (n == 366 && !DateTime.IsLeapYear(year))
			{
				n = 365;
			}

			// ***
			// *** Calculate the date
			// ***
			returnValue = new DateTime(year, 1, 1).AddDays(n - 1).SetTime(next.TimeOfDay);

			return returnValue;
		}
	}
}
