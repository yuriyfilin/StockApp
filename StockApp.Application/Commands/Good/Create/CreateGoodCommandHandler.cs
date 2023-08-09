using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Good.Create;

public class CreateGoodCommandHandler : IRequestHandler<CreateGoodCommand, BaseResponse>
{
    private readonly ILogger<CreateGoodCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGoodCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateGoodCommandHandler> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse> Handle(CreateGoodCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var good = command.Adapt<Domain.Entities.Good>();

            await _unitOfWork.Good.AddAsync(good, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return BaseResponse.Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not create good with {@Request}", command);
            return BaseResponse.Failed("Could not create good");
        }
    }
}