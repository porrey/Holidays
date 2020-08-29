using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class NationalDayOfPrayer : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.First, Division.Thursday, Period.May);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "National Day of Prayer calls on all people of different faiths in the United States to pray for the nation and its leaders.";
		public override string Name => "National Day of Prayer";
		public override string ObservanceRule => "First Thursday of May";
	}
}