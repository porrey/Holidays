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
