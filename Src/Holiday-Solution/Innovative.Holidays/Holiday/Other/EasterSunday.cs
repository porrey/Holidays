using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
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

		public override string Description
		{
			get
			{
				return "Celebration of the resurrection of Jesus.";
			}
		}

		public override string Name
		{
			get
			{
				return "Easter";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Sunday following the Paschal Full Moon";
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