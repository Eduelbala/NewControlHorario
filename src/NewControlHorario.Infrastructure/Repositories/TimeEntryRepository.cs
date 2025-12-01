using Microsoft.EntityFrameworkCore;
using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;
using NewControlHorario.Domain.Repositories;
using NewControlHorario.Infrastructure.Persistence;

namespace NewControlHorario.Infrastructure.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    private readonly AppDbContext _context;

    public TimeEntryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TimeEntry entry, CancellationToken cancellationToken = default)
    {
        await _context.TimeEntries.AddAsync(entry, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<TimeEntry>> GetByUserAsync(Guid userId, DateOnly? date = null, CancellationToken cancellationToken = default)
    {
        var query = _context.TimeEntries.AsQueryable().Where(e => e.UserId == userId);

        if (date.HasValue)
        {
            query = query.Where(e => DateOnly.FromDateTime(e.Timestamp.Date) == date.Value);
        }

        return await query.AsNoTracking().OrderBy(e => e.Timestamp).ToListAsync(cancellationToken);
    }

    public async Task<bool> HasOpenEntryAsync(Guid userId, TimeEntryType type, CancellationToken cancellationToken = default)
    {
        return await _context.TimeEntries.AnyAsync(e => e.UserId == userId && e.Type == type, cancellationToken);
    }
}
