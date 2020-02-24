using System;
using System.Linq;
using Dapper.DAL.Entities;
using Xunit;

namespace Dapper.DAL.Tests
{
    public class StudentRepositoryTests
    {
        private readonly StudentRepository _studentRepository = new StudentRepository();

        [Fact]
        public void RepositoryTest()
        {
            var student = new StudentEntity
            {
                Id = Guid.NewGuid(),
                Name = "Mike"
            };
            _studentRepository.Insert(student);

            var result = _studentRepository.GetById(student.Id);
            Assert.Equal(result, student, StudentEntity.IdNameComparer);

            var count = _studentRepository.GetAll().Count();
            _studentRepository.Delete(student.Id);
            Assert.True(count - 1 == _studentRepository.GetAll().Count());
        }
    }
}