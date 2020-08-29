namespace Innovative.Holiday.Religious.Christian
{
	public static class All
	{
		static All()
		{
			All.Items.AddRange(new IHoliday[]
			{
				new PalmSunday(),
				new GoodFriday(),
				new Easter(),
				new NationalDayOfPrayer(),
				new ChristmasEve(),
				new Christmas()
			});
		}

		public static IHolidayList Items { get; } = new HolidayList();
	}
}
