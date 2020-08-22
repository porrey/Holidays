using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class ArmedForcesDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Saturday, Period.May);

		protected override DateTime OnGetDateTime(int index)
		{
			return _calculator[index];
		}

		public override string Description => "It is a day to pay tribute to men and women who serve the United States’ armed forces. Armed Forces Day is also part of Armed Forces Week, which begins on the second Saturday of May.";
		public override string Name => "Armed Forces Day";
		public override string ObservanceRule => "Third Saturday of May";
		public override bool IsFederal => false;
	}
}