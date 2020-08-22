using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class GroundhogDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("2/2");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "The day on which folklore states that the behavior of a groundhog emerging from its burrow is said to predict the onset of Spring.";
		public override string Name => "Groundhog Day";
		public override string ObservanceRule => "February 2nd";
	}
}