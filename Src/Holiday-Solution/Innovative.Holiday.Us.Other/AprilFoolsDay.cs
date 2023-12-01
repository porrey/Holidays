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
	public class AprilFoolsDay : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("4/1");

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "A day that people commonly play tricks or jokes on family, friends, and coworkers, especially in English-speaking nations. Sometimes called 'the Feast of All Fools' as a play on the feast days of saints.";
		public override string Name => "April Fools' Day";
		public override string ObservanceRule => "April 1st";
	}
}