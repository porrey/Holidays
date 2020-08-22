using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class MemorialDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Last, Division.Monday, Period.May);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Also known as Decoration Day, Memorial Day originated in the 19th century as a day to remember the soldiers who gave their lives in the American Civil War by decorating their graves with flowers. Memorial Day is traditionally the beginning of the summer recreational season in America.";
		public override string Name => "Memorial Day";
		public override string ObservanceRule => "Final Monday of May";
		public override bool IsFederal => true;
	}
}