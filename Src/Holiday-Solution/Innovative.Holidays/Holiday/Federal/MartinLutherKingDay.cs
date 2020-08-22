using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class MartinLutherKingDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Monday, Period.January);

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
				return "Celebration of the birthday of civil rights leader Martin Luther King, Jr.; he was actually born on January 15, 1929";
			}
		}

		public override string Name
		{
			get
			{
				return "Martin Luther King Jr. Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Third Monday of January";
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