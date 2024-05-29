using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Dirigera.Models;
using SmartHome.Dirigera.Repositories;

namespace SmartHome.Api.Controllers;

[ApiController]
[Route("api/devices")]
[SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
public class DeviceController
{
    private readonly IDeviceRepository _deviceRepository;
    
    public DeviceController(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Device>> GetDevicesAsync()
    {
        var devices = await _deviceRepository.GetDevicesAsync();
        return devices;
    }
}