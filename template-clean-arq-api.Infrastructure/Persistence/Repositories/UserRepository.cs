using MediatR;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Application.Repositories;
using template_clean_arq_api.Domain.Entities;
using template_clean_arq_api.Infrastructure.Persistence.Context;

namespace template_clean_arq_api.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository implementation for User entity.
/// Infrastructure layer: handles data access concerns.
/// Follows Repository Pattern for data abstraction.
/// </summary>
internal class UserRepository(DatabaseContext context, IUnitOfWork unitOfWork) : IUserRepository
{
    private readonly DatabaseContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof(unitOfWork));
    public Task<Unit> Create(User user, CancellationToken cancellationToken)
    {
        // TODO: Implement user creation logic
        throw new NotImplementedException();
    }

    public Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        // TODO: Implement user retrieval logic
        // Example:
        // return _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken)
    {
        // TODO: Implement email existence check
        // Example:
        // return _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
        throw new NotImplementedException();
    }
}
