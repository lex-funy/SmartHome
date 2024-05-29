using System.Text.Json.Serialization;

namespace SmartHome.Dirigera.Models;

public class Device
{
    public string Id { get; set; }
    public string Type { get; set; }
    public bool IsReachable { get; set; }

    public Attributes Attributes { get; set; }
    public Capabilities Capabilities { get; set; }
    public Room Room { get; set; }

    public IList<DeviceSet> DeviceSet { get; set; }
}

public class Attributes
{
    public string CustomName { get; set; } = null!;
    public bool IsOn { get; set; }
    public int LightLevel { get; set; }
    public decimal ColorHue { get; set; }
    public decimal ColorSaturation { get; set; }
    public decimal ColorTemperature { get; set; }
    public int ColorTemperatureMin { get; set; }
    public int ColorTemperatureMax { get; set; }
}

public class Capabilities
{
    public List<string> CanSend { get; set; } = null!;
    public IList<string> CanReveice { get; set; } = null!;
}

public class Room
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class DeviceSet
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}