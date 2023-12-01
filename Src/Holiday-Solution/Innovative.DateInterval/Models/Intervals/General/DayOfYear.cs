//
// Copyright(C) 2013-2024, Daniel M. Porrey. All rights reserved.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
//
namespace Innovative.DateInterval
{
	public class DayOfYear : DateTimeInterval<string>
	{
		public DayOfYear()
			: base()
		{
		}

		public DayOfYear(string value)
			: base(value)
		{
		}

		protected override DateTime OnGetDateTime(int index)
		{
			DateTime returnValue = DateTime.MinValue;

			if (DateTime.TryParse(this.Value, out returnValue))
			{
				returnValue = returnValue.AddYears(index);
			}
			else
			{
				throw new FormatException();
			}

			return returnValue;
		}

		protected override string OnGetDefaultValue()
		{
			return DayOfYear.Default.Value;
		}

		protected override bool OnGetIsValidRange(string value)
		{
			return DateTime.TryParse(value, out DateTime _);
		}

		#region IDateTimeIntervalConverter
		protected override bool OnIsValidString(string value)
		{
			return this.OnGetIsValidRange(value);
		}

		protected override string OnConvertFromString(string value)
		{
			return value;
		}

		protected override string OnConvertToString()
		{
			return this.Value;
		}
		#endregion

		#region Predefined Values
		public static DayOfYear Default
		{
			get
			{
				//
				// The first day of the month is the default
				//
				return new DayOfYear("1/1");
			}
		}
		#endregion
	}
}