using NewControlHorario.Application.DTOs;

namespace NewControlHorario.Application.Services;

public interface IUserService
{
    Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto> CreateAsync(string email, string fullName, string passwordHash, IEnumerable<string> roles, CancellationToken cancellationToken = default);
}
