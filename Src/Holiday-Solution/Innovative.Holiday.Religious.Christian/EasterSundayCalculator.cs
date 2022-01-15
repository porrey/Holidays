//
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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
using System;

namespace Innovative.Holiday
{
	public class EasterSundayCalculator
	{
		public EasterSundayCalculator()
		{
			this.Year = DateTime.Now.Year;
		}

		public EasterSundayCalculator(int year)
		{
			this.Year = year;
		}

		public int Year { get; set; } = 0;

		public DateTime Date
		{
			get
			{
				return new DateTime(this.Year, this.Month, this.Day);
			}
		}

		private int Truncate(double n)
		{
			return (int)Math.Truncate(n);
		}

		private int Fx1
		{
			get
			{
				return this.Year % 19;
			}
		}

		private int Fx2
		{
			get
			{
				return this.Truncate(this.Year / 100);
			}
		}

		private int Fx3
		{
			get
			{
				return this.Year % 100;
			}
		}

		private int Fx4
		{
			get
			{
				return this.Truncate(this.Fx2 / 4);
			}
		}

		private int Fx5
		{
			get
			{
				return this.Fx2 % 4;
			}
		}

		private int Fx6
		{
			get
			{
				return this.Truncate((this.Fx2 + 8) / 25);
			}
		}

		private int Fx7
		{
			get
			{
				return this.Truncate((this.Fx2 - this.Fx6 + 1) / 3);
			}
		}

		private int Fx8
		{
			get
			{
				return ((19 * this.Fx1) + this.Fx2 - this.Fx4 - this.Fx7 + 15) % 30;
			}
		}

		private int Fx9
		{
			get
			{
				return this.Truncate(this.Fx3 / 4);
			}
		}

		private int Fx10
		{
			get
			{
				return this.Fx3 % 4;
			}
		}

		private int Fx11
		{
			get
			{
				return (32 + 2 * (this.Fx5 + this.Fx9) - this.Fx8 - this.Fx10) % 7;
			}
		}

		private int Fx12
		{
			get
			{
				return this.Truncate((this.Fx1 + (11 * this.Fx8) + (22 * this.Fx11)) / 415);
			}
		}

		private int Fx13
		{
			get
			{
				return ((this.Fx8 + this.Fx11 - (7 * this.Fx12) + 114)) % 31;
			}
		}

		private int Month
		{
			get
			{
				return this.Truncate((this.Fx8 + this.Fx11 - (7 * this.Fx12) + 114) / 31);
			}
		}

		private int Day
		{
			get
			{
				return this.Fx13 + 1;
			}
		}
	}
}
