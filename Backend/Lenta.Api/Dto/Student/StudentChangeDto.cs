namespace Lenta.Api.Dto.Student;

public class StudentChangeDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTimeOffset BirthDate { get; set; }
    public string UniversityName { get; set; } = null!;
    public int Course { get; set; }
    public string Faculty { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ChangeUser { get; set; } = null!;
}