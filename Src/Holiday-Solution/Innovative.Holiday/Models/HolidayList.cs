using System.Collections.Generic;
using System.Threading.Tasks;

namespace Innovative.Holiday
{
	/// <summary>
	/// A list of holidays.
	/// </summary>
	public class HolidayList : List<IHoliday>, IHolidayList
	{
		/// <summary>
		/// Adds a holiday to the list.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		public Task AddAsync(IHoliday holiday)
		{
			this.Add(holiday);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Adds a range of holidays to the list.
		/// </summary>
		/// <param name="items">A list of holidays to be added to the list.</param>
		public Task AddRangeAsync(IEnumerable<IHoliday> items)
		{
			base.AddRange(items);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Adds several ranges of holidays to the list.
		/// </summary>
		/// <param name="items">One or more lists of holidays to be added to the list.</param>
		public void AddRanges(params IEnumerable<IHoliday>[] items)
		{
			foreach (IEnumerable<IHoliday> list in items)
			{
				base.AddRange(list);
			}
		}

		/// <summary>
		/// Adds several ranges of holidays to the list.
		/// </summary>
		/// <param name="items">One or more lists of holidays to be added to the list.</param>
		public Task AddRangesAsync(params IEnumerable<IHoliday>[] items)
		{
			this.AddRanges(items);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Removes a holiday from the list.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		public Task<bool> RemoveAsync(IHoliday holiday)
		{
			return Task.FromResult(this.Remove(holiday));
		}
	}
}
