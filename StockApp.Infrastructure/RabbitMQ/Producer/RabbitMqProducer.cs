using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StockApp.Application.MessageBus;

namespace StockApp.Infrastructure.RabbitMQ.Producer;

public class RabbitMqProducer: IMessageBus
{
    private readonly RabbitMqConfig _configuration;
    private readonly IRabbitMqService _rabbitMqService;

    public RabbitMqProducer(IRabbitMqService rabbitMqService, IOptions<RabbitMqConfig> rabbitMqOptions)
    {
        _rabbitMqService = rabbitMqService;
        _configuration = rabbitMqOptions.Value;
    }

    public void SendSaleGoodsMessage <T> (T message) {
        using var connection = _rabbitMqService.CreateChannel();

        using var model = connection.CreateModel();

        model.QueueDeclare(_configuration.QueueName, durable: true, exclusive: false, autoDelete: false);
        model.ExchangeDeclare(_configuration.Exchange, ExchangeType.Fanout, durable: true, autoDelete: false);
        model.QueueBind(_configuration.QueueName, _configuration.Exchange, string.Empty);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        model.BasicPublish(exchange: String.Empty, routingKey: _configuration.QueueName, body: body);
    }
}