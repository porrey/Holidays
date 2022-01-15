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
