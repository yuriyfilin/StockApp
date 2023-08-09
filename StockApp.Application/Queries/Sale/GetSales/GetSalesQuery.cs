using MediatR;
using StockApp.Application.Request;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Sale.GetSales;

public class GetSalesQuery : BasePagedRequest, IRequest<PagedResponse<GetSalesResult>>
{
    public GetSalesQuery(int count, int page)
    {
        Count = count;
        Page = page;
    }
}