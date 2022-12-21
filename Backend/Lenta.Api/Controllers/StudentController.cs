using AutoMapper;
using Lenta.Api.Dto.Student;
using Lenta.Api.Interfaces;
using Lenta.DAL.Enities;
using Microsoft.AspNetCore.Mvc;

namespace Lenta.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class StudentController
{
    private readonly IStudentService _studentService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public StudentController(IStudentService studentService, IMapper mapper, IUserService userService)
    {
        _studentService = studentService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost]
    public async Task Create(StudentCreateDto newStudent)
    {
        var student = _mapper.Map<Student>(newStudent);
        await _studentService.Create(student);
    }

    [HttpPost]
    public async Task ChangeUserDetails(StudentChangeDto studentChangeDto)
    {
        var student = _mapper.Map<Student>(studentChangeDto);
        await _studentService.ChangeStudentDetails(student); 
    }

    [HttpGet]
    public async Task<IEnumerable<StudentDto>> GetAllStudents(string email)
    {
        var currentUser = await _userService.GetUserByEmail(email);
        if (currentUser.Role==Constants.Admin)
        {
           return await _studentService.GetAllStudents();
        }

        return await _studentService.GetCurrentStudent(email);
    }

}