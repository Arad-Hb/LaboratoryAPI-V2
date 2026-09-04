using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laboratory.Application.DTOs.Auth;
using Laboratory.Application.Services;

namespace Laboratory.Api.Controllers;

public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(request, cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUserAsync(CancellationToken cancellationToken)
    {
        var employeeId = GetCurrentEmployeeId();
        var result = await _authService.GetCurrentUserAsync(employeeId, cancellationToken);
        return HandleResult(result);
    }

    [Authorize(Roles = "SystemAdmin")]
    [HttpGet("users-by-role/{roleName}")]
    public async Task<IActionResult> GetUsersByRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        var result = await _authService.GetUsersByRoleAsync(roleName, cancellationToken);
        return HandleResult(result);
    }
}
