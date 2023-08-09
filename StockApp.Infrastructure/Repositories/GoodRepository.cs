using Microsoft.EntityFrameworkCore;
using StockApp.Application.Repositories;
using StockApp.Domain.Entities;
using StockApp.Infrastructure.Data;

namespace StockApp.Infrastructure.Repositories;

public class GoodRepository: BaseRepository<Good>, IGoodRepository
{
    private readonly DataContext _context;

    public GoodRepository(DataContext context): base(context)
    {
        _context = context;
    }

    public async Task<(decimal PurchaseSum, decimal SellingSum)> GetSumRemainingGoods()
    {
        var sums = await _context.Good
            .Where(g => g.Count > 0)
            .GroupBy(x => true)
            .Select(x => new 
            { 
                SumColumn1 = x.Sum(y => y.PurchasePrice * y.Count), 
                SumColumn2 = x.Sum(y => y.SellingPrice * y.Count)
            }).FirstOrDefaultAsync();

        return sums == null ? (PurchaseSum: 0, SellingSum: 0) : (PurchaseSum: sums.SumColumn1, SellingSum: sums.SumColumn2);
    }
}