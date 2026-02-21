using template_clean_arq_api.Application.UseCases.Users.Dtos;
using template_clean_arq_api.Domain.Entities;

namespace template_clean_arq_api.Application.UseCases.Users.Mappings;

/// <summary>
/// Extension methods for mapping User entity to DTOs.
/// Follows Single Responsibility Principle: Only handles User mappings.
/// Extension methods keep mapping logic close to usage while maintaining separation.
/// </summary>
public static class UserMappings
{
    /// <summary>
    /// Maps a User domain entity to UserDto.
    /// </summary>
    /// <param name="user">The user entity.</param>
    /// <returns>The mapped DTO.</returns>
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id.GetHashCode(), // NOTE: Review this mapping - using Guid hash is not ideal
            Name = user.Name,
            Email = user.Email,
            CreatedAt = DateTime.UtcNow // TODO: Add CreatedAt to User entity or remove from DTO
        };
    }

    /// <summary>
    /// Maps a collection of User entities to DTOs.
    /// </summary>
    public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
    {
        return users.Select(ToDto);
    }
}
