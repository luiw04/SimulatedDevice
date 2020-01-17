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

        public static Event GetEvent(Device device, int soapLevel)
        {
            var @event = new Faker<Event>()
                //.StrictMode(true)
                .RuleFor(e => e.DeviceId, device.Id)
                .RuleFor(e => e.Payload.Eid, e => e.Random.Number(0,5))
                .RuleFor(e => e.Payload.Level, () => soapLevel < 25 ? 100
                            : Random.Next(24, soapLevel))
                .Generate();

            return @event;
        }

        public static async Task SendEventAsync(this Device device, Event @event)
        {
            var delay = Random.Next(0, 10);

            await device.SendEventAsync(@event, TimeSpan.FromSeconds(delay));
        }

        public static async Task SendEventAsync(this Device device, Event @event, TimeSpan delay)
        {
            await Task.Delay(delay);
            @event.Metadata.Timestamp = DateTime.UtcNow;

            Console.WriteLine($"wazza dev {device.Id} with event {@event.Payload.Eid}");
        }
    }
}
