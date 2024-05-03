using Cargo.Application.Contracts.Logging;
using Cargo.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cargo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
