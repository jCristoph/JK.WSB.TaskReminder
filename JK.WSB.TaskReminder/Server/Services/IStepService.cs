using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;

namespace JK.WSB.TaskReminder.Server.Services
{
    public interface IStepService
    {
        Task<List<Step>> GetByQuestId(Guid questId);
        Task<ServiceResponse<int>> Create(StepDto stepDto);
        Task Remove(Guid stepId);
    }
}
