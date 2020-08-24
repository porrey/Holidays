using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Innovative.SystemTime;

namespace Innovative.DateInterval
{
	public enum Ordinal
	{
		First = 1,
		Second = 2,
		Third = 3,
		Fourth = 4,
		Fifth = 5,
		Last = 6,
		Other = 7
	}

	public enum Division
	{
		Sunday = 0,
		Monday = 1,
		Tuesday = 2,
		Wednesday = 3,
		Thursday = 4,
		Friday = 5,
		Saturday = 6,
		Day = 7,
	}

	public enum Period
	{
		January = 1,
		February = 2,
		March = 3,
		April = 4,
		May = 5,
		June = 6,
		July = 7,
		August = 8,
		September = 9,
		October = 10,
		November = 11,
		December = 12,
		The_Year = 13,
		The_Month = 14,
		The_Week = 15,
	}

	// ***
	// *** Format:
	// ***
	// *** [Interval] [Division] of|in [Period]
	// *** 
	// *** Possible values for Interval:
	// *** First, Second, Third, Fourth, Fifth, Last, 1st, 2nd, 3rd, 4th, 5th, ... 365th
	// ***
	// *** Possible values for Division:
	// *** Day, Week, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
	// *** 
	// *** Possible values for Period:
	// *** January, February, March, April, May, June, July, August, September, October, November, December
	// *** the Year, the Month, the Week	
	// ***

	public class NthParser
	{
		private Ordinal _ordinal = Ordinal.First;
		private Division _division = Division.Sunday;
		private Period _period = Period.January;
		private int _n = 0;
		private Time _time = Time.Empty;

		public NthParser()
		{
		}

		public NthParser(int n, Division division, Period period)
		{
			this.N = n;
			this.Division = division;
			this.Period = period;
		}

		public NthParser(Ordinal ordinal, Division division, Period period)
		{
			this.Ordinal = ordinal;
			this.Division = division;
			this.Period = period;
		}

		public NthParser(int n, Division division, Period period, Time time)
		{
			this.N = n;
			this.Division = division;
			this.Period = period;
			this.Time = time;
		}

		public NthParser(Ordinal ordinal, Division division, Period period, Time time)
		{
			this.Ordinal = ordinal;
			this.Division = division;
			this.Period = period;
			this.Time = time;
		}

		public int N
		{
			get
			{
				return _n;
			}
			set
			{
				_n = value;
				_ordinal = NthParser.GetOrdinal(value);
			}
		}

		public string Nth
		{
			get
			{
				return string.Format("{0}{1}", this.N, NthParser.Suffix(this.N));
			}
		}

		public Ordinal Ordinal
		{
			get
			{
				return _ordinal;
			}
			set
			{
				_ordinal = value;
				_n = NthParser.GetN(value);
			}
		}

		public Period Period
		{
			get
			{
				return _period;
			}
			set
			{
				_period = value;
			}
		}

		public Division Division
		{
			get
			{
				return _division;
			}
			set
			{
				_division = value;
			}
		}

