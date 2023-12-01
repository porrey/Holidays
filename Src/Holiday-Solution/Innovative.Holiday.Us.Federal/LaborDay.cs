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
	public class LaborDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.First, Division.Monday, Period.September);

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "Celebrates achievements of workers and the labor movement. Labor Day traditionally marks the end of the summer recreational season in America.";
		public override string Name => "Labor Day";
		public override string ObservanceRule => "First Monday of September";
	}
}