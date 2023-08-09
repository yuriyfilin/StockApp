using MediatR;
using StockApp.Application.Response;

namespace StockApp.Application.Commands.Good.Create;

public class CreateGoodCommand :  IRequest<BaseResponse>
{
    public string Name { get; set; }
    
    public string VendorCode { get; set; }
    
    public decimal PurchasePrice { get; set; }
    
    public decimal SellingPrice { get; set; }
    
    public int Units { get; set; }
}