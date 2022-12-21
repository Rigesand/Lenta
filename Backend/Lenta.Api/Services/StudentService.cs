using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lenta.Api.Dto.Student;
using Lenta.Api.Interfaces;
using Lenta.DAL;
using Lenta.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace Lenta.Api.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public StudentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeStudentDetails(Student student)
    {
        var dbStudent = await _context.Students.FirstOrDefaultAsync(it => it.Id == student.Id);

        dbStudent.FullName = student.FullName;
        dbStudent.Email = student.Email;
        dbStudent.BirthDate = student.BirthDate;
        dbStudent.UniversityName = student.UniversityName;
        dbStudent.Course = student.Course;
        dbStudent.Faculty = student.Faculty;
        dbStudent.PhoneNumber = student.PhoneNumber;
        dbStudent.Description = student.Description;
        dbStudent.ChangeDate = student.ChangeDate;
        dbStudent.ChangeUser = student.ChangeUser;

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudents()
    {
        return await _context.Students.AsNoTracking()
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<StudentDto>> GetCurrentStudent(string email)
    {
        return await _context.Students.Where(it=>it.Email==email).AsNoTracking()
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}