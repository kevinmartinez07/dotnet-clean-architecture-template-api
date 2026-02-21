namespace template_clean_arq_api.Application.Commons.Constants;

/// <summary>
/// HTTP-related constants for the application.
/// Following SRP: Only contains true constants, no logic.
/// NOTE: This class is kept for backward compatibility.
/// Consider using DomainErrors and Result pattern for new code.
/// </summary>
[Obsolete("Use DomainErrors and Result pattern instead. This will be removed in a future version.")]
public static class ErrorsConstants
{
    /// <summary>
    /// HTTP status code constants.
    /// </summary>
    public static class StatusCodes
    {
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int RequestTimeout = 408;
        public const int Conflict = 409;
        public const int UnprocessableEntity = 422;
        public const int Locked = 423;
        public const int InternalServerError = 500;
    }
}
