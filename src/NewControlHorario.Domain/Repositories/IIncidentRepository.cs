using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Domain.Repositories;

public interface IIncidentRepository
{
    Task<IReadOnlyCollection<Incident>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Incident?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Incident incident, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(Guid incidentId, IncidentStatus status, Guid? approverId, CancellationToken cancellationToken = default);
}
