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
using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class ColumbusDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Second, Division.Monday, Period.October);

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "Marks the arrival of Christopher Columbus in the America, when he landed in the Bahamas on October 12, 1492 (according to the Julian calendar). Celebrated since 1792 in New York City.[citation needed] Congress and President Franklin Delano Roosevelt set aside Columbus Day in 1934 as a federal holiday at the behest of the Knights of Columbus.";
		public override string Name => "Columbus Day";
		public override string ObservanceRule => "Second Monday of October";
	}
}