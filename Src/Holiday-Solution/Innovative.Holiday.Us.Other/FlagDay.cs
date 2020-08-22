using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class FlagDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("6/14");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Commemorates the adoption of the flag of the United States, in 1777.";
		public override string Name => "Flag Day";
		public override string ObservanceRule => "June 14th";
	}
}