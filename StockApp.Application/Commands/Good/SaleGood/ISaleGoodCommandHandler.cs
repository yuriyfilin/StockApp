namespace StockApp.Application.Commands.Good.SaleGood;

public interface ISaleGoodCommandHandler
{
    Task Execute(SaleGoodCommand command, CancellationToken cancellationToke);
}