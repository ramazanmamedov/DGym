using DGym.Domain.Common.Interfaces;
using DGym.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace DGym.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddPersistence();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DGymDbContext>(options =>
            options.UseSqlite("Data Source = DomeGym.db"));
        
        return services;
    }
}