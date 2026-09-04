using System.Security.Claims;
using Laboratory.Application.Security;
using Laboratory.Framework.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratory.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected IActionResult HandleResult(OperationResult result)
    {
        return StatusCode(result.StatusCode, result);
    }

    protected IActionResult HandleResult<T>(OperationResult<T> result)
    {
        return StatusCode(result.StatusCode, result);
    }

    protected string GetCurrentIdentityUserId()
    {
        var raw = User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue("sub")
            ?? User.FindFirstValue("nameid");

        if (!string.IsNullOrWhiteSpace(raw))
        {
            return raw;
        }

        throw new InvalidOperationException("شناسه حساب کاربری در توکن احراز هویت یافت نشد.");
    }

    protected int GetCurrentEmployeeId()
    {
        var raw = User.FindFirstValue(AuthClaimTypes.EmployeeId);
        if (int.TryParse(raw, out int employeeId) && employeeId > 0)
        {
            return employeeId;
        }

        throw new InvalidOperationException("شناسه کارمند در توکن احراز هویت یافت نشد.");
    }
}
