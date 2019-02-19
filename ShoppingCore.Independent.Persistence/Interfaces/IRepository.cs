using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShoppingCore.Domain.Common;

namespace ShoppingCore.Independent.Persistence.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        IQueryable<T> List();

        IEntity Find(int ID);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}