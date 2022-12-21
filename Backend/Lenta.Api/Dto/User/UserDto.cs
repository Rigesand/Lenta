using Lenta.Api.Dto.Student;

namespace Lenta.Api.Dto.User;

public class UserDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public ICollection<StudentDto>? Students { get; set; }
}