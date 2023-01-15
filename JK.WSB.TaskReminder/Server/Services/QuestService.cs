using JK.WSB.TaskReminder.Server.Repositories;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;

namespace JK.WSB.TaskReminder.Server.Services
{
    public class QuestService : IQuestService
    {
        private readonly IQuestRepository _questRepository;
        private readonly IUserRepository _userRepository;

        public QuestService(
            IQuestRepository questRepository,
            IUserRepository userRepository)
        {
            _questRepository = questRepository;
            _userRepository = userRepository;
        }

        public async Task<Quest> Get(Guid questId)
        {
            return await _questRepository.GetAsync(questId);
        }

        public async Task<List<Quest>> GetForUser(Guid userId)
        {
            return await _questRepository.GetByUserIdAsync(userId);
        }

        public async Task<ServiceResponse<int>> Create(QuestDto questDto)
        {
            ServiceResponse<int> result = new();

            try
            {
                var user = await _userRepository.GetAsync(questDto.UserId);

                _questRepository.Add(new Quest
                {
                    Name = questDto.Name,
                    RemindDate = questDto.RemindDate,
                    DeadLine = questDto.DeadLine,
                    Note = questDto.Note,
                    IsFavoruite = questDto.IsFavoruite,
                    IsDone = questDto.IsDone,
                    User = user!
                });

                result.Message = "Quest created successfully";
            }
            catch
            {
                result.Message = "Something goes wrong";
                result.Success = false;
                return result;
            }


            return result;
        }

        public async Task Update(Guid questId, QuestDto questDto)
        {
            var questToUpdate = await _questRepository.GetAsync(questId);

            questToUpdate.Name = questDto.Name;
            questToUpdate.RemindDate = questDto.RemindDate;
            questToUpdate.DeadLine = questDto.DeadLine;
            questToUpdate.Note = questDto.Note;
            questToUpdate.IsFavoruite = questDto.IsFavoruite;
            questToUpdate.IsDone = questDto.IsDone;

            _questRepository.Update(questToUpdate);
        }

        public async Task Remove(Guid questId)
        {
            var quest = await _questRepository.GetAsync(questId);
            _questRepository.Remove(quest);
        }
    }
}
