using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class Template : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("");

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "";
		public override string Name => "";
		public override string ObservanceRule => "";
		public override bool IsFederal => true;
	}
}