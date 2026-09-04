using System.ComponentModel.DataAnnotations;

namespace Laboratory.Application.DTOs.Auth;

public class LoginRequestDto
{
    [Required]
    [MaxLength(256)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}
