using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class StartDst : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("3/8");

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "Clocks were turned forward 1 hour from 2:00 am to 3:00 am";
		public override string Name => "Start of Daylight Savings Time";
		public override string ObservanceRule => "March 8th";
		public override bool IsFederal => true;
	}
}