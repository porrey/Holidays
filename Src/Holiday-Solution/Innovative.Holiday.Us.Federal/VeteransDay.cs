using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class VeteransDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("11/11");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Also known as Armistice Day, Veterans Day is the American name for the international holiday which commemorates the signing of the Armistice ending World War I. In the United States, the holiday honors all veterans of the United States Armed Forces, whether or not they have served in a conflict; but it especially honors the surviving veterans of wars.";
		public override string Name => "Veterans Day";
		public override string ObservanceRule => "November 11th";
	}
}