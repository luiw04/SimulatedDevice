using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    public static class DeviceSimulator
    {
        private static readonly Random Random = new Random();

        public static IEnumerable<Device> GetDevices(int numOfDevices = 5)
        {
            if(numOfDevices > 5)
            {
                throw new ArgumentException("I don't have more than 5 devices :'(");
            }

            var devices = new Faker<Device>()
                .StrictMode(true)
                .RuleFor(d => d.Id, i => i.PickRandom(DeviceConstants.NAMES))
                .RuleFor(d => d.Section, n => n.PickRandom(DeviceConstants.NAMES))
                .Generate(numOfDevices);

            return devices;
        }

        public Event GetEvent(Device device)
        {
            var Event = new Faker<Event>()
                .StrictMode(true)
                .RuleFor(e => e.DeviceId, device.Id);
        }

        public static void SendEvent(this Device device, Event @event)
        {
            var delay = Random.Next(0, 100);

            device.SendEvent(@event, TimeSpan.FromMilliseconds(delay));
        }

        public static void SendEvent(this Device device, Event @event, TimeSpan delay)
        {
            Task.Delay(delay);
            @event.Timestamp = DateTime.UtcNow;

            Console.WriteLine($"wazza dev {device.Id} and event {@event.Eid}");
        }
    }
}
