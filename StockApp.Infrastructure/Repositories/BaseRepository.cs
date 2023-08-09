using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StockApp.Application.Repositories;
using StockApp.Domain;
using StockApp.Infrastructure.Data;

namespace StockApp.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    private readonly DataContext _context;
    
    protected BaseRepository(DataContext context)
    {
        _context = context;
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
        => await _context.Set<T>().AddAsync(entity, cancellationToken);

    public virtual async Task<T?> FindAsync(int entityId, CancellationToken cancellationToken)
        => await _context.Set<T>().FindAsync(new object[] { entityId}, cancellationToken);

    public virtual async Task<List<T>> GetListByPage(int count, int page, CancellationToken cancellationToken)
        => await _context.Set<T>()
            .OrderByDescending(b => b.Id)
            .Skip(((page <= 0 ? 1 : page) - 1) * count).Take(count).ToListAsync(cancellationToken);

    public virtual async Task<List<T>> GetListByPage(int count, int page, Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken)
        => await _context.Set<T>()
                .Where(predicate)
                .OrderByDescending(b => b.Id)
                .Skip(((page <= 0 ? 1 : page) - 1) * count).Take(count).ToListAsync(cancellationToken);
    

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        => await _context.Set<T>().CountAsync(cancellationToken);

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
        => await _context.Set<T>()
            .Where(predicate)
            .CountAsync(cancellationToken);
}