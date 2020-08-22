using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative.DateInterval
{
	internal interface INthCalculator
	{
		Combination[] ValidCombinations { get; }
		DateTime Calculate(int n, Division division, Period period, int index, Time time);
	}
}
