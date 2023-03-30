using Microsoft.EntityFrameworkCore;

namespace TestedApplication.Database
{
    public class TasksDbContext : DbContext
    {
        public DbSet<UserTask> UserTasks { get; set; }
        public TasksDbContext(DbContextOptions<TasksDbContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
