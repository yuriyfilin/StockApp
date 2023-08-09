using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Commands.Acceptance.Create;
using StockApp.Application.Queries.Acceptance.GetAcceptances;
using StockApp.Application.Response;

namespace StockApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AcceptanceController : ControllerBase
{
    private readonly ILogger<AcceptanceController> _logger;
    private readonly IMediator _mediator;

    public AcceptanceController(ILogger<AcceptanceController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Создание приемки
    /// </summary>
    /// <param name="request">Объект с информацией приемки</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Add(CreateAcceptanceCommand request, CancellationToken token = default)
    {
        var result = await _mediator.Send(request, token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
    
    /// <summary>
    /// Получить постранично приемки
    /// </summary>
    /// <param name="count">Количество элементов на странице</param>
    /// <param name="page">Номер страницы</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<GetAcceptancesResult>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAcceptances(int count, int page, CancellationToken token = default)
    {
        var result = await _mediator.Send(new GetAcceptancesQuery(count, page), token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
}