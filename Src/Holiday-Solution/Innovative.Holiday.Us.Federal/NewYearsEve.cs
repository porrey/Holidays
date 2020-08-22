using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class NewYearsEve : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("12/31");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "A celebration of the final day of the year usually in the evening and leading into the new year.";
		public override string Name => "New Year's Eve";
		public override string ObservanceRule => "December 31st";
		public override bool IsFederal => true;
	}
}