using Lenta.Api.Dto.User;
using Lenta.DAL.Enities;

namespace Lenta.Api.Interfaces;

public interface IUserService
{
    public Task Register(User user);
    public Task<UserDto> Login(User user);
    public Task<UserDto> GetUserByEmail(string email);
}