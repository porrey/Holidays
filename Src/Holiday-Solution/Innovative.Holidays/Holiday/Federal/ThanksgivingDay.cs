using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class ThanksgivingDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Fourth, Division.Thursday, Period.November);

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			returnValue = _calculator[index];

			return returnValue;
		}

		public override string Description
		{
			get
			{
				return "Americans have a turkey dinner in honor of the dinner shared by Native Americans and the Pilgrims at Plymouth, Massachusetts, although the original most likely featured venison, squash and beans. Historically, Thanksgiving was observed on various days, although by the 1930s it was observed on the last Thursday of November. President Franklin Delano Roosevelt fixed it on the fourth Thursday of November, at the request of numerous powerful American merchants. (Many Americans also receive the Friday following Thanksgiving Day off work, and so many people begin their Christmas shopping on that Friday.";
			}
		}

		public override string Name
		{
			get
			{
				return "Thanksgiving Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Fourth Thursday of November";
			}
		}

		public override bool IsFederal
		{
			get
			{
				return true;
			}
		}
	}
}