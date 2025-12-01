namespace NewControlHorario.Application.DTOs;

public record UserDto(Guid Id, string Email, string FullName, bool IsActive, IReadOnlyCollection<string> Roles);
