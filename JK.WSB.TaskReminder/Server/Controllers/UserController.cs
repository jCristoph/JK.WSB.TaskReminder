using JK.WSB.TaskReminder.Server.Services;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JK.WSB.TaskReminder.Server.Controllers
{
    public class UserController : BaseController
    {
        private readonly IAuthService _authService;

        public UserController(
            IAuthService authService,
            ILogger<UserController> logger)
            : base(logger)
        {
            _authService = authService;
        }

        [HttpPost, Route("Login")]
        public async Task<ActionResult<ServiceResponse<LoggedUserDto>>> Login(LoginDto userDto)
        {
            return await _authService.Login(userDto);
        }

        [HttpPost, Route("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterDto registerDto)
        {
            return await _authService.Register(registerDto);
        }
    }
}
