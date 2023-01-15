using JK.WSB.TaskReminder.Shared.Models;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetAsync(Guid userId);
        Task<User?> GetUserByEmailAsync(string email);
        int Add(User user);
    }
}
