using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Saweat.Application;
using Saweat.Application.Contracts.Persistence;
using Saweat.Infrastructure;
using Saweat.Persistence;
using System.Linq.Expressions;

namespace Saweat.Test.Common;

public class TestServices
{
    private readonly IServiceProvider _serviceProvider;

    private TestServices()
    {
        IServiceCollection collection = new ServiceCollection();
        collection.AddApplicationServices();
        collection.AddInfrastructureServices();
        collection.AddPersistenceServices(connectionString: () => string.Empty, true);
        _serviceProvider = collection.BuildServiceProvider();
    }

    public static TestServices GetInstance()
    {
        return new TestServices();
    }

    public T GetService<T>() where T : class
    {
        return _serviceProvider.GetService<T>();
    }

    public T GetServiceAsScope<T>() where T : class, IDisposable
    {
        var scope = _serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    public static IRepository<TModel> GetMockRepository<TModel>(params TModel[] returns) where TModel : class
    {
        var repositoryMock = new Mock<IRepository<TModel>>();
        repositoryMock.Setup(x =>
                x.GetAllAsync(
                It.IsAny<Expression<Func<TModel, bool>>?>(),
                It.IsAny<Func<IQueryable<TModel>, IOrderedQueryable<TModel>>?>(),
                It.IsAny<Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>?>(),
                It.IsAny<bool>(),
                It.IsAny<CancellationToken>()
                ))
            .Returns(Task.FromResult(returns.ToList()));
        return repositoryMock.Object;
    }

    public static IUnitOfWork GetMockUnitOfWork<TModel>(IRepository<TModel> repository = null) where TModel : class, new()
    {
        repository = repository ?? GetMockRepository(Array.Empty<TModel>());
        var mock = new Mock<IUnitOfWork>();
        mock.Setup(x => x.GetRepository<TModel>()).Returns(repository);
        return mock.Object;
    }
}
