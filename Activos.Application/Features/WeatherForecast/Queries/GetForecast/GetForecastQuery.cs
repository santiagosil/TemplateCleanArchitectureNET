using Activos.Application.Models.Response;
using MediatR;

namespace Activos.Application.Features.WeatherForecast.Queries.GetForecast
{
    public class GetForecastQuery : IRequest<ApiResult<List<WeatherForecastResponse>>>
    {
        public int EjemploProp { get; set; }
    }
}
