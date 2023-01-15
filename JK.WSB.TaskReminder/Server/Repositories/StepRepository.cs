using JK.WSB.TaskReminder.Server.Data;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public class StepRepository : BaseRepository, IStepRepository
    {
        public StepRepository(DataContext context) : base(context)
        {
        }

        public async Task<Step> GetAsync(Guid stepId)
        {
            return await _context.Steps.SingleAsync(q => q.Id == stepId);
        }

        public async Task<List<Step>> GetByQuestIdAsync(Guid questId)
        {
            return await _context.Steps.Where(s => s.Parent.Id == questId).ToListAsync();
        }

        public int Add(Step step)
        {
            _context.Steps.Add(step);

            return _context.SaveChanges();
        }

        public int Remove(Step step)
        {
            _context.Steps.Remove(step);

            return _context.SaveChanges();
        }
    }
}
