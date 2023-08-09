namespace StockApp.Domain.Entities;

public class SaleGoods: Entity
{
    public int GoodId { get; set; }
    
    public int SaleId { get; set; }
    
    public int Count { get; set; }
    
    #region virtual fields
    
    public virtual Good Good { get; set; }
    
    public virtual Sale Sale { get; set; }
    
    #endregion
}