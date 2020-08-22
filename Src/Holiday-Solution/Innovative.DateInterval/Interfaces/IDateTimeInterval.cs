using System;

namespace Innovative.DateInterval
{
	public interface IDateTimeInterval
	{
		DateTime NextDateTime { get; }
		DateTime this[int index] { get; }
		DateTime GetAtInterval(int index);
	}
}
