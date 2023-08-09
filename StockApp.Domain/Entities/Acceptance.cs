namespace StockApp.Domain.Entities;

public class Acceptance: Entity
{
    #region virtual fields
    
    public virtual ICollection<AcceptanceGoods> AcceptanceGoods { get; set; }
    
    #endregion
}