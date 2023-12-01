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
	public class MemorialDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Last, Division.Monday, Period.May);

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "Also known as Decoration Day, Memorial Day originated in the 19th century as a day to remember the soldiers who gave their lives in the American Civil War by decorating their graves with flowers. Memorial Day is traditionally the beginning of the summer recreational season in America.";
		public override string Name => "Memorial Day";
		public override string ObservanceRule => "Final Monday of May";
	}
}