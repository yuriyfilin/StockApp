using Microsoft.EntityFrameworkCore;
using StockApp.Application.Repositories;
using StockApp.Domain.Entities;
using StockApp.Infrastructure.Data;

namespace StockApp.Infrastructure.Repositories;

public class SaleRepository: BaseRepository<Sale>, ISaleRepository
{
    private readonly DataContext _context;

    public SaleRepository(DataContext context): base(context)
    {
        _context = context;
    }
    
    public override async Task<List<Sale>> GetListByPage(int count, int page, CancellationToken cancellationToken)
        => await _context.Sale
            .Include(x => x.SaleGoods)
            .ThenInclude(x => x.Good)
            .OrderByDescending(b => b.Id)
            .Skip(((page <= 0 ? 1 : page) - 1) * count).Take(count).ToListAsync(cancellationToken);
}