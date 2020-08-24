using System;
using Innovative.DateInterval;

namespace Innovative.Holiday.Tests.Mocks
{
	public class MockDayOfYearFederalHoliday : FederalHoliday
	{
		public MockDayOfYearFederalHoliday(string dayOfYear)
		{
			this.DayOfYear = dayOfYear;
		}

		private string DayOfYear { get; set; }
		private IDateTimeInterval Calculator => new DayOfYear(this.DayOfYear);

		protected override DateTime OnGetDateTime(int index) => this.Calculator[index];
		public override string Description => $"Mock Federal Holiday on {this.DayOfYear}";
		public override string Name => "Mock Federal Holiday";
		public override string ObservanceRule => "Any date you choose.";
	}
}
