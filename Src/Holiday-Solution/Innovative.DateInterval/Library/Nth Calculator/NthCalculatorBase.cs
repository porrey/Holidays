using System;

namespace Innovative.DateInterval
{
	internal abstract class NthCalculatorBase : INthCalculator
	{
		private Combination[] _combinations = null;

		public NthCalculatorBase()
		{
		}

		public Combination[] ValidCombinations
		{
			get
			{
				if (_combinations == null)
				{
					this.OnLoadCombinations();
				}

				return _combinations;
			}
			internal set
			{
				_combinations = value;
			}
		}

		public DateTime Calculate(int n, Division division, Period period, int index, Time time)
		{
			DateTime returnValue = DateTime.MinValue;

			returnValue = this.OnCalculateNext(n, division, period, time);

			if (index != 0)
			{
				returnValue = this.OnCalculateIndex(n, returnValue, index);
			}

			return returnValue;
		}

		protected virtual void OnLoadCombinations()
		{
		}

		protected virtual DateTime OnCalculateNext(int n, Division division, Period period, Time time)
		{
			throw new NotImplementedException();
		}

		protected virtual DateTime OnCalculateIndex(int n, DateTime next, int index)
		{
			throw new NotImplementedException();
		}
	}
}
