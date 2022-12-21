using AutoMapper;
using Lenta.Api.Dto.User;
using Lenta.Api.Interfaces;
using Lenta.DAL;
using Lenta.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace Lenta.Api.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Register(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDto> Login(User user)
    {
        var dbUser = await _context.Users
            .FirstOrDefaultAsync(it => it.Email == user.Email && it.Password == user.Password);
        
        return _mapper.Map<UserDto>(dbUser);
    }

    public async Task<UserDto> GetUserByEmail(string email)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(it => it.Email == email);
        return _mapper.Map<UserDto>(dbUser);
    }
}