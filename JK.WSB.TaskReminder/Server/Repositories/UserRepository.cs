using JK.WSB.TaskReminder.Server.Data;
using JK.WSB.TaskReminder.Shared.Dtos;
using JK.WSB.TaskReminder.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JK.WSB.TaskReminder.Server.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<User?> GetAsync(Guid userId)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public int Add(User user)
        {
            _context.Users.Add(user);

            return _context.SaveChanges();
        }
    }
}
