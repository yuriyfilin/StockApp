using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StockApp.Application.Commands.Good.SaleGood;
using StockApp.Application.DTO;

namespace StockApp.Infrastructure.RabbitMQ.Receiver;

public class ConsumerService : IConsumerService, IDisposable
{
    private readonly IModel _model;
    private readonly IConnection _connection;
    private readonly RabbitMqConfig _configuration;
    private readonly ILogger<ConsumerService> _logger;
    private readonly IServiceProvider _serviceProvider;
    
    public ConsumerService(IRabbitMqService rabbitMqService,
        IOptions<RabbitMqConfig> rabbitMqOptions,
        ILogger<ConsumerService> logger,
        IServiceProvider serviceProvider)
    {
        _configuration = rabbitMqOptions.Value;
        _logger = logger;
        _serviceProvider = serviceProvider;
        
        _connection = rabbitMqService.CreateChannel();
        _model = _connection.CreateModel();
        _model.QueueDeclare(_configuration.QueueName, durable: true, exclusive: false, autoDelete: false);
        _model.ExchangeDeclare(_configuration.Exchange, ExchangeType.Fanout, durable: true, autoDelete: false);
        _model.QueueBind(_configuration.QueueName, _configuration.Exchange, string.Empty);
    }

    public async Task ReadMessages(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_model);
        consumer.Received += async (ch, ea) =>
        {
            var body = ea.Body.ToArray();
            var text = System.Text.Encoding.UTF8.GetString(body);

            if (!string.IsNullOrWhiteSpace(text))
            {
                _logger.LogInformation(text);
                await DoWorkAsync(text, stoppingToken);
                // await _updateCountGood.Execute(JsonConvert.DeserializeObject<UpdateCountGoodCommand>(text), new CancellationToken());
            }
            
            await Task.CompletedTask;
            _model.BasicAck(ea.DeliveryTag, false);
        };
        _model.BasicConsume(_configuration.QueueName, false, consumer);
        await Task.CompletedTask;
    }
    
    private async Task DoWorkAsync(string text, CancellationToken stoppingToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        var updateCountGood = scope.ServiceProvider.GetRequiredService<ISaleGoodCommandHandler>();

        var goods = new SaleGoodCommand
            {UpdateGoods = JsonConvert.DeserializeObject<List<CountGoodDTO>>(text) ?? new List<CountGoodDTO>()};
        await updateCountGood.Execute(goods, stoppingToken);
    }

    public void Dispose()
    {
        if (_model.IsOpen)
            _model.Close();
        if (_connection.IsOpen)
            _connection.Close();
    }
}