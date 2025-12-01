using Microsoft.AspNetCore.Mvc;
using NewControlHorario.Application.DTOs;
using NewControlHorario.Application.Services;

namespace NewControlHorario.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsync(id, cancellationToken);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Post(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(request.Email, request.FullName, request.PasswordHash, request.Roles, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
}

public record CreateUserRequest(string Email, string FullName, string PasswordHash, IEnumerable<string> Roles);
