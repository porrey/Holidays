![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/porrey/Holidays/.github%2Fworkflows%2Fdotnet.yml?style=for-the-badge&label=Build%20and%20Test) ![GitHub License](https://img.shields.io/github/license/porrey/Holidays?style=for-the-badge) ![.NET](https://img.shields.io/badge/.NET-10-purple?style=for-the-badge)

# Holidays
A .NET library suite for calculating holiday dates and determining whether a given date falls on a known holiday. The library supports US federal holidays, other US observances, Christian holidays, Daylight Saving Time events, and provides extension points for defining your own custom holidays.

Reference: [https://www.timeanddate.com/holidays](https://www.timeanddate.com/holidays)

---

## NuGet Packages

| Package | Description |
|---|---|
| [`Innovative.Holiday`](https://www.nuget.org/packages/Innovative.Holiday) | Core holiday abstractions, base classes, and the global `Holidays` registry |
| [`Innovative.Holiday.Us.Federal`](https://www.nuget.org/packages/Innovative.Holiday.Us.Federal) | 9 US federal public holidays (per OPM schedule) |
| [`Innovative.Holiday.Us.Other`](https://www.nuget.org/packages/Innovative.Holiday.Us.Other) | 12 additional US observances |
| [`Innovative.Holiday.Religious.Christian`](https://www.nuget.org/packages/Innovative.Holiday.Religious.Christian) | Christian holidays (Easter, Christmas, Good Friday, etc.) |
| [`Innovative.Holiday.Dst`](https://www.nuget.org/packages/Innovative.Holiday.Dst) | Daylight Saving Time start/end events |
| [`Innovative.Holiday.Static`](https://www.nuget.org/packages/Innovative.Holiday.Static) | `DateTime` / `DateTimeOffset` extension methods |
| [`Innovative.Holiday.Extensions`](https://www.nuget.org/packages/Innovative.Holiday.Extensions) | `IHolidayService` for dependency injection |
| [`Innovative.DateInterval`](https://www.nuget.org/packages/Innovative.DateInterval) | Core recurring-date interval abstractions used internally |
| [`Innovative.SystemTime`](https://www.nuget.org/packages/Innovative.SystemTime) | Standalone `Time` struct for time-of-day arithmetic |

All packages target **.NET 10.0** and are versioned at **10.0.0**.

---

## Quick Start

### Installation

Install the packages you need via the .NET CLI:

```shell
# Core library + US federal holidays + static DateTime extensions
dotnet add package Innovative.Holiday
dotnet add package Innovative.Holiday.Us.Federal
dotnet add package Innovative.Holiday.Static
```

For additional holiday sets:

```shell
dotnet add package Innovative.Holiday.Us.Other
dotnet add package Innovative.Holiday.Religious.Christian
dotnet add package Innovative.Holiday.Dst
```

For dependency injection support:

```shell
dotnet add package Innovative.Holiday.Extensions
```

---

## Usage

### 1. Static Extension Methods

Register the holidays you want to use once at startup (e.g., in `Program.cs`), then call the `IsHoliday` / `GetHoliday` extension methods on any `DateTime` value.

```csharp
using Innovative.Holiday;

// Register holiday sets with the global registry
Holidays.Register(Us.Federal.All.Items, Us.Other.All.Items, Religious.Christian.All.Items);

DateTime date = new DateTime(2025, 7, 4);

// Check whether the date is a holiday
bool isHoliday = date.IsHoliday(HolidayOccurrenceType.Actual);

// Get matching holidays
IEnumerable<IHoliday> holidays = date.GetHoliday(HolidayOccurrenceType.Actual);
foreach (IHoliday holiday in holidays)
{
    Console.WriteLine($"{holiday.Name} on {holiday.NextDateTime.ToShortDateString()}");
}
```

#### `HolidayOccurrenceType` values

| Value | Meaning |
|---|---|
| `Actual` | The calendar date the holiday officially falls on |
| `Observed` | The date when the holiday is officially observed (e.g., Monday when a holiday falls on Sunday) |
| `Any` | Match either the actual or the observed date |

### 2. Dependency Injection (`IHolidayService`)

Register `IHolidayService` in your DI container and inject it wherever you need it.

```csharp
// In your Startup / ConfigureServices
using Innovative.Holiday.Extensions;

services.UseHolidayService(new HolidayList(Us.Federal.All.Items));
```

Then inject and use the service:

```csharp
public class MyService(IHolidayService holidayService)
{
    public void CheckDate(DateTime date)
    {
        bool isHoliday = holidayService.IsHoliday(date, HolidayOccurrenceType.Observed);
        IEnumerable<IHoliday> holidays = holidayService.GetHoliday(date, HolidayOccurrenceType.Actual);
    }
}
```

### 3. Working Directly with Holiday Objects

Every holiday exposes the next occurrence and can be queried by index or year:

```csharp
using Innovative.Holiday;

var thanksgiving = new ThanksgivingDay();

// Next upcoming Thanksgiving
DateTime next = thanksgiving.NextDateTime;

// Thanksgiving in a specific year
DateTime in2030 = thanksgiving.GetByYear(2030);

// Observed date (Friday if it falls on Saturday, Monday if on Sunday)
DateTime observed2030 = thanksgiving.GetObservedByYear(2030);

Console.WriteLine($"Name:        {thanksgiving.Name}");
Console.WriteLine($"Description: {thanksgiving.Description}");
Console.WriteLine($"Rule:        {thanksgiving.ObservanceRule}");
Console.WriteLine($"Next actual: {next.ToLongDateString()}");
Console.WriteLine($"2030 actual: {in2030.ToLongDateString()}");
Console.WriteLine($"2030 observed: {observed2030.ToLongDateString()}");
```

---

## Holiday Packages

### US Federal Holidays (`Innovative.Holiday.Us.Federal`)

This package contains the 9 holidays recognized on the official [OPM federal pay schedule](https://www.opm.gov/policy-data-oversight/pay-leave/federal-holidays/). Note that Juneteenth National Independence Day is included in `Innovative.Holiday.Us.Other`, and Christmas Day is included in `Innovative.Holiday.Religious.Christian`.

| Holiday | Rule |
|---|---|
| New Year's Day | January 1 |
| Martin Luther King Jr. Day | 3rd Monday in January |
| Washington's Birthday | 3rd Monday in February |
| Memorial Day | Last Monday in May |
| Independence Day | July 4 |
| Labor Day | 1st Monday in September |
| Columbus Day | 2nd Monday in October |
| Veterans Day | November 11 |
| Thanksgiving Day | 4th Thursday in November |

All US federal holidays apply the **federal observance rule**: if the holiday falls on Saturday it is observed on the preceding Friday; if it falls on Sunday it is observed on the following Monday.

### Other US Holidays (`Innovative.Holiday.Us.Other`)

April Fools' Day, Armed Forces Day, Cinco de Mayo, Father's Day, Flag Day, Groundhog Day, Halloween, Juneteenth, Mother's Day, New Year's Eve, St. Patrick's Day, and Valentine's Day.

### Christian Holidays (`Innovative.Holiday.Religious.Christian`)

Easter, Good Friday, Palm Sunday, Christmas Eve, Christmas, and National Day of Prayer.

### Daylight Saving Time (`Innovative.Holiday.Dst`)

Start DST (2nd Sunday in March) and End DST (1st Sunday in November).

---

## Creating a Custom Holiday

1. Add a reference to `Innovative.Holiday` and (optionally) `Innovative.DateInterval`.
2. Create a class that extends `Holiday` (or `ObservedHoliday` / `FederalHoliday` if the holiday has an observed date).
3. Override `OnGetDateTime(int index)` using one of the built-in interval calculators.
4. Override `Name`, `Description`, and `ObservanceRule`.
5. Register it with the global registry or your DI `HolidayList`.

```csharp
using Innovative.DateInterval;
using Innovative.Holiday;

// A simple fixed-date holiday (e.g., April 15 every year)
public class TaxDay : Holiday
{
    private readonly IDateTimeInterval _calculator = new DayOfYear("4/15");

    protected override DateTime OnGetDateTime(int index) => _calculator[index];
    public override string Name => "Tax Day";
    public override string Description => "Federal income tax filing deadline in the US.";
    public override string ObservanceRule => "April 15th";
}

// A floating holiday (e.g., 2nd Tuesday in November)
public class ElectionDay : Holiday
{
    private readonly IDateTimeInterval _calculator = new Nth(2, DayOfWeek.Tuesday, 11);

    protected override DateTime OnGetDateTime(int index) => _calculator[index];
    public override string Name => "Election Day";
    public override string Description => "US federal election day.";
    public override string ObservanceRule => "Second Tuesday in November";
}

// Register with the global registry
Holidays.Register(new TaxDay());
Holidays.Register(new ElectionDay());
```

### Built-in `DateTimeInterval` Calculators

| Class | Description | Example |
|---|---|---|
| `DayOfYear` | A fixed month/day each year | `new DayOfYear("7/4")` → July 4 |
| `DayOfMonth` | A specific day number each month | `new DayOfMonth(15)` → 15th of each month |
| `Nth` | The *n*th weekday of a month | `new Nth(3, DayOfWeek.Monday, 1)` → 3rd Monday in January |
| `WeekDay` | A recurring weekday | `new WeekDay(DayOfWeek.Monday)` |
| `TimeOfDay` | A time of day | `new TimeOfDay(9, 0)` |

---

## API Reference

### `IHoliday`

| Member | Type | Description |
|---|---|---|
| `Name` | `string` | Display name of the holiday |
| `Description` | `string` | History or context for the holiday |
| `ObservanceRule` | `string` | Human-readable rule description |
| `NextDateTime` | `DateTime` | Next upcoming occurrence |
| `GetByIndex(int)` | `DateTime` | *n*th future occurrence (0 = next) |
| `GetByYear(int)` | `DateTime` | Occurrence in a specific year |

### `IObservedHoliday` (extends `IHoliday`)

| Member | Type | Description |
|---|---|---|
| `NextObserved` | `DateTime` | Next observed date |
| `GetObservedByIndex(int)` | `DateTime` | *n*th future observed date |
| `GetObservedByYear(int)` | `DateTime` | Observed date in a specific year |
| `ObservedHolidayRule` | `IObservedHolidayRule` | Rule that transforms actual → observed |

### `Holidays` (static registry)

| Method | Description |
|---|---|
| `Holidays.Register(IHoliday)` | Register a single holiday |
| `Holidays.Register(IEnumerable<IHoliday>)` | Register a collection of holidays |
| `Holidays.Register(params IEnumerable<IHoliday>[])` | Register multiple collections at once |
| `Holidays.MyHolidays` | The global `IHolidayList` used by extension methods |

### `DateTime` / `DateTimeOffset` Extension Methods

Provided by `Innovative.Holiday.Static`:

| Method | Returns | Description |
|---|---|---|
| `IsHoliday(HolidayOccurrenceType)` | `bool` | Returns `true` if the date matches a registered holiday |
| `IsHolidayAsync(HolidayOccurrenceType)` | `Task<bool>` | Async version of `IsHoliday` |
| `GetHoliday(HolidayOccurrenceType)` | `IEnumerable<IHoliday>` | Returns all holidays that match the date |
| `GetHolidayAsync(HolidayOccurrenceType)` | `Task<IEnumerable<IHoliday>>` | Async version of `GetHoliday` |

---

## License

This project is licensed under the [GNU Lesser General Public License v3.0 (LGPL-3.0)](LICENSE).  
Copyright © 2013–2025 Daniel M. Porrey. All rights reserved.
