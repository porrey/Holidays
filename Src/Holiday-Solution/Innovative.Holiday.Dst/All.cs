namespace Innovative.Holiday.Dst
{
	public static class All
	{
		static All()
		{
			All.Items.AddRange(new IHoliday[]
			{
				new StartDst(),
				new EndDst()
			});
		}

		public static IHolidayList Items { get; } = new HolidayList();
	}
}
