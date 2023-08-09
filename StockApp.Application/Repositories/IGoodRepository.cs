using StockApp.Domain.Entities;

namespace StockApp.Application.Repositories;

public interface IGoodRepository: IBaseRepository<Good>
{
    Task<(decimal PurchaseSum, decimal SellingSum)> GetSumRemainingGoods();
}