﻿//
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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
		/// Adds a <see cref="IHoliday"/> to the list.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		public Task AddAsync(IHoliday holiday)
		{
			this.Add(holiday);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Adds a range of <see cref="IHoliday"/> to the list.
		/// </summary>
		/// <param name="holidays">A list of <see cref="IHoliday"/> items.</param>
		public Task AddRangeAsync(IEnumerable<IHoliday> holidays)
		{
			base.AddRange(holidays);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Adds several ranges of <see cref="IHoliday"/> to the list.
		/// </summary>
		/// <param name="holidays">One or more lists of <see cref="IHoliday"/> to be added to the list.</param>
		public void AddRanges(params IEnumerable<IHoliday>[] holidays)
		{
			foreach (IEnumerable<IHoliday> list in holidays)
			{
				base.AddRange(list);
			}
		}

		/// <summary>
		/// Adds several ranges of <see cref="IHoliday"/> to the list.
		/// </summary>
		/// <param name="holidays">One or more lists of <see cref="IHoliday"/> to be added to the list.</param>
		public Task AddRangesAsync(params IEnumerable<IHoliday>[] holidays)
		{
			this.AddRanges(holidays);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Removes a <see cref="IHoliday"/> from the list.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		public Task<bool> RemoveAsync(IHoliday holiday)
		{
			return Task.FromResult(this.Remove(holiday));
		}
	}
}
