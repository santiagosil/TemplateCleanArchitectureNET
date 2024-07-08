using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Activos.Infrastructure.Persistence;

namespace Activos.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<ActivosDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(1),
                            errorNumbersToAdd: null);
                        options.CommandTimeout(3600);
                    }), ServiceLifetime.Transient
            );


            return services;
        }
    }
    
}
