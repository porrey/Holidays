using System;
using Innovative.DateInterval;

namespace Innovative.Holiday.Tests.Mocks
{
	public class MockDayOfYearHoliday : Holiday
	{
		public MockDayOfYearHoliday(string dayOfYear)
		{
			this.DayOfYear = dayOfYear;
		}

		private string DayOfYear { get; set; }
		private IDateTimeInterval Calculator => new DayOfYear(this.DayOfYear);

		protected override DateTime OnGetDateTime(int index) => this.Calculator[index];
		public override string Description => $"Mock Holiday on {this.DayOfYear}";
		public override string Name => "Mock Holiday";
		public override string ObservanceRule => "Any date you choose.";
	}
}
