using Iot.Units;
using Iot.Device.SenseHat;
using Iot.Device.CpuTemperature;
using System.Drawing;

namespace SenseHatDashboard.Server.Services
{
    public class SenseHatServices:ISenseHatServices
    {
        
        public SensorReadings SensorReadings => GetReadings();

        private readonly SenseHatLedMatrix ledMatrix;

        private readonly SenseHatPressureAndTemperature pressureAndTemperatureSensor;

        private readonly SenseHatTemperatureAndHumidity temperatureAndHumiditySensor;

        private readonly CpuTemperature temperatureCpuSensor;


        public SenseHatServices()
        {
            ledMatrix = new SenseHatLedMatrixI2c();
            pressureAndTemperatureSensor = new SenseHatPressureAndTemperature();
            temperatureAndHumiditySensor = new SenseHatTemperatureAndHumidity();
            temperatureCpuSensor = new CpuTemperature();
        }

        private SensorReadings GetReadings()
        {
            var tempHum =  temperatureAndHumiditySensor.Temperature;
            var tempPress = pressureAndTemperatureSensor.Temperature;
            var tempCpu = temperatureCpuSensor.Temperature;

            return new SensorReadings()
            {
                TempHumidity = temperatureAndHumiditySensor.Temperature,
                Humidity = temperatureAndHumiditySensor.Humidity,
                TempPressure = pressureAndTemperatureSensor.Temperature,
                Pressure = pressureAndTemperatureSensor.Pressure,
                TempCpu = temperatureCpuSensor.Temperature 
            };
        }

        private Temperature TempCorrection(Temperature cpuTemp, Temperature temp)
        {
            return Temperature.FromCelsius(temp.Celsius - ((cpuTemp.Celsius - temp.Celsius) / 5.466));
        }

        private Temperature TempCorrection(Temperature cpuTemp, Temperature humTemp, Temperature pressTemp)
        {
            var avgTemp = Temperature.FromCelsius((humTemp.Celsius + pressTemp.Celsius)/2);
            return Temperature.FromCelsius(avgTemp.Celsius - (cpuTemp.Celsius - avgTemp.Celsius));
        }

        
    }
}