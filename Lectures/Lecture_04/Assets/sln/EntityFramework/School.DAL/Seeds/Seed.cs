using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;

namespace School.DAL.Seeds
{
    public static class Seed
    {
        public static readonly AddressEntity AddressJane = new AddressEntity()
        {
            Id = Guid.Parse("88D642BD-6D3E-403C-AA15-8552DEDDFA8A"),
            City = "Monaco",
            Street = "Some street",
            Country = "Monaco",
            State = "Monaco",
        };

        public static readonly GradeEntity GradeJane = new GradeEntity()
        {
            Id = Guid.Parse("A464EAA4-867E-45F4-81F1-48465E2C236F"),
            Name = "Best class",
            Section = "The best",
            Students = new List<StudentEntity>()
        };

        public static readonly CourseEntity IcsCourse = new CourseEntity()
        {
            Id = Guid.Parse("346A21A2-3C1F-43A6-A6A0-DC57613AFE19"),
            Name = "ICS",
            Description = "C# programming",
            StudentCourses = new List<StudentCourseEntity>()
        };

        public static readonly StudentEntity StudentJane = new StudentEntity()
        {
            Id = Guid.Parse("0A7EE49A-C6AC-41AF-97D0-9F91B9FAF966"),
            Name = "Jane",
            Address = AddressJane,
            GradeId = GradeJane.Id,
            Grade = GradeJane,
            StudentCourses = new List<StudentCourseEntity>() {}
        };

        public static readonly StudentCourseEntity StudentCourseJane = new StudentCourseEntity()
        {
            Id = Guid.Parse("5A459757-0C73-414E-83E4-8B24E998E3CE"),
            CourseId = IcsCourse.Id,
            Course = IcsCourse,
            StudentId = StudentJane.Id,
            Student = StudentJane,
        };

        static Seed()
        {
            GradeJane.Students.Add(StudentJane);
            IcsCourse.StudentCourses.Add(StudentCourseJane);
            StudentJane.StudentCourses.Add(StudentCourseJane);
        }

        public static void SeedStudents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>()
                .HasData(new  //Seeding anonymous type in shape of StudentEntity
                {
                    Id = StudentJane.Id,
                    Name = StudentJane.Name,
                    AddressId = StudentJane.Address.Id, //AddressId is a shadow property (not defined on StudentEntity)
                    //Address navigation properties needs to be seeded separately
                    GradeId = StudentJane.GradeId,
                    //Grade
                    //StudentCourses 
                });
        }

        public static void SeedAddresses(this ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<AddressEntity>()
                .HasData(AddressJane);
        }

        public static void SeedGrades(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeEntity>()
                .HasData(new GradeEntity()
                {
                    Id = GradeJane.Id,
                    Name = GradeJane.Name,
                    Section = GradeJane.Section
                });
        }

        public static void SeedCourses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>()
                .HasData(new CourseEntity()
                {
                    Id = IcsCourse.Id,
                    Name = IcsCourse.Name,
                    Description = IcsCourse.Description
                });
        }

        public static void SeedStudentCourses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>()
                .HasData(new StudentCourseEntity()
                {
                    Id = StudentCourseJane.Id,
                    CourseId = StudentCourseJane.CourseId,
                    StudentId = StudentCourseJane.StudentId
                });
        }
    }
}