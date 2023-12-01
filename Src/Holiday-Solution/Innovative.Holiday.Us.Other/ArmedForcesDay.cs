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
	public class ArmedForcesDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Third, Division.Saturday, Period.May);

		protected override DateTime OnGetDateTime(int index)
		{
			return this._calculator[index];
		}

		public override string Description => "It is a day to pay tribute to men and women who serve the United States’ armed forces. Armed Forces Day is also part of Armed Forces Week, which begins on the second Saturday of May.";
		public override string Name => "Armed Forces Day";
		public override string ObservanceRule => "Third Saturday of May";
	}
}