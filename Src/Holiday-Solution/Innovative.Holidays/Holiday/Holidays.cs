using System.Collections.Generic;
using System.Linq;

namespace Innovative.Holidays
{
	public enum Day
	{
		// ***
		// *** Federal
		// ***
		NewYearsDay,
		MartinLutherKingDay,
		WashingtonsBirthday,
		MemorialDay,
		IdependanceDay,
		LaborDay,
		ColumbusDay,
		VeteransDay,
		ThanksgivingDay,
		ChristmasEve,
		ChristmasDay,
		NewYearsEve,
		// ***
		// *** Other
		// ***
		GroundhogDay,
		ValentinesDay,
		SaintPatricksDay,
		AprilFoolsDay,
		PalmSunday,
		GoodFriday,
		Easter,
		CincodeMayo,
		MothersDay,
		FlagDay,
		FathersDay,
		Halloween
	}

	public static class Holidays
	{
		public readonly static List<IHoliday> Other = new List<IHoliday>(new IHoliday[]
		{
			new GroundhogDay(),
			new ValentinesDay(),
			new SaintPatricksDay(),
			new AprilFoolsDay(),
			new PalmSunday(),
			new GoodFriday(),
			new EasterSunday(),
			new CincodeMayo(),
			new MothersDay(),
			new FlagDay(),
			new FathersDay(),
			new Halloween()
		});

		public readonly static List<IHoliday> Federal = new List<IHoliday>(new IHoliday[]
		{
			new NewYearsDay(),
			new MartinLutherKingDay(),
			new WashingtonsBirthday(),
			new MemorialDay(),
			new IdependanceDay(),
			new LaborDay(),
			new ColumbusDay(),
			new VeteransDay(),
			new ThanksgivingDay(),
			new ChristmasEve(),
			new Christmas(),
			new NewYearsEve()
		});

		public static readonly List<IHoliday> All = new List<IHoliday>(Holidays.Federal.Union(Holidays.Other));
	}
}
