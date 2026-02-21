using MediatR;
using Microsoft.AspNetCore.Mvc;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Application.Models;
using template_clean_arq_api.Domain.Errors;
using template_clean_arq_api.Domain.Enums;

namespace template_clean_arq_api.Presentation.HelperPresentation;

/// <summary>
/// Base controller with common functionality for all API controllers.
/// Provides access to MediatR and header validation.
/// Follows DRY principle - shared logic in one place.
/// </summary>
[ApiController]
public abstract class ApiBaseController : ControllerBase
{
    /// <summary>
    /// Gets the header validator from dependency injection.
    /// </summary>
    protected IHeaderValidator HeaderValidator => 
        HttpContext.RequestServices.GetRequiredService<IHeaderValidator>();

    /// <summary>
    /// Gets the MediatR sender from dependency injection.
    /// </summary>
    protected ISender Sender => 
        HttpContext.RequestServices.GetRequiredService<ISender>();

    /// <summary>
    /// Creates a problem details response with validation errors.
    /// </summary>
    /// <param name="errors">List of error messages.</param>
    /// <returns>UnprocessableEntity response with error details.</returns>
    protected IActionResult Problem(IReadOnlyList<string>? errors = null)
    {
        if (errors is null || errors.Count == 0)
        {
            return base.Problem();
        }

        var domainErrors = errors.Select(msg => 
            Error.Create("Validation.Failed", msg, ErrorType.BadRequest)
        ).ToArray();

        var response = ApiResponse<string>.Failure(domainErrors);
        return UnprocessableEntity(response);
    }

    /// <summary>
    /// Creates a problem details response with a custom error.
    /// </summary>
    /// <param name="error">The error to return.</param>
    /// <returns>ObjectResult with appropriate status code.</returns>
    protected IActionResult Problem(Error error)
    {
        var response = ApiResponse<string>.Failure(error);
        return new ObjectResult(response)
        {
            StatusCode = (int)error.Type
        };
    }
}
