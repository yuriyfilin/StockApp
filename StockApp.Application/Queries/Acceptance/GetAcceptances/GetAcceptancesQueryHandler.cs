using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Acceptance.GetAcceptances;

public class GetAcceptancesQueryHandler : IRequestHandler<GetAcceptancesQuery, PagedResponse<GetAcceptancesResult>>
{
    private readonly ILogger<GetAcceptancesQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetAcceptancesQueryHandler(ILogger<GetAcceptancesQueryHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<GetAcceptancesResult>> Handle(GetAcceptancesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Page <= 0)
                request.Page = 1;

            if (request.Count <= 0)
                request.Count = 1000;

            var total = await _unitOfWork.Acceptance.CountAsync(cancellationToken);
            var acceptances = await _unitOfWork.Acceptance.GetListByPage(request.Count, request.Page, cancellationToken);

            return PagedResponse<GetAcceptancesResult>.Ok(acceptances.Select(c => c.Adapt<GetAcceptancesResult>()).ToList(), total);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get acceptances with {@Request}", request);
            return PagedResponse<GetAcceptancesResult>.Failed("Could not get acceptances");
        }
    }
}