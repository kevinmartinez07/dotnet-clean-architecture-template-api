namespace template_clean_arq_api.Domain.Enums;

/// <summary>
/// Represents the type of error that can occur in the application.
/// Maps to HTTP status codes for standardized API responses.
/// </summary>
public enum ErrorType
{
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    RequestTimeout = 408,
    Conflict = 409,
    UnprocessableEntity = 422,
    Locked = 423,
    InternalServerError = 500
}
