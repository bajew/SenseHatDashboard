using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SenseHatDashboard.Shared;
using SenseHatDashboard.Server.Hubs;

namespace SenseHatDashboard.Server.Services
{
    public class SenseHatBroadcasterService: BackgroundService
    {
        private readonly ILogger _Logger;
        private readonly IHubContext<SenseHatHub,ISenseHatHub> _HubContext;
        private readonly ISenseHatServices _SenseHatServices;

        public SenseHatBroadcasterService(ILogger<SenseHatBroadcasterService> logger,
                                         IHubContext<SenseHatHub,ISenseHatHub> hubContext,
                                         ISenseHatServices senseHatServices)
        {
            _Logger = logger;
            _HubContext = hubContext;
            _SenseHatServices = senseHatServices;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var readings = _SenseHatServices.SensorReadings;
                    _Logger.LogInformation(readings.ToString());
                    await _HubContext.Clients.All.PublishSensorReadings(readings.ToSensorData());
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (TaskCanceledException)
            {
                _Logger.LogInformation("Connection cancelled");
            }
            catch (System.Exception ex)
            {
                _Logger.LogError(ex,"");
            }

        }
    }
}