using System;

namespace Innovative.Holiday
{
	/// <summary>
	/// Identifies a holiday than can have a different observed
	/// day that the actual day the holiday officially falls on.
	/// </summary>
	public interface IObservedHoliday
	{
		/// <summary>
		/// Gets the next observed date for this holiday.
		/// </summary>
		DateTime NextObserved { get; }

		/// <summary>
		/// Gets the next observed date for this holiday by index.
		/// </summary>
		/// <param name="index">A value the indicates the nth occurrence where 
		/// 0 is the next occurrence.</param>
		/// <returns>The date of the nth occurrence of this holiday.</returns>
		DateTime GetObservedByIndex(int index);

		/// <summary>
		/// Gets the observed date of this holiday in any specified year.
		/// </summary>
		/// <param name="year">The year within the date of this holiday is retrieved.</param>
		/// <returns>The date of the occurrence of this holiday in the specified year.</returns>
		DateTime GetObservedByYear(int year);

		/// <summary>
		/// Gets the rule used to adjust the date.
		/// </summary>
		IObservedHolidayRule ObservedHolidayRule { get; }
	}
}
