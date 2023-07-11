using Microsoft.EntityFrameworkCore;

namespace UserAPI.Models
{
    public class JWTUserContext:DbContext
    {
        public JWTUserContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
