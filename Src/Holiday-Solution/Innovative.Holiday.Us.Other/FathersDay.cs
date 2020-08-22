using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class FathersDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Sunday, Period.June);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "A day to honor fathers and fatherhood.";
		public override string Name => "Father's Day";
		public override string ObservanceRule => "Third Sunday of June";
		public override bool IsFederal => false;
	}
}