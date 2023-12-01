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
	public class StartDst : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("3/8");

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "Clocks were turned forward 1 hour from 2:00 am to 3:00 am";
		public override string Name => "Start of Daylight Savings Time";
		public override string ObservanceRule => "March 8th";
	}
}