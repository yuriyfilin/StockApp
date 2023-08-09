namespace StockApp.Application.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IGoodRepository Good { get; }

    ISaleRepository Sale { get; }

    IAcceptanceRepository Acceptance { get; }
}