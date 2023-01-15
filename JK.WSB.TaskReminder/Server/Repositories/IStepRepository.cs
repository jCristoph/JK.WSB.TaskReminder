using JK.WSB.TaskReminder.Shared.Models;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public interface IStepRepository
    {
        Task<Step> GetAsync(Guid stepId);
        Task<List<Step>> GetByQuestIdAsync(Guid questId);
        int Add(Step step);
        int Remove(Step step);
    }
}
