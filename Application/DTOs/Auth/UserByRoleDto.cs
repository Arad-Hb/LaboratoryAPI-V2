namespace Laboratory.Application.DTOs.Auth;

public class UserByRoleDto
{
    public string IdentityUserId { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public bool IsActive { get; set; }
    public IReadOnlyList<string> Roles { get; set; } = Array.Empty<string>();
}
