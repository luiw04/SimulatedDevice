using System;

namespace SimulatedDevice
{
    public class Event
    {
        public int DeviceId { get; set; }

        public int Eid { get; set; }

        public int Level { get; set; }

        public int EventId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
