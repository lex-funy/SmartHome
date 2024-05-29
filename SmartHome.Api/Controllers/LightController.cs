using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Dirigera.Repositories;

namespace SmartHome.Api.Controllers;

[ApiController]
[Route("api/lights")]
[SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
public class LightController
{
    private readonly ILightRepository _lightRepository;
    
    public LightController(ILightRepository lightRepository)
    {
        _lightRepository = lightRepository;
    }
    
    [HttpPost("{id}/on")]
    public async Task TurnLightOnAsync([FromRoute] string id)
    {
        await _lightRepository.TurnLightOn(id);
    }

    [HttpPost("{id}/off")]
    public async Task TurnLightOffAsync([FromRoute] string id)
    {
        await _lightRepository.TurnLightOff(id);
    }   
}