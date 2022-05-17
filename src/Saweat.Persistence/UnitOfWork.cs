namespace Saweat.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly Dictionary<Type, IRepository> _repositories;

    public UnitOfWork(SaweatDbContext context)
    {
        DbContext = context;
        _repositories = new Dictionary<Type, IRepository>();
    }

    public SaweatDbContext DbContext { get; }

    public IRepository<TModel> GetRepository<TModel>() where TModel : class, new()
    {
        if (_repositories.ContainsKey(typeof(IRepository<TModel>)))
            return (IRepository<TModel>)_repositories[typeof(IRepository<TModel>)];

        var repository = new Repository<TModel>(DbContext);
        _repositories.Add(typeof(IRepository<TModel>), repository);
        return repository;
    }

    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        await DbContext.SaveChangesAsync(token);
    }

    #region IDisposable members

    public void Dispose()
    {
        _repositories.Clear();
        DbContext.Dispose();
    }

    #endregion
}