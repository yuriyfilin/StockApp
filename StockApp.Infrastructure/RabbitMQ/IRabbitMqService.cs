using RabbitMQ.Client;

namespace StockApp.Infrastructure.RabbitMQ;

public interface IRabbitMqService
{
    IConnection CreateChannel();
}