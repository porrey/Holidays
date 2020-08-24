using System;
using Innovative.SystemTime;

namespace Innovative.DateInterval
{
	internal interface INthCalculator
	{
		Combination[] ValidCombinations { get; }
		DateTime Calculate(int n, Division division, Period period, int index, Time time);
	}
}
