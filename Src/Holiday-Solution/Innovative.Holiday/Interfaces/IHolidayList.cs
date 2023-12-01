//
// Copyright(C) 2013-2024, Daniel M. Porrey. All rights reserved.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
//
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
