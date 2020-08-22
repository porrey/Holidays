using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class GroundhogDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("2/2");

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
				return "The day on which folklore states that the behavior of a groundhog emerging from its burrow is said to predict the onset of Spring.";
			}
		}

		public override string Name
		{
			get
			{
				return "Groundhog Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "February 2nd";
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