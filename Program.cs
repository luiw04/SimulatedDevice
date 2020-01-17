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

            // Infinite loop
            while (true)
            {
                Parallel.ForEach(devices, device =>
                {
                    var @event = DeviceSimulator.GetEvent(device, device.Level);

                    // Send events randomly and within random periods of time
                    device.SendEventAsync(@event).Wait();
                });

                Task.Delay(1).Wait();
            }
        }
    }
}
