using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class FathersDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Sunday, Period.June);

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
				return "A day to honor fathers and fatherhood.";
			}
		}

		public override string Name
		{
			get
			{
				return "Father's Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Third Sunday of June";
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