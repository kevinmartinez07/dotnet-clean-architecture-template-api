using MediatR;
using template_clean_arq_api.Application.Commons;
using template_clean_arq_api.Application.Repositories;
using template_clean_arq_api.Application.UseCases.Users.Dtos;
using template_clean_arq_api.Application.UseCases.Users.Mappings;
using template_clean_arq_api.Domain.Errors;

namespace template_clean_arq_api.Application.UseCases.Users.Queries.Handler;

/// <summary>
/// Handler for retrieving a user by their ID.
/// Follows CQRS pattern via MediatR.
/// Returns Result pattern for type-safe error handling.
/// </summary>
internal sealed class GetUserByIdHandler(IUserRepository userRepository) : IRequestHandler<GetUserById, Result<UserDto>>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<Result<UserDto>> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        // 1. Retrieve the domain entity from repository
        var user = await _userRepository.GetUserById(request.Id, cancellationToken);

        // 2. Check if user exists
        if (user is null)
        {
            return Result.Failure<UserDto>(DomainErrors.User.NotFound(request.Id.ToString()));
        }

        // 3. Map domain entity to DTO and return success
        return Result.Success(user.ToDto());
    }
}
