namespace Innovative.Holiday.Us.Other
{
	public static class All
	{
		static All()
		{
			All.Items.AddRange(new IHoliday[]
			{
				new AprilFoolsDay(),
				new ArmedForcesDay(),
				new CincoDeMayo(),
				new FathersDay(),
				new FlagDay(),
				new GroundhogDay(),
				new Halloween(),
				new Juneteenth(),
				new MothersDay(),
				new NewYearsEve(),
				new SaintPatricksDay(),
				new ValentinesDay()
			});
		}

		public static IHolidayList Items { get; } = new HolidayList();
	}
}
