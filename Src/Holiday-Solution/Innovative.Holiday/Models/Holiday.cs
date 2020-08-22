using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public abstract class Holiday : DateTimeInterval, IHoliday
	{
		public abstract string Name { get; }

		public abstract string Description { get; }

		public abstract string ObservanceRule { get; }

		public virtual DateTime NextObservedDateTime
		{
			get
			{
				return this.GetByIndex(0);
			}
		}

		public virtual DateTime GetObservedByIndex(int index)
		{
			return this.GetByIndex(index);
		}

		public virtual DateTime GetObservedByYear(int year)
		{
			return this.GetByYear(year);
		}

		public override string ToString()
		{
			return $"{this.Name} [{this.NextDateTime.ToFullFormat()}]";
		}
	}
}