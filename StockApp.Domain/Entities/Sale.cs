namespace StockApp.Domain.Entities;

public class Sale: Entity
{
    #region virtual fields
    
    public virtual ICollection<SaleGoods> SaleGoods { get; set; }
    
    #endregion
}