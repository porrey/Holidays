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
	public class ValentinesDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("2/14");

		protected override DateTime OnGetDateTime(int index)=> _calculator[index];
		public override string Description => "St. Valentine's Day, or simply Valentine's Day is named after one or more early Christian martyrs named Saint Valentine, and was established by Pope Gelasius I in 496 AD. Modern traditional celebration of love and romance, including the exchange of cards, candy, flowers, and other gifts.";
		public override string Name => "Valentine's Day";
		public override string ObservanceRule => "February 14th";
	}
}