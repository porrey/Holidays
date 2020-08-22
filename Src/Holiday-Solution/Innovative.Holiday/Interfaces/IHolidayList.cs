using System.Collections.Generic;
using System.Threading.Tasks;

namespace Innovative.Holiday
{
	public interface IHolidayList :IList<IHoliday>
	{
		Task AddAsync(IHoliday holiday);
		Task<bool> RemoveAsync(IHoliday holiday);
		void AddRange(IEnumerable<IHoliday> items);
		Task AddRangeAsync(IEnumerable<IHoliday> items);
	}
}
