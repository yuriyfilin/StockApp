using StockApp.Application.Enums;

namespace StockApp.Application.Queries.Acceptance.GetAcceptances;

public class GetAcceptanceGoodResult
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string VendorCode { get; set; }
    
    public decimal PurchasePrice { get; set; }
    
    public decimal SellingPrice { get; set; }
    
    public string Units { get; set; }
    
    public int Count { get; set; }
}