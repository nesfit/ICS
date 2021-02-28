using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using School.DAL.Seeds;

namespace School.DAL
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentCourseEntity>()
                .HasIndex(sc => new {sc.StudentId, sc.CourseId}).IsUnique();

            modelBuilder.SeedStudents();
            modelBuilder.SeedAddresses();
            modelBuilder.SeedGrades();
            modelBuilder.SeedCourses();
            modelBuilder.SeedStudentCourses();
        }
    }
}