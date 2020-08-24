using System;

namespace Innovative.Holiday
{
	public abstract class FederalHoliday : Holiday, IFederalHoliday
	{
		public bool IsFederal => true;

		public override DateTime NextObservedDateTime
		{
			get
			{
				return this.GetObservedByIndex(0);
			}
		}

		public override DateTime GetObservedByIndex(int index)
		{
			return this.AdjustedDate(this.GetByIndex(index));
		}

		public override DateTime GetObservedByYear(int year)
		{
			return this.AdjustedDate(this.GetByYear(year));
		}

		protected virtual DateTime AdjustedDate(DateTime value)
		{
			DateTime returnValue = value;

			// ***
			// *** If the holiday is a Federal Holiday and it falls on Saturday then it is 
			// *** observed on Friday. If it falls on Sunday it is observed on Monday. If
			// *** it is not a federal holiday then it is observed on the same day.
			// ***
			if (value.DayOfWeek == DayOfWeek.Saturday)
			{
				returnValue = value.Subtract(TimeSpan.FromDays(1));
			}
			else if (value.DayOfWeek == DayOfWeek.Sunday)
			{
				returnValue = value.Add(TimeSpan.FromDays(1));
			}

			return returnValue;
		}

		public override string ToString()
		{
			return $"{this.Name} [Federal holiday on {this.NextDateTime.ToLongDateString()}]";
		}
	}
}