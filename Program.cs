using System.Threading.Tasks;

namespace SimulatedDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulator = new DeviceSimulator();

            // Create some devices initially, if devices are already created, avoid creation
            var allDevices = simulator.GetDevices(5);


            Parallel.ForEach(allDevices, (device) =>
            {
                // Send events randomly and within random periods of time
            });
        }
    }
}
