using System;

namespace Innovative.Holiday
{
	/// <summary>
	/// An interface for a rule that can adjust the 
	/// holiday date for an holiday that implements <see cref="IObservedHoliday"/>.
	/// </summary>
	public interface IObservedHolidayRule
	{
		/// <summary>
		/// Returns an adjusted date.
		/// </summary>
		/// <param name="value">The date to be adjusted.</param>
		/// <returns>Returns the adjusted date of this holiday.</returns>
		DateTime AdjustedDate(DateTime value);
	}
}
