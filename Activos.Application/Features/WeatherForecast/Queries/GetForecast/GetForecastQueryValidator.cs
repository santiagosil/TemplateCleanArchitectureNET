using FluentValidation;

namespace Activos.Application.Features.WeatherForecast.Queries.GetForecast
{
    public class GetForecastQueryValidator : AbstractValidator<GetForecastQuery>
    {
        public GetForecastQueryValidator()
        {
            RuleFor(c => c.EjemploProp)
                .GreaterThanOrEqualTo(18).WithMessage("debe ser mayor de edad");
        }
    }
}
