using template_clean_arq_api.Domain.Errors;

namespace template_clean_arq_api.Application.Commons;

/// <summary>
/// Represents the result of an operation that can either succeed or fail.
/// Implements the Result Pattern for functional error handling.
/// Benefits:
/// - Type-safe error handling without exceptions
/// - Explicit success/failure states
/// - Composable operations
/// - Better testability
/// </summary>
public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException("A successful result cannot have an error.");

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException("A failed result must have an error.");

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

/// <summary>
/// Generic Result type that contains a value on success.
/// </summary>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access value of a failed result.");

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue value) => Success(value);

    /// <summary>
    /// Maps the result value to a new type if successful.
    /// Follows Railway Oriented Programming pattern.
    /// </summary>
    public Result<TOutput> Map<TOutput>(Func<TValue, TOutput> mapper)
    {
        return IsSuccess
            ? Success(mapper(Value))
            : Failure<TOutput>(Error);
    }

    /// <summary>
    /// Pattern matching for functional-style handling.
    /// </summary>
    public TOutput Match<TOutput>(
        Func<TValue, TOutput> onSuccess,
        Func<Error, TOutput> onFailure)
    {
        return IsSuccess ? onSuccess(Value) : onFailure(Error);
    }
}
