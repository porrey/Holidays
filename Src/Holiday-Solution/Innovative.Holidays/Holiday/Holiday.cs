﻿using System;
using Innovative.DateInterval;

namespace Innovative.Holidays
{
	public abstract class Holiday : DateTimeInterval, IHoliday
	{
		public virtual string Name
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual string Description
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual string ObservanceRule
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsFederal
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual DateTime NextObservedDateTime
		{
			get
			{
				return this.GetObservedAtInterval(0);
			}
		}

		public virtual DateTime GetObservedAtInterval(int index)
		{
			DateTime returnValue = this.NextDateTime;

			// ***
			// *** If the holiday is a Federal Holiday and it falls on Saturday then it is 
			// *** observed on Friday. If it falls on Sunday it is observed on Monday. If
			// *** it is not a federal holiday then it is observed on the same day.
			// ***
			if (this.IsFederal)
			{
				if (this.NextDateTime.DayOfWeek == DayOfWeek.Saturday)
				{
					returnValue = this.NextDateTime.Subtract(TimeSpan.FromDays(1));
				}
				else if (this.NextDateTime.DayOfWeek == DayOfWeek.Sunday)
				{
					returnValue = this.NextDateTime.Add(TimeSpan.FromDays(1));
				}
			}

			return returnValue;
		}
	}
}