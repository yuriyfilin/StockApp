
namespace StockApp.Application.Queries.Good.GetGoods;

public class GetGoodResult
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string VendorCode { get; set; }
    
    public decimal PurchasePrice { get; set; }
    
    public decimal SellingPrice { get; set; }
    
    public string Units { get; set; }
    
    public int Count { get; set; }
}