using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public interface IHoliday : IDateTimeInterval
	{
		string Name { get; }
		string Description { get; }		
		string ObservanceRule { get; }
		DateTime NextObservedDateTime { get; }
		DateTime GetObservedByIndex(int index);
		DateTime GetObservedByYear(int year);
	}
}
