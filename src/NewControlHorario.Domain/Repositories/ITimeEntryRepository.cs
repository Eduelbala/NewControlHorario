using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Domain.Repositories;

public interface ITimeEntryRepository
{
    Task<IReadOnlyCollection<TimeEntry>> GetByUserAsync(Guid userId, DateOnly? date = null, CancellationToken cancellationToken = default);
    Task AddAsync(TimeEntry entry, CancellationToken cancellationToken = default);
    Task<bool> HasOpenEntryAsync(Guid userId, TimeEntryType type, CancellationToken cancellationToken = default);
}
