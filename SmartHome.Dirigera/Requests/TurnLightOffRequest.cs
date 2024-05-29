using System.Text.Json.Serialization;

namespace SmartHome.Dirigera.Requests;

public class TurnLightOffRequest
{
    [JsonPropertyName("attributes")]
    public TurnLightOffRequestAttributes Attributes { get; set; } = new() { IsOn = false };
}

public class TurnLightOffRequestAttributes
{
    [JsonPropertyName("isOn")]
    public bool IsOn { get; set; }
}