using template_clean_arq_api.Application.Commons;
using template_clean_arq_api.Domain.Errors;

namespace template_clean_arq_api.Application.Models;

/// <summary>
/// Standardized API response wrapper.
/// Provides a consistent contract for API responses across all endpoints.
/// Benefits:
/// - Consistent response structure
/// - Clear success/failure semantics
/// - Detailed error information
/// - Easy integration with Result pattern
/// </summary>
public sealed class ApiResponse<T>
{
    public bool IsSuccess { get; init; }
    public T? Data { get; init; }
    public string? Message { get; init; }
    public ErrorDetails? Error { get; init; }

    private ApiResponse() { }

    private ApiResponse(T data, string? message = null)
    {
        IsSuccess = true;
        Data = data;
        Message = message;
    }

    private ApiResponse(ErrorDetails error)
    {
        IsSuccess = false;
        Error = error;
    }

    /// <summary>
    /// Creates a successful response with data.
    /// </summary>
    public static ApiResponse<T> Success(T data, string? message = null)
        => new(data, message);

    /// <summary>
    /// Creates a failure response from a Result.
    /// </summary>
    public static ApiResponse<T> Failure(Error error)
        => new(new ErrorDetails
        {
            Code = error.Code,
            Message = error.Message,
            Type = error.Type.ToString()
        });

    /// <summary>
    /// Creates a failure response from multiple errors (validation scenarios).
    /// </summary>
    public static ApiResponse<T> Failure(Error[] errors)
        => new(new ErrorDetails
        {
            Code = errors.FirstOrDefault()?.Code ?? "Validation.Failed",
            Message = "One or more validation errors occurred.",
            Type = "BadRequest",
            ValidationErrors = errors.Select(e => new ValidationError
            {
                Code = e.Code,
                Message = e.Message
            }).ToArray()
        });

    /// <summary>
    /// Converts a Result to an ApiResponse.
    /// Enables seamless integration between domain/application layers and presentation layer.
    /// </summary>
    public static ApiResponse<T> FromResult(Result<T> result)
        => result.IsSuccess
            ? Success(result.Value)
            : Failure(result.Error);

    /// <summary>
    /// Pattern matching for functional-style response handling.
    /// </summary>
    public TResult Match<TResult>(
        Func<T, TResult> onSuccess,
        Func<ErrorDetails, TResult> onFailure)
        => IsSuccess && Data is not null
            ? onSuccess(Data)
            : onFailure(Error!);
}

/// <summary>
/// Detailed error information for API responses.
/// Provides rich error context for clients.
/// </summary>
public sealed class ErrorDetails
{
    public required string Code { get; init; }
    public required string Message { get; init; }
    public required string Type { get; init; }
    public ValidationError[]? ValidationErrors { get; init; }
}

/// <summary>
/// Represents a single validation error.
/// </summary>
public sealed class ValidationError
{
    public required string Code { get; init; }
    public required string Message { get; init; }
}
