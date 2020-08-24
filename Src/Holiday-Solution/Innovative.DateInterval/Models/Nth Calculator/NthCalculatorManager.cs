using System;
using System.Collections.Generic;
using System.Linq;
using Innovative.SystemTime;

namespace Innovative.DateInterval
{
	internal static class NthCalculatorManager
	{
		private static INthCalculator[] _calculatorList = null;
		private static List<Combination> _validCombinations = null;

		static NthCalculatorManager()
		{
			// ***
			// *** Load known calculators
			// ***
			_calculatorList = new INthCalculator[]
			{
				new NthDayOfMonth(),
				new NthDayOfTheWeek(),
				new NthDayOfTheYear(),
				new NthWeekDayOfMonth(),
				new NthWeekDayOfTheMonth(),
				new NthWeekDayOfTheWeek(),
				new NthWeekDayOfTheYear(),
			};

			// ***
			// *** Load the valid combinations
			// ***
			_validCombinations = new List<Combination>();

			foreach (INthCalculator item in _calculatorList)
			{
				_validCombinations.AddRange(item.ValidCombinations);
			}
		}

		public static INthCalculator[] CalculatorList
		{
			get
			{
				return NthCalculatorManager._calculatorList;
			}
			private set
			{
				NthCalculatorManager._calculatorList = value;
			}
		}

		public static List<Combination> ValidCombinations
		{
			get
			{
				return NthCalculatorManager._validCombinations;
			}
			private set
			{
				NthCalculatorManager._validCombinations = value;
			}
		}

		public static bool IsValidateCombination(int n, Division division, Period period)
		{
			bool returnValue = false;

			IEnumerable<Combination> qry = from tbl in NthCalculatorManager.ValidCombinations
										   where tbl.Period == period &&
										   tbl.Division == division &&
										   tbl.N.Contains(n)
										   select tbl;

			returnValue = (qry.Count() > 0);

			return returnValue;
		}

		public static DateTime Calculate(int n, Division division, Period period, int index, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			// ***
			// *** Get the entry in the list
			// ***
			IEnumerable<Combination> qry = from tbl in NthCalculatorManager.ValidCombinations
										   where tbl.Period == period &&
										   tbl.Division == division
										   select tbl;

			if (qry.Count() == 1)
			{
				if ((qry.Single().N.Contains(n) || n == -1))
				{
					if (qry.First().INthCalculator != null)
					{
						INthCalculator inth = qry.First().INthCalculator;

						// ***
						// *** Adjust N if -1 (indicates 'Last')
						// ***
						if (n == -1)
						{
							n = qry.First().N.Last();
						}

						returnValue = inth.Calculate(n, division, period, index, time);
					}
					else
					{
						throw new NthCalculatorMissingException();
					}
				}
				else
				{
					throw new NthCalculatorOrdinalException();
				}
			}
			else
			{
				throw new NthCalculatorInvalidCombinationException();
			}

			return returnValue;
		}
	}
}
