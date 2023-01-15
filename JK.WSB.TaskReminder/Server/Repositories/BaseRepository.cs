using JK.WSB.TaskReminder.Server.Data;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DataContext _context;
        protected BaseRepository(DataContext context) 
        { 
            _context = context;
        }
    }
}
