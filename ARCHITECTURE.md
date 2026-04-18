# Architecture Overview

## Summary

The **Holidays** repository is a .NET class library suite for calculating holiday dates and determining whether a given date falls on a known holiday. It is authored by Daniel M. Porrey and licensed under the GNU Lesser General Public License v3.0. All packages target **.NET 10.0** and are published as NuGet packages.

---

## Key Technologies

| Technology | Usage |
|---|---|
| C# / .NET 10.0 | Primary language and runtime |
| NuGet | Package distribution for each project |
| NUnit | Unit testing framework |
| Microsoft.Extensions.DependencyInjection | Holiday service registration |
| Microsoft.Extensions.Hosting | Example console app host |
| LGPL-3.0 | Open-source license |

---

## Repository Layout

```
/
├── Images/                         # Package icons
├── Src/
│   ├── Holiday-Solution.sln        # Visual Studio solution file
│   │
│   ├── Innovative.DateInterval/    # Core date interval abstraction
│   ├── Innovative.SystemTime/      # Time struct utility
│   │
│   ├── Innovative.Holiday/         # Core holiday abstractions
│   ├── Innovative.Holiday.Us.FederalRule/   # US federal observance rule
│   ├── Innovative.Holiday.Static/  # Static DateTime extension methods
│   ├── Innovative.Holiday.Extensions/      # DI/service integration
│   │
│   ├── Innovative.Holiday.Us.Federal/      # US federal holiday definitions
│   ├── Innovative.Holiday.Us.Other/        # Other US holiday definitions
│   ├── Innovative.Holiday.Religious.Christian/  # Christian holiday definitions
│   ├── Innovative.Holiday.Dst/     # Daylight Saving Time event definitions
│   ├── Innovative.Holiday.Seasons/ # Seasons template/stub
│   │
│   ├── Innovative.Holiday.Tests/
│   ├── Innovative.Holiday.Us.Federal.Tests/
│   ├── Innovative.Holiday.Us.Others.Tests/
│   ├── Innovative.Holiday.Dst.Tests/
│   ├── Innovative.Holiday.Religious.Christian.Tests/
│   ├── Innovative.Tests.Shared/    # Shared test utilities
│   │
│   └── Example/                    # Console app usage example
└── README.md
```

---

## Project Dependency Graph

```
Innovative.DateInterval
        │
        ▼
Innovative.Holiday  ◄──── Innovative.Holiday.Us.FederalRule
        │                         │
        ├── Innovative.Holiday.Static
        ├── Innovative.Holiday.Extensions (+ Microsoft.Extensions.DependencyInjection)
        │
        ├── Innovative.Holiday.Us.Federal  (depends on FederalRule)
        ├── Innovative.Holiday.Us.Other
        ├── Innovative.Holiday.Religious.Christian
        └── Innovative.Holiday.Dst
```

`Innovative.SystemTime` is a standalone utility with no intra-repo dependencies.

---

## Core Concepts

### 1. `DateTimeInterval` (Innovative.DateInterval)

The foundational abstraction. A `DateTimeInterval` represents a **recurring date** — it behaves like an infinite read-only list of `DateTime` values indexed from 0, where index 0 is always the *next upcoming* occurrence.

Key members:
- `NextDateTime` — next occurrence from today
- `this[int index]` — nth future occurrence
- `GetByIndex(int index)` — nth future occurrence
- `GetByYear(int year)` — occurrence in a specific year
- `OnGetDateTime(int index)` — abstract override point for subclasses

It implements `IComparable`, `IFormattable`, `ISerializable`, and `IEnumerable<DateTime>`, and defines implicit conversion to `DateTime`.

**Concrete interval types** (in `Models/Intervals/General/`):

| Class | Description |
|---|---|
| `DayOfYear` | A fixed month/day each year (e.g., July 4) |
| `DayOfMonth` | A specific day number each month |
| `Nth` | The nth weekday of a month (e.g., 3rd Monday in January) |
| `WeekDay` | A recurring weekday |
| `TimeOfDay` | A time of day |

### 2. `IHoliday` / `Holiday` (Innovative.Holiday)

`IHoliday` extends `IDateTimeInterval` and adds:
- `Name` — holiday name
- `Description` — history/context
- `ObservanceRule` — human-readable description of the rule

`Holiday` is the abstract base class. Each concrete holiday class overrides `OnGetDateTime(int index)` to return the nth occurrence, delegating to one of the `DateTimeInterval` calculators above.

### 3. `IObservedHoliday` / `ObservedHoliday`

Some holidays have an *observed* date (e.g., when a holiday falls on a weekend, it may be observed on Friday or Monday). `ObservedHoliday` extends `Holiday` and introduces:
- `NextObserved` — next observed date
- `GetObservedByIndex(int index)` / `GetObservedByYear(int year)`
- `ObservedHolidayRule` — an `IObservedHolidayRule` that transforms actual → observed date

### 4. `IObservedHolidayRule` / `FederalHolidayRule`

The Strategy pattern for date adjustment. `FederalHolidayRule` implements the US federal rule:
- Saturday → observed Friday
- Sunday → observed Monday

`FederalHoliday` is an abstract class that pre-wires `ObservedHolidayRule = new FederalHolidayRule()`. All US federal holidays extend it.

