using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Application.Extensions;
using StockApp.Application.Response;

namespace StockApp.Application.Behaviors;

public class MessagesLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : BaseResponse
{
    private readonly ILogger<TRequest> _logger;
    private IPipelineBehavior<TRequest, TResponse> _pipelineBehaviorImplementation;

    public MessagesLoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var messageId = Guid.NewGuid();
        try
        {
            _logger.LogInformation("Input Request  {@MediatRMessageId}, {@Request}", messageId, request);
            var response = await next();
            _logger.LogInformation("Output Response {@MediatRMessageId}, {@Response}", messageId, response);
            return response;
        }
        catch (ApplicationException e)
        {
            return HandleExptectedException(e, messageId);
        }
        catch (ArgumentException e)
        {
            return HandleExptectedException(e, messageId);
        }
        catch (NullReferenceException e)
        {
            return HandleExptectedException(e, messageId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error on processing Message with id {@MediatRMessageId}", messageId);
            throw;
        }
    }

    /// <summary>
    /// Так обрабатываем только те ошибки которые не надо ретраит и пробовать повторять второй раз. 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="messageId"></param>
    /// <returns></returns>
    private TResponse HandleExptectedException(Exception e, Guid messageId)
    {
        _logger.LogError(e, "Error on processing Message with id {@MediatRMessageId}", messageId);
        var response = Activator.CreateInstance<TResponse>();
        response.Success = false;
        response.Message = e.ExceptionMessages().JoinStrings(Environment.NewLine);
        return response;
    }
}
