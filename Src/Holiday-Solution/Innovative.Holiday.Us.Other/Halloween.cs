using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class Halloween : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("10/31");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Originally the end of the Celtic year, it now celebrates Eve of All Saint's Day.";
		public override string Name => "Halloween";
		public override string ObservanceRule => "October 31st";
		public override bool IsFederal => false;
	}
}