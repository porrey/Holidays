using System;

namespace Innovative.Holiday.Us.Federal.Tests
{
	public class DatePair
	{
		public DateTime Actual { get; set; }
		public DateTime Observed { get; set; }

		public static DatePair Create(int year, int month, int actualDay, int observedDay)
		{
			return new DatePair()
			{
				Actual = new DateTime(year, month, actualDay),
				Observed = new DateTime(year, month, observedDay)
			};
		}
	}
}
