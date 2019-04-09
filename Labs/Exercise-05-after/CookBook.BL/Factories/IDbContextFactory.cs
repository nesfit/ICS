using System;
using System.Collections.Generic;
using System.Text;
using CookBook.DAL;

namespace CookBook.BL.Factories
{
    public interface IDbContextFactory
    {
        CookBookDbContext CreateDbContext();
    }
}
