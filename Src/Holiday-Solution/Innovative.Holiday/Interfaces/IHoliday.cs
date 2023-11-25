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
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	/// <summary>
	/// Interface to define the base for a holiday.
	/// </summary>
	public interface IHoliday : IDateTimeInterval
	{
		/// <summary>
		/// Gets the name of the holiday.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets a description or history of the holiday.
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Gets a definition of how the day of this holiday is determined.
		/// </summary>
		string ObservanceRule { get; }
	}
}
