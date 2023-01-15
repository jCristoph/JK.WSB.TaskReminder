using JK.WSB.TaskReminder.Server.Services;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JK.WSB.TaskReminder.Server.Controllers
{
    public class QuestController : BaseController
    {
        private readonly IQuestService _questService;
        public QuestController(
            IQuestService questService,
            ILogger<QuestController> logger)
            : base(logger)
        {
            _questService = questService;
        }

        [HttpGet, Route("Get/{questId:guid}")]
        public async Task<ActionResult<Quest>> Get([FromRoute] Guid questId)
        {
            return await _questService.Get(questId);
        }

        [HttpGet, Route("GetForUser/{userId:guid}")]
        public async Task<ActionResult<List<Quest>>> GetForUser([FromRoute] Guid userId)
        {
            return await _questService.GetForUser(userId);
        }

        [HttpPost, Route("Add")]
        public async Task<ActionResult<ServiceResponse<int>>> Create(QuestDto questDto)
        {
            var result = await _questService.Create(questDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(500, result);
        }

        [HttpPut, Route("UpdateQuest/{questId}")]
        public async Task<ActionResult> Update([FromRoute] Guid questId, [FromBody] QuestDto questDto)
        {
            await _questService.Update(questId, questDto);

            return Ok();
        }

        [HttpDelete, Route("RemoveQuest/{questId}")]
        public async Task<ActionResult> Remove([FromRoute] Guid questId)
        {
            await _questService.Remove(questId);
            return Ok();
        }
    }
}
