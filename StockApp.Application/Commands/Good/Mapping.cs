    using Mapster;
    using StockApp.Application.Commands.Acceptance.Create;
    using StockApp.Application.Commands.Good.AcceptanceGood;
    using StockApp.Application.Commands.Sale.Create;
    using StockApp.Domain.Entities;

    namespace StockApp.Application.Commands.Good;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAcceptanceCommand, AcceptanceGoodCommand>()
            .Map(dest => dest.UpdateGoods, 
                src => src.AcceptanceGoods);
    }
}