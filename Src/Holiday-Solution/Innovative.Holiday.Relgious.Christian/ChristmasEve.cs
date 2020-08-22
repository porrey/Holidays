using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class ChristmasEve : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("12/24");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "The celebration of Christmas starting the evening prior.";
		public override string Name => "Christmas Eve";
		public override string ObservanceRule => "December 24th";
		public override bool IsFederal => true;
	}
}