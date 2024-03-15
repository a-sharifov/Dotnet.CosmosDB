using Dotnet.CosmosDB.Controllers.WeathersControllers.Requests;
using Dotnet.CosmosDB.Services.Weathers.Interfaces;
using Dotnet.CosmosDB.Services.Weathers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.CosmosDB.Controllers.WeathersControllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(IWeatherService weatherService) : ControllerBase
{
    public readonly IWeatherService _weatherService = weatherService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weathers = await _weatherService.GetAllAsync();
        return Ok(weathers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var weathers = _weatherService.Get(id);
        return Ok(weathers);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostRequest request)
    {
        var serviceRequest = new AddRequest(DateOnly.MaxValue, request.TemperatureC, request.Summary);
        await _weatherService.AddAsync(serviceRequest);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _weatherService.Delete(id);
        return Ok();
    }

    [HttpPut("UpdateTemperatureC")]
    public async Task<IActionResult> UpdateTemperatureC([FromBody] PutTemperatureCRequest request)
    {
        var serviceRequest = new UpdateTemperatureCRequest(request.Id, request.TemperatureC);
        await _weatherService.UpdateTemperatureCAsync(serviceRequest);
        return Ok();
    }

    [HttpPut("UpdateSummary")]
    public async Task<IActionResult> UpdateSummary([FromBody] PutSummaryRequest request)
    {
        var serviceRequest = new UpdateSummaryRequest(request.Id, request.Summary);
        await _weatherService.UpdateSummaryAsync(serviceRequest);
        return Ok();
    }
}
