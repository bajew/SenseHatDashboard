using System;

namespace SenseHatDashboard.Server.Services
{
    public interface ISenseHatServices
    {
        SensorReadings GetReadings();
    }
}