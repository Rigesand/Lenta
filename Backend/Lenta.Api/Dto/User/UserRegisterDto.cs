namespace Lenta.Api.Dto.User;

public class UserRegisterDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
}