using System;
using System.IO;
using System.Threading;
using Iot.Device.SenseHat;

namespace sensehat
{
    class Program
    {
        static void Main(string[] args)
        {
            SenseHatServices sense = new  SenseHatServices();
            string line = ""; 
            var startTime = DateTime.Now;
            do
            {
                var reading = sense.SensorReadings;
                System.Console.WriteLine(reading.ToTable());
                File.AppendAllText("sensehatdat.csv", reading.ToCsv());
                Thread.Sleep(1000);
                if(DateTime.Now - startTime > TimeSpan.FromHours(1))
                {
                    break;
                }
            } while (! line.StartsWith("n"));

            System.Console.WriteLine("---Recording Finished---");
        }
    }
}
