using System;
using System.Text.Json.Serialization;

public class Event
{
    [JsonPropertyName("hardware_serial")]
    public string DeviceId {get;set;}

    [JsonPropertyName("payload_fields")]
    public EventPayload Payload {get;set;}

    public Metadata Metadata {get;set;}
}

public class EventPayload
{
    public int Eid {get;set;}

    public int Level {get;set;}
}

public class Metadata
{
    [JsonPropertyName("time")]
    public DateTime Timestamp {get;set;}
}
