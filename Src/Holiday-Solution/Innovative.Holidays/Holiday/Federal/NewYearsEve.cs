using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class NewYearsEve : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("12/31");

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
				return "A celebration of the final day of the year usually in the evening and leading into the new year.";
			}
		}

		public override string Name
		{
			get
			{
				return "New Year's Eve";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "December 31st";
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