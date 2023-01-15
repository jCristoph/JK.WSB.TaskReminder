using JK.WSB.TaskReminder.Server.Services;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JK.WSB.TaskReminder.Server.Controllers
{
    public class StepController : BaseController
    {
        private readonly IStepService _stepService;

        public StepController(
            IStepService stepService,
            ILogger<StepController> logger)
            : base(logger)
        {
            _stepService = stepService;
        }

        [HttpGet, Route("GetByQuestId/{questId:guid}")]
        public async Task<ActionResult<List<Step>>> GetByQuestId([FromRoute] Guid questId)
        {
            return await _stepService.GetByQuestId(questId);
        }

        [HttpPost, Route("Add")]
        public async Task<ActionResult<ServiceResponse<int>>> Create(StepDto stepDto)
        {
            var result = await _stepService.Create(stepDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(500, result);
        }

        [HttpDelete, Route("RemoveStep/{questId}")]
        public async Task<ActionResult> Remove([FromRoute] Guid stepId)
        {
            await _stepService.Remove(stepId);

            return Ok();
        }
    }
}
