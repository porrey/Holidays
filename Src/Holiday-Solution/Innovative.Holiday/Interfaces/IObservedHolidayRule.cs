﻿//
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
