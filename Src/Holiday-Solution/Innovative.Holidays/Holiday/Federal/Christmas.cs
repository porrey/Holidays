using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class Christmas : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("12/25");

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			returnValue = _calculator[index];

			return returnValue;
		}

		public override string Description
		{
			get
			{
				return "A worldwide holiday that celebrates the birth of Jesus Christ. Popular aspects of the holiday include decorations, emphasis on family togetherness, and gift giving. Designated a federal holiday by Congress and President Ulysses S. Grant in 1870.";
			}
		}

		public override string Name
		{
			get
			{
				return "Christmas";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "December 25th";
			}
		}

		public override bool IsFederal
		{
			get
			{
				return true;
			}
		}
	}
}