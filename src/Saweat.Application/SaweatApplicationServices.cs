using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Saweat.Application;

public static class SaweatApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.AsTransient(), Assembly.GetExecutingAssembly() );
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Transient);
        return services;
    }
}
