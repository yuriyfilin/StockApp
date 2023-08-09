using Mapster;
using StockApp.Application.Enums;
using StockApp.Application.Queries.Acceptance.GetAcceptances;
using StockApp.Domain.Entities;

namespace StockApp.Application.Queries.Acceptance;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Acceptance, GetAcceptancesResult>()
            .Map(
                dest => dest.Goods,
                src => src.AcceptanceGoods.Select(ConvertFromAcceptanceGoods)
            );
    }

    private GetAcceptanceGoodResult ConvertFromAcceptanceGoods(AcceptanceGoods acceptanceGoods)
    {
        var result = acceptanceGoods.Good.Adapt<GetAcceptanceGoodResult>();
        result.Count = acceptanceGoods.Count;
        result.Units = ((Units) acceptanceGoods.Good.Units).ToString();

        return result;
    }
}