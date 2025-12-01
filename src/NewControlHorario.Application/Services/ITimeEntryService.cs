using NewControlHorario.Application.DTOs;
using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Application.Services;

public interface ITimeEntryService
{
    Task<IReadOnlyCollection<TimeEntryDto>> GetEntriesForUserAsync(Guid userId, DateOnly? date = null, CancellationToken cancellationToken = default);
    Task<TimeEntryDto> RegisterAsync(Guid userId, TimeEntryType type, string? comment = null, CancellationToken cancellationToken = default);
}
