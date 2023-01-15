using JK.WSB.TaskReminder.Server.Data;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public class QuestRepository : BaseRepository, IQuestRepository
    {
        public QuestRepository(DataContext context) : base(context)
        {
        }

        public async Task<Quest> GetAsync(Guid questId)
        {
            return await _context.Quests.SingleAsync(q => q.Id == questId);
        }

        public async Task<List<Quest>> GetByUserIdAsync(Guid userId) 
        {
            return await _context.Quests.Where(q => q.User.Id == userId).ToListAsync();
        }

        public int Add(Quest quest)
        {
            _context.Quests.Add(quest);

            return _context.SaveChanges();
        }

        public int Update(Quest quest)
        {
            _context.Quests.Update(quest);

            return _context.SaveChanges();
        }

        public int Remove(Quest quest)
        {
            _context.Quests.Remove(quest);

            return _context.SaveChanges();
        }
    }
}
