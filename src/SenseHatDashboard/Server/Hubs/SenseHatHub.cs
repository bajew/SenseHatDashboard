using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SenseHatDashboard.Shared;

namespace SenseHatDashboard.Server.Hubs
{
    public class SenseHatHub : Hub <ISenseHatHub> , ISenseHatHub
    {
        public async Task PublishSensorReadings(SensorData readings)
        {
            await Clients.Others.PublishSensorReadings(readings);
        }
    }
}