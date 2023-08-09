using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Good.GetGoods;

public class GetGoodsQueryHandler : IRequestHandler<GetGoodsQuery, PagedResponse<GetGoodResult>>
{
    private readonly ILogger<GetGoodsQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetGoodsQueryHandler(ILogger<GetGoodsQueryHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<GetGoodResult>> Handle(GetGoodsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Page <= 0)
                request.Page = 1;

            if (request.Count <= 0)
                request.Count = 1000;

            var total = await _unitOfWork.Good.CountAsync(cancellationToken);
            var goods = await _unitOfWork.Good.GetListByPage(request.Count, request.Page, cancellationToken);

            return PagedResponse<GetGoodResult>.Ok(goods.Select(c => c.Adapt<GetGoodResult>()).ToList(), total);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get goods with {@Request}", request);
            return PagedResponse<GetGoodResult>.Failed("Could not get goods");
        }
    }
}