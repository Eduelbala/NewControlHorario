using Microsoft.AspNetCore.Mvc;
using NewControlHorario.Application.DTOs;
using NewControlHorario.Application.Services;
using NewControlHorario.Domain.Enums;

namespace NewControlHorario.Api.Controllers;

[ApiController]
[Route("api/users/{userId:guid}/[controller]")]
public class TimeEntriesController : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService;

    public TimeEntriesController(ITimeEntryService timeEntryService)
    {
        _timeEntryService = timeEntryService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<TimeEntryDto>>> Get(Guid userId, [FromQuery] DateOnly? date, CancellationToken cancellationToken)
    {
        var entries = await _timeEntryService.GetEntriesForUserAsync(userId, date, cancellationToken);
        return Ok(entries);
    }

    [HttpPost]
    public async Task<ActionResult<TimeEntryDto>> Post(Guid userId, [FromBody] RegisterTimeEntryRequest request, CancellationToken cancellationToken)
    {
        var entry = await _timeEntryService.RegisterAsync(userId, request.Type, request.Comment, cancellationToken);
        return CreatedAtAction(nameof(Get), new { userId }, entry);
    }
}

public record RegisterTimeEntryRequest(TimeEntryType Type, string? Comment);
