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
	public class NationalDayOfPrayer : Holiday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.First, Division.Thursday, Period.May);

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "National Day of Prayer calls on all people of different faiths in the United States to pray for the nation and its leaders.";
		public override string Name => "National Day of Prayer";
		public override string ObservanceRule => "First Thursday of May";
	}
}