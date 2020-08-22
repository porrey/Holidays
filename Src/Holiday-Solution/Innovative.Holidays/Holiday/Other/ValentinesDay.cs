﻿using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public class ValentinesDay : Holiday
	{
		private IDateTimeInterval _calculator = new DayOfYear("2/14");

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			returnValue = _calculator[index];

			return returnValue;
		}

		public override string Description
		{
			get
			{
				return "St. Valentine's Day, or simply Valentine's Day is named after one or more early Christian martyrs named Saint Valentine, and was established by Pope Gelasius I in 496 AD. Modern traditional celebration of love and romance, including the exchange of cards, candy, flowers, and other gifts.";
			}
		}

		public override string Name
		{
			get
			{
				return "Valentine's Day";
			}
		}

		public override string ObservanceRule
		{
			get
			{
				return "February 14th";
			}
		}

		public override bool IsFederal
		{
			get
			{
				return false;
			}
		}
	}
}