using System;
using Innovative.Holidays;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			LaborDay ld = new LaborDay();
			DateTime dt = ld.NextObservedDateTime;
		}
	}
}
