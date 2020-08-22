using System;

namespace Innovative.DateInterval
{
	public interface IValue<T>
	{
		T Value { get; set; }
		bool IsValidRange(T value);
		T DefaultValue { get; }
		T FromString(string value);
	}
}
