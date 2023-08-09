using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Response;

namespace StockApp.Application.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResponse
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<TRequest> _logger;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(s => s.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count == 0)
            return await next();
        _logger.LogError("Error {@Errors} on validation request {@Request}", failures, request);
        var response = Activator.CreateInstance<TResponse>();
        response.Success = false;
        response.Message = JsonSerializer.Serialize(failures,
            new JsonSerializerOptions() {ReferenceHandler = ReferenceHandler.Preserve});
        return response;
    }
}
