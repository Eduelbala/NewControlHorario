using NewControlHorario.Application.DTOs;
using NewControlHorario.Domain.Entities;
using NewControlHorario.Domain.Enums;
using NewControlHorario.Domain.Repositories;

namespace NewControlHorario.Application.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepository;
    private readonly IUserRepository _userRepository;

    public TimeEntryService(ITimeEntryRepository timeEntryRepository, IUserRepository userRepository)
    {
        _timeEntryRepository = timeEntryRepository;
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<TimeEntryDto>> GetEntriesForUserAsync(Guid userId, DateOnly? date = null, CancellationToken cancellationToken = default)
    {
        var entries = await _timeEntryRepository.GetByUserAsync(userId, date, cancellationToken);
        return entries.Select(e => new TimeEntryDto(e.Id, e.UserId, e.Timestamp, e.Type, e.Comment)).ToArray();
    }

    public async Task<TimeEntryDto> RegisterAsync(Guid userId, TimeEntryType type, string? comment = null, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
        {
            throw new InvalidOperationException("El usuario no existe.");
        }

        var entry = new TimeEntry
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Timestamp = DateTimeOffset.UtcNow,
            Type = type,
            Comment = comment
        };

        await _timeEntryRepository.AddAsync(entry, cancellationToken);

        return new TimeEntryDto(entry.Id, entry.UserId, entry.Timestamp, entry.Type, entry.Comment);
    }
}
