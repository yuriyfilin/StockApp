using MediatR;
using StockApp.Application.Response;

namespace StockApp.Application.Queries.Good.GetGoods;

public class GetUnitsQuery : IRequest<BaseResponse<List<UnitsResult>>>
{

}