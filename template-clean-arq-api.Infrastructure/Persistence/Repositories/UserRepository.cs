using MediatR;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Application.Repositories;
using template_clean_arq_api.Domain.Entities;
using template_clean_arq_api.Infrastructure.Persistence.Context;

namespace template_clean_arq_api.Infrastructure.Persistence.Repositories
{
    internal class UserRepository(DatabaseContext context, IUnitOfWork unitOfWork) : IUserRepository
    {
        public Task<Unit> Create(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
