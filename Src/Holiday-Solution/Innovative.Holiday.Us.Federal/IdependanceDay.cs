using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class IdependanceDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("7/4");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Celebrates the adoption of the Declaration of Independence. Also popularly known as the Fourth of July.";
		public override string Name => "Independence Day";
		public override string ObservanceRule => "July 4th";
		public override bool IsFederal => true;
	}
}