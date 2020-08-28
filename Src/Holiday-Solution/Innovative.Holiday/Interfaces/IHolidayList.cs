using System.Collections.Generic;
using System.Threading.Tasks;

namespace Innovative.Holiday
{
	/// <summary>
	/// A list of holidays.
	/// </summary>
	public interface IHolidayList : IList<IHoliday>
	{
		/// <summary>
		/// Adds a holiday to the list.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		Task AddAsync(IHoliday holiday);

		/// <summary>
		/// Adds a range of holidays to the list.
		/// </summary>
		/// <param name="items">A list of holidays to be added to the list.</param>
		void AddRange(IEnumerable<IHoliday> items);

		/// <summary>
		/// Adds a range of holidays to the list.
		/// </summary>
		/// <param name="items">A list of holidays to be added to the list.</param>
		Task AddRangeAsync(IEnumerable<IHoliday> items);

		/// <summary>
		/// Adds several ranges of holidays to the list.
		/// </summary>
		/// <param name="items">One or more lists of holidays to be added to the list.</param>
		Task AddRangesAsync(params IEnumerable<IHoliday>[] items);

		/// <summary>
		/// Adds several ranges of holidays to the list.
		/// </summary>
		/// <param name="items">One or more lists of holidays to be added to the list.</param>
		void AddRanges(params IEnumerable<IHoliday>[] items);

		/// <summary>
		/// Removes a holiday from the list.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		Task<bool> RemoveAsync(IHoliday holiday);
	}
}
