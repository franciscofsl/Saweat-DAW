using Microsoft.Extensions.DependencyInjection;
using Saweat.Application;
using Saweat.Infrastructure;
using Saweat.Persistence;

namespace Saweat.Test.Common;

public class TestServices
{
    private readonly IServiceProvider _serviceProvider;

    public static TestServices GetInstance()
    {
        return new();
    }

    private TestServices()
    {
        IServiceCollection collection = new ServiceCollection();
        collection.AddApplicationServices();
        collection.AddInfrastructureServices();
        collection.AddPersistenceServices(() => string.Empty, true);
        this._serviceProvider = collection.BuildServiceProvider();
    } 

    public T GetService<T>() where T : class
    {
        return this._serviceProvider.GetService<T>();
    }

    public T GetServiceAsScope<T>() where T : class, IDisposable
    {
        var scope = this._serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }


}
 