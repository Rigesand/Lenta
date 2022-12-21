using Lenta.Api.Dto.Student;
using Lenta.DAL.Enities;

namespace Lenta.Api.Interfaces;

public interface IStudentService
{
    public Task Create(Student student);
    public Task ChangeStudentDetails(Student student);
    public Task<IEnumerable<StudentDto>> GetAllStudents();
    public Task<IEnumerable<StudentDto>> GetCurrentStudent(string email);
}