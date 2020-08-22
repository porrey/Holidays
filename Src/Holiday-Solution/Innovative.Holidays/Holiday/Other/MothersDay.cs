using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class MothersDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Second, Division.Sunday, Period.May);

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
				return "A day to honors mothers and motherhood.";
			}
		}

		public override string Name
		{
			get
			{
				return "Mother's Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Second Sunday of May";
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