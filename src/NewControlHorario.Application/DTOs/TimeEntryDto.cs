using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Application.DTOs;

public record TimeEntryDto(Guid Id, Guid UserId, DateTimeOffset Timestamp, TimeEntryType Type, string? Comment);
