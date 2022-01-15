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
	/// Adjusts a holiday date per the US federal holiday rule. If the holiday falls
	/// on a Saturday, it is observed on the previous Friday. If the holiday falls on
	/// a Sunday, it is observed on the next Monday. 
	/// </summary>
	public class FederalHolidayRule: IObservedHolidayRule
	{
		/// <summary>
		/// Returns an adjusted date.
		/// </summary>
		/// <param name="value">The date to be adjusted.</param>
		/// <returns>Returns the adjusted date of this holiday.</returns>
		public virtual DateTime AdjustedDate(DateTime value)
		{
			DateTime returnValue = value;

			//
			// If the holiday is a Federal Holiday and it falls on Saturday then it is 
			// observed on Friday. If it falls on Sunday it is observed on Monday.
			//
			if (value.DayOfWeek == DayOfWeek.Saturday)
			{
				returnValue = value.Subtract(TimeSpan.FromDays(1));
			}
			else if (value.DayOfWeek == DayOfWeek.Sunday)
			{
				returnValue = value.Add(TimeSpan.FromDays(1));
			}

			return returnValue;
		}
	}
}
