using Microsoft.EntityFrameworkCore;
using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;
using NewControlHorario.Domain.Repositories;
using NewControlHorario.Infrastructure.Persistence;

namespace NewControlHorario.Infrastructure.Repositories;

public class OvertimeRequestRepository : IOvertimeRequestRepository
{
    private readonly AppDbContext _context;

    public OvertimeRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OvertimeRequest request, CancellationToken cancellationToken = default)
    {
        await _context.OvertimeRequests.AddAsync(request, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<OvertimeRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.OvertimeRequests.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<OvertimeRequest>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.OvertimeRequests.AsNoTracking().Where(r => r.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task UpdateStatusAsync(Guid requestId, OvertimeStatus status, Guid? approverId, CancellationToken cancellationToken = default)
    {
        var request = await _context.OvertimeRequests.FirstOrDefaultAsync(r => r.Id == requestId, cancellationToken);
        if (request is null)
        {
            return;
        }

        request.Status = status;
        request.ApprovedById = approverId;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
