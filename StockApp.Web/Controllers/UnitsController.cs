using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Queries.Good.GetGoods;
using StockApp.Application.Response;

namespace StockApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UnitsController : ControllerBase
{
    private readonly ILogger<UnitsController> _logger;
    private readonly IMediator _mediator;

    public UnitsController(ILogger<UnitsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Получить список едениц товаров
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<List<UnitsResult>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetUnits(CancellationToken token = default)
    {
        var result = await _mediator.Send(new GetUnitsQuery(), token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
}