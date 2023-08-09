using System.Linq.Expressions;

namespace StockApp.Application.Repositories;

public interface IBaseRepository<T>
{
    Task AddAsync(T acceptance, CancellationToken cancellationToken);

    Task<T?> FindAsync(int entityId, CancellationToken cancellationToken);

    Task<List<T>> GetListByPage(int count, int page, CancellationToken cancellationToken);
    
    Task<List<T>> GetListByPage(int count, int page, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    Task<int> CountAsync(CancellationToken cancellationToken);
    
    Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}