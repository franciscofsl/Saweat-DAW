using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Saweat.Application.Contracts.Persistence;

public interface IRepository
{

}

public interface IRepository<TModel> : IRepository where TModel : class
{
    Task InsertAsync(TModel entity, CancellationToken token = default);
    Task InsertAsync(IEnumerable<TModel> entities, CancellationToken token = default);
    Task UpdateAsync(TModel entity, CancellationToken token = default);
    Task UpdateAsync(IEnumerable<TModel> entities, CancellationToken token = default);
    Task DeleteAsync(TModel entity, CancellationToken token = default);
    Task DeleteAsync(IEnumerable<TModel> entities, CancellationToken token = default);

    Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null,
        Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orders = null,
        Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null,
        bool tracking = false, CancellationToken token = default);

    Task<int> CountAsync(Expression<Func<TModel, bool>>? filter = null,
        CancellationToken token = default);

    Task<bool> ExistsAsync(Expression<Func<TModel, bool>>? filter = null,
        CancellationToken token = default);

    Task<TModel> GetByIdAsync(
        object idValue,
        Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null,
        bool traking = false,
        CancellationToken token = default);
}