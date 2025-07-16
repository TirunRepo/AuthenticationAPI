using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuthenticationAPI.Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}