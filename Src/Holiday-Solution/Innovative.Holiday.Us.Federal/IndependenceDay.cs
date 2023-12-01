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
	public class IndependenceDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("7/4");

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "Celebrates the adoption of the Declaration of Independence. Also popularly known as the Fourth of July.";
		public override string Name => "Independence Day";
		public override string ObservanceRule => "July 4th";
	}
}