using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class VeteransDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("11/11");

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
				return "Also known as Armistice Day, Veterans Day is the American name for the international holiday which commemorates the signing of the Armistice ending World War I. In the United States, the holiday honors all veterans of the United States Armed Forces, whether or not they have served in a conflict; but it especially honors the surviving veterans of wars.";
			}
		}

		public override string Name
		{
			get
			{
				return "Veterans Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "November 11th";
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