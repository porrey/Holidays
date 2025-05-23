﻿//
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
using System;
using Innovative.DateInterval;

namespace Innovative.Holiday.Tests.Mocks
{
	public class MockDayOfYearFederalHoliday : FederalHoliday
	{
		public MockDayOfYearFederalHoliday(string dayOfYear)
		{
			this.DayOfYear = dayOfYear;
		}

		private string DayOfYear { get; set; }
		private IDateTimeInterval Calculator => new DayOfYear(this.DayOfYear);

		protected override DateTime OnGetDateTime(int index) => this.Calculator[index];
		public override string Description => $"Mock Federal Holiday on {this.DayOfYear}";
		public override string Name => "Mock Federal Holiday";
		public override string ObservanceRule => "Any date you choose.";
	}
}
