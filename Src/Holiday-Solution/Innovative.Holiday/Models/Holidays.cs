//
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
	/// Contains global items used by the library.
	/// </summary>
	public static class Holidays
	{
		/// <summary>
		/// Gets a list of holidays that are being used by the current application. This
		/// list is used by the extension methods within the library.
		/// </summary>
		public static IHolidayList MyHolidays { get; } = new HolidayList();

		/// <summary>
		/// Register a holiday to be considered by extensions methods within this library.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		public static void Register(IHoliday holiday)
		{
			Holidays.MyHolidays.Add(holiday);
		}

		/// <summary>
		/// Register a holiday to be considered by extensions methods within this library.
		/// </summary>
		/// <param name="holiday">An instance of <see cref="IHoliday"/>.</param>
		public static Task RegisterAsync(IHoliday holiday)
		{
			Holidays.Register(holiday);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Registers a list of <see cref="IHoliday"/> items.
		/// </summary>
		/// <param name="holidays">A list of <see cref="IHoliday"/> items.</param>
		public static void Register(IEnumerable<IHoliday> holidays)
		{
			Holidays.MyHolidays.AddRange(holidays);
		}

		/// <summary>
		/// Registers a list of <see cref="IHoliday"/> items.
		/// </summary>
		/// <param name="holidays">A list of <see cref="IHoliday"/> items.</param>
		public static Task RegisterAsync(IEnumerable<IHoliday> holidays)
		{
			Holidays.Register(holidays);
			return Task.FromResult(0);
		}

		/// <summary>
		/// Registers several lists of <see cref="IHoliday"/> items.
		/// </summary>
		/// <param name="holidays">One or more lists of <see cref="IHoliday"/> items.</param>
		public static void Register(params IEnumerable<IHoliday>[] holidays)
		{
			Holidays.MyHolidays.AddRanges(holidays);
		}

		/// <summary>
		/// Registers several lists of <see cref="IHoliday"/> items.
		/// </summary>
		/// <param name="holidays">One or more lists of <see cref="IHoliday"/> items.</param>
		public static Task RegisterAsync(params IEnumerable<IHoliday>[] holidays)
		{
			Holidays.Register(holidays);
			return Task.FromResult(0);
		}
	}
}
