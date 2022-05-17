namespace Saweat.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync(CancellationToken token = default); 
    IRepository<TModel> GetRepository<TModel>() where TModel : class, new();
}