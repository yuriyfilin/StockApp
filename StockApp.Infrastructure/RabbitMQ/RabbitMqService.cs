using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace StockApp.Infrastructure.RabbitMQ;

public class RabbitMqService : IRabbitMqService
{
    private readonly RabbitMqConfig _configuration;
    
    public RabbitMqService(IOptions<RabbitMqConfig> options)
    {
        _configuration = options.Value;
    }
    public IConnection CreateChannel()
    {
        ConnectionFactory connection = new ConnectionFactory()
        {
            UserName = _configuration.UserName,
            Password = _configuration.Password,
            HostName = _configuration.Hostname,
            Port = _configuration.Port
        };
        connection.DispatchConsumersAsync = true;
        var channel = connection.CreateConnection();
        return channel;
    }
}