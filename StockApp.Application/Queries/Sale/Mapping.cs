using Mapster;
using StockApp.Application.Enums;
using StockApp.Application.Queries.Sale.GetSales;
using StockApp.Domain.Entities;

namespace StockApp.Application.Queries.Sale;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Sale, GetSalesResult>()
            .Map(
                dest => dest.Goods,
                src => src.SaleGoods.Select(ConvertFromSaleGoods)
            );
    }
    
    private GetSaleGoodResult ConvertFromSaleGoods(SaleGoods saleGoods)
    {
        var result = saleGoods.Good.Adapt<GetSaleGoodResult>();
        result.Count = saleGoods.Count;
        result.Units = ((Units) saleGoods.Good.Units).ToString();

        return result;
    }
}