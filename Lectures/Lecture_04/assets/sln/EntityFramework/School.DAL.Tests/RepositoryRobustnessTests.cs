using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using School.DAL.Repositories;
using School.DAL.Seeds;
using Xunit;
using UnitOfWorkDb = School.DAL.UnitOfWork.UnitOfWork;

namespace School.DAL.Tests;

public sealed class RepositoryRobustnessTests : IDisposable
{
    private readonly SqliteTestDatabase _sqliteDb;

    public RepositoryRobustnessTests()
    {
        _sqliteDb = TestDbContextFactory.CreateSqliteInMemory();
    }

    [Fact]
    public void UniqueIndex_StudentCoursePair_IsEnforced()
    {
        using var context = CreateContext();

        var studentId = Guid.NewGuid();
        context.Students.Add(new StudentEntity
        {
            Id = studentId,
            Name = "Index test student",
            ProjectGroupId = Seed.ProjectGroupJane.Id,
            StudentCourses =
            [
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentId,
                    CourseId = Seed.IcsCourse.Id
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentId,
                    CourseId = Seed.IcsCourse.Id
                }
            ]
        });

        Assert.Throws<DbUpdateException>(() => context.SaveChanges());
    }

    [Fact]
    public void InsertOrUpdate_NewStudent_PersistsEntityGraphAndRelations()
    {
        var studentId = Guid.NewGuid();
        var studentCourseId = Guid.NewGuid();

        using (var context = CreateContext())
        using (var unitOfWork = new UnitOfWorkDb(context))
        {
            var repository = new RepositoryBase<StudentEntity>(unitOfWork);

            repository.InsertOrUpdate(new StudentEntity
            {
                Id = studentId,
                Name = "Repository insert student",
                ProjectGroupId = Seed.ProjectGroupJane.Id,
                Address = new AddressEntity
                {
                    Id = Guid.NewGuid(),
                    Street = "Bozetechova 1",
                    City = "Brno",
                    State = "CZ",
                    Country = "Czechia"
                },
                StudentCourses =
                [
                    new StudentCourseEntity
                    {
                        Id = studentCourseId,
                        StudentId = studentId,
                        CourseId = Seed.IcsCourse.Id
                    }
                ]
            });

            unitOfWork.Commit();
        }

        using var verificationContext = CreateContext();
        var loaded = verificationContext.Students
            .Include(s => s.Address)
            .Include(s => s.ProjectGroup)
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .Single(s => s.Id == studentId);

        Assert.Equal("Repository insert student", loaded.Name);
        Assert.NotNull(loaded.Address);
        Assert.Equal("Brno", loaded.Address!.City);
        Assert.Equal(Seed.ProjectGroupJane.Id, loaded.ProjectGroupId);
        Assert.Single(loaded.StudentCourses);
        Assert.Equal(Seed.IcsCourse.Id, loaded.StudentCourses.Single().CourseId);
    }

    [Fact]
    public void InsertOrUpdate_UpdatedStudentCourses_RemovesOrphanedJoinRows()
    {
        var studentId = Guid.NewGuid();
        var courseA = Seed.IcsCourse.Id;
        var courseB = Guid.NewGuid();
        var linkA = Guid.NewGuid();
        var linkB = Guid.NewGuid();

        using (var context = CreateContext())
        using (var unitOfWork = new UnitOfWorkDb(context))
        {
            var repository = new RepositoryBase<StudentEntity>(unitOfWork);

            repository.InsertOrUpdate(new StudentEntity
            {
                Id = studentId,
                Name = "Join cleanup student",
                ProjectGroupId = Seed.ProjectGroupJane.Id,
                StudentCourses =
                [
                    new StudentCourseEntity { Id = linkA, StudentId = studentId, CourseId = courseA },
                    new StudentCourseEntity { Id = linkB, StudentId = studentId, CourseId = courseB }
                ]
            });

            context.Courses.Add(new CourseEntity
            {
                Id = courseB,
                Name = "Extra course",
                Description = "For orphan cleanup test"
            });

            unitOfWork.Commit();
        }

        using (var context = CreateContext())
        using (var unitOfWork = new UnitOfWorkDb(context))
        {
            var repository = new RepositoryBase<StudentEntity>(unitOfWork);

            repository.InsertOrUpdate(new StudentEntity
            {
                Id = studentId,
                Name = "Join cleanup student updated",
                ProjectGroupId = Seed.ProjectGroupJane.Id,
                StudentCourses =
                [
                    new StudentCourseEntity { Id = linkA, StudentId = studentId, CourseId = courseA }
                ]
            });

            unitOfWork.Commit();
        }

        using var verificationContext = CreateContext();
        var links = verificationContext.StudentCourses
            .Where(sc => sc.StudentId == studentId)
            .OrderBy(sc => sc.Id)
            .ToList();

        Assert.Single(links);
        Assert.Equal(linkA, links[0].Id);
        Assert.Equal(courseA, links[0].CourseId);
    }

    [Fact]
    public void DeleteById_ExistingStudent_RemovesRow()
    {
        var studentId = Guid.NewGuid();

        using (var context = CreateContext())
        using (var unitOfWork = new UnitOfWorkDb(context))
        {
            var repository = new RepositoryBase<StudentEntity>(unitOfWork);

            repository.InsertOrUpdate(new StudentEntity
            {
                Id = studentId,
                Name = "Delete me",
                ProjectGroupId = Seed.ProjectGroupJane.Id
            });

            unitOfWork.Commit();
        }

        using (var context = CreateContext())
        using (var unitOfWork = new UnitOfWorkDb(context))
        {
            var repository = new RepositoryBase<StudentEntity>(unitOfWork);

            repository.DeleteById(studentId);
            unitOfWork.Commit();
        }

        using var verificationContext = CreateContext();
        Assert.Null(verificationContext.Students.SingleOrDefault(s => s.Id == studentId));
    }

    private SchoolDbContext CreateContext() => _sqliteDb.CreateContext();

    public void Dispose()
    {
        _sqliteDb.Dispose();
    }
}
