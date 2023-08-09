using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Application.MessageBus;
using StockApp.Application.Repositories;
using StockApp.Infrastructure.Data;
using StockApp.Infrastructure.RabbitMQ;
using StockApp.Infrastructure.RabbitMQ.Producer;
using StockApp.Infrastructure.RabbitMQ.Receiver;
using StockApp.Infrastructure.Repositories;

namespace StockApp.Infrastructure;

public static class Bootstrap
{
    public static IServiceCollection AddInfrastructureLayer
        (this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<DataContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultContext"),
                    b => b.MigrationsAssembly("StockApp.Infrastructure")))
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<IAcceptanceRepository, AcceptanceRepository>()
            .AddTransient<IGoodRepository, GoodRepository>()
            .AddTransient<ISaleRepository, SaleRepository>()
            .AddHostedService<ConsumerHostedService>()
            .AddScoped<IMessageBus, RabbitMqProducer>()
            .AddTransient<IRabbitMqService, RabbitMqService>()
            .AddTransient<IConsumerService, ConsumerService>();;
    }
}
