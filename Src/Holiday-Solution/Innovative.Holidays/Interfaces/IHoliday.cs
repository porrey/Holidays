using System;

namespace Innovative.Holidays
{
	public interface IHoliday
	{
		string Name { get; }
		string Description { get; }		
		string ObservanceRule { get; }
		bool IsFederal { get; }
		DateTime NextDateTime { get; }		
		DateTime this[int index] { get; }
		DateTime GetAtInterval(int index);
		DateTime NextObservedDateTime { get; }
		DateTime GetObservedAtInterval(int index);
	}
}
