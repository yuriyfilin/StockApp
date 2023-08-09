    using Mapster;
    using StockApp.Application.Commands.Sale.Create;
    using StockApp.Domain.Entities;

    namespace StockApp.Application.Commands.Sale;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSaleCommand, Domain.Entities.Sale>()
            .Map(dest => dest.SaleGoods, 
                src => src.SaleGoods.Select(sg => new SaleGoods {GoodId = sg.GoodId, Count = sg.Count})
                );
    }
}