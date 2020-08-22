using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class MothersDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Second, Division.Sunday, Period.May);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "A day to honors mothers and motherhood.";
		public override string Name => "Mother's Day";
		public override string ObservanceRule => "Second Sunday of May";
	}
}