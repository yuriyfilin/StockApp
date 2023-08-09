namespace StockApp.Application.Commands.Good.AcceptanceGood;

public interface IAcceptanceGoodCommandHandler
{
    Task Execute(AcceptanceGoodCommand command, CancellationToken cancellationToke);
}