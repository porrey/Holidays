using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class NewYearsDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("1/1");

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
				return "Celebrates beginning of the calendar year.";
			}
		}

		public override string Name
		{
			get
			{
				return "New Year's Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "January 1st";
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