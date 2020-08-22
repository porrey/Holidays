using System;
using Innovative.DateInterval;

namespace Innovative.Holiday
{
	public class CincoDeMayo : Holiday
	{
		private readonly IDateTimeInterval _calculator = new DayOfYear("5/5");

		protected override DateTime OnGetDateTime(int index)=>_calculator[index];
		public override string Description => "A celebration of Mexican culture by Mexican-Americans living in the United States. It celebrates the defeat of the French army during the Battle of Puebla (Batalla de Puebla) in Mexico on May 5, 1862.";
		public override string Name => "Cinco de Mayo";
		public override string ObservanceRule => "May 5th";
		public override bool IsFederal => false;
	}
}