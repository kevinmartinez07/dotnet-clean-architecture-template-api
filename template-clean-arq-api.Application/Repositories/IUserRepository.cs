using MediatR;
using template_clean_arq_api.Domain.Entities;

namespace template_clean_arq_api.Application.Repositories
{
    public interface IUserRepository
    {
        Task<Unit> Create(User user, CancellationToken cancellationToken);
    }
}
