using System;

namespace Innovative.Holiday
{
	/// <summary>
	/// Identifies a holiday than can have a different observed
	/// day that the actual day the holiday officially falls on.
	/// </summary>
	public abstract class ObservedHoliday : Holiday, IObservedHoliday
	{
		/// <summary>
		/// Gets the next observed date for this holiday.
		/// </summary>
		public virtual DateTime NextObserved
		{
			get
			{
				return this.GetObservedByIndex(0);
			}
		}

		/// <summary>
		/// Gets the next observed date for this holiday by index.
		/// </summary>
		/// <param name="index">A value the indicates the nth occurrence where 
		/// 0 is the next occurrence.</param>
		/// <returns>The date of the nth occurrence of this holiday.</returns>
		public virtual DateTime GetObservedByIndex(int index)
		{
			return this.ObservedHolidayRule.AdjustedDate(this.GetByIndex(index));
		}

		/// <summary>
		/// Gets the observed date of this holiday in any specified year.
		/// </summary>
		/// <param name="year">The year within the date of this holiday is retrieved.</param>
		/// <returns>The date of the occurrence of this holiday in the specified year.</returns>
		public virtual DateTime GetObservedByYear(int year)
		{
			return this.ObservedHolidayRule.AdjustedDate(this.GetByYear(year));
		}

		/// <summary>
		/// Gets the rule used to adjust the date.
		/// </summary>
		public abstract IObservedHolidayRule ObservedHolidayRule { get; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return $"{this.Name} [Federal holiday on {this.NextDateTime.ToLongDateString()}]";
		}
	}
}