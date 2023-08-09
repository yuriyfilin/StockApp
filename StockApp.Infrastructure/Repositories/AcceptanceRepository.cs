using Microsoft.EntityFrameworkCore;
using StockApp.Application.Repositories;
using StockApp.Domain.Entities;
using StockApp.Infrastructure.Data;

namespace StockApp.Infrastructure.Repositories;

public class AcceptanceRepository: BaseRepository<Acceptance>, IAcceptanceRepository
{
    private readonly DataContext _context;

    public AcceptanceRepository(DataContext context): base(context)
    {
        _context = context;
    }

    public override async Task<List<Acceptance>> GetListByPage(int count, int page, CancellationToken cancellationToken)
        => await _context.Acceptance
            .Include(x => x.AcceptanceGoods)
            .ThenInclude(x => x.Good)
            .OrderByDescending(b => b.Id)
            .Skip(((page <= 0 ? 1 : page) - 1) * count).Take(count).ToListAsync(cancellationToken);
}