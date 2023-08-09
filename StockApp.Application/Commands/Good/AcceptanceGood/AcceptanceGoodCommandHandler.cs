using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;

namespace StockApp.Application.Commands.Good.AcceptanceGood;

public class AcceptanceGoodCommandHandler : IAcceptanceGoodCommandHandler
{
    private readonly ILogger<AcceptanceGoodCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AcceptanceGoodCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<AcceptanceGoodCommandHandler> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(AcceptanceGoodCommand command, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var updateGood in command.UpdateGoods)
            {
                var good = await _unitOfWork.Good.FindAsync(updateGood.GoodId, cancellationToken);
                if (good != null)
                    good.Count += updateGood.Count;
            }
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not create good with {@Request}", command);
        }
    }
}