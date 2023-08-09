using MediatR;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Sale.Create;

public class CreateSaleCommand :  IRequest<BaseResponse>
{
    public List<CreateSaleGoodDTO> SaleGoods { get; set; }
}