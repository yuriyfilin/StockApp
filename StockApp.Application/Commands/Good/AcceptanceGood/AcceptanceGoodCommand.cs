using MediatR;
using StockApp.Application.DTO;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Good.AcceptanceGood;

public class AcceptanceGoodCommand :  IRequest<BaseResponse>
{
    public List<CountGoodDTO> UpdateGoods { get; set; }
}