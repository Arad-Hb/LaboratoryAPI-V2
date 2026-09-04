namespace Laboratory.Application.DTOs.Auth;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public CurrentUserDto User { get; set; } = new();
}
