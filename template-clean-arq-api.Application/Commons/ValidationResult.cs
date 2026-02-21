using template_clean_arq_api.Domain.Errors;

namespace template_clean_arq_api.Application.Commons;

/// <summary>
/// Represents a validation result that can contain multiple errors.
/// Extends Result to handle validation scenarios with multiple failures.
/// </summary>
public sealed class ValidationResult : Result
{
    public Error[] Errors { get; }

    private ValidationResult(Error[] errors)
        : base(false, errors.FirstOrDefault() ?? Error.None)
    {
        Errors = errors;
    }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}

/// <summary>
/// Generic validation result with value.
/// </summary>
public sealed class ValidationResult<TValue> : Result<TValue>
{
    public Error[] Errors { get; }

    private ValidationResult(Error[] errors)
        : base(default, false, errors.FirstOrDefault() ?? Error.None)
    {
        Errors = errors;
    }

    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
}
