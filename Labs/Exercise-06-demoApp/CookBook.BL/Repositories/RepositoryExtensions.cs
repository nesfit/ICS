using System;
using System.Collections.Generic;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Repositories
{
    public static class RepositoryExtensions
    {
        public static IEqualityComparer<IEntity> IdComparer { get; } = new IdEqualityComparer();

        private sealed class IdEqualityComparer : IEqualityComparer<IEntity>
        {
            public Boolean Equals(IEntity x, IEntity y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Id.Equals(y.Id);
            }

            public Int32 GetHashCode(IEntity obj) => obj.Id.GetHashCode();
        }
    }
}