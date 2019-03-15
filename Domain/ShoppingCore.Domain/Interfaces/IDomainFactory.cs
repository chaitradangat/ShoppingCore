using ShoppingCore.Domain.Interfaces;
using System;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IDomainFactory
    {
        IEntity GetEntity<T>();
    }
}
