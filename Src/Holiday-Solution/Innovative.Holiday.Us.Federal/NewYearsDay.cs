using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class NewYearsDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("1/1");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Celebrates beginning of the calendar year.";
		public override string Name => "New Year's Day";
		public override string ObservanceRule => "January 1st";
	}
}