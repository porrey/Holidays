using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class EndDst : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("11/1");

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "Clocks were turned back 1 hour from 2:00 am to 1:00 am";
		public override string Name => "End of Daylight Savings Time";
		public override string ObservanceRule => "November 1st";
	}
}