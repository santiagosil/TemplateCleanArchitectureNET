using Activos.Application.Models.Response;
using Activos.Domain;
using AutoMapper;

namespace Activos.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastResponse>();
        }
    }
}
