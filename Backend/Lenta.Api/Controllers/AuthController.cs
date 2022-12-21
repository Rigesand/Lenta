using AutoMapper;
using Lenta.Api.Dto.User;
using Lenta.Api.Interfaces;
using Lenta.DAL.Enities;
using Microsoft.AspNetCore.Mvc;

namespace Lenta.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task Register(UserRegisterDto userDto)
    {
        var newUser = _mapper.Map<User>(userDto);
        await _userService.Register(newUser);
    }

    [HttpPost]
    public async Task<UserDto> Login(UserLoginDto userLoginDto)
    {
        var user = _mapper.Map<User>(userLoginDto);
        var result=await _userService.Login(user);
        if (result==null)
        {
            throw new Exception("Такого пользователя не существует");
        }

        return result;
    }
}