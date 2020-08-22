using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class AprilFoolsDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("4/1");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "A day that people commonly play tricks or jokes on family, friends, and coworkers, especially in English-speaking nations. Sometimes called 'the Feast of All Fools' as a play on the feast days of saints.";
		public override string Name => "April Fools' Day";
		public override string ObservanceRule => "April 1st";
		public override bool IsFederal => false;
	}
}