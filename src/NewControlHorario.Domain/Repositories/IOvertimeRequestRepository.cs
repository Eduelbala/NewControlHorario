using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Domain.Repositories;

public interface IOvertimeRequestRepository
{
    Task<OvertimeRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<OvertimeRequest>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddAsync(OvertimeRequest request, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(Guid requestId, OvertimeStatus status, Guid? approverId, CancellationToken cancellationToken = default);
}
