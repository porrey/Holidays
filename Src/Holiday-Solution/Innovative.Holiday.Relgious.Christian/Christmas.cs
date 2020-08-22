using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class Christmas : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("12/25");

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "A worldwide holiday that celebrates the birth of Jesus Christ. Popular aspects of the holiday include decorations, emphasis on family togetherness, and gift giving. Designated a federal holiday by Congress and President Ulysses S. Grant in 1870.";
		public override string Name => "Christmas";
		public override string ObservanceRule => "December 25th";
		public override bool IsFederal => true;
	}
}