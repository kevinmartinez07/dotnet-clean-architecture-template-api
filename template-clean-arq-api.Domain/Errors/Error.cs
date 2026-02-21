using template_clean_arq_api.Domain.Enums;

namespace template_clean_arq_api.Domain.Errors;

/// <summary>
/// Represents an immutable error in the domain.
/// Following Value Object pattern from DDD.
/// </summary>
public sealed record Error
{
    public string Code { get; init; }
    public string Message { get; init; }
    public ErrorType Type { get; init; }

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    /// <summary>
    /// Creates a new Error instance.
    /// Private constructor + static factory ensures immutability and controlled creation.
    /// </summary>
    public static Error Create(string code, string message, ErrorType type)
        => new(code, message, type);

    /// <summary>
    /// Creates a custom error with a specific message.
    /// </summary>
    public static Error Custom(string code, string message, ErrorType type = ErrorType.InternalServerError)
        => new(code, message, type);

    /// <summary>
    /// Represents an empty/no error state.
    /// Follows Null Object Pattern to avoid null checks.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.InternalServerError);
}
