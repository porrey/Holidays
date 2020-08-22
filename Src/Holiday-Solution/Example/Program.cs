using System;
using Innovative.Holiday;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			LaborDay ld = new LaborDay();
			DateTime dt1 = ld.NextObservedDateTime;

			GoodFriday gf = new GoodFriday();
			DateTime dt2 = gf.NextObservedDateTime;

			EasterSunday es = new EasterSunday();
			DateTime dt3 = es.NextObservedDateTime;
		}
	}
}
