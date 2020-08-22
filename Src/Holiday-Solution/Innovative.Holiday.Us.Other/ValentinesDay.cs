using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class ValentinesDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("2/14");

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "St. Valentine's Day, or simply Valentine's Day is named after one or more early Christian martyrs named Saint Valentine, and was established by Pope Gelasius I in 496 AD. Modern traditional celebration of love and romance, including the exchange of cards, candy, flowers, and other gifts.";
		public override string Name => "Valentine's Day";
		public override string ObservanceRule => "February 14th";
		public override bool IsFederal => false;
	}
}