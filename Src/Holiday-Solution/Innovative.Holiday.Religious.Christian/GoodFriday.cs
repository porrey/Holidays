using System;

namespace Innovative.Holiday
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

		public override string Description => "Friday of Holy Week, when Western Christians commemorate the crucifixion and death of Jesus.";
		public override string Name => "Good Friday";
		public override string ObservanceRule => "Friday (2 days) before Easter";
	}
}