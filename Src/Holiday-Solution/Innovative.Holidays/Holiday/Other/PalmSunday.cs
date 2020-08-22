using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class PalmSunday : Holiday
	{
		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			EasterSundayCalculator easterSundayCalculator = new EasterSundayCalculator(DateTime.Now.Year + (int)index);
			returnValue = easterSundayCalculator.Date.Subtract(TimeSpan.FromDays(7));

			return returnValue;
		}

		public override string Description
		{
			get
			{
				return "Celebration to commemorate the entry of Jesus into Jerusalem.";
			}
		}

		public override string Name
		{
			get
			{
				return "Palm Sunday";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Sunday before Easter";
			}
		}

		public override bool IsFederal
		{
			get
			{
				return false;
			}
		}
	}
}