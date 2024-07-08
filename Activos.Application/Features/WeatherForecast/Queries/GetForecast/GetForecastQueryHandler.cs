using Activos.Application.Models.Response;
using AutoMapper;
using MediatR;
using Activos.Domain;
using Activos.Application.Exceptions;

namespace Activos.Application.Features.WeatherForecast.Queries.GetForecast
{
    public class GetForecastQueryHandler : IRequestHandler<GetForecastQuery, ApiResult<List<WeatherForecastResponse>>>
    {
        private readonly IMapper _mapper;
        public GetForecastQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<ApiResult<List<WeatherForecastResponse>>> Handle(GetForecastQuery request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Range(1, 5).Select(index => new Domain.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            return new ApiResult<List<WeatherForecastResponse>>(_mapper.Map<List<WeatherForecastResponse>>(result));
        }
    }
}
