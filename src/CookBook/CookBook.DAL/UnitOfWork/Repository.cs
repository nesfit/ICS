using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    public DbSet<TEntity> DbSet { get; }

    public Repository(DbContext dbContext) => DbSet = dbContext.Set<TEntity>();

    public IQueryable<TEntity> Get() => DbSet;

    public void Delete(Guid entityId) => DbSet.Remove(DbSet.Single(i => i.Id == entityId));
}