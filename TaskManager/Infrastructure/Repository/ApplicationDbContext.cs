using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Infrastructure.Repository
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Manager> Manger { get; set; }
        public DbSet<ProjectTask> Task { get; set; }
    }
}
