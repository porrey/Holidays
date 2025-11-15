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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Innovative.Holiday.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Innovative.Holiday.Example
{
	public class HostedService(ILogger<HostedService> logger, IHostApplicationLifetime appLifetime, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory) : IHostedService
	{
		protected int ExitCode { get; set; }
		protected ILogger<HostedService> Logger { get; set; } = logger;
		protected IHostApplicationLifetime HostApplicationLifetime { get; set; } = appLifetime;
		protected IConfiguration Configuration { get; set; } = configuration;
		protected IServiceScopeFactory ServiceScopeFactory { get; set; } = serviceScopeFactory;

		public Task StartAsync(CancellationToken cancellationToken)
		{
			//
			// Create a date/time instance.
			//
			DateTime dt = new(2020, 9, 7);

			//
			// Use static methods:
			//
			#region Static Methods
			{
				//
				// Register the holidays.
				//
				Holidays.Register(Us.Federal.All.Items, Us.Other.All.Items, Religious.Christian.All.Items);

				//
				// Check if the date is a holiday.
				//
				bool isHoliday = dt.IsHoliday(HolidayOccurrenceType.Observed);
				this.Logger.LogInformation("The date {date} {is} a holiday.", dt.Date.ToShortDateString(), isHoliday ? "is" : " is NOT ");

				//
				// Get the holiday on this day.
				//
				IEnumerable<IHoliday> holidays = dt.GetHoliday(HolidayOccurrenceType.Actual);
				this.Logger.LogInformation("The holiday is {name}", holidays.First().Name);
			}
			#endregion

			//
			// Use IHolidayService
			//
			#region IHolidayService
			//
			// Create a date/time instance.
			//
			using (IServiceScope scope = this.ServiceScopeFactory.CreateScope())
			{
				//
				// Get the service
				//
				IHolidayService holidayService = scope.ServiceProvider.GetService<IHolidayService>();

				//
				// Check if the date is a holiday.
				//
				bool isHoliday = holidayService.IsHoliday(dt, HolidayOccurrenceType.Observed);
				this.Logger.LogInformation("The date {date} {is} a holiday.", dt.Date.ToShortDateString(), isHoliday ? "is" : " is NOT ");

				//
				// Get the holiday on this day.
				//
				IEnumerable<IHoliday> holidays = holidayService.GetHoliday(dt, HolidayOccurrenceType.Actual);
				this.Logger.LogInformation("The holiday is {name}", holidays.First().Name);
			}
			#endregion

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			this.Logger.LogDebug("Exiting service {name} with return code: {code}", nameof(HostedService), this.ExitCode);

			//
			// Exit code.
			//
			Environment.ExitCode = this.ExitCode;
			return Task.CompletedTask;
		}
	}
}
