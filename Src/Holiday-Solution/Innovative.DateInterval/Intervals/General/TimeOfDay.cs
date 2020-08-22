using System;

namespace Innovative.DateInterval
{
	public class TimeOfDay : DateTimeInterval<Time>
	{
		public TimeOfDay()
			: base()
		{
		}

		public TimeOfDay(Time value)
			: base(value)
		{
		}

		public TimeOfDay(string value)
			: base(value)
		{
		}

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = this.Value.Date;

			// ***
			// *** Always return the full date of 
			// *** next occurrence of the time
			// *** value
			// **
			if (returnValue < DateTime.Now)
			{
				// ***
				// *** Set the date and time to the next
				// *** time slot
				// ***
				returnValue = returnValue.AddDays(1);

				// ***
				// *** Index represents days
				// ***
				returnValue = returnValue.Add(TimeSpan.FromDays(index));
			}

			return returnValue;
		}

		protected override Time OnGetDefaultValue()
		{
			return TimeOfDay.Default.Value;
		}

		#region IDateTimeIntervalConverter
		protected override Time OnConvertFromString(string value)
		{
			return Time.Parse(value);
		}

		protected override string OnConvertToString()
		{
			return this.Value;
		}

		protected override bool OnIsValidString(string value)
		{
			return Time.CanParse(value);
		}
		#endregion

		#region Predefined Values
		public static TimeOfDay Default
		{
			get
			{
				return TimeOfDay.Midnight;
			}
		}

		public static TimeOfDay Noon
		{
			get
			{
				return new TimeOfDay(new Time("12:00 AM"));
			}
		}

		public static TimeOfDay Midnight
		{
			get
			{
				return new TimeOfDay(new Time("12:00 PM"));
			}
		}
		#endregion
	}
}