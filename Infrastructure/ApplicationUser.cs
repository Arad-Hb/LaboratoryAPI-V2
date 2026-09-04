using DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace InfrastructureEfPersistance;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;

    public Employee? Employee { get; set; }
}

public class ApplicationRole : IdentityRole
{
}
