﻿using System.Linq;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Application.Interfaces
{
    /// <summary>
    /// This interface defines the repository which needs to be implemented
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: IEntity
    {
        IQueryable<T> List();

        IEntity Find(int ID);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}