using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Sale.GetSales;

public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, PagedResponse<GetSalesResult>>
{
    private readonly ILogger<GetSalesQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesQueryHandler(ILogger<GetSalesQueryHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<GetSalesResult>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Page <= 0)
                request.Page = 1;

            if (request.Count <= 0)
                request.Count = 1000;

            var total = await _unitOfWork.Acceptance.CountAsync(cancellationToken);
            var sale = await _unitOfWork.Sale.GetListByPage(request.Count, request.Page, cancellationToken);

            return PagedResponse<GetSalesResult>.Ok(sale.Select(c => c.Adapt<GetSalesResult>()).ToList(), total);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get sales with {@Request}", request);
            return PagedResponse<GetSalesResult>.Failed("Could not get sales");
        }
    }
}