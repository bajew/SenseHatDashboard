using System;
using SenseHatDashboard.Shared;
using System.Threading.Tasks;

namespace SenseHatDashboard.Server.Hubs
{
    public interface ISenseHatHub
    {
        Task PublishSensorReadings(SensorData readings);
    }
}