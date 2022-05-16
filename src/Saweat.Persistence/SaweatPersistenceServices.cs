using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saweat.Application.Contracts.Persistence;
using Saweat.Persistence.Contexts;
using Saweat.Persistence.Repositories;

namespace Saweat.Persistence;

public static class SaweatPersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, Func<IServiceProvider, string> connectionString, bool inMemory = false)
    {
        string value = connectionString.Invoke(services.BuildServiceProvider());
        services.AddDbContext<SaweatDbContext>(options =>
            options.UseSqlServer(value), ServiceLifetime.Transient);
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }
}