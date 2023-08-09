using MediatR;
using StockApp.Application.Request;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Good.GetRemainingGoods;

public class GetRemainingGoodsQuery : BasePagedRequest, IRequest<BaseResponse<RemainingGoodsResult>>
{
    public GetRemainingGoodsQuery(int count, int page)
    {
        Count = count;
        Page = page;
    }
}