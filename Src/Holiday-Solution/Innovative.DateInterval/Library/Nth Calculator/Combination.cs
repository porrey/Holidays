using System;
using System.Collections.Generic;

namespace Innovative.DateInterval
{
	internal class Combination
	{
		public Period Period { get; set; }
		public Division Division { get; set; }
		public IEnumerable<int> N { get; set; }
		public INthCalculator INthCalculator { get; set; }
	}
}
