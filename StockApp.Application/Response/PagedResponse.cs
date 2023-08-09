namespace StockApp.Application.Response;

public class PagedResponse<T> : BaseResponse<List<T>>
{
    public int Total { get; init; }

    public static PagedResponse<T> Ok(List<T> data, int total)
    {
        return new()
        {
            Success = true,
            Data = data,
            Total = total
        };
    }

    public new static PagedResponse<T> Failed(string message)
    {
        return new() {Message = message};
    }
}