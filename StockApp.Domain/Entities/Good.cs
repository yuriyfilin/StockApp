namespace StockApp.Domain.Entities;

public class Good: Entity
{
    public string Name { get; set; }
    
    public string VendorCode { get; set; }
    
    public decimal PurchasePrice { get; set; }
    
    public decimal SellingPrice { get; set; }
    
    public int Units { get; set; }
    
    public int Count { get; set; }
    
    #region virtual fields
    
    public virtual ICollection<AcceptanceGoods> AcceptanceGoods { get; set; }
    
    public virtual ICollection<SaleGoods> SaleGoods { get; set; }
    
    #endregion
}