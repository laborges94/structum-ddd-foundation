namespace Structum.Core.Results;

public class Result
{
    private readonly List<Error> _errors = [];

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public IReadOnlyList<Error> Errors => _errors;

    protected Result(bool isSuccess, IEnumerable<Error>? errors)
    {
        if (isSuccess && errors is not null && errors.Any())
            throw new InvalidOperationException("Success result cannot contain errors.");

        if (!isSuccess && (errors is null || !errors.Any()))
            throw new InvalidOperationException("Failure result must contain at least one error.");

        IsSuccess = isSuccess;

        if (errors is not null)
            _errors.AddRange(errors);
    }

    public static Result Success()
        => new(true, null);

    public static Result Failure(Error error)
        => new(false, [error]);

    public static Result Failure(IEnumerable<Error> errors)
    {
        var list = errors.ToList();

        if (list.Count == 0)
            throw new ArgumentException("Failure must contain at least one error.", nameof(errors));

        return new(false, list);
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected Result(T value)
        : base(true, null) => Value = value;

    protected Result(IEnumerable<Error> errors)
        : base(false, errors) => Value = default;

    public static Result<T> Success(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        return new(value);
    }

    public new static Result<T> Failure(Error error)
        => new([error]);

    public new static Result<T> Failure(IEnumerable<Error> errors)
        => new(errors);

    public static implicit operator Result<T>(T value)
        => Success(value);
}