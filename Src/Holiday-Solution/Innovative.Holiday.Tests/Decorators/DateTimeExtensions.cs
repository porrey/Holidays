﻿//
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

namespace Innovative.Holiday.Tests
{
	public static class DateTimeExtensions
	{
		public static DateTime NextDayOfWeek(this DateTime value, DayOfWeek dayOfWeek)
		{
			DateTime returnValue = value;

			int adjustment = (7 + (int)dayOfWeek - (int)value.DayOfWeek) % 7;
			returnValue = value.AddDays(adjustment);

			//
			// All dates must be in the future.
			//
			if (returnValue.Date <= DateTime.Now.Date)
			{
				returnValue = returnValue.AddDays(7);
			}

			return returnValue;
		}

		public static DateTimeOffset NextDayOfWeek(this DateTimeOffset value, DayOfWeek dayOfWeek)
		{
			DateTimeOffset returnValue = value;

			int adjustment = (7 + (int)dayOfWeek - (int)value.DayOfWeek) % 7;
			returnValue = value.AddDays(adjustment);

			//
			// All dates must be in the future.
			//
			if (returnValue.Date <= DateTimeOffset.Now.Date)
			{
				returnValue = returnValue.AddDays(7);
			}

			return returnValue;
		}
	}
}
