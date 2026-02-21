using FluentValidation;
using MediatR;
using template_clean_arq_api.Application.Commons;
using template_clean_arq_api.Application.Commons.Constants;
using template_clean_arq_api.Application.Models;
using template_clean_arq_api.Domain.Errors;

namespace template_clean_arq_api.Application.Settings.Behaviors;

/// <summary>
/// MediatR Pipeline Behavior for FluentValidation.
/// Intercepts requests and validates them before reaching the handler.
/// Follows Open/Closed Principle: adds validation without modifying handlers.
/// </summary>
public sealed class ValidationsBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationsBehaviors(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count == 0)
        {
            return await next();
        }

        var errors = failures
            .Select(f => Error.Create(
                "Validation.Failed",
                f.ErrorMessage,
                Domain.Enums.ErrorType.BadRequest))
            .ToArray();

        return CreateValidationFailureResponse<TResponse>(errors);
    }

    private static TResponse CreateValidationFailureResponse<T>(Error[] errors)
    {
        var responseType = typeof(T);

        // Check if response is Result<TValue>
        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var valueType = responseType.GetGenericArguments()[0];
            var failureMethod = typeof(ValidationResult<>)
                .MakeGenericType(valueType)
                .GetMethod(nameof(ValidationResult<object>.WithErrors));

            if (failureMethod != null)
            {
                var result = failureMethod.Invoke(null, [errors]);
                return (TResponse)result!;
            }
        }

        // Fallback for unexpected types
        throw new InvalidOperationException(
            $"Cannot create validation failure response for type {responseType.Name}. " +
            "Expected Result<T> or ValidationResult<T>.");
    }
}
