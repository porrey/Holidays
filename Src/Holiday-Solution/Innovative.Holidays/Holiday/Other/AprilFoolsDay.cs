using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class AprilFoolsDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("4/1");

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
				return "A day that people commonly play tricks or jokes on family, friends, and coworkers, especially in English-speaking nations. Sometimes called 'the Feast of All Fools' as a play on the feast days of saints.";
			}
		}

		public override string Name
		{
			get
			{
				return "April Fools' Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "April 1st";
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