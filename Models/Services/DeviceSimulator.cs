using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    public static class DeviceSimulator
    {
        private static readonly Random Random = new Random();

        public static IEnumerable<Device> GetDevices(int count)
        {
            return new Faker<Device>()
                .StrictMode(true)
                .RuleFor(d => d.Id, i => i.Random.Number(1, count - 1))
                .RuleFor(d => d.Name, n => n.PickRandom(DeviceConstants.NAMES))
                .RuleFor(d => d.Section, s => s.PickRandom(DeviceConstants.SECTIONS))
                .Generate(count);
        }

        public static IEnumerable<Event> GetEvents(int count)
        {
            return new Faker<Event>()
                .StrictMode(true)
                .RuleFor(d => d.DeviceId, i => i.Random.Number(1, count - 1))
                .RuleFor(d => d.Eid, i => i.Random.Number(1, count - 1))
                .RuleFor(d => d.Level, i => i.Random.Number(1, count - 1))
                .RuleFor(d => d.EventId, i => i.Random.Number(1, count - 1))
                .Generate(count);
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
