using Microsoft.EntityFrameworkCore;
using Exercise.Data.Models;

namespace Exercise.Data
{
    public class GlobalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base (options)
        {
        }
    }
}
