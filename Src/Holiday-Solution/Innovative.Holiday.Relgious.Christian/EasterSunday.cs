using System;

namespace Innovative.Holiday
{
	public class EasterSunday : Holiday
	{
		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			// ***
			// *** Returns the full date and time of
			// *** nth occurrence of this time. The value
			// *** 0 always returns the 'next' occurrence
			// *** and has the same value as the NextDateTime
			// *** property.
			// ***
			EasterSundayCalculator easterSundayCalculator = new EasterSundayCalculator(DateTime.Now.Year + (int)index);
			returnValue = easterSundayCalculator.Date;

			return returnValue;
		}

		public override string Description => "Celebration of the resurrection of Jesus.";
		public override string Name => "Easter";
		public override string ObservanceRule => "Sunday following the Paschal Full Moon";
	}
}