using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Commands.Sale.Create;
using StockApp.Application.Queries.Sale.GetSales;
using StockApp.Application.Response;

namespace StockApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SaleController : ControllerBase
{
    private readonly ILogger<SaleController> _logger;
    private readonly IMediator _mediator;

    public SaleController(ILogger<SaleController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Создание продажи
    /// </summary>
    /// <param name="request">Объект с информацией продажи</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Add(CreateSaleCommand request, CancellationToken token = default)
    {
        var result = await _mediator.Send(request, token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
    
    /// <summary>
    /// Получить постранично продажи
    /// </summary>
    /// <param name="count">Количество элементов на странице</param>
    /// <param name="page">Номер страницы</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<GetSalesResult>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSales(int count, int page, CancellationToken token = default)
    {
        var result = await _mediator.Send(new GetSalesQuery(count, page), token);
        return result.Success ? Ok(result) : UnprocessableEntity(result);
    }
}