using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class WashingtonsBirthday : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Monday, Period.February);

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
				return "Honors George Washington. Sometimes labeled as Presidents Day.";
			}
		}

		public override string Name
		{
			get
			{
				return "Washington's Birthday";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Third Monday of February";
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