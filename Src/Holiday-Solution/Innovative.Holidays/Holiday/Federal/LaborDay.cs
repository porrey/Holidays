using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class LaborDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.First, Division.Monday, Period.September);

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
				return "Celebrates achievements of workers and the labor movement. Labor Day traditionally marks the end of the summer recreational season in America.";
			}
		}

		public override string Name
		{
			get
			{
				return "Labor Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "First Monday of September";
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