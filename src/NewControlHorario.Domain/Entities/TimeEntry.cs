using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Domain.Entities;

public class TimeEntry
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public TimeEntryType Type { get; set; }
    public string? Comment { get; set; }

    public User? User { get; set; }
}
