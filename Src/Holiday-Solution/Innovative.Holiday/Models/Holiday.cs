using Innovative.DateInterval;

namespace Innovative.Holiday
{
	/// <summary>
	/// Abstract class to define the base for a holiday.
	/// </summary>
	public abstract class Holiday : DateTimeInterval, IHoliday
	{
		/// <summary>
		/// Gets the name of the holiday.
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Gets a description or history of the holiday.
		/// </summary>
		public abstract string Description { get; }

		/// <summary>
		/// Gets a definition of how the day of this holiday is determined.
		/// </summary>
		public abstract string ObservanceRule { get; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return $"{this.Name} [{this.NextDateTime.ToLongDateString()}]";
		}
	}
}