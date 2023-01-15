using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JK.WSB.TaskReminder.Server.Services
{
    public interface IQuestService
    {
        Task<Quest> Get(Guid questId);
        Task<List<Quest>> GetForUser(Guid userId);
        Task<ServiceResponse<int>> Create(QuestDto questDto);
        Task Update(Guid questId, QuestDto questDto);
        Task Remove(Guid questId);

    }
}
