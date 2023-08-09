namespace StockApp.Application.Request;

public abstract class BasePagedRequest
{
    public int Page { get; set; }
    public int Count { get; set; }
}