using FIT.EFCore.Sample.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIT.EFCore.Sample.DAL
{
    public class TodosDbContext : DbContext
    {
        public TodosDbContext()
        {
        }

        public TodosDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasMany(t => t.Todos)
                .WithOne(t => t.Group)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
