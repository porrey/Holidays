using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class ChristmasEve : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("12/24");

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
				return "The celebration of Christmas starting the evening prior.";
			}
		}

		public override string Name
		{
			get
			{
				return "Christmas Eve";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "December 24th";
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