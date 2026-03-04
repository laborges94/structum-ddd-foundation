namespace Structum.Core.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException();

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
        => new(true, Error.None);

    public static Result Failure(Error error)
        => new(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected Result(T value)
        : base(true, Error.None) => Value = value;

    protected Result(Error error)
        : base(false, error) => Value = default;

    public static Result<T> Success(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        return new(value);
    }

    public static new Result<T> Failure(Error error)
        => new(error);

    public static implicit operator Result<T>(T value)
        => Success(value);    
}