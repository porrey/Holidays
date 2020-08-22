﻿using System;

namespace Innovative.DateInterval
{
	public class DayOfYear : DateTimeInterval<string>
	{
		public DayOfYear()
			: base()
		{
		}

		public DayOfYear(string value)
			: base(value)
		{
		}

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			if (DateTime.TryParse(this.Value, out returnValue))
			{
				// ***
				// *** Always return the full date of 
				// *** next occurrence of the time
				// *** value for index 0
				// **
				if (returnValue < DateTime.Now)
				{
					// ***
					// *** Set the date and time to the next
					// *** time slot
					// ***
					while (returnValue < DateTime.Now)
					{
						returnValue = returnValue.AddYears(1);
					}

					// ***
					// *** Add the years
					// ***
					returnValue = returnValue.AddYears(index);
				}
			}
			else
			{
				throw new FormatException();
			}

			return returnValue;
		}		

		protected override string OnGetDefaultValue()
		{
			return DayOfYear.Default.Value;
		}

		protected override bool OnGetIsValidRange(string value)
		{
			bool returnValue = false;

			DateTime d = DateTime.MinValue;
			returnValue = DateTime.TryParse(value, out d);

			return returnValue;
		}

		#region IDateTimeIntervalConverter
		protected override bool OnIsValidString(string value)
		{
			return this.OnGetIsValidRange(value);
		}

		protected override string OnConvertFromString(string value)
		{
			return value;
		}

		protected override string OnConvertToString()
		{
			return this.Value;
		}
		#endregion

		#region Predefined Values
		public static DayOfYear Default
		{
			get
			{
				// ***
				// *** The first day of the month is the default
				// ***
				return new DayOfYear("1/1");
			}
		}
		#endregion
	}
}