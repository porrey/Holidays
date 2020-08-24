using System;
using System.Collections.Generic;

namespace Innovative.DateInterval
{
	public class DayOfMonth : DateTimeInterval<int>
	{
		public DayOfMonth()
			: base()
		{
		}

		public DayOfMonth(int value)
			: base(value)
		{
		}

		public DayOfMonth(string value)
			: base(value)
		{
		}

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			if (this.IsValidRange(this.Value))
			{
				returnValue = DateTime.Now.SpecifyDayOfMonth(this.Value, SpecificDayBehavior.AdjustForLast);

				if (returnValue < DateTime.Now)
				{
					returnValue = returnValue.AddMonths(1);
				}

				returnValue = returnValue.AddMonths((int)index).SpecifyDayOfMonth(this.Value, SpecificDayBehavior.AdjustForLast);
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}

			return returnValue;
		}

		protected override int OnGetDefaultValue()
		{
			return DayOfMonth.Default.Value;
		}

		protected override bool OnGetIsValidRange(int value)
		{
			bool returnValue = false;

			if (value >= 1 && value <= 31)
			{
				returnValue = true;
			}

			return returnValue;
		}

		#region IDateTimeIntervalConverter
		protected override bool OnIsValidString(string value)
		{
			bool returnValue = false;

			int parsedValue = 0;

			if (int.TryParse(value, out parsedValue))
			{
				returnValue = this.OnGetIsValidRange(parsedValue);
			}

			return returnValue;
		}

		protected override int OnConvertFromString(string value)
		{
			return int.Parse(value);
		}

		protected override string OnConvertToString()
		{
			return this.Value.ToString();
		}
		#endregion

		#region Predefined Values
		public static DayOfMonth Default
		{
			get
			{
				// ***
				// *** The first day of the month is the default
				// ***
				return DayOfMonth.First;
			}
		}

		public static DayOfMonth First
		{
			get
			{
				return new DayOfMonth(1);
			}
		}
		#endregion
	}
}