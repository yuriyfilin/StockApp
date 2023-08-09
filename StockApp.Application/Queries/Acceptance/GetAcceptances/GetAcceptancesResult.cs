
namespace StockApp.Application.Queries.Acceptance.GetAcceptances;

public class GetAcceptancesResult
{
    public int Id { get; set; }
    
    public List<GetAcceptanceGoodResult> Goods { get; set; }
}