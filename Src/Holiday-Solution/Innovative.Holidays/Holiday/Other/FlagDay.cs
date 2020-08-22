using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class FlagDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("6/14");

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
				return "Commemorates the adoption of the flag of the United States, in 1777.";
			}
		}

		public override string Name
		{
			get
			{
				return "Flag Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "June 14th";
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