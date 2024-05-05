using Cargo.Application.Contracts.Percistance;
using Cargo.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cargo.Application;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IBranchRepository, BranchRepository>();
        return services;
    }
}
