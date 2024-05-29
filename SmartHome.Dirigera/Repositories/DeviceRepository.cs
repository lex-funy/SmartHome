using System.Diagnostics.CodeAnalysis;
using Flurl.Http;
using Flurl.Http.Configuration;
using SmartHome.Dirigera.Models;

namespace SmartHome.Dirigera.Repositories;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> GetDevicesAsync();
}

[SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
public class DeviceRepository : IDeviceRepository
{
    private readonly IFlurlClient _flurlClient;
    
    public DeviceRepository(IFlurlClientCache flurlClientCache)
    {
        _flurlClient = flurlClientCache.Get("DirigeraClient");
    }
    
    public async Task<IEnumerable<Device>> GetDevicesAsync()
    {
        var devices = await _flurlClient
            .Request("v1/devices")
            .GetJsonAsync<IEnumerable<Device>>();

        return devices;
    }
}