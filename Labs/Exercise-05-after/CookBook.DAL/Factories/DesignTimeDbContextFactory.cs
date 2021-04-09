using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CookBook.DAL.Factories
{
    /// <summary>
    /// Allows to use `dotnet ef migrations add xxx`
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1
    /// https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CookBookDbContext>(); 
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = CookBook;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");

            return new CookBookDbContext(builder.Options);
        }
    }
}
