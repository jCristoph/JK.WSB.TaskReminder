using JK.WSB.TaskReminder.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace JK.WSB.TaskReminder.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
