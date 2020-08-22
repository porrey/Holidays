namespace Innovative.Holiday.Us.Federal
{
	public static class All
	{
		static All()
		{
			All.Items.AddRange(new IHoliday[]
			{
				new NewYearsDay(),
				new MartinLutherKingDay(),
				new WashingtonsBirthday(),
				new MemorialDay(),
				new IndependenceDay(),
				new LaborDay(),
				new ColumbusDay(),
				new VeteransDay(),
				new ThanksgivingDay()
			});
		}

		public static IHolidayList Items { get; } = new HolidayList();
	}
}
