using Microsoft.AspNetCore.Mvc;
using template_clean_arq_api.Application.Models;
using template_clean_arq_api.Application.Commons;

namespace template_clean_arq_api.Presentation.Extensions;

/// <summary>
/// Extension methods for converting Results to HTTP responses.
/// Follows Open/Closed Principle: Extends functionality without modifying existing code.
/// Benefits:
/// - Centralized HTTP status code mapping
/// - Consistent error responses
/// - Easy to test and maintain
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts a Result to an IActionResult with appropriate HTTP status code.
    /// </summary>
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(ApiResponse<T>.Success(result.Value));
        }

        var response = ApiResponse<T>.Failure(result.Error);
        var statusCode = (int)result.Error.Type;

        return new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }

    /// <summary>
    /// Converts a Result to an IActionResult for creation operations (201 Created).
    /// </summary>
    public static IActionResult ToCreatedResult<T>(
        this Result<T> result,
        string routeName,
        object? routeValues = null)
    {
        if (result.IsSuccess)
        {
            var response = ApiResponse<T>.Success(result.Value, "Resource created successfully.");
            return new CreatedAtRouteResult(routeName, routeValues, response);
        }

        var errorResponse = ApiResponse<T>.Failure(result.Error);
        var statusCode = (int)result.Error.Type;

        return new ObjectResult(errorResponse)
        {
            StatusCode = statusCode
        };
    }

    /// <summary>
    /// Converts a ValidationResult to an IActionResult.
    /// </summary>
    public static IActionResult ToActionResult<T>(this ValidationResult<T> result)
    {
        var response = ApiResponse<T>.Failure(result.Errors);
        return new BadRequestObjectResult(response);
    }

    /// <summary>
    /// Converts a Result without value to NoContent (204) on success.
    /// </summary>
    public static IActionResult ToNoContentResult(this Result result)
    {
        if (result.IsSuccess)
        {
            return new NoContentResult();
        }

        var response = ApiResponse<object>.Failure(result.Error);
        var statusCode = (int)result.Error.Type;

        return new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }
}
