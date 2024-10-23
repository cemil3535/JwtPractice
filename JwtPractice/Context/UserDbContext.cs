using JwtPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtPractice.Entities
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { 

        }

        public DbSet<User> Users => Set<User>();

       
    }
}
