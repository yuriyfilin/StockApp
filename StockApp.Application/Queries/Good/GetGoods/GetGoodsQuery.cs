using MediatR;
using StockApp.Application.Request;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Good.GetGoods;

public class GetGoodsQuery : BasePagedRequest, IRequest<PagedResponse<GetGoodResult>>
{
    public GetGoodsQuery(int count, int page)
    {
        Count = count;
        Page = page;
    }
}