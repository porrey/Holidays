using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class SaintPatricksDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("3/17");

		protected override DateTime OnGetDateTime(int index)=>  _calculator[index];
		public override string Description => "A holiday honoring Saint Patrick that celebrates Irish culture. Primary activity is simply the wearing of green clothing (wearing o' the green), although drinking beer dyed green is also popular. Big parades in some cities, such as in New York City and Chicago. In Chicago the Chicago is dyed green.";
		public override string Name => "Saint Patrick's Day";
		public override string ObservanceRule => "March 17th";
		public override bool IsFederal => false;
	}
}