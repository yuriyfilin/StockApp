using Microsoft.Extensions.Logging;
using StockApp.Application.Repositories;

namespace StockApp.Application.Commands.Good.SaleGood;

public class SaleGoodCommandHandler : ISaleGoodCommandHandler
{
    private readonly ILogger<SaleGoodCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public SaleGoodCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<SaleGoodCommandHandler> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(SaleGoodCommand command, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var updateGood in command.UpdateGoods)
            {
                var good = await _unitOfWork.Good.FindAsync(updateGood.GoodId, cancellationToken);
                if (good != null)
                    good.Count -= updateGood.Count;
            }
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not create good with {@Request}", command);
        }
    }
}