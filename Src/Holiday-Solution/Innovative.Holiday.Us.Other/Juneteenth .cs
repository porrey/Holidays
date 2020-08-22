using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class Juneteenth : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("6/19");

		protected override DateTime OnGetDateTime(int index)=>_calculator[index];
		public override string Description => "Juneteenth is an annual observance on June 19 to remember when Union soldiers enforced the Emancipation Proclamation and freed all remaining slaves in Texas on June 19, 1865. This day is an opportunity for people to celebrate freedom and equal rights in the United States.";
		public override string Name => "Juneteenth ";
		public override string ObservanceRule => "June 19th";
		public override bool IsFederal => false;
	}
}