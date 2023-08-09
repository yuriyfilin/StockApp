using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Good.GetRemainingGoods;

public class GetRemainingGoodsQueryHandler : IRequestHandler<GetRemainingGoodsQuery, BaseResponse<RemainingGoodsResult>>
{
    private readonly ILogger<GetRemainingGoodsQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetRemainingGoodsQueryHandler(ILogger<GetRemainingGoodsQueryHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<RemainingGoodsResult>> Handle(GetRemainingGoodsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Page <= 0)
                request.Page = 1;

            if (request.Count <= 0)
                request.Count = 1000;

            var total = await _unitOfWork.Good.CountAsync(g => g.Count > 0, cancellationToken);
            var goods = await _unitOfWork.Good.GetListByPage(
                request.Count, request.Page,
                g => g.Count > 0,
                cancellationToken);

            var sumRemainingGoods = await _unitOfWork.Good.GetSumRemainingGoods();

            var result = new RemainingGoodsResult
            {
                Goods = goods.Select(g => g.Adapt<RemainingGoodResult>()).ToList(),
                Total = total,
                PurchaseSum = sumRemainingGoods.PurchaseSum,
                SellingSum = sumRemainingGoods.SellingSum
            };

            return BaseResponse<RemainingGoodsResult>.Ok(result);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get goods with {@Request}", request);
            return BaseResponse<RemainingGoodsResult>.Failed("Could not get goods");
        }
    }
}