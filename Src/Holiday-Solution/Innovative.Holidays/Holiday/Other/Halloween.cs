using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class Halloween : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("10/31");

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
				return "Originally the end of the Celtic year, it now celebrates Eve of All Saint's Day.";
			}
		}

		public override string Name
		{
			get
			{
				return "Halloween";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "October 31st";
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