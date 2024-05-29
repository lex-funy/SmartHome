using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Flurl.Http;
using Flurl.Http.Configuration;
using SmartHome.Dirigera.Requests;

namespace SmartHome.Dirigera.Repositories;

public interface ILightRepository
{
    Task TurnLightOn(string id);
    Task TurnLightOff(string id);
}

[SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
public class LightRepository : ILightRepository
{
    private readonly IFlurlClient _flurlClient;

    public LightRepository(IFlurlClientCache flurlClientCache)
    {
        _flurlClient = flurlClientCache.Get("DirigeraClient");
    }

    public async Task TurnLightOn(string id)
    {
        var test = await _flurlClient
            .Request($"v1/devices/{id}")
            .PatchJsonAsync(new List<TurnLightOnRequest> { new() });
    }

    public async Task TurnLightOff(string id)
    {
        var request = new List<TurnLightOffRequest> { new() };

        var requestJson = JsonSerializer.Serialize(request);
        
        
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

        var _httpClient = new HttpClient(handler)
        {
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("Dirigera__BearerToken"))
            },
            BaseAddress = new Uri(Environment.GetEnvironmentVariable("Dirigera__BaseUrl"))
        };
        
        _httpClient.PatchAsJsonAsync($"v1/devices/{id}", request);
        
        var test = await _flurlClient
            .Request($"v1/devices/{id}")
            .AllowAnyHttpStatus()
            .PatchJsonAsync(request)
            .ReceiveString();
    }
}