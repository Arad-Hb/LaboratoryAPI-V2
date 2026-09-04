using Laboratory.Application.DTOs.Auth;
using Laboratory.Framework.Common;

namespace Laboratory.Application.Services;

public interface IAuthService
{
    Task<OperationResult<LoginResponseDto>> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);
    Task<OperationResult<CurrentUserDto>> GetCurrentUserAsync(int employeeId, CancellationToken cancellationToken);
    Task<OperationResult<IReadOnlyList<UserByRoleDto>>> GetUsersByRoleAsync(string roleName, CancellationToken cancellationToken);
}
