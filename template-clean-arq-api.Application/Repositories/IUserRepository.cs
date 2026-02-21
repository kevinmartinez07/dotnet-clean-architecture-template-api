using MediatR;
using template_clean_arq_api.Domain.Entities;

namespace template_clean_arq_api.Application.Repositories;

/// <summary>
/// Repository interface for User entity.
/// Application layer: defines the contract.
/// Infrastructure layer: implements the contract.
/// 
/// IMPORTANT: Repositories should return Domain Entities, NOT DTOs.
/// DTOs are for data transfer between layers, not for domain logic.
/// 
/// Why this matters:
/// - Repository is about data persistence, not data representation
/// - DTOs are Application/Presentation concerns
/// - Domain entities can be mapped to DTOs in handlers
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="user">The user entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Unit (void equivalent for async).</returns>
    Task<Unit> Create(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The user entity if found, null otherwise.</returns>
    Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Checks if a user with the given email exists.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if exists, false otherwise.</returns>
    Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken);
}
