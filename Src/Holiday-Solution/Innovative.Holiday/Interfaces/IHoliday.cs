using Innovative.DateInterval;

namespace Innovative.Holiday
{
	/// <summary>
	/// Interface to define the base for a holiday.
	/// </summary>
	public interface IHoliday : IDateTimeInterval
	{
		/// <summary>
		/// Gets the name of the holiday.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets a description or history of the holiday.
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Gets a definition of how the day of this holiday is determined.
		/// </summary>
		string ObservanceRule { get; }
	}
}
