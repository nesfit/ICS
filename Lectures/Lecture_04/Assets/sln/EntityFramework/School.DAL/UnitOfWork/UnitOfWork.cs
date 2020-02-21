using System;
using Microsoft.EntityFrameworkCore;

namespace School.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public DbContext DbContext { get; }

        public void Dispose() => DbContext.Dispose();

        public void Commit() => DbContext.SaveChanges();
    }
}