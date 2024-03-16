using Microsoft.Extensions.DependencyInjection;

namespace TechChallenge.Hackthon.Application.Settings;

public static class DependencyInjections
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(DependencyInjections).Assembly));

        return services;
    }
}
