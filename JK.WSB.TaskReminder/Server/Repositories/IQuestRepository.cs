using JK.WSB.TaskReminder.Shared.Models;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public interface IQuestRepository
    {
        Task<Quest> GetAsync(Guid questId);
        Task<List<Quest>> GetByUserIdAsync(Guid userId);
        int Add(Quest quest);
        int Update(Quest quest);
        int Remove(Quest quest);
    }
}
