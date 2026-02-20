using MediatR;
using Microsoft.AspNetCore.Mvc;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Application.Models;

namespace template_clean_arq_api.Presentation.HelperPresentation
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected IHeaderValidator HeaderValidator => HttpContext.RequestServices.GetRequiredService<IHeaderValidator>();
        protected ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();

        //protected async Task<IActionResult<ApiResponse<TResponse>>> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        //{
        //    var result = await Sender.Send(request, cancellationToken);
        //    return result.Match(Ok, (errors, messageErrors) => errors != null ? Problem([.. errors]) : Problem(messageErrors));
        //}

        //protected async Task<IActionResult> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        //{
        //    var result = await Sender.Send(request, cancellationToken);
        //    return Ok(result);
        //}

        protected IActionResult Problem(IReadOnlyList<string>? errors = null)
        {
            return errors != null && errors.Count != 0 ? UnprocessableEntity(ApiResponse<string>.Failure(errors)) : base.Problem();
        }

        protected IActionResult Problem(IReadOnlyDictionary<string, string>? errors)
        {
            return errors != null && errors.Count != 0 ? UnprocessableEntity(ApiResponse<string>.Failure(errors)) : base.Problem();
        }
    }
}
