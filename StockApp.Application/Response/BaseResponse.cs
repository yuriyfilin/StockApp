namespace StockApp.Application.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public static BaseResponse Ok()
    {
        return new() {Success = true};
    }

    public static BaseResponse Failed(string message)
    {
        return new() {Message = message};
    }
}

public class BaseResponse<T> : BaseResponse
{
    public T Data { get; set; }

    public static BaseResponse<T> Ok(T data)
    {
        return new() {Success = true, Data = data};
    }

    public new static BaseResponse<T> Failed(string message)
    {
        return new() {Message = message};
    }
}