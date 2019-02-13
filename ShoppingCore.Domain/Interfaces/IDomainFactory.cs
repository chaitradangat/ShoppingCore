using ShoppingCore.Domain.Common;
using System;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IDomainFactory
    {
        IEntity<T> GetEntity<T>();
    }
}
