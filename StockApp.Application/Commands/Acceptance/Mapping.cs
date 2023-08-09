    using Mapster;
    using StockApp.Application.Commands.Acceptance.Create;
    using StockApp.Domain.Entities;

    namespace StockApp.Application.Commands.Acceptance;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAcceptanceCommand, Domain.Entities.Acceptance>()
            .Map(dest => dest.AcceptanceGoods, 
                src => src.AcceptanceGoods.Select(ag => new AcceptanceGoods {GoodId = ag.GoodId, Count = ag.Count})
                );
    }
}