using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class SaintPatricksDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("3/17");

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
				return "A holiday honoring Saint Patrick that celebrates Irish culture. Primary activity is simply the wearing of green clothing (wearing o' the green), although drinking beer dyed green is also popular. Big parades in some cities, such as in New York City and Chicago. In Chicago the Chicago is dyed green.";
			}
		}

		public override string Name
		{
			get
			{
				return "Saint Patrick's Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "March 17th";
			}
		}

		public override bool IsFederal
		{
			get
			{
				return false;
			}
		}
	}
}