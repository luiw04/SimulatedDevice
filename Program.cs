using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            // Create some devices initially, if devices are already created, avoid creation
            var devices = DeviceSimulator.GetDevices(5);
            var events = DeviceSimulator.GetEvents(30).ToList();
            var random = new Random();

            // Infinite loop
            while (true)
            {
                Parallel.ForEach(devices, device =>
                {
                    // Send events randomly and within random periods of time
                    device.SendEvent(events[random.Next(events.Count)]);
                });

                Task.Delay(500);
            }
        }
    }
}
