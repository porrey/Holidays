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
// Ignore Spelling: Juneteenth

using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class Juneteenth : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("6/19");

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "Juneteenth is an annual observance on June 19 to remember when Union soldiers enforced the Emancipation Proclamation and freed all remaining slaves in Texas on June 19, 1865. This day is an opportunity for people to celebrate freedom and equal rights in the United States.";
		public override string Name => "Juneteenth ";
		public override string ObservanceRule => "June 19th";
	}
}