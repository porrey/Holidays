using System.Collections.Generic;
using System.Threading.Tasks;

namespace Innovative.Holiday
{
	public class HolidayList : List<IHoliday>, IHolidayList
	{
		public Task AddAsync(IHoliday holiday)
		{
			this.Add(holiday);
			return Task.FromResult(0);
		}

		public Task AddRangeAsync(IEnumerable<IHoliday> items)
		{
			base.AddRange(items);
			return Task.FromResult(0);
		}

		public Task<bool> RemoveAsync(IHoliday holiday)
		{
			return Task.FromResult(this.Remove(holiday));
		}
	}
}
