namespace StockApp.Infrastructure.RabbitMQ.Receiver;

public interface IConsumerService
{
    Task ReadMessages(CancellationToken stoppingToken);
}