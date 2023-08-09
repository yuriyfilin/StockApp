using Mapster;
using StockApp.Application.Enums;
using StockApp.Application.Queries.Good.GetRemainingGoods;

namespace StockApp.Application.Queries.Good;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Good, RemainingGoodResult>()
            .Map(dest => dest.Units, src => ((Units)src.Units).ToString());
    }
}