using System;

namespace Innovative.Holiday
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

		public override string Description => "Celebration to commemorate the entry of Jesus into Jerusalem.";
		public override string Name => "Palm Sunday";
		public override string ObservanceRule => "Sunday before Easter";
		public override bool IsFederal => false;
	}
}