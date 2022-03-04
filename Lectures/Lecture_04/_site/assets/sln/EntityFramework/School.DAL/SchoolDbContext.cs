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

        public DbSet<AddressEntity> Addresses => Set<AddressEntity>();
        public DbSet<CourseEntity> Courses => Set<CourseEntity>();
        public DbSet<GradeEntity> Grades => Set<GradeEntity>();
        public DbSet<StudentEntity> Students => Set<StudentEntity>();
        public DbSet<StudentCourseEntity> StudentCourses => Set<StudentCourseEntity>();
        
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