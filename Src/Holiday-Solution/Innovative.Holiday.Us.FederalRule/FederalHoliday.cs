namespace Innovative.Holiday
{
	public abstract class FederalHoliday : ObservedHoliday
	{
		public override IObservedHolidayRule ObservedHolidayRule { get; } = new FederalHolidayRule();
	}
}
