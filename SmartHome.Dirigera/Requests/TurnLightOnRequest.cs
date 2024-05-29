using System.Text.Json.Serialization;

namespace SmartHome.Dirigera.Requests;

public class TurnLightOnRequest
{
    [JsonPropertyName("attributes")]
    public TurnLightOnRequestAttributes Attributes { get; set; } = new();
}

public class TurnLightOnRequestAttributes
{
    [JsonPropertyName("isOn")]
    public bool IsOn = true;
}