namespace HardwarePriceHistory.Core.Abstractions;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public bool HasMessage => Message != "";

    protected Result(bool isSuccess, T data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public static Result<T> Success(T data, string message = "")
    {
        return new Result<T>(true, data, message);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(false, default, message);
    }
}