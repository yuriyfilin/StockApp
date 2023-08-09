using MediatR;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Acceptance.Create;

public class CreateAcceptanceCommand :  IRequest<BaseResponse>
{
    public List<CreateAcceptanceGoodDto> AcceptanceGoods { get; set; }
}