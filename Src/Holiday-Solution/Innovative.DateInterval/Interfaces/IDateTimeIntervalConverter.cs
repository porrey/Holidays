using System;

namespace Innovative.DateInterval
{
	public interface IDateTimeIntervalStringConverter<T>
	{
		bool IsValidString(string value);
		string ConvertToString();
		T ConvertFromString(string value);
	}
}
