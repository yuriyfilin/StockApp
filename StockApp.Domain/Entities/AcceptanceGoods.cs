namespace StockApp.Domain.Entities;

public class AcceptanceGoods: Entity
{
    public int GoodId { get; set; }
    
    public int AcceptanceId { get; set; }
    
    public int Count { get; set; }
    
    #region virtual fields
    
    public virtual Good Good { get; set; }
    
    public virtual Acceptance Acceptance { get; set; }
    
    #endregion
}