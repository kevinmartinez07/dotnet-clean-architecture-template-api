using template_clean_arq_api.Domain.Enums;

namespace template_clean_arq_api.Domain.Errors;

/// <summary>
/// Centralized catalog of domain errors.
/// Static nested classes provide logical grouping and discoverability.
/// Following DDD principles - errors are part of domain knowledge.
/// </summary>
public static class DomainErrors
{
    public static class General
    {
        public static Error BadRequest(string? message = null) =>
            Error.Create(
                "General.BadRequest",
                message ?? "The request is invalid.",
                ErrorType.BadRequest);

        public static Error Unauthorized(string? message = null) =>
            Error.Create(
                "General.Unauthorized",
                message ?? "You are not authorized to perform this action.",
                ErrorType.Unauthorized);

        public static Error Forbidden(string? message = null) =>
            Error.Create(
                "General.Forbidden",
                message ?? "Access denied.",
                ErrorType.Forbidden);

        public static Error NotFound(string? message = null) =>
            Error.Create(
                "General.NotFound",
                message ?? "The requested resource was not found.",
                ErrorType.NotFound);

        public static Error RequestTimeout(string? message = null) =>
            Error.Create(
                "General.RequestTimeout",
                message ?? "The request exceeded the timeout period.",
                ErrorType.RequestTimeout);

        public static Error Conflict(string? message = null) =>
            Error.Create(
                "General.Conflict",
                message ?? "Conflict in the request.",
                ErrorType.Conflict);

        public static Error UnprocessableEntity(string? message = null) =>
            Error.Create(
                "General.UnprocessableEntity",
                message ?? "The entity could not be processed.",
                ErrorType.UnprocessableEntity);

        public static Error Locked(string? message = null) =>
            Error.Create(
                "General.Locked",
                message ?? "The resource is locked.",
                ErrorType.Locked);

        public static Error InternalServerError(string? message = null) =>
            Error.Create(
                "General.InternalServerError",
                message ?? "An unexpected error occurred.",
                ErrorType.InternalServerError);
    }

    public static class Validation
    {
        public static Error HeaderRequired(string headerName) =>
            Error.Create(
                "Validation.HeaderRequired",
                $"The header '{headerName}' is required.",
                ErrorType.BadRequest);

        public static Error HeaderInvalid(string headerName) =>
            Error.Create(
                "Validation.HeaderInvalid",
                $"The header '{headerName}' must be a valid value.",
                ErrorType.BadRequest);

        public static Error QueryRequired(string queryName) =>
            Error.Create(
                "Validation.QueryRequired",
                $"The query parameter '{queryName}' is required.",
                ErrorType.BadRequest);

        public static Error QueryInvalid(string queryName) =>
            Error.Create(
                "Validation.QueryInvalid",
                $"The query parameter '{queryName}' must be a valid value.",
                ErrorType.BadRequest);
    }

    public static class Transaction
    {
        public static Error AlreadyExists() =>
            Error.Create(
                "Transaction.AlreadyExists",
                "An active transaction already exists.",
                ErrorType.Conflict);

        public static Error NotFound() =>
            Error.Create(
                "Transaction.NotFound",
                "No active transaction found to commit.",
                ErrorType.NotFound);
    }

    public static class User
    {
        public static Error NotFound(string? userId = null) =>
            Error.Create(
                "User.NotFound",
                userId is null 
                    ? "User not found." 
                    : $"User with id '{userId}' was not found.",
                ErrorType.NotFound);

        public static Error DuplicateEmail(string email) =>
            Error.Create(
                "User.DuplicateEmail",
                $"User with email '{email}' already exists.",
                ErrorType.Conflict);

        public static Error InvalidCredentials() =>
            Error.Create(
                "User.InvalidCredentials",
                "Invalid email or password.",
                ErrorType.Unauthorized);
    }
}
