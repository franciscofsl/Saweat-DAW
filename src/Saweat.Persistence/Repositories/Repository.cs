namespace Saweat.Persistence.Repositories;

public class Repository<TModel> : IRepository<TModel> where TModel : class
{
    private readonly SaweatDbContext _context;

    public Repository(SaweatDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync(Expression<Func<TModel, bool>>? filter = null, CancellationToken token = default)
    {
        IQueryable<TModel> query = _context.Set<TModel>();
        return filter is not null
            ? await query.CountAsync(filter, token)
            : await query.CountAsync(token);
    }

    public async Task DeleteAsync(TModel entity, CancellationToken token = default)
    {
        await Task.Run(function: () => _context.Set<TModel>().Remove(entity), token);
    }

    public async Task DeleteAsync(IEnumerable<TModel> entities, CancellationToken token = default)
    {
        await Task.Run(action: () => _context.Set<TModel>().RemoveRange(entities), token);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TModel, bool>>? filter = null,
        CancellationToken token = default)
    {
        IQueryable<TModel> query = _context.Set<TModel>();
        return filter is not null
            ? await query.AnyAsync(filter, token)
            : await query.AnyAsync(token);
    }

    public async Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null,
        Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orders = null,
        Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null,
        bool tracking = false, CancellationToken token = default)
    {
        IQueryable<TModel> query = _context.Set<TModel>();
        if (filter is not null) query = query.Where(filter);

        if (include is not null) query = include(query);

        if (tracking == false) query = query.AsNoTracking();

        return orders != null
            ? await orders(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<TModel> GetByIdAsync(object idValue,
        Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null,
        bool tracking = false,
        CancellationToken token = default)
    {
        if (idValue == null) throw new ArgumentNullException(nameof(idValue));

        IQueryable<TModel> query = _context.Set<TModel>();
        var entityType = _context.Model.FindEntityType(typeof(TModel));

        var primaryKeyName = entityType?.FindPrimaryKey()?.Properties.Select(P => P.Name).FirstOrDefault() ??
                             string.Empty;
        var primaryKeyType = entityType?.FindPrimaryKey()?.Properties.Select(P => P.ClrType).FirstOrDefault();

        var expressionTree = GetPrimaryKeyExpression(idValue, primaryKeyName, primaryKeyType);

        query = include is not null ? include(query) : query;
        query = tracking ? query : query.AsNoTracking();


        return await query.FirstOrDefaultAsync(expressionTree, token);
    }

    public async Task InsertAsync(TModel entity, CancellationToken token = default)
    {
        await _context.Set<TModel>().AddAsync(entity, token);
    }

    public async Task InsertAsync(IEnumerable<TModel> entities, CancellationToken token = default)
    {
        await _context.Set<TModel>().AddRangeAsync(entities, token);
    }

    public async Task UpdateAsync(TModel entity, CancellationToken token = default)
    {
        await Task.Run(function: () => _context.Set<TModel>().Update(entity), token);
    }

    public async Task UpdateAsync(IEnumerable<TModel> entities, CancellationToken token = default)
    {
        await Task.Run(action: () => _context.Set<TModel>().UpdateRange(entities), token);
    }

    private static Expression<Func<TModel, bool>> GetPrimaryKeyExpression(object idValue, string primaryKeyName,
        Type? primaryKeyType)
    {
        if (idValue == null) throw new ArgumentNullException(nameof(idValue));

        if (idValue == null) throw new ArgumentNullException(nameof(idValue));

        var parameterExpression = Expression.Parameter(typeof(TModel), name: "entity");
        var memberExpression = Expression.Property(parameterExpression, primaryKeyName);
        var constantExpression = Expression.Constant(idValue, primaryKeyType ?? typeof(object));
        var binaryExpression = Expression.Equal(memberExpression, constantExpression);
        return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
    }
}
