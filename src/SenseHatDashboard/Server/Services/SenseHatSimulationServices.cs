using Iot.Units;
using SenseHatDashboard.Server.Services;

namespace SenseHatDashboard.Server.Services
{
    public class SenseHatSimulationServices : ISenseHatServices
    {
        public SensorReadings SensorReadings => GetMockReadings();

        private SensorReadings GetMockReadings()
        {
            System.Random rnd = new System.Random();
            
            return new SensorReadings()
            {
                TempHumidity = Temperature.FromCelsius(rnd.Next(20,30)),
                Humidity = rnd.Next(40, 50),
                TempPressure = Temperature.FromCelsius(rnd.Next(20,30)),
                Pressure = rnd.Next(250, 300),
                TempCpu = Temperature.FromCelsius(rnd.Next(40,60))
            };
        }
    }
}