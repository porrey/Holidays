//
// Copyright(C) 2013-2025, Daniel M. Porrey. All rights reserved.
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
using Innovative.SystemTime;

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
				if (this._combinations == null)
				{
					this.OnLoadCombinations();
				}

				return this._combinations;
			}
			internal set
			{
				this._combinations = value;
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
