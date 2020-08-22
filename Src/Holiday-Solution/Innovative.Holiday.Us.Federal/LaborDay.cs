using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class LaborDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.First, Division.Monday, Period.September);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Celebrates achievements of workers and the labor movement. Labor Day traditionally marks the end of the summer recreational season in America.";
		public override string Name => "Labor Day";
		public override string ObservanceRule => "First Monday of September";
		public override bool IsFederal => true;
	}
}