using MediatR;
using StockApp.Application.DTO;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Good.SaleGood;

public class SaleGoodCommand :  IRequest<BaseResponse>
{
    public List<CountGoodDTO> UpdateGoods { get; set; }
}