//
// Copyright(C) 2013-2025, Daniel M. Porrey. All rights reserved.
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