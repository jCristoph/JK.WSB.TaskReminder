using JK.WSB.TaskReminder.Server.Controllers;
using JK.WSB.TaskReminder.Server.Repositories;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JK.WSB.TaskReminder.Server.Services
{
    public class StepService : IStepService
    {
        private readonly IStepRepository _stepRepository;
        private readonly IQuestRepository _questRepository;

        public StepService(
            IStepRepository stepRepository,
            IQuestRepository questRepository)
        {
            _stepRepository = stepRepository;
            _questRepository = questRepository;
        }

        public async Task<List<Step>> GetByQuestId(Guid questId)
        {
            return await _stepRepository.GetByQuestIdAsync(questId);
        }

        public async Task<ServiceResponse<int>> Create(StepDto stepDto)
        {
            ServiceResponse<int> result = new();

            try
            {
                var quest = await _questRepository.GetAsync(stepDto.QuestId);

                _stepRepository.Add(new Step
                {
                    Name = stepDto.Name,
                    IsDone = stepDto.IsDone,
                    Parent = quest
                });

                result.Message = "Step created successfully";
            }
            catch
            {
                result.Message = "Something goes wrong";
                result.Success = false;
                return result;
            }

            return result;
        }

        public async Task Remove(Guid stepId)
        {
            var step = await _stepRepository.GetAsync(stepId);
            _stepRepository.Remove(step);
        }
    }
}
