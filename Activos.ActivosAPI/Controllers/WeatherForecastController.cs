using Activos.Application.Features.WeatherForecast.Queries.GetForecast;
using Activos.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Activos.ActivosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{edad}",Name = "GetWeatherForecast")]
        public async Task<ApiResult<List<WeatherForecastResponse>>> Get(int edad)
        {
            return await _mediator.Send(new GetForecastQuery { EjemploProp = edad});
        }
    }
}
