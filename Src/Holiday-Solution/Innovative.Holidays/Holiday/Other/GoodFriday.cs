using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class GoodFriday : Holiday
	{
		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			EasterSundayCalculator easterSundayCalculator = new EasterSundayCalculator(DateTime.Now.Year + (int)index);
			returnValue = easterSundayCalculator.Date.Subtract(TimeSpan.FromDays(2));

			return returnValue;
		}

		public override string Description
		{
			get
			{
				return "Friday of Holy Week, when Western Christians commemorate the crucifixion and death of Jesus.";
			}
		}

		public override string Name
		{
			get
			{
				return "Good Friday";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Friday before Easter";
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