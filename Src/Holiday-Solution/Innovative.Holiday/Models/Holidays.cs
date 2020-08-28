namespace Innovative.Holiday
{
	/// <summary>
	/// Contains global items used by the library.
	/// </summary>
	public static class Holidays
	{
		/// <summary>
		/// Gets a list of holidays that are being used by the current application. This
		/// list is used by the extension methods within the library.
		/// </summary>
		public static IHolidayList MyHolidays { get; } = new HolidayList();
	}
}
