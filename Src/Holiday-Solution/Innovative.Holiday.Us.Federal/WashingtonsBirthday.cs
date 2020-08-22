using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class WashingtonsBirthday : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Monday, Period.February);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Honors George Washington. Sometimes labeled as Presidents Day.";
		public override string Name => "Washington's Birthday";
		public override string ObservanceRule => "Third Monday of February";
	}
}