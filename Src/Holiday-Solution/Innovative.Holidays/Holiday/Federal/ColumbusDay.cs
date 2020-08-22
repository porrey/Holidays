using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class ColumbusDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Second, Division.Monday, Period.October);

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
				return "Marks the arrival of Christopher Columbus in the America, when he landed in the Bahamas on October 12, 1492 (according to the Julian calendar). Celebrated since 1792 in New York City.[citation needed] Congress and President Franklin Delano Roosevelt set aside Columbus Day in 1934 as a federal holiday at the behest of the Knights of Columbus.";
			}
		}

		public override string Name
		{
			get
			{
				return "Columbus Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Second Monday of October";
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