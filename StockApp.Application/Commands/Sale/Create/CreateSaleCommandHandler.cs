using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.MessageBus;
using StockApp.Application.Repositories;
using StockApp.Application.Response;
using StockApp.Domain.Entities;

namespace StockApp.Application.Commands.Sale.Create;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, BaseResponse>
{
    private readonly ILogger<CreateSaleCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageBus _messageBus;

    public CreateSaleCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageBus messageBus,
        ILogger<CreateSaleCommandHandler> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _messageBus = messageBus;
    }

    public async Task<BaseResponse> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var sale = command.Adapt<Domain.Entities.Sale>();

            await _unitOfWork.Sale.AddAsync(sale, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _messageBus.SendSaleGoodsMessage(command.SaleGoods);
            
            return BaseResponse.Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not create sale with {@Request}", command);
            return BaseResponse.Failed("Could not create sale");
        }
    }
}