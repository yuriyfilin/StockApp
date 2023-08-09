using MediatR;
using StockApp.Application.Request;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Acceptance.GetAcceptances;

public class GetAcceptancesQuery : BasePagedRequest, IRequest<PagedResponse<GetAcceptancesResult>>
{
    public GetAcceptancesQuery(int count, int page)
    {
        Count = count;
        Page = page;
    }
}