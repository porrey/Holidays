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
	public class VeteransDay : FederalHoliday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("11/11");

		protected override DateTime OnGetDateTime(int index) => _calculator[index];
		public override string Description => "Also known as Armistice Day, Veterans Day is the American name for the international holiday which commemorates the signing of the Armistice ending World War I. In the United States, the holiday honors all veterans of the United States Armed Forces, whether or not they have served in a conflict; but it especially honors the surviving veterans of wars.";
		public override string Name => "Veterans Day";
		public override string ObservanceRule => "November 11th";
	}
}