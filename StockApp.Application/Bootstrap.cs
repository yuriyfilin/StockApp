using System.Reflection;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Application.Behaviors;
using StockApp.Application.Commands.Good.AcceptanceGood;
using StockApp.Application.Commands.Good.SaleGood;

namespace StockApp.Application;

public static class Bootstrap
{
    public static IServiceCollection AddApplicationLayer
        (this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(Bootstrap).Assembly, typeof(Bootstrap).Assembly);
        
        return services
            .AddValidatorsFromAssembly(typeof(Bootstrap).Assembly)
            .AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(MessagesLoggingBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
            .AddTransient<IAcceptanceGoodCommandHandler, AcceptanceGoodCommandHandler>()
            .AddTransient<ISaleGoodCommandHandler, SaleGoodCommandHandler>();
    }
}
