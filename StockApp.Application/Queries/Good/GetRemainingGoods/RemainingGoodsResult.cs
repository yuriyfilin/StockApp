namespace StockApp.Application.Queries.Good.GetRemainingGoods;

public class RemainingGoodsResult
{
    public decimal PurchaseSum { get; set; }
    
    public decimal SellingSum { get; set; }
    
    public int Total { get; set; }
    
    public List<RemainingGoodResult> Goods { get; set; }
}