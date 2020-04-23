using Iot.Units;
using System;
using System.Text;

namespace sensehat
{
    public class SensorReadings
    {
        public Temperature TempHumidity { get; set; }

        public Temperature TempPressure { get; set; }
        
        public Temperature TempCpu {get;set;}

        public float Humidity { get; set; }

        public float Pressure { get; set; }

        public DateTime TimeStamp { get; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"TempHumidity: {TempHumidity.Celsius,5:F2} °C"
                + $" TempPressure: {TempPressure.Celsius,5:F2} °C"
                + $" TempCpu: {TempCpu.Celsius,5:F2} °C"
                + $" Humidity: {Humidity,4:F1} %"
                + $" Pressure: {Pressure,6:F1} hPa";
        }

        public string ToTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"   Name   |   Value   ");
            sb.AppendLine($"T.CPU.    | {TempCpu.Celsius,5:F2} °C");

            sb.AppendLine($"T.Hum.    | {TempHumidity.Celsius,5:F2} °C");

            sb.AppendLine($"T.Prs.    | {TempPressure.Celsius,5:F2} °C");
            sb.AppendLine($"Humidity  | {Humidity,4:F1} %");
            sb.AppendLine($"Pressure  | {Pressure,6:F1} hPa");
            
            return sb.ToString();
        }
        public string ToCsv()
        {
           StringBuilder sb = new StringBuilder();
            sb.Append($"{TempCpu.Celsius,5:F2}|");
            sb.Append($"{TempHumidity.Celsius,5:F2}|");
            sb.Append($"{TempPressure.Celsius,5:F2}|");
            sb.Append($"{Humidity,4:F1}|");
            sb.Append($"{Pressure,6:F1}|");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}