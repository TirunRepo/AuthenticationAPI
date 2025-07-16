
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            return await _context.Users.AnyAsync(x => x.Email == email && x.Password == password);
        }
    }
}
