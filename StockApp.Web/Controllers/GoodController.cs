using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Commands.Good.Create;
using StockApp.Application.Queries.Good.GetGoods;
using StockApp.Application.Queries.Good.GetRemainingGoods;
using StockApp.Application.Response;

namespace StockApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GoodController : ControllerBase
{
    private readonly ILogger<GoodController> _logger;
    private readonly IMediator _mediator;

    public GoodController(ILogger<GoodController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Создание товара
    /// </summary>
    /// <param name="request">Объект с информацию товара</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Add(CreateGoodCommand request, CancellationToken token = default)
    {
        var result = await _mediator.Send(request, token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
    
    /// <summary>
    /// Получить постранично товары
    /// </summary>
    /// <param name="count">Количество элементов на странице</param>
    /// <param name="page">Номер страницы</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<RemainingGoodResult>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGoods(int count, int page, CancellationToken token = default)
    {
        var result = await _mediator.Send(new GetGoodsQuery(count, page), token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<RemainingGoodsResult>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRemainingGoods(int count, int page, CancellationToken token = default)
    {
        var result = await _mediator.Send(new GetRemainingGoodsQuery(count, page), token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
}