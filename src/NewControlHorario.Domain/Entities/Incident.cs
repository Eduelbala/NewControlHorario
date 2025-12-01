using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Domain.Entities;

public class Incident
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public IncidentType Type { get; set; }
    public IncidentStatus Status { get; set; } = IncidentStatus.Pending;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Notes { get; set; }
    public Guid? ApprovedById { get; set; }

    public User? User { get; set; }
}
