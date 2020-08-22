using System;

namespace Innovative.DateInterval
{
	public interface IDateTimeInterval
	{
		DateTime NextDateTime { get; }
		DateTime this[int index] { get; }
		DateTime GetByIndex(int index);
		DateTime GetByYear(int year);
		int GetYearIndex(int year);
	}
}
