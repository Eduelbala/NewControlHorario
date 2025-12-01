using Microsoft.EntityFrameworkCore;
using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;
using NewControlHorario.Domain.Repositories;
using NewControlHorario.Infrastructure.Persistence;

namespace NewControlHorario.Infrastructure.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _context;

    public IncidentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Incident incident, CancellationToken cancellationToken = default)
    {
        await _context.Incidents.AddAsync(incident, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Incident?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Incidents.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Incident>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Incidents.AsNoTracking().Where(i => i.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task UpdateStatusAsync(Guid incidentId, IncidentStatus status, Guid? approverId, CancellationToken cancellationToken = default)
    {
        var incident = await _context.Incidents.FirstOrDefaultAsync(i => i.Id == incidentId, cancellationToken);
        if (incident is null)
        {
            return;
        }

        incident.Status = status;
        incident.ApprovedById = approverId;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
