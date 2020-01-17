using System.Collections.Generic;
using Bogus;

public class DeviceSimulator
{
    public IEnumerable<Device> GetDevices(int numOfDevices)
    {
        var devices = new Faker<Device>()
            .StrictMode(true)
            .RuleFor(d => d.Id, i => i.Random.Number(1,numOfDevices - 1))
            .RuleFor(d => d.Name, n => n.PickRandom(DeviceConstants.NAMES))
            .RuleFor(d => d.Section, s => s.PickRandom(DeviceConstants.NAMES));

        // TODO: Return a list of numOfDevices, limit the number to the mocked data in constant arrays
        var devs = new List<Device>();
        devs.Add(devices);
        return devs;
    }
}