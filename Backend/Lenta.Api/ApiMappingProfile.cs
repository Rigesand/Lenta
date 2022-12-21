using AutoMapper;
using Lenta.Api.Dto.Student;
using Lenta.Api.Dto.User;
using Lenta.DAL.Enities;

namespace Lenta.Api;

public class ApiMappingProfile: Profile
{
    public ApiMappingProfile()
    {
        CreateMap<UserLoginDto, User>();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserRegisterDto, User>()
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()));

        CreateMap<StudentCreateDto, Student>()
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()))
            .ForMember(d => d.CreatedDate, m => m.MapFrom(s => DateTime.UtcNow));
        
        CreateMap<StudentChangeDto, Student>()
            .ForMember(d => d.ChangeDate, m => m.MapFrom(s => DateTime.UtcNow));

        CreateMap<Student, StudentDto>();
    }
}