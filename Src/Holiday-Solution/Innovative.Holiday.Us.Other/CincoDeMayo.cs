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
// Ignore Spelling: Cinco

using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class CincoDeMayo : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("5/5");

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "A celebration of Mexican culture by Mexican-Americans living in the United States. It celebrates the defeat of the French army during the Battle of Puebla (Batalla de Puebla) in Mexico on May 5, 1862.";
		public override string Name => "Cinco de Mayo";
		public override string ObservanceRule => "May 5th";
	}
}