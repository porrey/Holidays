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
	public class ThanksgivingDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new Nth(Ordinal.Fourth, Division.Thursday, Period.November);

		protected override DateTime OnGetDateTime(int index) => this._calculator[index];
		public override string Description => "Americans have a turkey dinner in honor of the dinner shared by Native Americans and the Pilgrims at Plymouth, Massachusetts, although the original most likely featured venison, squash and beans. Historically, Thanksgiving was observed on various days, although by the 1930s it was observed on the last Thursday of November. President Franklin Delano Roosevelt fixed it on the fourth Thursday of November, at the request of numerous powerful American merchants. (Many Americans also receive the Friday following Thanksgiving Day off work, and so many people begin their Christmas shopping on that Friday.";
		public override string Name => "Thanksgiving Day";
		public override string ObservanceRule => "Fourth Thursday of November";
	}
}