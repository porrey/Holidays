//
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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

namespace Innovative.Holiday
{
	public class Easter : Holiday
	{
		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			//
			// Returns the full date and time of
			// nth occurrence of this time. The value
			// 0 always returns the 'next' occurrence
			// and has the same value as the NextDateTime
			// property.
			//
			EasterSundayCalculator easterSundayCalculator = new EasterSundayCalculator(DateTime.Now.Year + (int)index);
			returnValue = easterSundayCalculator.Date;

			return returnValue;
		}

		public override string Description => "Celebration of the resurrection of Jesus.";
		public override string Name => "Easter";
		public override string ObservanceRule => "Sunday following the Paschal Full Moon";
	}

	[Obsolete("Use Innovative.Holiday.Easter instead.")]
	public class EasterSunday : Easter
	{
	}
}