		public Time Time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
			}
		}

		public DateTime GetNextDateTime(int index)
		{
			return NthCalculatorManager.Calculate(this.N, this.Division, this.Period, index, this.Time);
		}

		public override string ToString()
		{
			string returnValue = string.Empty;

			if (this.N <= 5)
			{
				returnValue = string.Format("{0} {1} of {2}", this.Ordinal, this.Division, this.Period);
			}
			else
			{
				returnValue = string.Format("{0} {1} of {2}", this.Nth, this.Division, this.Period);
			}

			return returnValue;
		}

		public static NthParser Parse(string s)
		{
			NthParser returnValue = NthParser.Default;

			if (!NthParser.TryParse(s, out returnValue))
			{
				throw new FormatException();
			}

			return returnValue;
		}

		public static bool CanParse(string s)
		{
			bool returnValue = false;

			NthParser parsedValue = null;
			returnValue = NthParser.TryParse(s, out parsedValue);

			return returnValue;
		}

		public static bool TryParse(string s, out NthParser result)
		{
			bool returnValue = false;
			result = NthParser.Default;


			// ***
			// *** Join the Ordinal enumerator names with the | character into a string
			// *** and build the Ordinal pattern
			// ***
			string ordinalSection = String.Join("|", Enum.GetNames(typeof(Ordinal))).Replace("_", " ");
			string ordinalPattern = string.Format(@"(?<Ordinal>({0})|([0-9]{{1,3}})(st|nd|rd|th))", ordinalSection);

			// ***
			// *** Join the Division enumerator names with the | character into a string
			// *** and build the Division pattern
			// ***
			string section2 = String.Join("|", Enum.GetNames(typeof(Division))).Replace("_", " ");
			string divisionPattern = string.Format("(?<Division>({0}))", section2);

			// ***
			// *** Join the Period enumerator names with the | character into a string
			// *** and build the Period pattern
			// ***
			string section3 = String.Join("|", Enum.GetNames(typeof(Period))).Replace("_", " ");
			string periodPattern = string.Format("(?<Period>({0}))", section3);

			string pattern = string.Format(@"({0}\s{1}\s(of|in)\s{2})", ordinalPattern, divisionPattern, periodPattern);
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			MatchCollection matches = regex.Matches(s);

			if (matches.Count > 0)
			{
				GroupCollection groups = matches[0].Groups;

				if (groups.Count >= 3)
				{
					// ***
					// *** Used to convert strings to title case
					// *** 
					CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
					TextInfo textInfo = cultureInfo.TextInfo;

					// ***
					// *** Get the Ordinal
					// ***
					string interval = textInfo.ToTitleCase(groups["Ordinal"].Value).Replace(" ", "_");
					Ordinal parsedValue = Ordinal.Other;

					if (Enum.TryParse<Ordinal>(interval, out parsedValue))
					{
						result.Ordinal = parsedValue;
					}
					else
					{
						// ***
						// *** Need to parse the integer. The right two characters will
						// *** always be st, nd, rd or th
						// ***
						string intText = interval.Substring(0, interval.Length - 2);
						result.N = int.Parse(intText);
					}

					// ***
					// *** Get the Division
					// ***
					string division = textInfo.ToTitleCase(groups["Division"].Value).Replace(" ", "_");
					result.Division = (Division)Enum.Parse(typeof(Division), division, true);

					// ***
					// *** Get the Period
					// ***
					string period = textInfo.ToTitleCase(groups["Period"].Value).Replace(" ", "_");
					result.Period = (Period)Enum.Parse(typeof(Period), period, true);

					returnValue = true;
				}
			}

			return returnValue;
		}

		public static NthParser Default
		{
			get
			{
				// ***
				// ***The default is defined as Midnight
				// ***
				return new NthParser();
			}
		}

		/// <summary>
		/// Returns the count of the occurrences a given DayOfWeek in a 
		/// month of a particular year
		/// </summary>
		/// <param name="day"></param>
		/// <param name="month"></param>
		/// <param name="year"></param>
		/// <returns></returns>
		public static int DayOfWeekCount(DayOfWeek day, int month, int year)
		{
			int returnValue = 0;

			int daysInMonth = DateTime.DaysInMonth(year, month);
			int extraDays = daysInMonth % 7;
			DayOfWeek firstDayOfMonth = (new DateTime(year, month, 1)).DayOfWeek;

			if (extraDays > 0)
			{
				if (extraDays == 1 && day == firstDayOfMonth)
				{
					returnValue = 5;
				}
				else if (extraDays == 2 && (day == firstDayOfMonth || day == (firstDayOfMonth.AddDays(1))))
				{
					returnValue = 5;
				}
				else if (extraDays == 3 && (day == firstDayOfMonth || day == (firstDayOfMonth.AddDays(1)) || day == (firstDayOfMonth.AddDays(2))))
				{
					returnValue = 5;
				}
				else
				{
					returnValue = 4;
				}
			}
			else
			{
				// ***
				// *** There are always 4 occurrences
				// ***
				returnValue = 4;
			}


			return returnValue;
		}

		public static string Suffix(int n)
		{
			string returnValue = string.Empty;

			// ***
			// *** If the number ends in 1 then st
			// *** If the number ends in 2 then nd
			// *** If the number ends in 3 then rd
			// *** All other numbers are th
			// ***
			int lastDigit = n % 10;

			if (lastDigit == 0)
			{
				returnValue = string.Empty;
			}
			else if (lastDigit == 1)
			{
				returnValue = "st";
			}
			else if (lastDigit == 2)
			{
				returnValue = "nd";
			}
			else if (lastDigit == 3)
			{
				returnValue = "rd";
			}
			else
			{
				returnValue = "th";
			}

			return returnValue;
		}

		public static Ordinal GetOrdinal(int n)
		{
			Ordinal returnValue = Ordinal.Other;

			switch (n)
			{
				case 1:
					returnValue = Ordinal.First;
					break;
				case 2:
					returnValue = Ordinal.Second;
					break;
				case 3:
					returnValue = Ordinal.Third;
					break;
				case 4:
					returnValue = Ordinal.Fourth;
					break;
				case 5:
					returnValue = Ordinal.Fifth;
					break;
				default:
					returnValue = Ordinal.Other;
					break;
			}

			return returnValue;
		}

		public static int GetN(Ordinal ordinal)
		{
			int returnValue = 0;

			switch (ordinal)
			{
				case Ordinal.First:
					returnValue = 1;
					break;
				case Ordinal.Second:
					returnValue = 2;
					break;
				case Ordinal.Third:
					returnValue = 3;
					break;
				case Ordinal.Fourth:
					returnValue = 4;
					break;
				case Ordinal.Fifth:
					returnValue = 5;
					break;
				case Ordinal.Last:
					returnValue = -1;
					break;
				case Ordinal.Other:
					returnValue = 0;
					break;
			}

			return returnValue;
		}
	}
}