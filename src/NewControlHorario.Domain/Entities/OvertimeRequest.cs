using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Domain.Entities;

public class OvertimeRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Hours { get; set; }
    public string Reason { get; set; } = string.Empty;
    public OvertimeStatus Status { get; set; } = OvertimeStatus.Pending;
    public Guid? ApprovedById { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public User? User { get; set; }
}
