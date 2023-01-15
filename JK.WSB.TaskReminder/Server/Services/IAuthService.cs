using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;

namespace JK.WSB.TaskReminder.Server.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoggedUserDto>> Login(LoginDto userDto);
        Task<ServiceResponse<int>> Register(RegisterDto registerDto);
    }
}
