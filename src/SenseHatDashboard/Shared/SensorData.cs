using System;

namespace SenseHatDashboard.Shared
{
    public class SensorData
    {
        public DateTime TimeStamp { get; set; }
        public double TempHumidity { get; set; }
        public double TempPressure { get; set; }
        public double TempCpu { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }

        public override  string ToString()
        {
            return $"[{TimeStamp}] TCpu:{TempCpu} TH: {TempHumidity} TP: {TempPressure} H: {Humidity} P: {Pressure}";
        }
    }
}