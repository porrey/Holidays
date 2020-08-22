using System;

namespace Innovative.DateInterval
{
	public abstract class DateTimeIntervalException : Exception
	{
		public DateTimeIntervalException()
			: base()
		{
		}

		public DateTimeIntervalException(string message)
			: base(message)
		{
		}

		public DateTimeIntervalException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
