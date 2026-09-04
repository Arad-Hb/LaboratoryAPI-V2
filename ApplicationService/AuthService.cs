using Laboratory.Application.DTOs.Auth;
using Laboratory.Application.Services;
using Laboratory.Framework.Common;

namespace Laboratory.ApplicationService;

public class AuthService : IAuthService
{
    public Task<OperationResult<LoginResponseDto>> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
    {
        return Task.FromResult(OperationResult<LoginResponseDto>.Failure("سرویس احراز هویت هنوز پیاده‌سازی نشده است.", 501));
    }

    public Task<OperationResult<CurrentUserDto>> GetCurrentUserAsync(int employeeId, CancellationToken cancellationToken)
    {
        return Task.FromResult(OperationResult<CurrentUserDto>.Failure("سرویس احراز هویت هنوز پیاده‌سازی نشده است.", 501));
    }

    public Task<OperationResult<IReadOnlyList<UserByRoleDto>>> GetUsersByRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        return Task.FromResult(OperationResult<IReadOnlyList<UserByRoleDto>>.Failure("سرویس احراز هویت هنوز پیاده‌سازی نشده است.", 501));
    }
}
