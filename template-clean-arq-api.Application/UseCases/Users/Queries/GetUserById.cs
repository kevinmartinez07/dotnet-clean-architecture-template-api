using MediatR;
using template_clean_arq_api.Application.Commons;
using template_clean_arq_api.Application.UseCases.Users.Dtos;

namespace template_clean_arq_api.Application.UseCases.Users.Queries
{
    public sealed record GetUserById : IRequest<Result<UserDto>>
    {
        public Guid Id { get; init; }
        public string Token { get; init; }
    }
}
