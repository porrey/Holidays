using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class CincodeMayo : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("5/5");

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
				return "A celebration of Mexican culture by Mexican-Americans living in the United States.";
			}
		}

		public override string Name
		{
			get
			{
				return "Cinco de Mayo";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "May 5th";
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