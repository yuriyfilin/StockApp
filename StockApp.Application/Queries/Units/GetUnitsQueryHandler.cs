using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Enums;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Good.GetGoods;

public class GetUnitsQueryHandler : IRequestHandler<GetUnitsQuery, BaseResponse<List<UnitsResult>>>
{
    private readonly ILogger<GetGoodsQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetUnitsQueryHandler(ILogger<GetGoodsQueryHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public Task<BaseResponse<List<UnitsResult>>> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var values = (
                from Units units in Enum.GetValues(typeof(Units))
                select new UnitsResult {Id = (int) units, Value = units.ToString()}
            ).ToList();

            return Task.FromResult(BaseResponse<List<UnitsResult>>.Ok(values));

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get units with {@Request}", request);
            return Task.FromResult(BaseResponse<List<UnitsResult>>.Failed("Could not get units"));
        }
    }
}