### 5. Holiday Class Hierarchy

```
DateTimeInterval  (Innovative.DateInterval)
    └── Holiday  (Innovative.Holiday)
            ├── ObservedHoliday
            │       └── FederalHoliday  (Innovative.Holiday.Us.FederalRule)
            │               ├── NewYearsDay
            │               ├── MartinLutherKingDay
            │               ├── WashingtonsBirthday
            │               ├── MemorialDay
            │               ├── IndependenceDay
            │               ├── LaborDay
            │               ├── ColumbusDay
            │               ├── VeteransDay
            │               └── ThanksgivingDay
            ├── Easter / EasterSunday (custom algorithm)
            ├── Christmas, ChristmasEve, GoodFriday, PalmSunday, ...
            ├── StartDst, EndDst
            └── AprilFoolsDay, Halloween, ValentinesDay, ...
```

### 6. `HolidayList` / `Holidays` (Innovative.Holiday)

`HolidayList` is a `List<IHoliday>` implementing `IHolidayList`, with both synchronous and async Add/Remove/AddRange helpers.

`Holidays` is a **static registry** class with a global `MyHolidays` list. Call `Holidays.Register(...)` to enroll holidays for use by extension methods.

Each holiday package exposes a static `All.Items` (`IHolidayList`) for convenient bulk registration:

```csharp
Holidays.Register(Us.Federal.All.Items, Us.Other.All.Items, Religious.Christian.All.Items);
```

### 7. Static Extension Methods (Innovative.Holiday.Static)

Extensions on `DateTime` and `DateTimeOffset` backed by `Holidays.MyHolidays`:

```csharp
bool isHoliday = someDate.IsHoliday(HolidayOccurrenceType.Actual);
IEnumerable<IHoliday> holidays = someDate.GetHoliday(HolidayOccurrenceType.Observed);
```

The `HolidayOccurrenceType` enum controls whether to compare against actual or observed dates:
- `Actual` — the calendar date of the holiday
- `Observed` — the date when the holiday is officially observed
- `Any` — either

### 8. Dependency Injection (Innovative.Holiday.Extensions)

For applications using `Microsoft.Extensions.DependencyInjection`, `IHolidayService` wraps the same lookup logic as an injectable service:

```csharp
services.UseHolidayService(myHolidayList);
// then inject IHolidayService and call:
holidayService.IsHoliday(date, HolidayOccurrenceType.Observed);
holidayService.GetHoliday(date, HolidayOccurrenceType.Actual);
```

### 9. `Innovative.SystemTime` — Time Struct

A self-contained `struct Time` that wraps `TimeSpan` and provides time-of-day arithmetic, comparisons, and implicit conversions with `DateTime`, `TimeSpan`, and `string`.

---

## Holiday Packages

| Package | Contents |
|---|---|
| `Innovative.Holiday.Us.Federal` | 9 US federal public holidays (New Year's Day, MLK Day, Washington's Birthday, Memorial Day, Independence Day, Labor Day, Columbus Day, Veterans Day, Thanksgiving Day) |
| `Innovative.Holiday.Us.Other` | ~13 additional US observances (Valentine's Day, St. Patrick's Day, April Fools' Day, Mother's Day, Armed Forces Day, Flag Day, Father's Day, Juneteenth, Halloween, Groundhog Day, Cinco de Mayo, New Year's Eve) |
| `Innovative.Holiday.Religious.Christian` | Easter, Good Friday, Palm Sunday, Christmas, Christmas Eve, National Day of Prayer |
| `Innovative.Holiday.Dst` | Start DST, End DST |
| `Innovative.Holiday.Seasons` | Template stub for season definitions |

---

## Testing Strategy

Tests use **NUnit** with `[TestCaseSource]` to verify each holiday against known correct actual and observed dates for multiple years (typically 2000–2034).

Test projects mirror their corresponding library projects:

| Test Project | Tests |
|---|---|
| `Innovative.Holiday.Tests` | Core holiday base classes |
| `Innovative.Holiday.Us.Federal.Tests` | All 9 US federal holidays, actual and observed |
| `Innovative.Holiday.Us.Others.Tests` | US other holidays |
| `Innovative.Holiday.Dst.Tests` | DST start/end dates |
| `Innovative.Holiday.Religious.Christian.Tests` | Easter and other Christian holidays |
| `Innovative.Tests.Shared` | Shared `DatePair` test model and `Assert2` helper |

---

## Adding a New Holiday

1. Create a class that extends `Holiday` (or `FederalHoliday` / `ObservedHoliday` if it has an observed date).
2. Override `OnGetDateTime(int index)` using a `DateTimeInterval` calculator (`DayOfYear`, `Nth`, etc.) or custom logic.
3. Override `Name`, `Description`, and `ObservanceRule`.
4. Register it: `Holidays.Register(new MyHoliday())` or add it to an `All.Items` list.

A `Template.cs` class in `Innovative.Holiday.Seasons` is provided as a starting point.

---

## NuGet Publishing

The `NuGet.Publish.cmd` script at the root of `Src/` automates publishing all library packages to NuGet. Each `.csproj` has `<GeneratePackageOnBuild>true</GeneratePackageOnBuild>` and includes version, author, license, icon, and symbol package settings.
