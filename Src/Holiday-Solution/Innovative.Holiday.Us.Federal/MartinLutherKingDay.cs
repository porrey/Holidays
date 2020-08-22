using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class MartinLutherKingDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Monday, Period.January);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Celebration of the birthday of civil rights leader Martin Luther King, Jr.; he was actually born on January 15, 1929";
		public override string Name => "Martin Luther King Jr. Day";
		public override string ObservanceRule => "Third Monday of January";
		public override bool IsFederal => true;
	}
}