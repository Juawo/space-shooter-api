using System.Runtime.InteropServices.JavaScript;

namespace SpaceShooterApi.Models;

public class Result<T>
{
    public bool Success { get; private set; }
    public T Data { get;  private set; }
    public ErrorType Error { get;  set; }
    public Result(bool success, T data, ErrorType error)
    {
        Success = success;
        Data = data;
        Error = error;
    }
    public static Result<T> Ok(T data) => new Result<T>(true, data, ErrorType.None);
    public static Result<T> Failure(ErrorType error) => new Result<T>(false, default, error);
}