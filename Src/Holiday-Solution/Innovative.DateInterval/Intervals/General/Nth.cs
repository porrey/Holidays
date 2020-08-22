using System;
using System.Collections.Generic;

namespace Innovative.DateInterval
{
	public class Nth : DateTimeInterval<NthParser>
	{
		public Nth()
			: base()
		{
		}

		public Nth(NthParser value)
			: base(value)
		{
		}

		public Nth(string value)
		{
			this.Value = NthParser.Parse(value);
		}

		public Nth(int nth, Division division, Period period)
		{
			this.Value = new NthParser(nth, division, period);
		}

		public Nth(Ordinal ordinal, Division division, Period period)
		{
			this.Value = new NthParser(ordinal, division, period);
		}

		protected override DateTime OnGetDateTime(int index)
		{
			return this.Value.GetNextDateTime(index);
		}

		protected override NthParser OnGetDefaultValue()
		{
			return NthParser.Default;
		}

		#region IDateTimeIntervalConverter
		protected override NthParser OnConvertFromString(string value)
		{
			return NthParser.Parse(value);
		}

		protected override string OnConvertToString()
		{
			return this.Value.ToString();
		}

		protected override bool OnIsValidString(string value)
		{
			bool returnValue = false;

			returnValue = NthParser.CanParse(value);

			return returnValue;
		}
		#endregion
	}
}