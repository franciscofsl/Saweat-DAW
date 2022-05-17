namespace Saweat.Persistence;

public static class SaweatPersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        Func<string> connectionString, bool inMemory = false)
    {
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        if (inMemory)
            return services.AddDbContext<SaweatDbContext>(options => options.UseInMemoryDatabase("SaweatInMemory"),
                ServiceLifetime.Transient);

        var connectionStringValue = connectionString.Invoke();
        services.AddDbContext<SaweatDbContext>(options =>
            options.UseSqlServer(connectionStringValue), ServiceLifetime.Transient);

        return services;
    }
}