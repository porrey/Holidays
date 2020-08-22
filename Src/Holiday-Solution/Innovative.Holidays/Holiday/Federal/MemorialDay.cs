using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class MemorialDay : Holiday
	{
		private IDateTimeInterval _calculator = new Nth(Ordinal.Last, Division.Monday, Period.May);

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
				return "Also known as Decoration Day, Memorial Day originated in the 19th century as a day to remember the soldiers who gave their lives in the American Civil War by decorating their graves with flowers. Memorial Day is traditionally the beginning of the summer recreational season in America.";
			}
		}

		public override string Name
		{
			get
			{
				return "Memorial Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "Final Monday of May";
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