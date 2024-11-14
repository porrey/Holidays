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
// Ignore Spelling: Patricks

using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class SaintPatricksDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("3/17");

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "A holiday honoring Saint Patrick that celebrates Irish culture. Primary activity is simply the wearing of green clothing (wearing o' the green), although drinking beer dyed green is also popular. Big parades in some cities, such as in New York City and Chicago. In Chicago the Chicago is dyed green.";
		public override string Name => "Saint Patrick's Day";
		public override string ObservanceRule => "March 17th";
	}
}