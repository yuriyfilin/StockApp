using StockApp.Application.Repositories;
using StockApp.Infrastructure.Data;

namespace StockApp.Infrastructure.Repositories;

/// <summary>
/// 
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _db;
    private readonly Lazy<IGoodRepository> _good;
    private readonly Lazy<ISaleRepository> _sale;
    private readonly Lazy<IAcceptanceRepository> _acceptance;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="db"></param>
    public UnitOfWork(DataContext db)
    {
        _db = db;

        _good = new Lazy<IGoodRepository>(() => new GoodRepository(db));
        _sale = new Lazy<ISaleRepository>(() => new SaleRepository(db));
        _acceptance = new Lazy<IAcceptanceRepository>(() => new AcceptanceRepository(db));
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _db.SaveChangesAsync(cancellationToken);

    public IGoodRepository Good => _good.Value;
    public ISaleRepository Sale => _sale.Value;
    public IAcceptanceRepository Acceptance => _acceptance.Value;
}