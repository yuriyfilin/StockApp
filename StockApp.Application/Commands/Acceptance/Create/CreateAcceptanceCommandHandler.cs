using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Commands.Good.AcceptanceGood;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Acceptance.Create;

public class CreateAcceptanceCommandHandler : IRequestHandler<CreateAcceptanceCommand, BaseResponse>
{
    private readonly ILogger<CreateAcceptanceCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAcceptanceGoodCommandHandler _acceptanceGood;

    public CreateAcceptanceCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateAcceptanceCommandHandler> logger,
        IAcceptanceGoodCommandHandler acceptanceGood)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _acceptanceGood = acceptanceGood;
    }

    public async Task<BaseResponse> Handle(CreateAcceptanceCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var acceptance = command.Adapt<Domain.Entities.Acceptance>();

            await _unitOfWork.Acceptance.AddAsync(acceptance, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _acceptanceGood.Execute(command.Adapt<AcceptanceGoodCommand>(), cancellationToken);

            return BaseResponse.Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not create acceptance with {@Request}", command);
            return BaseResponse.Failed("Could not create acceptance");
        }
    }
}