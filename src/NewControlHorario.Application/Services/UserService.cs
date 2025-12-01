using NewControlHorario.Application.DTOs;
using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Repositories;

namespace NewControlHorario.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return users
            .Select(u => new UserDto(u.Id, u.Email, u.FullName, u.IsActive, u.Roles.Select(r => r.Name).ToArray()))
            .ToArray();
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        return user is null
            ? null
            : new UserDto(user.Id, user.Email, user.FullName, user.IsActive, user.Roles.Select(r => r.Name).ToArray());
    }

    public async Task<UserDto> CreateAsync(string email, string fullName, string passwordHash, IEnumerable<string> roles, CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            FullName = fullName,
            PasswordHash = passwordHash,
            Roles = roles.Select(name => new Role { Id = Guid.NewGuid(), Name = name }).ToList()
        };

        await _userRepository.AddAsync(user, cancellationToken);

        return new UserDto(user.Id, user.Email, user.FullName, user.IsActive, user.Roles.Select(r => r.Name).ToArray());
    }
}
