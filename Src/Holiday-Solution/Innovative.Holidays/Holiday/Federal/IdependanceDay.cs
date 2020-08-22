using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class IdependanceDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("7/4");

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
				return "Celebrates the adoption of the Declaration of Independence. Also popularly known as the Fourth of July.";
			}
		}

		public override string Name
		{
			get
			{
				return "Independence Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "July 4th";
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