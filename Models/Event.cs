using System;
using System.Text.Json.Serialization;

namespace SimulatedDevice
{
    public class Event
    {
        [JsonPropertyName("hardware_serial")]
        public string DeviceId { get; set; }

        [JsonPropertyName("payload_fields")]
        public EventPayload Payload { get; set; }
        
        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }
    }

    public class EventPayload
    {
        [JsonPropertyName("eid")]
        public int Eid { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }
    }

    public class Metadata
    {
        [JsonPropertyName("time")]
        public DateTime Timestamp { get; set; }
    }
}
