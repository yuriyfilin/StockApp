namespace StockApp.Application.Queries.Sale.GetSales;

public class GetSalesResult
{
    public int Id { get; set; }
    
    public List<GetSaleGoodResult> Goods { get; set; }
}